using System;
using System.Windows.Forms;

namespace CoffeeShop
{
    public partial class Payment : Form
    {
        public delegate void PaymentMadeEvent(object sender, PaymentMadeEventArgs e);
        public event PaymentMadeEvent PaymentMade;

        private decimal paymentAmount = 0.00M;

        public Payment()
        {
            InitializeComponent();
        }

        public decimal PaymentAmount
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
            decimal total = 0;
            try
            {
                total = decimal.Parse(amountBox.Text.TrimStart('$')) - decimal.Parse(payBox.Text);
            }
            catch
            {
                MessageBox.Show("Please Enter Valid Amount");
                return;
            }

            if(total > 0)
            {
                amountBox.Text = total.ToString();
            } else
            {
                MessageBox.Show("Please give " + string.Format("{0:c}" + " change.", -total));
                PaymentMade(this, new PaymentMadeEventArgs() { PaymentSuccess = true });

            }


          
        }
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
