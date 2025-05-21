using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private void Form1_Load(object sender, EventArgs e)
        {
            FillMonthsAndYears();
            LoadGoodsFromFile("goods.txt"); // Уточни путь к файлу с товарами
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

            // Заполняем годы (например, с текущего года и последующие 10 лет)
            for (int y = DateTime.Now.Year; y <= DateTime.Now.Year + 10; y++)
            {
                comboBoxYear.Items.Add(y.ToString());
            }

            // Выбираем текущий месяц и год по умолчанию
            comboBoxMonth.SelectedIndex = DateTime.Now.Month - 1;
            comboBoxYear.SelectedIndex = 0;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            string code = textBoxCode.Text.Trim();
            string selectedMonth = comboBoxMonth.SelectedItem?.ToString();
            string selectedYear = comboBoxYear.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(selectedMonth) && !string.IsNullOrEmpty(selectedYear))
            {
                // Форматируем строку для записи в файл
                string record = $"{code}|{selectedMonth}/{selectedYear}";

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
                MessageBox.Show("Выберите месяц и год, а также введите код товара.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

            List<string> matchingRecords = new List<string>();

            foreach (var line in File.ReadAllLines("expiry_dates.csv"))
            {
                var parts = line.Split('|');

                if (parts.Length >= 2 && parts[1] == targetDate)
                {
                    matchingRecords.Add(line);
                }
            }

            if (matchingRecords.Count > 0)
            {
                // Отобразим результат, например, в отдельном окне
                MessageBox.Show(string.Join(Environment.NewLine, matchingRecords));
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
    }

    }


 
    
    
