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
    public partial class ClientFormRazer : Form
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();

        public string CurrentUser = LoginForm.UserInformation.CurrentLoggedInUser;

        private string sessionId;

        public ClientFormRazer(string sessionId)
        {
            InitializeComponent();

            this.sessionId = sessionId;
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
        Dictionary<int, int> orders = new Dictionary<int, int>();

        private void ClientFormRazer_Load(object sender, EventArgs e)
        {
            lblClient.Text = CurrentUser;
            label8.Text = "Welcome, " + CurrentUser + " ! ⏷";
            tmTimeDate.Start();
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
            menuStrip1.Renderer = new MyRenderer();
            btnShow_Click(null, null);
        }

        private void btnShow_Click(object sender, EventArgs e)
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
            txtCash.Text = "";
            txtChange.Text = "";
            //txtNoItems.Text = "";
            txtQuantity.Text = "";
            //txtTotalPrice.Text = "";
            pictureBox1.Image = null;
        }

        private void btnAddtoCart_Click(object sender, EventArgs e)
        {
            int quantity, quantityLeft;
            int currentQuantity = 0;
            int currentNumberOfItems = 0;
            int indexNumber;

            double total, price;
            double currentTotalPrice = 0.0;

            string itemName;

            try
            {
                indexNumber = Convert.ToInt32(txtIndex.Text);
            }
            catch
            {
                MessageBox.Show("Invalid Index Number Input!", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (txtQuantity.Text == string.Empty)
                {
                    throw new Exception();
                }

                quantity = int.Parse(txtQuantity.Text);
            }
            catch
            {
                MessageBox.Show("Invalid Quantity!", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (quantity < 1)
            {
                MessageBox.Show("Quantity should be at least 1!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SqlCommand countQuery = new SqlCommand("SELECT COUNT(*) FROM AdminTable WHERE IndexNumber = " + indexNumber, Program.Connection);
            object countResult = countQuery.ExecuteScalar();

            if (countResult != null && (int)countResult == 0)
            {
                MessageBox.Show("Items not in the List!", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlCommand query = new SqlCommand("SELECT * FROM AdminTable WHERE IndexNumber=" + indexNumber, Program.Connection);

            using (SqlDataReader reader = query.ExecuteReader())
            {
                reader.Read();

                itemName = reader.GetString(reader.GetOrdinal("ItemName"));
                quantityLeft = reader.GetInt32(reader.GetOrdinal("Quantity"));
                price = reader.GetDouble(reader.GetOrdinal("Price"));
            }

            if (orders.ContainsKey(indexNumber))
            {
                orders.TryGetValue(indexNumber, out currentQuantity);
            }

            if (quantity > quantityLeft - currentQuantity)
            {
                MessageBox.Show("Items Shortage!", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            total = price * quantity;

            gridItemsPurchased.Rows.Add(itemName, quantity.ToString(), price.ToString(), total.ToString());
            ListViewItem listitem = new ListViewItem(itemName);
            listitem.SubItems.Add(quantity.ToString());
            listitem.SubItems.Add(price.ToString());
            listitem.SubItems.Add(total.ToString());
            listView1.Items.Add(listitem);

            MessageBox.Show("Item added to cart !", "Okay", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (orders.ContainsKey(indexNumber))
            {
                orders.Remove(indexNumber);
            }

            orders.Add(indexNumber, currentQuantity + quantity);

            try
            {
                currentTotalPrice = double.Parse(txtTotalPrice.Text);
                currentNumberOfItems = int.Parse(txtNoItems.Text);
            }
            catch { }

            txtTotalPrice.Text = (currentTotalPrice + total).ToString();
            txtNoItems.Text = (currentNumberOfItems + quantity).ToString();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (orders.Count == 0)
            {
                MessageBox.Show("Shopping Cart empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double totalPrice = 0;
            double cash = 0;

            try
            {
                totalPrice = double.Parse(txtTotalPrice.Text);

            }
            catch { }

            InputCashDialogRazer enterCash = new InputCashDialogRazer(totalPrice);

            enterCash.OnCashEntered += cashEvent =>
            {
                cash = cashEvent.Value;

                txtCash.Text = cashEvent.Value.ToString();
                txtChange.Text = (cash - totalPrice).ToString();

                foreach (KeyValuePair<int, int> order in orders)
                {
                    new SqlCommand(string.Format("UPDATE AdminTable SET Quantity = Quantity - {0} WHERE IndexNumber = {1}", order.Value, order.Key), Program.Connection).ExecuteNonQuery();
                }

                MessageBox.Show("Purchase Complete!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // MessageBox.Show("-----------------------------------------------------------------"+ Environment.NewLine +"You order "+ orders.Count.ToString()+ "kinds of items"); 
                orders.Clear();
                gridItemsPurchased.Rows.Clear();
                listView1.Clear();

                txtCash.Text = "";
                txtChange.Text = "";
                txtNoItems.Text = "";
                txtQuantity.Text = "";
                txtTotalPrice.Text = "";
                pictureBox1.Image = null;
                txtIndex.Clear();
                btnShow_Click(null, null);

            };

            enterCash.ShowDialog();
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            orders.Clear();
            gridItemsPurchased.Rows.Clear();

            txtCash.Text = "";
            txtChange.Text = "";
            txtNoItems.Text = "";
            txtQuantity.Text = "";
            txtTotalPrice.Text = "";
            pictureBox1.Image = null;
            listView1.Items.Clear();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            tmTimeDate.Start();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Exit the System?", "Notice !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (this.sessionId != null)
                {
                    SqlDataAdapter SDA = new SqlDataAdapter("UPDATE HistoryLogin SET Time_LoggedOut='" + Convert.ToString(lblTime.Text) + "'WHERE SessionId='" + this.sessionId + "'", Program.Connection);
                    SDA.SelectCommand.ExecuteNonQuery();
                }

                this.Dispose();
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new AboutForm()).ShowDialog();
        }
        private int check = 0;
        private void label8_Click(object sender, EventArgs e)
        {
            if (check == 0)
            {
                for (int i = 10; i <= 164; i++)
                {
                    panel2.Size = new Size(390, i);
                    Thread.Sleep(2);
                    panel2.Visible = true;
                }
                check = 1;
                label8.Text = "Welcome, " + CurrentUser + " ! ⏶";

            }

            else if (check == 1)
            {
                for (int i = 164; i >= 10; i--)
                {
                    panel2.Size = new Size(390, i);
                    Thread.Sleep(2);
                    panel2.Visible = false;
                }
                check = 0;
                label8.Text = "Welcome, " + CurrentUser + " ! ⏷";
            }
        }
        int index = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SqlCommand cmd2 = new SqlCommand("SELECT ItemImage FROM AdminTable WHERE IndexNumber = " + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "", Program.Connection);
                da.SelectCommand = cmd2;
                DataSet ds = new DataSet();
                byte[] mydata = new byte[0];
                da.Fill(ds, "AdminTable");
                DataRow myrow;
                myrow = ds.Tables["AdminTable"].Rows[0];
                mydata = (byte[])myrow["ItemImage"];
                MemoryStream stream = new MemoryStream(mydata);
                pictureBox1.Image = Image.FromStream(stream);

            }
            catch (Exception)
            {
                pictureBox1.Image = null;

            }
            try
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Firebrick;
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.White;
            }
            catch (Exception) { }
            try
            {
                SqlCommand query = new SqlCommand("SELECT * FROM AdminTable WHERE IndexNumber=" + dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + "", Program.Connection);

                using (SqlDataReader reader = query.ExecuteReader())
                {
                    reader.Read();

                    index = reader.GetInt32(reader.GetOrdinal("IndexNumber"));
                }
                txtIndex.Text = index.ToString();
            }
            catch (Exception)
            {
                txtIndex.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlCart.Visible = true;
            pnlCart.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pnlCart.Hide();
        }

        private void pnlCart_Paint(object sender, PaintEventArgs e)
        {

        }




    }
}
