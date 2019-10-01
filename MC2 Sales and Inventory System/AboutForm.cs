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
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void lblClose_MouseHover(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.Red;
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.Transparent;
        }
    }
}
