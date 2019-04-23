using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace CoffeeShop
{
    public partial class AddProduct : Form
    {
        private byte[] imageBlob;
        private System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en-US");

        public AddProduct()
        {
            InitializeComponent();

            catComboBOX.DataSource = null;

           
            catComboBOX.DataSource = sqlconnector.GetProductypes();
            catComboBOX.DisplayMember = "ProductTypes";
            catComboBOX.ValueMember = "Description";
            
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

        private void saveBTN_Click(object sender, EventArgs e)
        {
            
            Models.Product product = new Models.Product();
            product.Description = descTextBOX.Text;
            product.Price = Convert.ToDecimal(priceTextBOX.Text, culture); 
            product.Image = imageBlob;
            Models.ProductType type = (Models.ProductType)catComboBOX.SelectedItem;
            product.ProductType = type.ProductTypeID;
            sqlconnector.SaveProduct(product);
            saveBTN.Text = "Product Saved";
            saveBTN.BackColor = Color.AliceBlue;

        }
    }
}
