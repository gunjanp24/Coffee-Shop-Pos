using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CoffeeShop
{
    public partial class ShopPOS : Form
    {
        private BindingList<Models.Product> products = new BindingList<Models.Product>();
        private DataTable dt = sqlconnector.productsDataTable;
        private List<Models.ProductType> types = sqlconnector.productTypes;

        private double subTotalAmount = 0;
        private double total = 0;
        private double tax = 0;

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
                        Height = 155,
                        Width = 157,
                        Text = foundRows[i]["Description"].ToString(),
                        Tag = foundRows[i],
                        TextAlign = ContentAlignment.BottomCenter
                };

                    Byte[] imagedata = new byte[0];
                    imagedata = (Byte[])(foundRows[i]["Image"]);
                    System.IO.MemoryStream mem = new System.IO.MemoryStream(imagedata);
                    b.Image = (Image.FromStream(mem)).GetThumbnailImage(120,100, ()=> false, IntPtr.Zero);
                    b.ImageAlign = ContentAlignment.TopCenter;
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
            p.Price = double.Parse(x);
            x = ((DataRow)b.Tag)["ProductID"].ToString();
            p.ProductID = int.Parse(x);
            x = ((DataRow)b.Tag)["ProductType"].ToString();
            p.ProductType = int.Parse(x);

            products.Add(p);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            SUBTOTAL += p.Price;

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
            SUBTOTAL -= selectedProoduct.Price;
        }
        
        public double SUBTOTAL
        {
            get
            {
                return subTotalAmount;
            }
            set
            {
                subTotalAmount = value;
                subTotal.Text = string.Format("{0:c}", subTotalAmount);
                
                if (subTotalAmount > 0)
                {
                    tax = subTotalAmount * 0.0825;
                } else
                {
                    tax = 0;
                }
                taxBox.Text = string.Format("{0:c}", tax);

                total = subTotalAmount + tax;
                totalTextBox.Text = string.Format("{0:c}", total);

            }
        }

        
        private void btnPay_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            //payment.Show();
            payment.PaymentMade += new Payment.PaymentMadeEvent(payment_PaymentMade);
            payment.PaymentAmount = total; 
            
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
                trans.TAX = tax;
                trans.SALES = subTotalAmount;
                //save transaction
                try
                {
                    sqlconnector.SaveTransaction(trans);
                    foreach (Models.Product product in products)
                    {
                        item = new Models.TransactionItem();

                        item.TransactionID = trans.TransactionID;
                        item.ProductID = product.ProductID;
                        sqlconnector.SaveTransactionItem(item);
                    }
                    products.Clear();
                    subTotalAmount = 0;
                    totalTextBox.Text = "0";
                    subTotal.Text = "0";
                    taxBox.Text = "0";
                }
                catch
                {
                    MessageBox.Show("Payment not saved");
                    return;
                }
            }


        }
        
    }
}
