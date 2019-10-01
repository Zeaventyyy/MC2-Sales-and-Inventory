using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MC2_Sales_and_Inventory_System
{
    public partial class LoadingFormRazer : Form
    {
        public LoadingFormRazer()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 4;

            if (panel2.Width >= 700)
            {
                tmProgress.Stop();
                this.Hide();
                (new LoginFormRazer()).Show();

            }
        }

    }
}
