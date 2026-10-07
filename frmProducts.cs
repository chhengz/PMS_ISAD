using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PMS_ISAD
{
    public partial class frmProducts : Form
    {
        A6PMS d = new A6PMS();
        SqlCommand com;

        int row_selected = -1; // used to store the selected row index

        public frmProducts()
        {
            d.Connection();
            InitializeComponent();
            LoadData();
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            // --
        }
        public void LoadData()
        {
            try
            {
                dgv.DataSource = null;
                com = new SqlCommand("spGetAllProduct", d.con);
                com.CommandType = CommandType.StoredProcedure;

                SqlDependency dep = new SqlDependency(com);
                dep.OnChange += new OnChangeEventHandler(OnChange);

                SqlDataAdapter dap = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                dap.Fill(dt);

                dgv.DataSource = dt;

                dgv.DefaultCellStyle.Font = new Font("Khmer OS System", 12);
                dgv.Columns["ProCode"].Width = 50;
                dgv.Columns["ProName"].Width = 200;
                dgv.Columns["Qty"].Width = 100;
                dgv.Columns["UPIS"].Width = 100;
                dgv.Columns["SUP"].Width = 100;

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

        // This method is called when the SQL dependency changes
        //private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    row_selected = e.RowIndex;
        //}


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
                (dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("ProName LIKE '%{0}%' OR CONVERT(ProCode, 'System.String') LIKE '%{0}%'", txtSearch.Text.Trim());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void clean_Click(object sender, EventArgs e)
        {
            txtProID.Clear();
            txtPName.Clear();
            txtQty.Clear();
            txtPrice.Clear();
            txtSalePrice.Clear();
            dgv.ClearSelection(); // clear the selection in DataGridView
            dgv.CurrentCell = null; // remove the current cell selection

            //lsv.Clear(); // clear the ListView

            txtProID.Enabled = true;
            txtProID.Focus();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAddNew_Click_1(object sender, EventArgs e)
        {
            try
            {
                com = new SqlCommand("spInsertProduct", d.con);
                com.CommandType = CommandType.StoredProcedure;
                // @pcode, @pn, @q, @p, @sp

                com.Parameters.AddWithValue("@pcode", txtProID.Text);
                com.Parameters.AddWithValue("@pn", txtPName.Text);
                com.Parameters.AddWithValue("@q", txtQty.Text);
                com.Parameters.AddWithValue("@p", txtPrice.Text);
                com.Parameters.AddWithValue("@sp", txtSalePrice.Text);

                com.ExecuteNonQuery(); // run stored procedure


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // clear all textboxes
                txtProID.Text = "";
                txtPName.Text = "";
                txtQty.Text = "";
                txtPrice.Text = "";
                txtSalePrice.Text = "";

                txtProID.Focus(); // set focus to ProID textbox
                LoadData(); // reload the data after adding a new product
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {

                if (row_selected < 0) // no row selected
                {
                    MessageBox.Show("Please select a product to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                com = new SqlCommand("spUpdateProduct", d.con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@pc", txtProID.Text);
                com.Parameters.AddWithValue("@pn", txtPName.Text);
                com.Parameters.AddWithValue("@q", txtQty.Text);
                com.Parameters.AddWithValue("@p", txtPrice.Text);
                com.Parameters.AddWithValue("@s", txtSalePrice.Text);
                com.ExecuteNonQuery(); // run stored procedure


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // clear all textboxes
                txtProID.Enabled = true; // re-enable ProID textbox for further editing
                txtProID.Text = "";
                txtPName.Text = "";
                txtQty.Text = "";
                txtPrice.Text = "";
                txtSalePrice.Text = "";
                txtProID.Focus(); // set focus to ProID textbox
                LoadData(); // reload the data after editing a product

            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                com = new SqlCommand("spDeleteProduct", d.con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@pc", txtProID.Text);

                com.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //catch
            //{
            //    MessageBox.Show("Error: " + "Please select a Product to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            finally
            {
                // clear all textboxes
                //txtProID.Text = "";
                //txtPName.Text = "";
                //txtQty.Text = "";
                //txtPrice.Text = "";
                //txtSalePrice.Text = "";
                txtProID.Focus(); // set focus to ProID textbox
                LoadData(); // reload the data after editing a product
            }


        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            row_selected = e.RowIndex;
            try
            {

                if (row_selected < 0) return; // Header clicked

                DataGridViewRow row = dgv.Rows[row_selected];
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

                txtProID.Enabled = false; // disable ProID textbox for editing
                txtProID.Text = row.Cells[0].Value?.ToString() ?? "";
                txtPName.Text = row.Cells[1].Value?.ToString() ?? "";
                txtQty.Text = row.Cells[2].Value?.ToString() ?? "";
                txtPrice.Text = row.Cells[3].Value?.ToString() ?? "";
                txtSalePrice.Text = row.Cells[4].Value?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}