using System;
using System.Windows.Forms;
using System.Threading;

namespace CoffeeShop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread t1 = new Thread(sqlconnector.GetProductypes);
            Thread t2 = new Thread(sqlconnector.GetProducts);
            t1.Start(); t2.Start();
            Application.Run(new startForm());
        }
    }
}
