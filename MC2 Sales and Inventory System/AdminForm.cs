using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace MC2_Sales_and_Inventory_System
{
    public partial class AdminForm : Form
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        int i = 0;

        public AdminForm()
        {
            InitializeComponent();
        }

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }
        }

        private class MyColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return Color.LightBlue; }
            }
            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.Silver; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.LightBlue; }
            }
        }
        
        private void AdminForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
            menuStrip1.Renderer = new MyRenderer();
            btnRefresh_Click(null, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridView1.RowTemplate.Height = 100;
            SqlDataAdapter SDA = new SqlDataAdapter("Select * from AdminTable ORDER BY IndexNumber ASC", Program.Connection);
            DataTable data = new DataTable();
            SDA.Fill(data);
            dataGridView1.DataSource = data;
            for (int i = 0; i < dataGridView1.Columns.Count; i++) 
            {
                if (dataGridView1.Columns[i] is DataGridViewImageColumn)
                {

                    ((DataGridViewImageColumn)dataGridView1.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Stretch;
                }
            }

            txtItem.Text = String.Empty;
            txtDescription.Text = String.Empty;
            txtQuantity.Text = String.Empty;
            txtPrice.Text = String.Empty; 
            txtIndexNumber.Text = String.Empty;
            txtName2.Text = String.Empty;
            txtDescription1.Text = String.Empty;
            txtQuantity1.Text = String.Empty;
            txtPrice1.Text = String.Empty;
            txtSearch.Text = String.Empty;
            txtDelete.Text = String.Empty;
            pictureBox1.Image = null;
            pictureBox2.Image = null;


        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
           
            opb1.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            DialogResult res = opb1.ShowDialog();
            if (res == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opb1.FileName);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            double quantity = 0;
            double price = 0;
            
            

            if (txtItem.Text == "" || txtDescription.Text == "" || pictureBox1.Image == null)
            {
                MessageBox.Show("Fill all the necessary Information Needed!", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                quantity = double.Parse(txtQuantity.Text);
            }
            catch { }

            try
            {
                price = double.Parse(txtPrice.Text);
            }
            catch { }

            if (txtQuantity.Text == "")
            {
                MessageBox.Show("Input quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (quantity <= 0)
            {
                MessageBox.Show("Invalid input to Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            if (txtPrice.Text == "")
            {
                MessageBox.Show("Input price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (price <= 0)
            {
                MessageBox.Show("Invalid input to Price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtItem.Text == "" || txtDescription.Text == "" || quantity <= 0 || price <= 0)
            {
                return;
            }

            try
            {
                bool isExists = false;
                SqlDataAdapter SDACheckExist = new SqlDataAdapter("SELECT COUNT(*) FROM AdminTable WHERE ItemName='" + txtItem.Text + "'", Program.Connection);
                isExists = Convert.ToInt32(SDACheckExist.SelectCommand.ExecuteScalar().ToString()) > 0;

                if (isExists)
                {
                    MessageBox.Show("Item Already Exists!", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pictureBox1.Image = null;
                    txtItem.Text = String.Empty;
                    txtQuantity.Text = String.Empty;
                    txtDescription.Text = String.Empty;
                    txtPrice.Text = String.Empty;
                    return;
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to Add this Item?", "Notice !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO AdminTable(ItemImage,ItemName,Description,Quantity,Price)VALUES (@ItemImage,'" + txtItem.Text + "','" + txtDescription.Text + "','" + txtQuantity.Text + "','" + txtPrice.Text + "')", Program.Connection);
                        MemoryStream stream = new MemoryStream();
                        pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] pic = stream.ToArray();
                        cmd.Parameters.AddWithValue("@ItemImage", pic);
                        i = cmd.ExecuteNonQuery();

                        if (i > 0)
                        {
                            MessageBox.Show("Items Added Successfully !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("Invalid Input!", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Text = String.Empty;
                txtPrice.Text = String.Empty;
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Fill all the necessary Information Needed!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception a)
            {
                MessageBox.Show("  " + a);
            }

            btnRefresh_Click(null, null);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            opb1.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            DialogResult res = opb1.ShowDialog();
            if (res == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(opb1.FileName);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            double quantity = 0;
            double price = 0;

            if (txtName2.Text == "" || txtDescription1.Text == "")
            {
                MessageBox.Show("Fill all the necessary Information Needed!", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                quantity = double.Parse(txtQuantity1.Text);
            }
            catch { }

            try
            {
                price = double.Parse(txtPrice1.Text);
            }
            catch { }

            if (txtQuantity1.Text == "")
            {
                MessageBox.Show("Input quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (quantity <= 0)
            {
                MessageBox.Show("Invalid input in quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (txtPrice1.Text == "")
            {
                MessageBox.Show("Input price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (price <= 0)
            {
                MessageBox.Show("Invalid input in price", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (txtName2.Text == "" || txtDescription1.Text == "" || quantity <= 0 || price <= 0)
            {
                return;
            }

            try
            {
                double currentQuantity;
                SqlCommand selectCommand = new SqlCommand("SELECT * FROM AdminTable WHERE IndexNumber = '" + txtIndexNumber.Text + "'", Program.Connection);

                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("Items Not Found!", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    reader.Read();
                    currentQuantity = double.Parse(reader[4].ToString());
                }

                if (txtDescription1.Text == "" ||  txtPrice1.Text == "")
                {
                    MessageBox.Show("Fill all the necessary Information Needed!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (MessageBox.Show("Do you want to Update this Item?", "Notice !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (rdoAdd.Checked)
                        {
                            currentQuantity += quantity;
                        }

                        if (rdoSubtract.Checked)
                        {
                            currentQuantity -= quantity;
                        }

                        if (rdoEqual.Checked)
                        {
                            currentQuantity = quantity;
                        }

                        if (currentQuantity < 0)
                        {
                            currentQuantity = 0;
                        }

                        SqlCommand cmd = new SqlCommand("UPDATE AdminTable SET ItemImage = @ItemImage, ItemName='" + txtName2.Text + "',Description='" + txtDescription1.Text + "', Quantity = " + currentQuantity + ", Price='" + txtPrice1.Text + "' WHERE IndexNumber='" + txtIndexNumber.Text + "'", Program.Connection);
                        MemoryStream stream = new MemoryStream();
                            
                        pictureBox2.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] pic = stream.ToArray();
                        cmd.Parameters.AddWithValue("@ItemImage", pic);
                        i = cmd.ExecuteNonQuery();

                        if (i > 0)
                        {
                            MessageBox.Show("Items Updated Succesfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException a)
            {
                MessageBox.Show("Invalid Input !"+ a, "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity1.Text = String.Empty;
                txtPrice1.Text = String.Empty;
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show("Insert Image!", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception a)
            {
                MessageBox.Show("  " + a);
            }

            btnRefresh_Click(null, null);
            rdoEqual.Checked = true;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                MessageBox.Show("Enter search query", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM AdminTable Where ItemName LIKE '%" + txtSearch.Text + "%'", Program.Connection);
            DataTable data = new DataTable();
            SDA.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                bool isExists = false;
                SqlDataAdapter SDACheckExist = new SqlDataAdapter("SELECT COUNT(*) FROM AdminTable WHERE IndexNumber='" + txtDelete.Text + "'", Program.Connection);
                isExists = Convert.ToInt32(SDACheckExist.SelectCommand.ExecuteScalar().ToString()) > 0;

                if (txtDelete.Text == "")
                {
                    MessageBox.Show("Enter Index Number!", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!isExists)
                {
                    MessageBox.Show("Index Number Not Found!", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtDelete.Text = String.Empty;
                }
                else
                {
                    if (MessageBox.Show("Do you want to Delete this Item?", "Notice !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SqlDataAdapter SDA = new SqlDataAdapter("DELETE FROM AdminTable WHERE IndexNumber= '" + txtDelete.Text + "'", Program.Connection);
                        SDA.SelectCommand.ExecuteNonQuery();
                        MessageBox.Show("Item(s) Deleted Succesfully!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDelete.Text = String.Empty;
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                MessageBox.Show("Invalid Input !", "Notice!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDelete.Text = String.Empty;
            }
            catch (Exception a)
            {
                MessageBox.Show("  " + a);
            }

            btnRefresh_Click(null, null);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit the System?", "Notice !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            timer1.Start();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new AboutForm()).ShowDialog();
        }

        private void viewLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new HistoryLoginForm()).ShowDialog();
        }

        private void viewRegistersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new HistoryClientListForm()).ShowDialog();
        }

        private void viewPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new HistoryPurchaseForm()).ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.tabControl.SelectedTab == tabPage3)
            {
                txtDelete.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                return;
            }

            txtIndexNumber.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtName2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtDescription1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtQuantity1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtPrice1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            
            this.tabControl.SelectedTab = tabPage2;

            SqlCommand cmd2 = new SqlCommand("SELECT ItemImage FROM AdminTable WHERE IndexNumber = " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "", Program.Connection);
            da.SelectCommand = cmd2;
            DataSet ds = new DataSet();
            byte[] mydata = new byte[0];
            da.Fill(ds, "AdminTable");
            DataRow myrow;
            myrow = ds.Tables["AdminTable"].Rows[0];
            mydata = (byte[])myrow["ItemImage"];
            MemoryStream stream = new MemoryStream(mydata);
            pictureBox2.Image = Image.FromStream(stream);
            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Firebrick;
            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private int check = 0;

        private void label10_Click(object sender, EventArgs e)
        {
            if (check == 0)
            {
                for (int i = 10; i <= 164; i+=5)
                {
                    panel2.Size = new Size(390, i);
                    Thread.Sleep(2);
                    panel2.Visible = true;
                }
                check = 1;
                label10.Text = "Welcome, Admin ! ⏶";

            }

            else if (check == 1)
            {
                for (int i = 164; i >= 10; i-=50)
                {
                    panel2.Size = new Size(390, i);
                    Thread.Sleep(2);
                    
                }
                panel2.Visible = false;
                check = 0;
                label10.Text = "Welcome, Admin ! ⏷";


            }
        }

        private void txtName2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
