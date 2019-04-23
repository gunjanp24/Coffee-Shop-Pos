using System;
using System.Windows.Forms;
using System.Drawing;

namespace CoffeeShop
{
    public partial class Payment : Form
    {
        public delegate void PaymentMadeEvent(object sender, PaymentMadeEventArgs e);
        public event PaymentMadeEvent PaymentMade;

        private double paymentAmount = 0.00;

        public Payment()
        {
            InitializeComponent();
            
        }

        public double PaymentAmount
        {
            get
            {
                return paymentAmount;
            }
            set
            {
                paymentAmount = value;
                amountBox.Text = string.Format("{0:c}", paymentAmount);
                
            }

        }

        private void payBTN_Click(object sender, EventArgs e)
        {
            double total = 0;
            try
            {
                total = double.Parse(amountBox.Text.TrimStart('$')) - double.Parse(payBox.Text);
            }
            catch
            {
                MessageBox.Show("Please Enter Valid Amount");
                payBox.Text = "";
                return;
            }

            if(total > 0)
            {
                amountBox.Text = total.ToString();
            } else
            {
                MessageBox.Show("Please give " + string.Format("{0:c}" + " change.", -total));
                PaymentMade(this, new PaymentMadeEventArgs() { PaymentSuccess = true });
                this.Close();
            }


          
        }
        #region Styles
        private void payBTN_Enter(object sender, EventArgs e)
        {
            payBTN.BackColor = Color.LightGreen;
        }

        private void payBTN_Leave(object sender, EventArgs e)
        {
            payBTN.BackColor = Color.LightSteelBlue;
        }

        private void payBTN_MouseEnter(object sender, EventArgs e)
        {
            payBTN.BackColor = Color.LightGreen;
        }

        private void payBTN_MouseLeave(object sender, EventArgs e)
        {
            payBTN.BackColor = Color.LightSteelBlue;
        }
        #endregion
    }
    
    public class PaymentMadeEventArgs : EventArgs
     {
        private bool paymentSuccess;

        public bool PaymentSuccess
          {
              get { return paymentSuccess; }
               set { paymentSuccess = value; }
           }
     }
     
}
