namespace Сроковый_товар
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxCode = new System.Windows.Forms.TextBox();
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.comboBoxYear = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelProductName = new System.Windows.Forms.Label();
            this.buttonGenerateReport = new System.Windows.Forms.Button();
            this.checkBoxNewItem = new System.Windows.Forms.CheckBox();
            this.buttonGenerateFutureReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxCode
            // 
            this.textBoxCode.Location = new System.Drawing.Point(12, 27);
            this.textBoxCode.Name = "textBoxCode";
            this.textBoxCode.Size = new System.Drawing.Size(89, 22);
            this.textBoxCode.TabIndex = 0;
            this.textBoxCode.TextChanged += new System.EventHandler(this.textBoxCode_TextChanged);
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Location = new System.Drawing.Point(330, 27);
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(63, 24);
            this.comboBoxMonth.TabIndex = 1;
            // 
            // comboBoxYear
            // 
            this.comboBoxYear.FormattingEnabled = true;
            this.comboBoxYear.Location = new System.Drawing.Point(399, 27);
            this.comboBoxYear.Name = "comboBoxYear";
            this.comboBoxYear.Size = new System.Drawing.Size(63, 24);
            this.comboBoxYear.TabIndex = 2;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(15, 125);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(133, 43);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Location = new System.Drawing.Point(12, 61);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(106, 16);
            this.labelProductName.TabIndex = 4;
            this.labelProductName.Text = "Наименование";
            // 
            // buttonGenerateReport
            // 
            this.buttonGenerateReport.Location = new System.Drawing.Point(329, 125);
            this.buttonGenerateReport.Name = "buttonGenerateReport";
            this.buttonGenerateReport.Size = new System.Drawing.Size(133, 44);
            this.buttonGenerateReport.TabIndex = 5;
            this.buttonGenerateReport.Text = "Вывести";
            this.buttonGenerateReport.UseVisualStyleBackColor = true;
            this.buttonGenerateReport.Click += new System.EventHandler(this.buttonGenerateReport_Click);
            // 
            // checkBoxNewItem
            // 
            this.checkBoxNewItem.AutoSize = true;
            this.checkBoxNewItem.Location = new System.Drawing.Point(15, 90);
            this.checkBoxNewItem.Name = "checkBoxNewItem";
            this.checkBoxNewItem.Size = new System.Drawing.Size(168, 20);
            this.checkBoxNewItem.TabIndex = 6;
            this.checkBoxNewItem.Text = "Обнулившийся товар";
            this.checkBoxNewItem.UseVisualStyleBackColor = true;
            // 
            // buttonGenerateFutureReport
            // 
            this.buttonGenerateFutureReport.Location = new System.Drawing.Point(173, 125);
            this.buttonGenerateFutureReport.Name = "buttonGenerateFutureReport";
            this.buttonGenerateFutureReport.Size = new System.Drawing.Size(132, 42);
            this.buttonGenerateFutureReport.TabIndex = 7;
            this.buttonGenerateFutureReport.Text = "Сформировать текущий месяц";
            this.buttonGenerateFutureReport.UseVisualStyleBackColor = true;
            this.buttonGenerateFutureReport.Click += new System.EventHandler(this.buttonGenerateFutureReport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 188);
            this.Controls.Add(this.buttonGenerateFutureReport);
            this.Controls.Add(this.checkBoxNewItem);
            this.Controls.Add(this.buttonGenerateReport);
            this.Controls.Add(this.labelProductName);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxYear);
            this.Controls.Add(this.comboBoxMonth);
            this.Controls.Add(this.textBoxCode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Сроковый товар";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCode;
        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.ComboBox comboBoxYear;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Button buttonGenerateReport;
        private System.Windows.Forms.CheckBox checkBoxNewItem;
        private System.Windows.Forms.Button buttonGenerateFutureReport;
    }
}

