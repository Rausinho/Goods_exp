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

    public partial class ReportForm : Form
    {
        public ReportForm(string targetDate)
        {
            InitializeComponent();

            // Очищаем предыдущий список товаров
            listBoxResults.Items.Clear();

            // Читаем файл и выводим товары, соответствующие целевым месяцам и годам
            foreach (var line in File.ReadAllLines("expiry_dates.csv"))
            {
                var parts = line.Split('|');

                if (parts.Length >= 3 && parts[2] == targetDate)
                {
                    // Добавляем товар в список
                    listBoxResults.Items.Add($"{parts[0]} — {parts[1]} ({targetDate})");
                }
            }
        }
    }
}
