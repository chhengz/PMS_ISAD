


using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PMS_ISAD
{
    public partial class frmSuppliers : Form
    {
        private readonly A6PMS d = new A6PMS();
        private string store_supID = "";
        private BindingSource bindingSource = new BindingSource();
        private DateTime lastUpdate = DateTime.MinValue;
        private readonly TimeSpan debounceInterval = TimeSpan.FromSeconds(1);

        public frmSuppliers()
        {
            d.Connection();
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            try
            {
                dgvSup.DataSource = null;
                using (var com = new SqlCommand("spGetAllSupplier", d.con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    var dep = new SqlDependency(com);
                    dep.OnChange += OnChange;

                    using (var dap = new SqlDataAdapter(com))
                    {
                        DataTable dt = new DataTable();
                        dap.Fill(dt);
                        bindingSource.DataSource = dt;
                        dgvSup.DataSource = bindingSource;
                        dgvSup.DefaultCellStyle.Font = new Font("Khmer OS System", 12);
                        dgvSup.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnChange(object caller, SqlNotificationEventArgs e)
        {
            if (DateTime.Now - lastUpdate < debounceInterval)
                return;

            lastUpdate = DateTime.Now;
            if (InvokeRequired)
                BeginInvoke(new MethodInvoker(LoadData));
            else
                LoadData();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                if (d.con.State != ConnectionState.Open) d.con.Open();
                using (var com = new SqlCommand("spInsertSupplier", d.con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@sn", txtName.Text);
                    com.Parameters.AddWithValue("@sd", txtAddress.Text);
                    com.Parameters.AddWithValue("@sc", txtContact.Text);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Supplier added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                d.con.Close();
                ClearInputs();
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(store_supID) || !int.TryParse(store_supID, out int id))
            {
                MessageBox.Show("Please select a valid Supplier to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ValidateInputs()) return;

            try
            {
                if (d.con.State != ConnectionState.Open) d.con.Open();
                using (var com = new SqlCommand("spUpdateSupplier", d.con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@id", id);
                    com.Parameters.AddWithValue("@sn", txtName.Text);
                    com.Parameters.AddWithValue("@sd", txtAddress.Text);
                    com.Parameters.AddWithValue("@sc", txtContact.Text);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Supplier updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                d.con.Close();
                ClearInputs();
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(store_supID) || !int.TryParse(store_supID, out int id))
            {
                MessageBox.Show("Please select a valid Supplier to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (d.con.State != ConnectionState.Open) d.con.Open();
                using (var com = new SqlCommand("spDeleteSupplier", d.con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@id", id);
                    com.ExecuteNonQuery();
                    MessageBox.Show("Supplier deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                d.con.Close();
                ClearInputs();
                LoadData();
            }
        }

        private void clean_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("Are you sure you want to exit?", "Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (re == DialogResult.Yes)
                Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                bindingSource.Filter = $"Supplier LIKE '%{txtSearch.Text.Trim()}%' OR SupCon LIKE '%{txtSearch.Text.Trim()}%'";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Header clicked

            DataGridViewRow row = dgvSup.Rows[e.RowIndex];
            if (row.Cells[0].Value == null || row.Cells[0].Value == DBNull.Value)
            {
                MessageBox.Show("This row is empty.");
                return;
            }

            store_supID = row.Cells[0].Value?.ToString() ?? "";
            txtName.Text = row.Cells[1].Value?.ToString() ?? "";
            txtAddress.Text = row.Cells[2].Value?.ToString() ?? "";
            txtContact.Text = row.Cells[3].Value?.ToString() ?? "";
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtAddress.Text) || string.IsNullOrWhiteSpace(txtContact.Text))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void ClearInputs()
        {
            store_supID = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
            dgvSup.ClearSelection();
            dgvSup.CurrentCell = null;
            txtName.Focus();
        }
    }
}




/**
 * 


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PMS_ISAD
{
    public partial class frmSuppliers: Form
    {

        A6PMS d = new A6PMS();
        //SqlDependency dep;
        SqlDataAdapter dap;
        SqlCommand com;

        string store_supID = "";

        public frmSuppliers()
        {
            d.Connection();
            InitializeComponent();
            LoadData();
        }


        public void LoadData()
        {
            try
            {
                dgvSup.DataSource = null;
                com = new SqlCommand("spGetAllSupplier", d.con);
                com.CommandType = CommandType.StoredProcedure;

                SqlDependency dep = new SqlDependency(com);
                dep.OnChange += new OnChangeEventHandler(OnChange);

                dap = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                dap.Fill(dt);

                dgvSup.DataSource = dt;
                dgvSup.DefaultCellStyle.Font = new Font("Khmer OS System", 12);
                dgvSup.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void OnChange(Object caller, SqlNotificationEventArgs e)
        {
            if (this.InvokeRequired)
            {
                dgvSup.BeginInvoke(new MethodInvoker(LoadData));
            }
            else
            {
                LoadData();
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                
                com = new SqlCommand("spInsertSupplier", d.con);
                com.CommandType = CommandType.StoredProcedure;
                //@sn, @sd, @sc

                com.Parameters.AddWithValue("@sn", txtName.Text);
                com.Parameters.AddWithValue("@sd", txtAddress.Text);
                com.Parameters.AddWithValue("@sc", txtContact.Text);

                com.ExecuteNonQuery();

                // Show success message
                MessageBox.Show("Supplier added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Refresh the DataGridView to show new data
                dgvSup.Refresh(); 
                // clear all textboxes
                txtName.Text = "";
                txtAddress.Text = "";
                txtContact.Text = "";
                //LoadData(); // Reload the data in DataGridView
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (store_supID != "")
                {
                    com = new SqlCommand("spUpdateSupplier", d.con);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@id", int.Parse(store_supID));
                    com.Parameters.AddWithValue("@sn", txtName.Text);
                    com.Parameters.AddWithValue("@sd", txtAddress.Text);
                    com.Parameters.AddWithValue("@sc", txtContact.Text);
                    com.ExecuteNonQuery();
                    // Show success message
                    MessageBox.Show("Supplier updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select a Supplier to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // clear all textboxes
                dgvSup.Refresh(); // Refresh the DataGridView to show updated data
                txtName.Text = "";
                txtAddress.Text = "";
                txtContact.Text = "";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                com = new SqlCommand("spDeleteSupplier", d.con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@id", int.Parse(store_supID));

                com.ExecuteNonQuery();

                // Show success message
                MessageBox.Show("Supplier deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                dgvSup.Refresh(); // Refresh the DataGridView to show updated data
            }
            catch
            {
                MessageBox.Show("Error: " + "Please select a Supplier to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clean_Click(object sender, EventArgs e)
        {
            store_supID = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtContact.Text = "";
            dgvSup.ClearSelection(); // clear the selection in DataGridView
            dgvSup.CurrentCell = null; // remove the current cell selection
            txtName.Focus();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                (dgvSup.DataSource as DataTable).DefaultView.RowFilter = string.Format("Supplier LIKE '%{0}%' OR SupCon LIKE '%{0}%'", txtSearch.Text.Trim());

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

            DataGridViewRow row = dgvSup.Rows[i];

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

            store_supID = row.Cells[0].Value?.ToString() ?? "";
            txtName.Text = row.Cells[1].Value?.ToString() ?? "";
            txtAddress.Text = row.Cells[2].Value?.ToString() ?? "";
            txtContact.Text = row.Cells[3].Value?.ToString() ?? "";

        }
    }
}

*/