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
    public partial class ForgotPasswordFormRazer : Form
    {
        public ForgotPasswordFormRazer()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {

            bool isExists = false;
            SqlDataAdapter SDACheckExist = new SqlDataAdapter("SELECT COUNT(*) FROM LoginTable WHERE Username='" + txtUsername.Text + "'", Program.Connection);
            isExists = Convert.ToInt32(SDACheckExist.SelectCommand.ExecuteScalar().ToString()) > 0;

            if (txtUsername.Text == "")
            {
                MessageBox.Show("Enter Username !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (!isExists)
            {
                MessageBox.Show("Username Not Found!", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Text = String.Empty;
            }
            else if (txtAnswer.Text == "")
            {
                MessageBox.Show("Enter your Secret Answer !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (txtNewPass.Text == "")
            {
                MessageBox.Show("Enter your New Password !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtNewPass.Text.Length < 6)
            {
                MessageBox.Show("Password Must be 6 - 15 characters long!", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtRetype.Text == "")
            {
                MessageBox.Show("Enter a Retype Password !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from LoginTable Where Username= '" + txtUsername.Text + "' and Answer = '" + txtAnswer.Text + "'", Program.Connection);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    SqlDataAdapter sda1 = new SqlDataAdapter("Select Username from LoginTable Where Username= '" + txtUsername.Text + "' and Answer = '" + txtAnswer.Text + "'", Program.Connection);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);

                    if (dt1.Rows[0][0].ToString() == "admin")
                    {
                        MessageBox.Show("You Can't change the Administrator Password!", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        if (txtRetype.Text == txtNewPass.Text || txtNewPass.Text == txtRetype.Text)
                        {

                            SqlDataAdapter SDA2 = new SqlDataAdapter("UPDATE LoginTable SET Password='" + txtRetype.Text + "' WHERE Username='" + txtUsername.Text + "'", Program.Connection);
                            SDA2.SelectCommand.ExecuteNonQuery();
                            MessageBox.Show("Password changed Successfully !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Password not Match !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtNewPass.Text = String.Empty;
                            txtRetype.Text = String.Empty;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Your Username or Secret Answer is Not Match!", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }










    }
}
