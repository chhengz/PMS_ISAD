using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMS_ISAD
{
    public partial class frmCustomers: Form
    {

        A6PMS d = new A6PMS();
        SqlCommand com;

        string store_cusID = ""; // used to store customer ID for update and delete

        public frmCustomers()
        {
            d.Connection();
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                dgv.DataSource = null;
                com = new SqlCommand("spGetAllCustomer", d.con);
                com.CommandType = CommandType.StoredProcedure;

                SqlDependency dep = new SqlDependency(com);
                dep.OnChange += new OnChangeEventHandler(OnChange);

                SqlDataAdapter dap = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                dap.Fill(dt);

                dgv.DataSource = dt;

                dgv.DefaultCellStyle.Font = new Font("Khmer OS System", 12);
                //dgv.Columns["cusID"].Width = 60;
                dgv.Columns["CusName"].Width = 200;
                dgv.Columns["CusContact"].Width = 200;

                // Set the DataGridView to fill all columns proportionally
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // define row hight
                //dgv.RowTemplate.Height = 50;


                // define image size in DataGridView
                //DataGridViewImageColumn img = new DataGridViewImageColumn();
                //img = (DataGridViewImageColumn)dgv.Columns["Photo"];
                //img.ImageLayout = DataGridViewImageCellLayout.Stretch;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }


        public void OnChange(object caller, SqlNotificationEventArgs e)
        {
            if (this.InvokeRequired)
            {
                dgv.BeginInvoke(new MethodInvoker(LoadData));
            }
            else
            {
                LoadData();
            }
        }


        private void CustomerForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'a6Y32025DataSet1.tbCustomers' table. You can move, or remove it, as needed.
            //this.tbCustomersTableAdapter.Fill(this.a6Y32025DataSet1.tbCustomers);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult re = DialogResult.Yes;
            re = MessageBox.Show("Are you sure you want to exit?", "Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (re == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                //var salary = Decimal.Parse(txtSalary.Text, NumberStyles.Currency);
                com = new SqlCommand("spInsertCustomer", d.con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@cn", txtName.Text);
                com.Parameters.AddWithValue("@cc", txtContact.Text);

                com.ExecuteNonQuery();

            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // clear all textboxes
                txtName.Text = "";
                txtContact.Text = "";
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                com = new SqlCommand("spUpdateCustomer", d.con);
                com.CommandType = CommandType.StoredProcedure;

                // convert store_cusID to int

                com.Parameters.AddWithValue("@id", int.Parse(store_cusID));
                com.Parameters.AddWithValue("@cn", txtName.Text);
                com.Parameters.AddWithValue("@cc", txtContact.Text);

                // Check if store_cusID is empty
                if (string.IsNullOrEmpty(store_cusID))
                {
                    MessageBox.Show("Please select a customer to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Check if textboxes are empty
                if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrWhiteSpace(txtContact.Text))
                {
                    MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if the contact number is valid
                //if (!System.Text.RegularExpressions.Regex.IsMatch(txtContact.Text, @"^\d{10}$"))
                //{
                //    MessageBox.Show("Please enter a valid 10-digit contact number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}

                com.ExecuteNonQuery(); // run stored procedure

            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //if (store_cusID == "")
                //{
                //    MessageBox.Show("Please select a customer to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                //com = new SqlCommand("spUpdateCustomer", d.con);
                //com.CommandType = CommandType.StoredProcedure;

                //com.Parameters.AddWithValue("@id", store_cusID);
                //com.Parameters.AddWithValue("@cn", txtName.Text);
                //com.Parameters.AddWithValue("@cc", txtContact.Text);
                //com.ExecuteNonQuery();


                // clear all textboxes
                txtName.Text = "";
                txtContact.Text = "";
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                com = new SqlCommand("spDeleteCustomer", d.con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@id", store_cusID);

                com.ExecuteNonQuery();

            }
            catch
            {
                MessageBox.Show("Error: " + "Please select a staff to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                (dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("CusName LIKE '%{0}%' OR CusContact LIKE '%{0}%'", txtSearch.Text.Trim());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int i = e.RowIndex;
            if (i < 0) return; // Header clicked

            DataGridViewRow row = dgv.Rows[i];

            // Check if the entire row is empty/null
            bool isRowEmpty = true;
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Value != null && cell.Value != DBNull.Value && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                {
                    isRowEmpty = false;
                    break;
                }
            }

            if (isRowEmpty)
            {
                MessageBox.Show("This row is empty.");
                return;
            }

            store_cusID = row.Cells[0].Value?.ToString() ?? "";
            txtName.Text = row.Cells[1].Value?.ToString() ?? "";
            txtContact.Text = row.Cells[2].Value?.ToString() ?? "";

        }

        private void clean_Click(object sender, EventArgs e)
        {
            // clear all textboxes
            txtName.Text = "";
            txtContact.Text = "";
            store_cusID = ""; // reset the stored customer ID
            dgv.ClearSelection(); // clear the selection in DataGridView
            dgv.CurrentCell = null; // remove the current cell selection

            // focus on textbox Name
            txtName.Focus();
        }
    }
}
