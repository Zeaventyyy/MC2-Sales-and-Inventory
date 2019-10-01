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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }



        string dt2 = DateTime.Now.ToString("HH:mm:ss");
        string dt3 = DateTime.Now.ToString("yyyy-MM-dd");

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            try
            {
                tmDateTime.Start();
                this.AcceptButton = btnRegister;
                btnRegister.Focus();
                
            }
            catch (System.Data.SqlClient.SqlException)
            {
                if (MessageBox.Show("Unable to connect to Database, Please Try Again!", "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Error) == DialogResult.OK)
                {
                    this.Close();
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Enter Username !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtUsername.Text.Length < 6)
            {
                MessageBox.Show("Username Must be 6 - 15 characters long!", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Enter Password !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Password Must be 6 - 15 characters long!", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtConfirmPassword.Text == "")
            {
                MessageBox.Show("Enter a Confirm Password !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cboQuestion.Text == "")
            {
                MessageBox.Show("Select Question !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (txtAnswer.Text == "")
            {
                MessageBox.Show("Enter your Secret Answer!", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if (chbAgree.Checked)
            {

                bool isExists = false;
                SqlDataAdapter SDACheckExist = new SqlDataAdapter("SELECT COUNT(*) FROM LoginTable WHERE Username='" + txtUsername.Text + "'", Program.Connection);
                isExists = Convert.ToInt32(SDACheckExist.SelectCommand.ExecuteScalar().ToString()) > 0;

                if (isExists)
                {
                    MessageBox.Show("Username Already Exists!", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Text = String.Empty;
                    return;
                }
                else if (txtConfirmPassword.Text == txtPassword.Text || txtPassword.Text == txtConfirmPassword.Text)
                {
                    SqlDataAdapter SDA = new SqlDataAdapter("INSERT INTO LoginTable (Username,Password,Question,Answer,Date_Registered,Time_Registered)VALUES ('" + txtUsername.Text + "','" + txtConfirmPassword.Text + "','" + cboQuestion.Text + "','" + txtAnswer.Text + "','" + dt3 + "','" + dt2 + "')", Program.Connection);
                    SDA.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("Registered Successfully", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Password not Match !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Text = String.Empty;
                    txtConfirmPassword.Text = String.Empty;
                }
            }
            else
            {
                MessageBox.Show("Please click the checkbox to Proceed !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();

        }

        private void tmDateTime_Tick(object sender, EventArgs e)
        {
            dt2 = DateTime.Now.ToLongTimeString();
            tmDateTime.Start();
        }

    }
}
