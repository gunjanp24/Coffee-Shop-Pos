namespace CoffeeShop
{
    partial class AddProduct
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.descTextBOX = new System.Windows.Forms.TextBox();
            this.priceTextBOX = new System.Windows.Forms.TextBox();
            this.catComboBOX = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uploadBTN = new System.Windows.Forms.Button();
            this.saveBTN = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Catergory";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 223);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Image";
            // 
            // descTextBOX
            // 
            this.descTextBOX.Location = new System.Drawing.Point(191, 36);
            this.descTextBOX.Name = "descTextBOX";
            this.descTextBOX.Size = new System.Drawing.Size(331, 34);
            this.descTextBOX.TabIndex = 4;
            // 
            // priceTextBOX
            // 
            this.priceTextBOX.Location = new System.Drawing.Point(194, 102);
            this.priceTextBOX.Name = "priceTextBOX";
            this.priceTextBOX.Size = new System.Drawing.Size(328, 34);
            this.priceTextBOX.TabIndex = 5;
            // 
            // catComboBOX
            // 
            this.catComboBOX.BackColor = System.Drawing.SystemColors.HighlightText;
            this.catComboBOX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.catComboBOX.FormattingEnabled = true;
            this.catComboBOX.Location = new System.Drawing.Point(196, 167);
            this.catComboBOX.Name = "catComboBOX";
            this.catComboBOX.Size = new System.Drawing.Size(326, 32);
            this.catComboBOX.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(196, 223);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(326, 189);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // uploadBTN
            // 
            this.uploadBTN.Location = new System.Drawing.Point(551, 278);
            this.uploadBTN.Name = "uploadBTN";
            this.uploadBTN.Size = new System.Drawing.Size(143, 51);
            this.uploadBTN.TabIndex = 8;
            this.uploadBTN.Text = "Upload";
            this.uploadBTN.UseVisualStyleBackColor = true;
            this.uploadBTN.Click += new System.EventHandler(this.uploadBTN_Click);
            // 
            // saveBTN
            // 
            this.saveBTN.Location = new System.Drawing.Point(283, 433);
            this.saveBTN.Name = "saveBTN";
            this.saveBTN.Size = new System.Drawing.Size(173, 49);
            this.saveBTN.TabIndex = 9;
            this.saveBTN.Text = "Save";
            this.saveBTN.UseVisualStyleBackColor = true;
            this.saveBTN.Click += new System.EventHandler(this.saveBTN_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "jpg";
            this.openFileDialog1.FileName = "Select Image";
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 532);
            this.Controls.Add(this.saveBTN);
            this.Controls.Add(this.uploadBTN);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.catComboBOX);
            this.Controls.Add(this.priceTextBOX);
            this.Controls.Add(this.descTextBOX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Lucida Handwriting", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "AddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Product";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox descTextBOX;
        private System.Windows.Forms.TextBox priceTextBOX;
        private System.Windows.Forms.ComboBox catComboBOX;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button uploadBTN;
        private System.Windows.Forms.Button saveBTN;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}