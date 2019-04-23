using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop
{
    public partial class ViewProduct : Form
    {

        private DataTable dt = sqlconnector.GetProducts();
        public ViewProduct()
        {
            InitializeComponent();
            dataGridView1.DataSource = null;

           
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["ProductType"].Visible = false;
            dataGridView1.Columns["Image"].Width = 1250;
            dataGridView1.RowHeadersWidth = 20;

            comboBox1.DataSource = null;
            comboBox1.DataSource = sqlconnector.GetProductypes();
            comboBox1.DisplayMember = "Description";
            
        }
        
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string filterValue = ((Models.ProductType)comboBox1.SelectedItem).ProductTypeID.ToString();
            string rowfilter = string.Format("[{0}] = '{1}'", "ProductType", filterValue);
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowfilter;

        }
    }
}
