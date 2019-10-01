using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MC2_Sales_and_Inventory_System
{
    static class Program
    {
        public static SqlConnection Connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\zeave\Desktop\MC2 Designs (6)\MC2 Designs\MC2 Sales and Inventory System\MC2.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Connection.Open();
            }
            catch
            {
                MessageBox.Show("Unable to connect to database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
//            Application.Run(new LoadingFormRazer());
            Application.Run(new LoadingForm());
        }
    }
}
