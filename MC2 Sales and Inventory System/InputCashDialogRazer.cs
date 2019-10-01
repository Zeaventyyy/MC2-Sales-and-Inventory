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
    public partial class InputCashDialogRazer : Form
    {
        public delegate void Callback(CashEnteredEventArgs e);

        public event Callback OnCashEntered;

        protected double totalPrice;

        public InputCashDialogRazer(double totalPrice)
        {
            InitializeComponent();
            this.totalPrice = totalPrice;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            double value;

            try
            {
                value = Double.Parse(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Invalid Cash Input!", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (value < 0)
            {
                MessageBox.Show("Cash should be at least 1!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (totalPrice > value)
            {
                MessageBox.Show("Insufficient Balance!", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            OnCashEntered(new CashEnteredEventArgs
            {
                Value = value
            });

            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        public class CashEnteredEventArgs : EventArgs
        {
            public double Value { get; set; }
        }



    }
}
