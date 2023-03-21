using Invoice_Billing_Software.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Invoice_Billing_Software
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login_Page());
            //Application.Run(new Business_Page());
            /*Application.Run(new Home_Page());
            Application.Run(new Invoice_Page());
            Application.Run(new Products_Page());
            Application.Run(new Expenses_Page());*/
            
        }
    }
}
