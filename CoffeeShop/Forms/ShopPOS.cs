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
    public partial class ShopPOS : Form
    {
        private BindingList<Models.Product> products = new BindingList<Models.Product>();
        private DataTable dt = sqlconnector.GetProducts();
        private List<Models.ProductType> types = sqlconnector.GetProductypes();
        private decimal transTotal = 0.00M;

        public ShopPOS()
        {
            InitializeComponent();
            /*
            Models.Product p = new Models.Product();
            p.Description = "Trial";
            p.Price = 2.54M;
            p.ProductType = 2;
            p.ProductID = 1;
            products.Add(p);
            */
            listBox1.DataSource = null;
            listBox1.DataSource = products;
            listBox1.DisplayMember = "Description";

            CreateTabbedPanel();
            AddProductstoTab();
        }

        private void AddProductstoTab()
        {
            foreach(TabPage tp in tabControl1.TabPages)
            {
                string filterValue = (types.Find(x => x.Description.Contains(tp.Text))).ProductTypeID.ToString();
                string rowfilter = string.Format("[{0}] = '{1}'", "ProductType", filterValue);
                DataRow[] foundRows;

                foundRows = dt.Select(rowfilter);
                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.Dock = DockStyle.Fill;

                for(int i = 0; i<foundRows.Length; i++)
                {

                    //Models.Product product
                    Button b = new Button
                    {
                        Height = 120,
                        Width = 120,
                        Text = foundRows[i]["Description"].ToString(),
                        Tag = foundRows[i],

                    };
                    b.Click += new EventHandler(UpdateProductList);
                    flp.Controls.Add(b);

                }

                tp.Controls.Add(flp);

            
            }
        }

        void UpdateProductList(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            Models.Product p = new Models.Product();
            var x = ((DataRow)b.Tag)["Description"].ToString();
            p.Description = x;
            x = ((DataRow)b.Tag)["Price"].ToString();
            p.Price = decimal.Parse(x);
            x = ((DataRow)b.Tag)["ProductID"].ToString();
            p.ProductID = int.Parse(x);
            x = ((DataRow)b.Tag)["ProductType"].ToString();
            p.ProductType = int.Parse(x);

            products.Add(p);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            TransTotal += p.Price;

        }

        private void CreateTabbedPanel()
        {
            tabControl1.TabPages.Clear();
            foreach(Models.ProductType type in types)
            {
                tabControl1.TabPages.Add(type.Description.ToString());
            }
        }

        private void FormatListItem(object sender, ListControlConvertEventArgs e)
        {
            string currentDesc = ((Models.Product)e.ListItem).Description;
            string currentPrice = string.Format("{0:c}", ((Models.Product)e.ListItem).Price);
            string padd = currentDesc.PadRight(23);

            e.Value = padd + currentPrice;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Models.Product selectedProoduct = (Models.Product)listBox1.SelectedItem;
            products.Remove(selectedProoduct);
            TransTotal -= selectedProoduct.Price;
        }

        public decimal TransTotal
        {
            get
            {
                return transTotal;
            }
            set
            {
                transTotal = value;
                totalTextBox.Text = string.Format("{0:c}", transTotal);

            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            //payment.Show();
            payment.PaymentMade += new Payment.PaymentMadeEvent(payment_PaymentMade);
            payment.PaymentAmount = TransTotal;
            //payment.ShowDialog();
            payment.Show();
        }

        void payment_PaymentMade(object sender, PaymentMadeEventArgs e)
        {
            Models.Transaction trans = new Models.Transaction();
            Models.TransactionItem item = new Models.TransactionItem();
            

            if(e.PaymentSuccess == true)
            {
                trans.TransactionDate = DateTime.Now;
                trans.TransactionID = Guid.NewGuid().ToString("N");
                sqlconnector.SaveTransaction(trans);
                //save transaction
                foreach (Models.Product product in products)
                {
                    item = new Models.TransactionItem();

                    item.TransactionID = trans.TransactionID;
                    item.ProductID = product.ProductID;
                    sqlconnector.SaveTransactionItem(item);
                }
            }


        }
    }
}
