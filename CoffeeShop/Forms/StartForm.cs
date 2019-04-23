using System;
using System.Windows.Forms;

namespace CoffeeShop
{
    public partial class startForm : Form
    {
        public startForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddProduct frm = new AddProduct();
            frm.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(sqlconnector.productsDataTable != null && sqlconnector.productTypes != null)
            {
                ViewProduct frm = new ViewProduct();
                frm.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (sqlconnector.productsDataTable != null && sqlconnector.productTypes != null)
            {
                ShopPOS frm = new ShopPOS();
                frm.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DisplaySales frm = new DisplaySales();
            frm.Show();
        }
    }
}
