namespace UCProduct
{
    partial class UCProductCard
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
            this.pictureBox_product_image = new System.Windows.Forms.PictureBox();
            this.button_select = new System.Windows.Forms.Button();
            this.label_product_price = new System.Windows.Forms.Label();
            this.label_product_name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_product_image)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_product_image
            // 
            this.pictureBox_product_image.Location = new System.Drawing.Point(21, 24);
            this.pictureBox_product_image.Name = "pictureBox_product_image";
            this.pictureBox_product_image.Size = new System.Drawing.Size(138, 133);
            this.pictureBox_product_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_product_image.TabIndex = 1;
            this.pictureBox_product_image.TabStop = false;
            // 
            // button_select
            // 
            this.button_select.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(121)))), ((int)(((byte)(5)))));
            this.button_select.FlatAppearance.BorderSize = 0;
            this.button_select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_select.Font = new System.Drawing.Font("Microsoft PhagsPa", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button_select.ForeColor = System.Drawing.Color.White;
            this.button_select.Location = new System.Drawing.Point(181, 104);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(243, 53);
            this.button_select.TabIndex = 17;
            this.button_select.Text = "Chọn";
            this.button_select.UseVisualStyleBackColor = false;
            // 
            // label_product_price
            // 
            this.label_product_price.AutoSize = true;
            this.label_product_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label_product_price.Location = new System.Drawing.Point(178, 60);
            this.label_product_price.Name = "label_product_price";
            this.label_product_price.Size = new System.Drawing.Size(87, 18);
            this.label_product_price.TabIndex = 16;
            this.label_product_price.Text = "40.000 VNĐ";
            // 
            // label_product_name
            // 
            this.label_product_name.Font = new System.Drawing.Font("Microsoft PhagsPa", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label_product_name.Location = new System.Drawing.Point(177, 24);
            this.label_product_name.Name = "label_product_name";
            this.label_product_name.Size = new System.Drawing.Size(247, 23);
            this.label_product_name.TabIndex = 15;
            this.label_product_name.Text = "Latte đá";
            // 
            // UCProductCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.Controls.Add(this.button_select);
            this.Controls.Add(this.label_product_price);
            this.Controls.Add(this.label_product_name);
            this.Controls.Add(this.pictureBox_product_image);
            this.Name = "UCProductCard";
            this.Size = new System.Drawing.Size(447, 179);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_product_image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_product_image;
        private System.Windows.Forms.Button button_select;
        private System.Windows.Forms.Label label_product_price;
        private System.Windows.Forms.Label label_product_name;
    }
}
