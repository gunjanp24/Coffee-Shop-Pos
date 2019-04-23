using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace CoffeeShop
{
    public partial class DisplaySales : Form
    {
        
        public DisplaySales()
        {
            InitializeComponent();

            genGraph();

            
            sqlconnector.GetSalesAndTaxTotals(out double sales, out double tax);
            salesBox.Text += sales.ToString();
            taxBox.Text += tax.ToString();
        }

        private void genGraph()
        {
            List<string> chart = sqlconnector.ChartData();
           // List<string> chart = new List<string>() { "Iced Tea", "Biscuit", "Hot Tea", "Coke", "Coffee", "Steam Milk", "Pepsi", "Limeade", "Cake", "Biscuit", "Hot Tea", "Coke", "Coffee", "Steam Milk", "Hot Tea", "Coke", "Coffee", "Steam Milk", "Pepsi", "Limeade", "Cake", "Biscuit", "Hot Tea" };

            Dictionary<string, int> KV = new Dictionary<string, int>();
            foreach (string X in chart)
            {
                if (KV.ContainsKey(X) == false)
                {
                    KV.Add(X, 1);
                }
                if (KV.ContainsKey(X) == true)
                {
                    KV[X] = KV[X] + 1;

                }
            }

            dataChart.DataSource = null;

            dataChart.DataSource = KV;
            dataChart.Series["Series1"].XValueMember = "Key";
            dataChart.Series["Series1"].YValueMembers = "Value";
            dataChart.Series["Series1"].Name = "Total Sales by Product";
            dataChart.ChartAreas[0].AxisX.Interval = 1;
            //dataChart.ChartAreas[0].AxisY.Interval = 1;
            dataChart.Show();

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
