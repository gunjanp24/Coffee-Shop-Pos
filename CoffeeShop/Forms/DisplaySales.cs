﻿using System;
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
    public partial class DisplaySales : Form
    {
        
        public DisplaySales()
        {
            InitializeComponent();

            genGraph();
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

            dataChart.Show();

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}