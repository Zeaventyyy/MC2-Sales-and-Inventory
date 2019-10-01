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
    public partial class HistoryClientListFormDark : Form
    {
        public HistoryClientListFormDark()
        {
            InitializeComponent();
        }

        private void HistoryClientListFormDark_Load(object sender, EventArgs e)
        {

            
            SqlDataAdapter SDA = new SqlDataAdapter("Select * from LoginTable", Program.Connection);
            DataTable data = new DataTable();
            SDA.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                bool isExists = false;
                SqlDataAdapter SDACheckExist = new SqlDataAdapter("SELECT COUNT(*) FROM LoginTable WHERE Username='" + txtSearch.Text + "'", Program.Connection);
                isExists = Convert.ToInt32(SDACheckExist.SelectCommand.ExecuteScalar().ToString()) > 0;

                if (txtSearch.Text == "")
                {
                    MessageBox.Show("Enter Username!", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!isExists)
                {
                    MessageBox.Show("Username Not Found!", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSearch.Text = String.Empty;
                }

                else
                {
                    SqlDataAdapter SDA = new SqlDataAdapter("Select * from LoginTable WHERE Username='" + txtSearch.Text + "'", Program.Connection);
                    DataTable data = new DataTable();
                    SDA.Fill(data);
                    dataGridView1.DataSource = data;
                    txtSearch.Text = String.Empty;
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("  " + a);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
                bool isExists = false;
                SqlDataAdapter SDACheckExist = new SqlDataAdapter("SELECT COUNT(*) FROM LoginTable WHERE Username='" + txtSearch.Text + "'", Program.Connection);
                isExists = Convert.ToInt32(SDACheckExist.SelectCommand.ExecuteScalar().ToString()) > 0;

                if (txtSearch.Text == "")
                {
                    MessageBox.Show("Enter Username!", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!isExists)
                {
                    MessageBox.Show("Username Not Found!", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSearch.Text = String.Empty;
                }
                else
                {
                    if (MessageBox.Show("Do you want to Delete this Item?", "Notice !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SqlDataAdapter SDA = new SqlDataAdapter("DELETE FROM LoginTable WHERE Username= '" + txtSearch.Text + "'", Program.Connection);
                        SDA.SelectCommand.ExecuteNonQuery();
                        MessageBox.Show("Client Deleted Succesfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtSearch.Text = String.Empty;

                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("  " + a);
            }
            btnRefresh_Click(null, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            SqlDataAdapter SDA2 = new SqlDataAdapter("Select * from LoginTable", Program.Connection);
            DataTable data = new DataTable();
            SDA2.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
