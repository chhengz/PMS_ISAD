using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMS_ISAD
{
    public partial class frmStaffs: Form
    {
        A6PMS p = new A6PMS();
        SqlCommand com;
        SqlDataAdapter dap;
        DataTable dt;
        byte[] photo;
        String fp;
        string store_salary = "";
        string display_salary = "";
        string store_staffID = "";

        public frmStaffs()
        {
            p.Connection();
            InitializeComponent();
            LoadData();
        }

        private void StaffForm_Load(object sender, EventArgs e)
        {
            //txtID.Text = "";
            //txtName.Text = "";
            //txtPosition.Text = "";
            //txtSalary.Text = "";
        }

        public void LoadData()
        {
            try
            {
                dgvStaff.DataSource = null;
                com = new SqlCommand("spGetAllStaff", p.con);
                com.CommandType = CommandType.StoredProcedure;

                SqlDependency dep = new SqlDependency(com);
                dep.OnChange += new OnChangeEventHandler(OnChange);

                SqlDataAdapter dap = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                dap.Fill(dt);

                dgvStaff.DataSource = dt;

                dgvStaff.DefaultCellStyle.Font = new Font("Khmer OS System", 12);
                dgvStaff.Columns["staffID"].Width = 100;
                dgvStaff.Columns["FullName"].Width = 200;

                // define row hight
                dgvStaff.RowTemplate.Height = 50;


                // define image size in DataGridView
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img = (DataGridViewImageColumn)dgvStaff.Columns["Photo"];
                img.ImageLayout = DataGridViewImageCellLayout.Stretch;

                
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
                dgvStaff.BeginInvoke(new MethodInvoker(LoadData));
            }
            else
            {
                LoadData();
            }
        }

        

        // Exit Button
        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult re = DialogResult.Yes;
            re = MessageBox.Show("Are you sure you want to exit?", "Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (re == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /*
        private void button6_Click(object sender, EventArgs e)
        {
            // browse staff picture
            //pictureBox_Staff = new PictureBox();

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox_Staff.Image = new Bitmap(open.FileName);
            }
        }
        */

        /*
         * 
        private void pictureBox_Staff_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                picStaff.Image = new Bitmap(open.FileName);
            }
        }
        */

        // add new staff
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                var salary = Decimal.Parse(txtSalary.Text, NumberStyles.Currency);
                com = new SqlCommand("spInsertStaff", p.con);
                com.CommandType = CommandType.StoredProcedure;
                //@id, @fn, @g, @db, @po, @s, @sw, @ph

                com.Parameters.AddWithValue("@id", txtID.Text);
                com.Parameters.AddWithValue("@fn", txtName.Text);

                if (rdbtnFemale.Checked == true)
                {
                    com.Parameters.AddWithValue("@g", "F");
                }
                else
                {
                    com.Parameters.AddWithValue("@g", "M");
                }
                //com.Parameters.AddWithValue("@db", dtpDOB.Value);
                com.Parameters.AddWithValue("@po", txtPosition.Text);
                com.Parameters.AddWithValue("@s", salary);
                com.Parameters.AddWithValue("@sw", 0);

                if (fp != null) photo = File.ReadAllBytes(fp);
                //else photo = null;

                com.Parameters.AddWithValue("@ph", photo);
                com.ExecuteNonQuery(); // run stored procedure
                fp = null;
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // clear all textboxes
                txtID.Text = "";
                txtName.Text = "";
                txtPosition.Text = "";
                txtSalary.Text = "";
                picStaff.Image = null;
                //picStaff.Image = Image.FromFile("default.png"); // reset to default image

                LoadData();
            }
        }

        // load image
        private void picStaff_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            open.Title = "Select Staff Image...";
            if (open.ShowDialog() == DialogResult.OK)
            {
                //picStaff.Image = new Bitmap(open.FileName);
                //fp = open.FileName;
                fp = open.FileName;
                picStaff.Image = Image.FromFile(fp);
            }
        }

        // read staff data from DataGridView
        // This method is called when a cell in the DataGridView is clicked
        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (i < 0) return; // Header clicked

            DataGridViewRow row = dgvStaff.Rows[i];

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

            // Safe to proceed
            store_staffID = row.Cells[0].Value?.ToString() ?? "";
            txtID.Text = row.Cells[0].Value?.ToString() ?? "";
            txtName.Text = row.Cells[1].Value?.ToString() ?? "";

            if (row.Cells[2].Value?.ToString() == "F")
                rdbtnFemale.Checked = true;
            else
                rdbtnMale.Checked = true;

            if (row.Cells[3].Value != DBNull.Value && row.Cells[3].Value != null)
            {
                //dtpDOB.Format = DateTimePickerFormat.Custom;
                //dtpDOB.Value = Convert.ToDateTime(row.Cells[3].Value);
            }
            else
            {
                //dtpDOB.Value = DateTime.Today;
                //dtpDOB.Format = DateTimePickerFormat.Short;
            }

            txtPosition.Text = row.Cells[4].Value?.ToString() ?? "";
            
            //store_salary = row.Cells[5].Value == DBNull.Value ? "" : string.Format("{0:C}", row.Cells[5].Value);
            
            display_salary = row.Cells[5].Value == DBNull.Value ? "" : string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:C}", row.Cells[5].Value);
            txtSalary.Text = display_salary;


            if (row.Cells[7].Value != DBNull.Value && row.Cells[7].Value != null)
            {
                photo = (byte[])row.Cells[7].Value;
                MemoryStream ms = new MemoryStream(photo);
                picStaff.Image = Image.FromStream(ms);
            }
            else
            {
                picStaff.Image = null;
            }
        }

        /* ORIGINAL CODE FOR dgvStaff_CellClick
         * 
        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int i;
            int i = e.RowIndex;
            DataGridViewRow row = dgvStaff.Rows[i];

            try
            {
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

                if (dgvStaff.RowCount > 0)
                {
                    i = e.RowIndex;
                    if (i < 0) return;
                    DataGridViewRow row = dgvStaff.Rows[i];
                    txtID.Text = row.Cells[0].Value.ToString();
                    txtName.Text = row.Cells[1].Value.ToString();
                    
                    if (row.Cells[2].Value.ToString() == "F")
                    {
                        rdbtnFemale.Checked = true;
                    }
                    else
                    {
                        rdbtnMale.Checked = true;
                    }

                    dtpDOB.Format = DateTimePickerFormat.Custom;
                    dtpDOB.Value = Convert.ToDateTime(row.Cells[3].Value);
                    txtPosition.Text = row.Cells[4].Value.ToString();
                    //txtSalary.Text = Decimal.Parse(row.Cells[5].Value.ToString()).ToString("C", CultureInfo.CurrentCulture);
                    txtSalary.Text = string.Format(CultureInfo.CurrentCulture, "{0:C}", row.Cells[5].Value);


                    photo = (byte[])row.Cells[7].Value;
                    MemoryStream ms = new MemoryStream(photo);
                    picStaff.Image = Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        */

        // edit/update staff data
        

        // preview
        private void btnPreview_Click(object sender, EventArgs e)
        {
            // preview

        }


        // Search
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                 //(dgvStaff.DataSource as DataTable).DefaultView.RowFilter = string.Format("FullName LIKE '%{0}%' OR CONVERT(staffID, 'System.String') LIKE '%{0}%'", txtSearch.Text.Trim());                 
                
                // check if not found
                //if (dgvStaff.Rows.Count < 1)
                //{
                //    //MessageBox.Show("No staff found with the given name or ID.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    MessageBox.Show("No results found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                com = new SqlCommand("spDeleteStaff", p.con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@id", txtID.Text);

                com.ExecuteNonQuery();

            }
            catch
            {
                MessageBox.Show("Error: " + "Please select a staff to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // clear all textboxes
                txtID.Text = "";
                txtName.Text = "";
                txtPosition.Text = "";
                txtSalary.Text = "";
                picStaff.Image = null;
            }
        }

        // Edit Staff
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                store_salary = string.Format("{0:c}", txtSalary.Text);

                var salary = Decimal.Parse(store_salary, NumberStyles.Currency);

                com = new SqlCommand("spUpdateStaff", p.con);
                com.CommandType = CommandType.StoredProcedure;
                //@id, @fn, @g, @db, @po, @s, @sw, @ph

                com.Parameters.AddWithValue("@id", store_staffID);
                com.Parameters.AddWithValue("@fn", txtName.Text);

                if (rdbtnFemale.Checked == true)
                {
                    com.Parameters.AddWithValue("@g", "F");
                }
                else
                {
                    com.Parameters.AddWithValue("@g", "M");
                }
                //com.Parameters.AddWithValue("@db", dtpDOB.Value);
                com.Parameters.AddWithValue("@po", txtPosition.Text);
                com.Parameters.AddWithValue("@s", salary);
                com.Parameters.AddWithValue("@sw", 0);

                if (fp != null) photo = File.ReadAllBytes(fp);
                //else photo = null;

                com.Parameters.AddWithValue("@ph", photo);
                com.ExecuteNonQuery(); // run stored procedure
                fp = null;
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // clear all textboxes
                txtID.Text = "";
                txtName.Text = "";
                txtPosition.Text = "";
                txtSalary.Text = "";
                picStaff.Image = null;
                LoadData();
            }
        }

        // -----
    }
}
