namespace SimulatedAnnealing
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNumCities = new System.Windows.Forms.TextBox();
            this.textBoxInitialTemp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxEndTemp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelGraph = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество городов";
            // 
            // textBoxNumCities
            // 
            this.textBoxNumCities.Location = new System.Drawing.Point(215, 24);
            this.textBoxNumCities.Name = "textBoxNumCities";
            this.textBoxNumCities.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumCities.TabIndex = 1;
            this.textBoxNumCities.Text = "10";
            // 
            // textBoxInitialTemp
            // 
            this.textBoxInitialTemp.Location = new System.Drawing.Point(215, 50);
            this.textBoxInitialTemp.Name = "textBoxInitialTemp";
            this.textBoxInitialTemp.Size = new System.Drawing.Size(100, 20);
            this.textBoxInitialTemp.TabIndex = 3;
            this.textBoxInitialTemp.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Начальная температура";
            // 
            // textBoxEndTemp
            // 
            this.textBoxEndTemp.Location = new System.Drawing.Point(215, 76);
            this.textBoxEndTemp.Name = "textBoxEndTemp";
            this.textBoxEndTemp.Size = new System.Drawing.Size(100, 20);
            this.textBoxEndTemp.TabIndex = 5;
            this.textBoxEndTemp.Text = "0,001";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Конечная температура";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(122, 175);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "Запустить";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(354, 24);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(374, 371);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Функция понижение температуры:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "F = начальная температура * 0,1 / номер интераци",
            "F = начальная температура / номер итерации"});
            this.comboBox1.Location = new System.Drawing.Point(12, 125);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(303, 21);
            this.comboBox1.TabIndex = 9;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Матрица смежности графа:";
            // 
            // labelGraph
            // 
            this.labelGraph.AutoSize = true;
            this.labelGraph.Location = new System.Drawing.Point(13, 243);
            this.labelGraph.Name = "labelGraph";
            this.labelGraph.Size = new System.Drawing.Size(0, 13);
            this.labelGraph.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 415);
            this.Controls.Add(this.labelGraph);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.textBoxEndTemp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxInitialTemp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNumCities);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNumCities;
        private System.Windows.Forms.TextBox textBoxInitialTemp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxEndTemp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelGraph;
    }
}

