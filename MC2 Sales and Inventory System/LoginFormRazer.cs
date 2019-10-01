using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using MetroFramework.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace MC2_Sales_and_Inventory_System
{
    public partial class LoginFormRazer : Form
    {
        public LoginFormRazer()
        {
            InitializeComponent();
        }

        internal class UserInformation
        {
            public static string CurrentLoggedInUser
            {
                get;
                set;
            }
        }



        string dt3 = DateTime.Now.ToString("HH:mm:ss");

        private void LoginFormRazer_Load(object sender, EventArgs e)
        {
            try
            {
                if (Properties.Settings.Default.Username != String.Empty)
                {
                    txtUsername.Text = Properties.Settings.Default.Username;
                    txtPassword.Text = Properties.Settings.Default.Password;
                    chkRememberMe.Checked = true;
                    txtUsername.ForeColor = Color.LightGray;
                    txtPassword.ForeColor = Color.LightGray;
                    txtUsername.BackColor = Color.FromArgb(255, 255, 192);
                    txtPassword.BackColor = Color.FromArgb(255, 255, 192);
                    txtPassword.UseSystemPasswordChar = true;
                }

                tmDateTime.Start();
                lblDate.Text = DateTime.Now.ToLongDateString();
                lblTime.Text = DateTime.Now.ToLongTimeString();
                dt3 = DateTime.Today.ToLongTimeString();
                this.AcceptButton = btnLogin;
                btnLogin.Focus();

            }

            catch (System.Data.SqlClient.SqlException)
            {
                if (MessageBox.Show("Unable to connect to Database, Retry Connection?", "Notice!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    this.Hide();
                    (new LoginForm()).Show();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private int attempts = 5;
        private int count = 30;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserInformation.CurrentLoggedInUser = txtUsername.Text.Trim();

            if (txtUsername.Text == "Username")
            {
                MessageBox.Show("Enter your Username !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label10.Visible = true;
            }
            else if (txtPassword.Text == "Password")
            {
                MessageBox.Show("Enter your Password !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label9.Visible = true;
            }
            else if (txtUsername.Text.Length < 6)
            {
                MessageBox.Show("Please input your Username 6 - 15 characters long !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label10.Visible = true;
            }
            else if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Please input your Password 6 - 15 characters !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label9.Visible = true;
            }
            else
            {
                SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from LoginTable Where Username = '" + txtUsername.Text + "' and Password = '" + txtPassword.Text + "'", Program.Connection);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows[0][0].ToString() == "1")
                {
                    SqlDataAdapter sda1 = new SqlDataAdapter("Select Username from LoginTable Where Username= '" + txtUsername.Text + "' and Password = '" + txtPassword.Text + "'", Program.Connection);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);

                    if (dt1.Rows[0][0].ToString() == "admin")
                    {
                        if (chkRememberMe.Checked)
                        {
                            Properties.Settings.Default.Username = txtUsername.Text;
                            Properties.Settings.Default.Password = txtPassword.Text;
                            MessageBox.Show("Welcome, " + txtUsername.Text + " !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            (new AdminFormRazer()).ShowDialog();
                            txtUsername.ForeColor = Color.LightGray;
                            txtPassword.ForeColor = Color.LightGray;
                            txtUsername.BackColor = Color.FromArgb(255, 255, 192);
                            txtPassword.BackColor = Color.FromArgb(255, 255, 192);
                            Properties.Settings.Default.Save();
                        }
                        else
                        {
                            MessageBox.Show("Welcome, " + txtUsername.Text + " ! ⏷", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            (new AdminFormRazer()).ShowDialog();
                            Properties.Settings.Default.Username = txtUsername.Text;
                            Properties.Settings.Default.Password = txtPassword.Text;
                            txtUsername.Text = "Username";
                            txtUsername.ForeColor = Color.LightGray;
                            txtPassword.Text = "Password";
                            txtPassword.ForeColor = Color.LightGray;
                            txtPassword.UseSystemPasswordChar = false;
                            txtUsername.BackColor = Color.White;
                            txtPassword.BackColor = Color.White;
                            Properties.Settings.Default.Reset();
                        }
                    }
                    else
                    {
                        string dt2 = DateTime.Today.ToString("yyyy-MM-dd");
                        string sessionId = Guid.NewGuid().ToString();

                        SqlDataAdapter SDA = new SqlDataAdapter("INSERT INTO HistoryLogin (Username,Date,Time_LoggedIn,SessionId)VALUES ('" + txtUsername.Text + "','" + dt2 + "','" + dt3 + "', '" + sessionId + "')", Program.Connection);
                        SDA.SelectCommand.ExecuteNonQuery();

                        if (chkRememberMe.Checked)
                        {
                            Properties.Settings.Default.Username = txtUsername.Text;
                            Properties.Settings.Default.Password = txtPassword.Text;
                            MessageBox.Show("Welcome, " + txtUsername.Text + " !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            (new ClientForm(sessionId)).ShowDialog();
                            txtUsername.ForeColor = Color.LightGray;
                            txtPassword.ForeColor = Color.LightGray;
                            txtUsername.BackColor = Color.FromArgb(255, 255, 192);
                            txtPassword.BackColor = Color.FromArgb(255, 255, 192);
                            Properties.Settings.Default.Save();
                        }
                        else
                        {
                            MessageBox.Show("Welcome, " + txtUsername.Text + " !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            (new ClientFormRazer(sessionId)).ShowDialog();
                            Properties.Settings.Default.Username = txtUsername.Text;
                            Properties.Settings.Default.Password = txtPassword.Text;
                            txtUsername.Text = "Username";
                            txtUsername.ForeColor = Color.LightGray;
                            txtPassword.Text = "Password";
                            txtPassword.ForeColor = Color.LightGray;
                            txtPassword.UseSystemPasswordChar = false;
                            txtUsername.BackColor = Color.White;
                            txtPassword.BackColor = Color.White;
                            Properties.Settings.Default.Reset();
                        }
                    }
                }
                else
                {
                    attempts--;
                    MessageBox.Show("Your Username or Password is Incorrect." + Environment.NewLine + "You have " + attempts + " attempt(s) left!", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsername.Text = String.Empty;
                    txtPassword.Text = String.Empty;
                    label10.Visible = true;
                    label9.Visible = true;
                    txtUsername.Text = "Username";
                    txtUsername.ForeColor = Color.LightGray;
                    txtUsername.BackColor = Color.FromArgb(255, 128, 128);
                    txtPassword.Text = "Password";
                    txtPassword.ForeColor = Color.LightGray;
                    txtPassword.BackColor = Color.FromArgb(255, 128, 128);
                    txtPassword.UseSystemPasswordChar = false;

                    if (attempts == 0)
                    {
                        MessageBox.Show("Sorry, You have entered 5 incorrect attempt(s). " + Environment.NewLine + "Please try again after 30 seconds !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        label5.Text = "00:" + count.ToString();
                        timer1.Start();
                        timer1.Enabled = true;
                        btnLogin.Enabled = false;
                        label5.Visible = true;
                        label7.Visible = true;

                    }
                    else if (attempts == 2)
                    {
                        lklForgotPassword.Visible = true;
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = String.Empty;
                txtUsername.ForeColor = Color.LightGray;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "Username";
                txtUsername.ForeColor = Color.LightGray;
            }
            label10.Visible = false;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            txtUsername.BackColor = Color.White;
            txtUsername.ForeColor = Color.Black;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = String.Empty;
                txtPassword.ForeColor = Color.LightGray;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.LightGray;
                txtPassword.UseSystemPasswordChar = false;
            }
            label9.Visible = false;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.BackColor = Color.White;
            txtPassword.ForeColor = Color.Black;
        }

        private void tmDateTime_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            dt3 = DateTime.Now.ToLongTimeString();
            tmDateTime.Start();
        }

        private void lklForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            (new ForgotPasswordFormRazer()).ShowDialog();
        }

        private void lklSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            (new RegisterFormRazer()).ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count--;
            label5.Text = "00:" + count.ToString();
            if (count == 0)
            {
                timer1.Stop();
                label5.Text = "";
                label5.Location = new Point(184, 293);
                btnLogin.Enabled = true;
                label5.Visible = true;
                label7.Visible = false;
                attempts = 5;
                count = 30;
            }
            else if (count <= 9)
            {
                label5.Text = "00:0" + count.ToString();
            }
            else
            {

            }
        }
        int check = 0;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (check == 0)
            {
                for (int i = 10; i <= 709; i += 5)
                {
                    panel4.Size = new Size(409, i);
                    Thread.Sleep(2);
                    panel4.Visible = true;
                }
                check = 1;

            }

            else if (check == 1)
            {
                for (int i = 709; i >= 10; i -= 100)
                {
                    panel4.Size = new Size(409, i);
                    Thread.Sleep(2);
                    panel4.Visible = false;
                }

                check = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadingFormDark Dark = new LoadingFormDark();
            Dark.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadingFormRazer Razer = new LoadingFormRazer();
            Razer.Show();
            this.Close();
        }









    }
}
