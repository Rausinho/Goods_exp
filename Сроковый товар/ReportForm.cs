using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Сроковый_товар
{
    public partial class ReportForm : Form
    {
        public ReportForm(List<string> records)
        {
            InitializeComponent();

            // Проходим по всем записям и добавляем их в ListBox
            foreach (var record in records)
            {
                listBoxResults.Items.Add(record);
            }
        }
    }
}
