namespace CoffeeShop
{
    partial class Payment
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
            this.amountBox = new System.Windows.Forms.TextBox();
            this.payBox = new System.Windows.Forms.TextBox();
            this.payBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Amount to pay";
            this.label1.UseMnemonic = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Payment Amount";
            // 
            // amountBox
            // 
            this.amountBox.Location = new System.Drawing.Point(266, 46);
            this.amountBox.Name = "amountBox";
            this.amountBox.ReadOnly = true;
            this.amountBox.Size = new System.Drawing.Size(189, 36);
            this.amountBox.TabIndex = 2;
            this.amountBox.TabStop = false;
            // 
            // payBox
            // 
            this.payBox.Location = new System.Drawing.Point(269, 122);
            this.payBox.MaxLength = 10;
            this.payBox.Name = "payBox";
            this.payBox.Size = new System.Drawing.Size(185, 36);
            this.payBox.TabIndex = 3;
            // 
            // payBTN
            // 
            this.payBTN.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.payBTN.BackColor = System.Drawing.Color.LightSteelBlue;
            this.payBTN.FlatAppearance.BorderSize = 0;
            this.payBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.payBTN.Location = new System.Drawing.Point(150, 210);
            this.payBTN.Name = "payBTN";
            this.payBTN.Size = new System.Drawing.Size(224, 57);
            this.payBTN.TabIndex = 4;
            this.payBTN.Text = "Make payment";
            this.payBTN.UseVisualStyleBackColor = false;
            this.payBTN.Click += new System.EventHandler(this.payBTN_Click);
            this.payBTN.Enter += new System.EventHandler(this.payBTN_Enter);
            this.payBTN.Leave += new System.EventHandler(this.payBTN_Leave);
            this.payBTN.MouseEnter += new System.EventHandler(this.payBTN_MouseEnter);
            this.payBTN.MouseLeave += new System.EventHandler(this.payBTN_MouseLeave);
            // 
            // Payment
            // 
            this.AcceptButton = this.payBTN;
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 336);
            this.Controls.Add(this.payBTN);
            this.Controls.Add(this.payBox);
            this.Controls.Add(this.amountBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Lucida Handwriting", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "Payment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Payment";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox amountBox;
        private System.Windows.Forms.TextBox payBox;
        private System.Windows.Forms.Button payBTN;
    }
}