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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


/* 
 * Author: @chheng_hilo
 * If you trying hard to read my code, You're a real developer with respectful <3
 * Because VibeCoder don't event try!
 */

namespace PMS_ISAD
{
    public partial class frmOrderDetail: Form
    {
        A6PMS d = new A6PMS();
        SqlDataAdapter dap; // Data adapter for database operations
        DataTable dt; // Data table to hold data from the database
        SqlCommand com;
        Decimal Total = 0;

        // these string use to protect when calculate with {$} symbols
        string store_txtPrice = "";
        string display_txtPrice = "";
        string store_price = "";
        string store_amount = "";
        string display_total = "";

        public frmOrderDetail()
        {
            InitializeComponent();
        }

        private void frmOrderDetail_Load(object sender, EventArgs e)
        {
            try
            {
                d.Connection();

                // Load data into the DataGridView
                dap = new SqlDataAdapter("SELECT * FROM fnGetAllStaff()", d.con);
                dt = new DataTable();

                // Staff Function
                dap.Fill(dt);
                cboStaffID.DataSource = dt;
                cboStaffID.DisplayMember = "staffID"; // Display the FullName in the combobox
                cboStaffID.ValueMember = "FullName"; // Set the ValueMember to staffID by FullName
                cboStaffID.Text = null;

                
                // Customer Function
                dap = new SqlDataAdapter("SELECT * FROM fnGetAllCustomer()", d.con);
                dt = new DataTable();

                dap.Fill(dt);
                cboCusID.DataSource = dt;
                cboCusID.DisplayMember = "cusID"; // Display the FullName in the combobox
                cboCusID.ValueMember = "CusName"; // Set the ValueMember to staffID by FullName
                cboCusID.Text = null;


                // Add columns to the ListView
                lsv.Clear();
                lsv.View = View.Details;
                lsv.Columns.Add("PID", 50);
                lsv.Columns.Add("Product Name", 200);
                lsv.Columns.Add("Quantity", 100);
                lsv.Columns.Add("Price ", 150);
                lsv.Columns.Add("Amount", 120);


            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        // Staff ID selection change committed event
        private void cboStaffID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtStaffName.Text = cboStaffID.SelectedValue.ToString(); // Get the selected staff name
        }

        // Customer ID selection change committed event
        private void cboCusID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtCusName.Text = cboCusID.SelectedValue.ToString(); // Get the selected customer name
        }


        // Search Product by code
        private void txtProID_Leave(object sender, EventArgs e)
        {
            try
            {
                com = new SqlCommand("spGetProductByID", d.con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@pc", txtProID.Text);
                //com.ExecuteNonQuery();

                var dr = com.ExecuteReader();
                
                if (dr.Read())
                {
                    txtProName.Text = dr[0].ToString();

                    /* I track this code to see what happened
                     * I just define new string display_txtPrice to store ($) symbol
                     * and use string store_txtPrice to calculate Decimal
                     */
                    store_txtPrice = string.Format("{0:c}", Decimal.Parse(dr[1].ToString()));
                    display_txtPrice = string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:c}", Decimal.Parse(dr[1].ToString()));

                    // For this line we can use direcally with string format
                    // display_txtPrice for only for display {$} (Decimal Currency) but we needn't have to use for caculate
                    txtPrice.Text = display_txtPrice; 
                }
                else
                {
                    display_txtPrice = null;
                    txtProName.Text = null;
                    txtPrice.Text = null;
                }

                dr.Dispose();
                com.Dispose();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Button Add Product
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
                    
                    Total = Total - decimal.Parse(lv.SubItems[4].Text, NumberStyles.Currency); //, CultureInfo.GetCultureInfo("en-US")

                    //display_total

                    var price = decimal.Parse(txtPrice.Text, NumberStyles.Currency); // , CultureInfo.GetCultureInfo("en-US")
                    amount = qty * price;
                    lv.SubItems[4].Text = string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:c}", amount); // Amount
                    
                    store_amount = string.Format("{0:c}", amount); // use to calculate with total when deleted

                    display_total = string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:c}", amount + Total);
                    Total = amount + Total;
                }
                else
                {
                    ListViewItem item;
                    string[] arr = new string[5];
                    arr[0] = txtProID.Text;                 // Product ID
                    arr[1] = txtProName.Text;               // Product Name
                    arr[2] = txtProQTY.Text;                // Product Qty

                    //MessageBox.Show("Qty:" + txtProQTY.Text);
                    
                    //s = decimal.Parse(txtPrice.Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat);
                    s = decimal.Parse(store_txtPrice, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat);

                    arr[3] = string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:c}", s);        // Product Price
                    store_price = string.Format("{0:c}", s); // use to calculate with Qty/Amount when save and delete

                    amount = decimal.Parse(txtProQTY.Text) * decimal.Parse(store_txtPrice, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat);          // Price * Amount
                    
                    arr[4] = string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:c}", amount);   // Amount
                    store_amount = string.Format("{0:c}", amount); // use to calculate with total when save and delete

                    item = new ListViewItem(arr);
                    lsv.Items.Add(item);

                    Total = Total + amount;
                    display_total = string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:c}", amount + Total);

                }

                txtProID.Text = null;
                txtProName.Text = null;
                txtProQTY.Text = null;
                txtPrice.Text = null;
                txtTotal.Text = string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:c}", display_total);
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /*
        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlTransaction transaction = null;
            SqlConnection connection = null;

            try
            {
                // Validate staff and customer selection
                if (cboStaffID.SelectedValue == null || cboCusID.SelectedValue == null)
                {
                    MessageBox.Show("Please select both Staff and Customer before saving.",
                                  "Validation Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }

                // Validate at least one product in the order
                if (lsv.Items.Count == 0)
                {
                    MessageBox.Show("Please add at least one product to the order before saving.",
                                  "Validation Error",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    return;
                }

                // Create connection
                //connection = new SqlConnection(d.con); // Replace with your actual connection string
                //connection.Open();
                transaction = connection.BeginTransaction();

                // Prepare Order Master data
                DataTable dtMaster = new DataTable();
                dtMaster.Columns.Add("OrdDate", typeof(DateTime));
                dtMaster.Columns.Add("staffID", typeof(byte));
                dtMaster.Columns.Add("FullName", typeof(string));
                dtMaster.Columns.Add("cusID", typeof(int));
                dtMaster.Columns.Add("cusName", typeof(string));
                dtMaster.Columns.Add("Total", typeof(decimal));

                // Add master row
                dtMaster.Rows.Add(
                    dtpOrder.Value,
                    Convert.ToByte(cboStaffID.SelectedValue),
                    txtStaffName.Text,
                    Convert.ToInt32(cboCusID.SelectedValue),
                    txtCusName.Text,
                    Convert.ToDecimal(Total)
                );

                // Prepare Order Detail data
                DataTable dtDetail = new DataTable();
                dtDetail.Columns.Add("ProCode", typeof(string));
                dtDetail.Columns.Add("ProName", typeof(string));
                dtDetail.Columns.Add("Qty", typeof(int));
                dtDetail.Columns.Add("Price", typeof(decimal));
                dtDetail.Columns.Add("Amount", typeof(decimal));

                // Add detail rows
                foreach (ListViewItem item in lsv.Items)
                {
                    string productCode = item.Text;
                    string productName = item.SubItems[1].Text;
                    int quantity = int.Parse(item.SubItems[2].Text);
                    decimal price = decimal.Parse(item.SubItems[3].Text.Replace("$", "").Trim());
                    decimal amount = decimal.Parse(item.SubItems[4].Text.Replace("$", "").Trim());

                    dtDetail.Rows.Add(productCode, productName, quantity, price, amount);
                }

                // Create and configure command
                using (SqlCommand com = new SqlCommand("spSetOrderDetail", connection, transaction))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.CommandTimeout = 30; // 30 seconds timeout

                    // Add parameters
                    com.Parameters.Add("@OM", SqlDbType.Structured).Value = dtMaster;
                    com.Parameters.Add("@OD", SqlDbType.Structured).Value = dtDetail;

                    // Execute stored procedure
                    int rowsAffected = com.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        transaction.Commit();
                        MessageBox.Show("Order saved successfully!",
                                        "Success",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                        // Reset UI
                        lsv.Items.Clear();
                        cboStaffID.SelectedIndex = -1;
                        txtStaffName.Clear();
                        cboCusID.SelectedIndex = -1;
                        txtCusName.Clear();
                        Total = 0;
                        txtTotal.Text = "$0.00";
                    }
                    else
                    {
                        transaction.Rollback();
                        MessageBox.Show("No records were saved. Please try again.",
                                      "Warning",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Warning);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                transaction?.Rollback();
                MessageBox.Show($"Database error: {sqlEx.Message}\nError Number: {sqlEx.Number}",
                              "Database Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
            catch (FormatException formatEx)
            {
                transaction?.Rollback();
                MessageBox.Show($"Invalid data format: {formatEx.Message}",
                              "Format Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                MessageBox.Show($"Error: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
            finally
            {
                transaction?.Dispose();
                connection?.Close();
                connection?.Dispose();
            }
        }
        */

        // save data to server
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtMaster = new DataTable();


                // check if Staff and Customer are selected, and if there are items in the ListView
                if (cboStaffID.SelectedValue == null || cboCusID.SelectedValue == null)
                    {
                        MessageBox.Show("Please select both Staff and Customer before saving.");
                        return;
                    }

                // Check if there are items in the ListView
                    if (lsv.Items.Count == 0)
                    {
                        MessageBox.Show("Please add at least one product to the order before saving.");
                        return;
                    }

                // Import Master
                // Match these types exactly with your SQL type
                        dtMaster.Columns.Add("OrdDate", typeof(DateTime));  // Changed to DateTime
                        dtMaster.Columns.Add("staffID", typeof(byte));      // tinyint in SQL is byte in C#
                        dtMaster.Columns.Add("FullName", typeof(string));
                        dtMaster.Columns.Add("cusID", typeof(int));
                        dtMaster.Columns.Add("cusName", typeof(string));
                        dtMaster.Columns.Add("Total", typeof(float));     // money in SQL is decimal in C#


                    //// Add row directly with proper types
                    //dtMaster.Rows.Add(
                    //    dtpOrder.Value,                     // Use DateTime directly
                    //    Convert.ToByte(cboStaffID.Text),
                    //    txtStaffName.Text,
                    //    Convert.ToInt32(cboCusID.Text),
                    //    txtCusName.Text,
                    //    Total
                    //);

                        dtMaster.Rows.Add(
                         dtpOrder.Value,
                         Convert.ToByte(cboStaffID.Text),
                         txtStaffName.Text,
                         Convert.ToInt32(cboCusID.Text),
                         txtCusName.Text,
                         Convert.ToDecimal(Total)
                        );


                    com = new SqlCommand("spSetOrderDetail", d.con);
                        com.CommandType = CommandType.StoredProcedure;

                        SqlParameter param1 = new SqlParameter();
                        param1.ParameterName = "@OM";
                        param1.SqlDbType = SqlDbType.Structured;
                        param1.Value = dtMaster;

                        com.Parameters.Add(param1);

                        //com.ExecuteNonQuery();


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

                            float p = float.Parse(store_price, NumberStyles.Currency);
                            float a = float.Parse(store_amount, NumberStyles.Currency); // replace by store_amount for save format
                            dtDetail.Rows.Add(pc, pn, q, p, a);
                        }



                        SqlParameter param2 = new SqlParameter();
                        param2.ParameterName = "@OD";
                        param2.SqlDbType = SqlDbType.Structured;
                        param2.Value = dtDetail;

                        com.Parameters.Add(param2);


                        com.ExecuteNonQuery();

                        MessageBox.Show("Order saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dtMaster.Clear();
                dtDetail.Clear();
                lsv.Items.Clear();
                cboStaffID.SelectedIndex = -1;
                txtStaffName.Clear();
                cboCusID.SelectedIndex = -1;
                txtCusName.Clear();
                Total = 0;
                txtTotal.Text = "$0.00";

            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // button remove

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

                        var a = Decimal.Parse(store_amount, NumberStyles.Currency); // use store_amount instead of it.SubItems[4].Text
                        Total = Total - a;

                        txtTotal.Text = string.Format(CultureInfo.GetCultureInfo("en-US"), "{0:c}", Total);
                    }
                }
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    foreach (ListViewItem item in lsv.Items)
        //    {
        //        string pc = item.Text;
        //        string pn = item.SubItems[1].Text;
        //        int q = int.Parse(item.SubItems[2].Text);


        //        MessageBox.Show($"Product Code: {pc}\nProduct Name: {pn}\nQuantity: {q}",
        //            "Product Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
    }
}
