using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient; 

namespace MC2_Sales_and_Inventory_System
{
    public partial class HistoryLoginForm : Form
    {
        public HistoryLoginForm()
        {
            InitializeComponent();
        }

        

        private void HistoryLoginForm_Load(object sender, EventArgs e)
        {
            SqlDataAdapter SDA = new SqlDataAdapter("Select * from HistoryLogin", Program.Connection);
            DataTable data = new DataTable();
            SDA.Fill(data);
            dataGridView1.DataSource = data;  
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Clear?", "Notice !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SqlDataAdapter SDA = new SqlDataAdapter("DELETE  FROM HistoryLogin", Program.Connection);
                SDA.SelectCommand.ExecuteNonQuery();
                SqlDataAdapter SDA2 = new SqlDataAdapter("Select * from HistoryLogin", Program.Connection);
                DataTable data = new DataTable();
                SDA2.Fill(data);
                dataGridView1.DataSource = data;

            }
        }
    }
}
