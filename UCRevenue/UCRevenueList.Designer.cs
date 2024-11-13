namespace UCRevenue
{
    partial class UCRevenueList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel4 = new System.Windows.Forms.Panel();
            this.button_filter = new System.Windows.Forms.Button();
            this.textBox_Year = new System.Windows.Forms.TextBox();
            this.dateTimePicker_Month = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Day = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.radioButton_Year = new System.Windows.Forms.RadioButton();
            this.radioButton_Month = new System.Windows.Forms.RadioButton();
            this.radioButton_Day = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView_revenue = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_export_excel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label_total_revenue = new System.Windows.Forms.Label();
            this.comboBox_stores = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_revenue)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.comboBox_stores);
            this.panel4.Controls.Add(this.button_filter);
            this.panel4.Controls.Add(this.textBox_Year);
            this.panel4.Controls.Add(this.dateTimePicker_Month);
            this.panel4.Controls.Add(this.dateTimePicker_Day);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.radioButton_Year);
            this.panel4.Controls.Add(this.radioButton_Month);
            this.panel4.Controls.Add(this.radioButton_Day);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(329, 567);
            this.panel4.TabIndex = 14;
            // 
            // button_filter
            // 
            this.button_filter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_filter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(128)))), ((int)(((byte)(32)))));
            this.button_filter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_filter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_filter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button_filter.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_filter.Location = new System.Drawing.Point(10, 314);
            this.button_filter.Name = "button_filter";
            this.button_filter.Size = new System.Drawing.Size(313, 40);
            this.button_filter.TabIndex = 5;
            this.button_filter.Text = "Lọc";
            this.button_filter.UseVisualStyleBackColor = false;
            // 
            // textBox_Year
            // 
            this.textBox_Year.Location = new System.Drawing.Point(123, 196);
            this.textBox_Year.Name = "textBox_Year";
            this.textBox_Year.Size = new System.Drawing.Size(200, 22);
            this.textBox_Year.TabIndex = 4;
            // 
            // dateTimePicker_Month
            // 
            this.dateTimePicker_Month.Location = new System.Drawing.Point(123, 127);
            this.dateTimePicker_Month.Name = "dateTimePicker_Month";
            this.dateTimePicker_Month.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker_Month.TabIndex = 3;
            // 
            // dateTimePicker_Day
            // 
            this.dateTimePicker_Day.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Day.Location = new System.Drawing.Point(123, 65);
            this.dateTimePicker_Day.Name = "dateTimePicker_Day";
            this.dateTimePicker_Day.Size = new System.Drawing.Size(203, 22);
            this.dateTimePicker_Day.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(128)))), ((int)(((byte)(32)))));
            this.label8.Location = new System.Drawing.Point(5, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 25);
            this.label8.TabIndex = 1;
            this.label8.Text = "Bộ lọc thống kê";
            // 
            // radioButton_Year
            // 
            this.radioButton_Year.AutoSize = true;
            this.radioButton_Year.Checked = true;
            this.radioButton_Year.Location = new System.Drawing.Point(10, 197);
            this.radioButton_Year.Name = "radioButton_Year";
            this.radioButton_Year.Size = new System.Drawing.Size(89, 20);
            this.radioButton_Year.TabIndex = 0;
            this.radioButton_Year.TabStop = true;
            this.radioButton_Year.Text = "Theo năm";
            this.radioButton_Year.UseVisualStyleBackColor = true;
            // 
            // radioButton_Month
            // 
            this.radioButton_Month.AutoSize = true;
            this.radioButton_Month.Location = new System.Drawing.Point(10, 130);
            this.radioButton_Month.Name = "radioButton_Month";
            this.radioButton_Month.Size = new System.Drawing.Size(96, 20);
            this.radioButton_Month.TabIndex = 0;
            this.radioButton_Month.Text = "Theo tháng";
            this.radioButton_Month.UseVisualStyleBackColor = true;
            // 
            // radioButton_Day
            // 
            this.radioButton_Day.AutoSize = true;
            this.radioButton_Day.Location = new System.Drawing.Point(10, 65);
            this.radioButton_Day.Name = "radioButton_Day";
            this.radioButton_Day.Size = new System.Drawing.Size(93, 20);
            this.radioButton_Day.TabIndex = 0;
            this.radioButton_Day.Text = "Theo ngày";
            this.radioButton_Day.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(329, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(874, 567);
            this.panel1.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView_revenue);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 56);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(874, 511);
            this.panel3.TabIndex = 1;
            // 
            // dataGridView_revenue
            // 
            this.dataGridView_revenue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_revenue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_revenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_revenue.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_revenue.Name = "dataGridView_revenue";
            this.dataGridView_revenue.RowHeadersWidth = 51;
            this.dataGridView_revenue.RowTemplate.Height = 24;
            this.dataGridView_revenue.Size = new System.Drawing.Size(874, 511);
            this.dataGridView_revenue.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_export_excel);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label_total_revenue);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(874, 56);
            this.panel2.TabIndex = 0;
            // 
            // button_export_excel
            // 
            this.button_export_excel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button_export_excel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_export_excel.Location = new System.Drawing.Point(760, 14);
            this.button_export_excel.Name = "button_export_excel";
            this.button_export_excel.Size = new System.Drawing.Size(98, 29);
            this.button_export_excel.TabIndex = 26;
            this.button_export_excel.Text = "Xuất Excel";
            this.button_export_excel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Tổng số tiền:";
            // 
            // label_total_revenue
            // 
            this.label_total_revenue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label_total_revenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(128)))), ((int)(((byte)(32)))));
            this.label_total_revenue.Location = new System.Drawing.Point(118, 13);
            this.label_total_revenue.Name = "label_total_revenue";
            this.label_total_revenue.Size = new System.Drawing.Size(390, 25);
            this.label_total_revenue.TabIndex = 24;
            this.label_total_revenue.Text = "0 đ";
            // 
            // comboBox_stores
            // 
            this.comboBox_stores.FormattingEnabled = true;
            this.comboBox_stores.Location = new System.Drawing.Point(123, 261);
            this.comboBox_stores.Name = "comboBox_stores";
            this.comboBox_stores.Size = new System.Drawing.Size(200, 24);
            this.comboBox_stores.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Doanh thu theo";
            // 
            // UCRevenueList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Name = "UCRevenueList";
            this.Size = new System.Drawing.Size(1203, 567);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_revenue)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button_filter;
        private System.Windows.Forms.TextBox textBox_Year;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Month;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Day;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButton_Year;
        private System.Windows.Forms.RadioButton radioButton_Month;
        private System.Windows.Forms.RadioButton radioButton_Day;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView_revenue;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_export_excel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_total_revenue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_stores;
    }
}
