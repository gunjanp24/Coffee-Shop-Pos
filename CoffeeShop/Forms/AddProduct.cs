using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace CoffeeShop
{
    public partial class AddProduct : Form
    {
        private byte[] imageBlob;
        private System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");

        public AddProduct()
        {
            InitializeComponent();
            comboLoad();
         

        }

        private void uploadBTN_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                FileStream imgfile = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read );
                imageBlob = new byte[imgfile.Length];
                imgfile.Read(imageBlob, 0, imageBlob.Length);
                imgfile.Close();
                MemoryStream memory = new MemoryStream(imageBlob);
                pictureBox1.Image = Image.FromStream(memory);

            }
        }

        private void comboLoad()
        {
            catComboBOX.DataSource = null;
            Models.ProductType selectcombo = new Models.ProductType();
            selectcombo.ProductTypeID = -1;
            selectcombo.Description = "Please select product type";
            List<Models.ProductType> pt = new List<Models.ProductType>();
            pt.Add(selectcombo);
            foreach (Models.ProductType i in sqlconnector.productTypes)
            {
                pt.Add(i);
            }

            catComboBOX.DataSource = pt;
           // catComboBOX.DisplayMember = "ProductTypes";
            catComboBOX.ValueMember = "Description";


        }

        private void saveBTN_Click(object sender, EventArgs e)
        {
            
            Models.Product product = new Models.Product();
            if (descTextBOX.Text != "" && ((String)(descTextBOX.Text)).Length > 2 && ((String)(descTextBOX.Text)).Length < 31)
            {
                product.Description = descTextBOX.Text;
            }
            else
            {
                MessageBox.Show(" Description Input Invalid \n Must be more than 2 characters \n Must be less than 30 characters");
                return;
            }

            try
            {
                double x =  Convert.ToDouble(priceTextBOX.Text, culture);
                if (x > 0.01 && x < 50001)
                {
                    product.Price = x;
                } else { throw new DivideByZeroException(); }
            }
            catch
            {
                MessageBox.Show(" Price Input Invalid \n Must a positive number \n Sample Format \n ----> 0.25 \n ----> 5 \n ----> 51.25 \n Any number between 0.01 and 50,000");
                return;
            }

            if (((Models.ProductType)catComboBOX.SelectedItem).ProductTypeID > 0)
            {
                Models.ProductType type = (Models.ProductType)catComboBOX.SelectedItem;
                product.ProductType = type.ProductTypeID;
            }
            else
            {
                MessageBox.Show("Product Type Selection Invalid");
                return;
            }

            if (imageBlob != null)
            {
                product.Image = imageBlob;
            }
            else
            {
                MessageBox.Show("Image Input Invalid");
                return;
            }
            
        
            try
            {
                sqlconnector.SaveProduct(product);
                saveBTN.Text = "Product Saved";
                saveBTN.BackColor = Color.AliceBlue;
            }
            catch
            {
                MessageBox.Show("Unable to Save New Product");
                return;

            }
        }
    }
}
