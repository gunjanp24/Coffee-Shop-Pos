using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace CoffeeShop
{
    public partial class ViewProduct : Form
    {
        private DataTable dt = sqlconnector.productsDataTable;
        private List<Models.ProductType> ptList = sqlconnector.productTypes;

        public ViewProduct()
        {
            InitializeComponent();

            loadGrid();
            loadCombo();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int id = -10;
            id = ((Models.ProductType)comboBox1.SelectedItem).ProductTypeID;
            if ( id < 0)
            {
                dt.DefaultView.RowFilter = null;//(dataGridView1.DataSource as DataTable).DefaultView.RowFilter = null;

            }
            else
            {
                string filterValue = id.ToString();
                string rowfilter = string.Format("[{0}] = '{1}'", "ProductType", filterValue);
                dt.DefaultView.RowFilter = rowfilter;// (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = rowfilter;

            }
        }

        private void loadGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["ProductType"].Visible = false;
            dataGridView1.Columns["Image"].Width = 200;
            dataGridView1.RowHeadersWidth = 20;

        }

        private void loadCombo()
        {
            comboBox1.DataSource = null;

            Models.ProductType displayAll = new Models.ProductType
            {
                Description = "Display All Products",
                ProductTypeID = -10
            };

            List<Models.ProductType> pt = new List<Models.ProductType>();
            pt.Add(displayAll);

            foreach (Models.ProductType i in ptList)
            {
                pt.Add(i);
            }

            comboBox1.DataSource = pt;
            comboBox1.DisplayMember = "Description";
        }

    }
}
