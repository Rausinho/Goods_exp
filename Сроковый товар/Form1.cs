using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Сроковый_товар
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool RecordExistsInFile(string code, string date)
        {
            foreach (var line in File.ReadAllLines("expiry_dates.csv"))
            {
                var parts = line.Split('|');

                if (parts.Length >= 3 && parts[0] == code && parts[2] == date)
                {
                    return true; // Такая запись уже существует
                }
            }

            return false; // Записи с таким кодом и датой нет
        }


        private Dictionary<string, string> _goods = new Dictionary<string, string>();

        private void LoadGoodsFromFile(string filename)
        {
            foreach (var line in File.ReadAllLines(filename))
            {
                var parts = line.Split('|');

                if (parts.Length >= 2 && !string.IsNullOrEmpty(parts[0]) && !string.IsNullOrEmpty(parts[1]))
                {
                    _goods[parts[0].Trim()] = parts[1].Trim();
                }
            }
        }
        private void FillMonthsAndYears()
        {
            // Заполняем месяцы
            for (int i = 1; i <= 12; i++)
            {
                comboBoxMonth.Items.Add(i.ToString());
            }

            // Заполняем годы (например, с текущего года и последующие 3 года)
            for (int y = DateTime.Now.Year; y <= DateTime.Now.Year + 3; y++)
            {
                comboBoxYear.Items.Add(y.ToString());
            }

            // Выбираем текущий месяц и год по умолчанию
            //По хорошему этот кусок кода нужно удалить, чтобы поля были пустыми

            //comboBoxMonth.SelectedIndex = DateTime.Now.Month - 1;
            //comboBoxYear.SelectedIndex = 0;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string code = textBoxCode.Text.Trim();
            string selectedMonth = comboBoxMonth.SelectedItem?.ToString();
            string selectedYear = comboBoxYear.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(selectedMonth) && !string.IsNullOrEmpty(selectedYear))
            {
                string fullDate = $"{selectedMonth}/{selectedYear}";

                // Проверяем, установлена ли галочка "Новый товар"
                if (checkBoxNewItem.Checked)
                {
                    // Удаляем предыдущие записи с таким же кодом товара
                    RemovePreviousRecords(code);
                }
                else
                {
                    // Проверяем, существует ли уже такая запись
                    if (RecordExistsInFile(code, fullDate))
                    {
                        MessageBox.Show("Запись уже существует.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return; // Завершаем метод, не сохраняя запись
                    }
                }

                // Получаем название товара по его коду
                if (_goods.TryGetValue(code, out string productName))
                {
                    // Форматируем строку: <код товара>|<название товара>|<месяц>/<год>
                    string record = $"{code}|{productName}|{fullDate}";

                    try
                    {
                        // Записываем данные в файл
                        File.AppendAllText("expiry_dates.csv", record + Environment.NewLine, Encoding.UTF8);

                        MessageBox.Show("Данные успешно сохранены!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при сохранении данных:\n{ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Товар с указанным кодом не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Выберите месяц и год, а также введите код товара.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RemovePreviousRecords(string code)
        {
            // Читаем файл, удаляем старые записи и переписываем файл
            List<string> updatedRecords = new List<string>();

            foreach (var line in File.ReadAllLines("expiry_dates.csv"))
            {
                var parts = line.Split('|');

                if (parts.Length >= 3 && parts[0] != code)
                {
                    updatedRecords.Add(line);
                }
            }

            // Переписываем файл с обновлёнными данными
            File.WriteAllLines("expiry_dates.csv", updatedRecords, Encoding.UTF8);
        }
        private void buttonGenerateReport_Click(object sender, EventArgs e)
        {
            string selectedMonth = comboBoxMonth.SelectedItem?.ToString();
            string selectedYear = comboBoxYear.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedMonth) || string.IsNullOrEmpty(selectedYear))
            {
                MessageBox.Show("Выберите месяц и год.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string targetDate = $"{selectedMonth}/{selectedYear}";

            // Собираем список товаров, соответствующих выбранному критерию
            List<string> matchingRecords = new List<string>();

            foreach (var line in File.ReadAllLines("expiry_dates.csv"))
            {
                var parts = line.Split('|');

                if (parts.Length >= 3 && parts[2] == targetDate)
                {
                    matchingRecords.Add($"{parts[0]} — {parts[1]} ({targetDate})");
                }
            }

            if (matchingRecords.Count > 0)
            {
                // Открываем новую форму и передаём ей список товаров
                ReportForm reportForm = new ReportForm(targetDate);
                reportForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Товаров с указанными параметрами не найдено.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void textBoxCode_TextChanged(object sender, EventArgs e)
        {
            string enteredCode = textBoxCode.Text.Trim();

            if (!_goods.TryGetValue(enteredCode, out string productName))
            {
                // Если товар не найден, выводим сообщение
                labelProductName.Text = $"Товар с кодом '{enteredCode}' не найден.";
            }
            else
            {
                // Если товар найден, выводим его название
                labelProductName.Text = productName;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillMonthsAndYears();
            LoadGoodsFromFile("goods.txt");
        }

        private void buttonGenerateFutureReport_Click(object sender, EventArgs e)
        {
            // Получаем текущий месяц и год
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;

            // Вычисляем целевой месяц и год (через три месяца)
            int targetMonth = currentMonth + 3;
            int targetYear = currentYear;

            // Если целевые месяц и год превышают пределы текущего года, увеличиваем год
            if (targetMonth > 12)
            {
                targetMonth -= 12;
                targetYear++;
            }

            // Формируем строку даты в формате M/YY (без ведущих нулей)
            string targetDate = $"{targetMonth % 10}/{targetYear}";

            // Открываем новую форму и передаём ей строку с целевой датой
            ReportForm reportForm = new ReportForm(targetDate);
            reportForm.ShowDialog();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // Информация о программе
            string appVersion = "v1.0"; // Версия программы
            string lastUpdate = "30 мая 2025 г."; // Дата последнего обновления

            // Форматируем сообщение
            string message = $"Версия: {appVersion}\n" +
                             $"Последнее обновление: {lastUpdate}";

            // Показываем информационное окно
            MessageBox.Show(message, "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

}



