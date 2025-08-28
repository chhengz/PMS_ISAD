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
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace PMS_ISAD
{
    public partial class frmImportDetail: Form
    {

        A6PMS d = new A6PMS();
        SqlDataAdapter dap; // Data adapter for database operations
        DataTable dt; // Data table to hold data from the database
        SqlCommand com;

        Decimal Total = 0;
        string store_amount = "";
        string store_price = "";


        public frmImportDetail()
        {
            InitializeComponent();
        }

        // form load event
        private void frmImportDetail_Load(object sender, EventArgs e)
         {
            try
            {
                d.Connection();

                dap = new SqlDataAdapter("SELECT * FROM fnGetAllStaff()", d.con);
                dt = new DataTable();

                dap.Fill(dt);
                cboStaffID.DataSource = dt;
                cboStaffID.DisplayMember = "staffID"; // Display the FullName in the combobox
                cboStaffID.ValueMember = "FullName"; // Set the ValueMember to staffID by FullName
                cboStaffID.Text = null;

                dap = new SqlDataAdapter("SELECT * FROM fnGetAllSupplier()", d.con);
                dt = new DataTable();

                dap.Fill(dt);
                cboSupName.DataSource = dt;
                cboSupName.DisplayMember = "Supplier"; // Display the Supplier in the combobox 
                cboSupName.ValueMember = "supID"; // Set the ValueMember to SupplierID
                cboSupName.Text = null;


                lsv.Clear();
                lsv.View = View.Details;
                lsv.Columns.Add("PID", 50);
                lsv.Columns.Add("Product Name", 200);
                lsv.Columns.Add("Quantity", 100);
                lsv.Columns.Add("Price ", 150);
                lsv.Columns.Add("Amount", 120);

                //Atlernating row color
                foreach (ListViewItem list in lsv.Items)
                {
                    if ((list.Index % 2) == 0)
                        list.BackColor = Color.Gray;
                    else
                        list.BackColor = Color.LightBlue;
                }

            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Staff ID selection change committed event
        private void cboStaffID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtStaffName.Text = cboStaffID.SelectedValue.ToString(); // Get the selected staff name
        }


        private void cboSupName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtSupID.Text = cboSupName.SelectedValue.ToString(); // Get the selected supplier ID
        }

        // Search Product by code
        private void txtProID_Leave(object sender, EventArgs e)
        {
            //dap = new SqlDataAdapter("SELECT * FROM fnGetProductByID(" + txtProID.Text + ")", d.con);
            try
            {
                com = new SqlCommand("spGetProductByID", d.con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@pc", txtProID.Text);

                //com.ExecuteNonQuery();
                SqlDataReader dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtProName.Text = dr[0].ToString();
                    }
                }
                else
                {
                    txtProName.Text = null;
                }
                dr.Dispose();
                com.Dispose();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ListViewItem lv = null;
            Decimal amount, s;

            try
            {
                foreach (ListViewItem item in lsv.Items)
                {
                    if (item.Text.Equals(txtProID.Text, StringComparison.Ordinal))
                    {
                        lv = item;
                        break;
                    }
                }

                if (lv != null)
                {
                    var qty = int.Parse(lv.SubItems[2].Text) + int.Parse(txtProQTY.Text);
                    lv.SubItems[2].Text = qty.ToString();
                    Total = Total - decimal.Parse(lv.SubItems[4].Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US"));
                    var price = decimal.Parse(txtPrice.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US"));
                    amount = qty * price;
                    lv.SubItems[4].Text = string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:c}", amount);
                    store_amount = string.Format("{0:c}", amount);
                    Total = amount + Total;
                }
                else
                {
                    ListViewItem item;
                    string[] arr = new string[5];
                    arr[0] = txtProID.Text;                 // Product ID
                    arr[1] = txtProName.Text;               // Product Name
                    arr[2] = txtProQTY.Text;                // Product Qty
                    s = decimal.Parse(txtPrice.Text);
                    
                    arr[3] = string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:c}", s);        // Product Price
                    store_price = string.Format("{0:c}", s);
                    amount = decimal.Parse(txtProQTY.Text) * decimal.Parse(txtPrice.Text);          // Price * Amount
                    
                    arr[4] = string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:c}", amount);   // Amount
                    store_amount = string.Format("{0:c}", amount);

                    item = new ListViewItem(arr);
                    lsv.Items.Add(item);
                    Total = Total + amount;

                }

                txtProID.Text = null;
                txtProName.Text = null;
                txtProQTY.Text = null;
                txtPrice.Text = null;
                txtTotal.Text = string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:c}", Total);
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // Remove button
        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult re;

            foreach (ListViewItem item in lsv.Items)
            {
                if (item.Selected)
                {
                    re = MessageBox.Show("Do you want to remove this item?",
                        "Revome", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (re == DialogResult.Yes)
                    {
                        ListViewItem it = lsv.SelectedItems[0];
                        lsv.Items.Remove(item);
                        //var a = Decimal.Parse(it.SubItems[4].Text, NumberStyles.Currency);
                        var a = Decimal.Parse(store_amount, NumberStyles.Currency);
                        Total = Total - a;
                        txtTotal.Text = string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:c}", Total);
                    }
                }
            }

        }

        // Save button
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtMaster = new DataTable();


                // check if any item is added to the list view
                if (lsv.Items.Count == 0)
                {
                    MessageBox.Show("Please add at least one product to the import list.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                // Import Master
                // Match these types exactly with your SQL type
                dtMaster.Columns.Add("ImpDate", typeof(DateTime));  // Changed to DateTime
                dtMaster.Columns.Add("staffID", typeof(byte));      // tinyint in SQL is byte in C#
                dtMaster.Columns.Add("FullName", typeof(string));
                dtMaster.Columns.Add("supID", typeof(int));
                dtMaster.Columns.Add("Supplier", typeof(string));
                dtMaster.Columns.Add("Total", typeof(decimal));     // money in SQL is decimal in C#

                // Add row directly with proper types
                dtMaster.Rows.Add(
                    dtpImport.Value,  // Use DateTime directly
                    Convert.ToByte(cboStaffID.Text),
                    txtStaffName.Text,
                    Convert.ToInt32(txtSupID.Text),
                    cboSupName.Text,
                    Convert.ToDecimal(Total)
                );

                com = new SqlCommand("spSetImportDetail", d.con);
                com.CommandType = CommandType.StoredProcedure;

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@IM";
                param1.SqlDbType = SqlDbType.Structured;
                param1.Value = dtMaster;
                
                com.Parameters.Add(param1);

                com.ExecuteNonQuery();


                // Import Detail
                DataTable dtDetail = new DataTable();
                dtDetail.Columns.Add("ProCode", typeof(string));
                dtDetail.Columns.Add("ProName", typeof(string));
                dtDetail.Columns.Add("Qty", typeof(int));
                dtDetail.Columns.Add("Price", typeof(float));
                dtDetail.Columns.Add("Amount", typeof(float));



                foreach (ListViewItem item in lsv.Items)
                {
                    string pc = item.Text;
                    string pn = item.SubItems[1].Text;
                    int q = int.Parse(item.SubItems[2].Text);
                    
                    //float p = float.Parse(item.SubItems[3].Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat);
                    //float a = float.Parse(item.SubItems[4].Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat);

                    float p = float.Parse(store_price, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat);
                    float a = float.Parse(store_amount, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat); // replace by store_amount for save format
                    dtDetail.Rows.Add(pc, pn, q, p, a);
                }

                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@ID";
                param2.SqlDbType = SqlDbType.Structured;
                param2.Value = dtDetail;

                com.Parameters.Add(param2);


                com.ExecuteNonQuery();

                MessageBox.Show("Import saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // clear form
                txtProID.Text = null;
                txtProName.Text = null;
                txtProQTY.Text = null;
                txtPrice.Text = null;
                txtTotal.Text = string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:c}", Total);

            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            /*
            //try
            //{
                DataTable dtMaster = new DataTable();

                dtMaster.Columns.Add("ImpDate", typeof(string));     // Column for import date (as string, consider DateTime if needed)
                dtMaster.Columns.Add("staffID", typeof(int));        // Column for staff ID
                dtMaster.Columns.Add("FullName", typeof(string));    // Column for staff full name
                dtMaster.Columns.Add("supID", typeof(int));          // Column for supplier ID
                dtMaster.Columns.Add("Supplier", typeof(string));    // Column for supplier name
                dtMaster.Columns.Add("Total", typeof(float));      // Column for total import amount


            //DateTime impDate = dtpImport.Value;
            //string impDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            string impDate = dtpImport.Value.ToString("yyyy-MM-dd HH:mm:ss");


            dtMaster.Rows.Add(
                    //impDate,
                    DateTime.Parse(impDate),
                    cboStaffID.Text, 
                    txtStaffName.Text,
                    txtSupID.Text,
                    cboSupName.Text,
                    Total 
                   );

                com = new SqlCommand("spSetImportDetail", d.con);
                com.CommandType = CommandType.StoredProcedure;


            SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@IM";
                param1.SqlDbType = SqlDbType.Structured;
                param1.Value = dtMaster;

                com.Parameters.Add(param1);
                com.ExecuteNonQuery();
            //}
            //catch (Exception err)
            //{
            //    MessageBox.Show("Error: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            */

        }

        // Exit button
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

        // Report
        private void btnReport_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand com = new SqlCommand("spGetNST", d.con);
                com.CommandType = CommandType.StoredProcedure;
            
                com.Parameters.Add("@C", SqlDbType.Int).Direction = ParameterDirection.Output; // Output parameter for Product Count
                com.Parameters.Add("@N", SqlDbType.Int).Direction = ParameterDirection.Output; // Output parameter for SUM of Qty
                com.Parameters.Add("@T", SqlDbType.Float).Direction = ParameterDirection.Output; // Output parameter for SUM of Amount (Total)
           
                com.ExecuteNonQuery();

                var c = com.Parameters["@C"].Value.ToString();
                var n = com.Parameters["@N"].Value.ToString();
                var t = com.Parameters["@T"].Value.ToString();

                //int productCount = (int)com.Parameters["@C"].Value;
                //int totalQty = (int)com.Parameters["@N"].Value;
                //float totalAmount = (float)com.Parameters["@T"].Value;
                MessageBox.Show($"Product Count: {c}\nTotal Quantity: {n}\nTotal Amount: {t:C}",
                    "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
