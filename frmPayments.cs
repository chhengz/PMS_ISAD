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
    
    public partial class frmPayments: Form
    {
        A6PMS d = new A6PMS();
        SqlDataAdapter dap;
        DataTable dt;
        Decimal t, ds, r;

        public frmPayments()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult re = DialogResult.Yes;
            re = MessageBox.Show("Are you sure you want to exit?", "Exit",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (re == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // Helper method for currency parsing
        private decimal ParseCurrency(string value)
        {
            return decimal.Parse(value, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat);
        }

        private void frmPayments_Load(object sender, EventArgs e)
        {
            try
            {
                d.Connection();
                dap = new SqlDataAdapter("SELECT * FROM fnGetAllStaff()", d.con);
                dt = new DataTable();

                dap.Fill(dt);
                cboStaffID.DataSource = dt;
                cboStaffID.DisplayMember = "StaffID"; // Assuming StaffName is the column to display
                cboStaffID.ValueMember = "FullName"; // Assuming StaffID is the primary key
                cboStaffID.Text = null; // Clear the selection

                dap = new SqlDataAdapter("SELECT * FROM fnGetOrderCode()", d.con);
                dt = new DataTable();
                dap.Fill(dt);
                cboOrderID.DataSource = null;
                cboOrderID.Items.Clear(); // Clear any existing items
                cboOrderID.DataSource = dt;
                cboOrderID.DisplayMember = "OrdCode"; // Assuming OrderCode is the column to display
                cboOrderID.ValueMember = "OrdCode"; // Assuming OrderID is the primary key
                cboOrderID.Text = null; // Clear the selection


                txtDeposit.Enabled = false;
                btnPay.Enabled = false;

            }
            catch (SqlException ex)
            {
                MessageBox.Show($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

        }

        private void cboStaffID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtStaffName.Text = cboStaffID.SelectedValue.ToString(); // Assuming StaffName is the column to display
        }

        private void txtDeposit_Leave(object sender, EventArgs e)
        {
            if (txtDeposit.Text == "")
            {
                MessageBox.Show("Please enter a valid deposit amount.");
                //txtDeposit.Focus();
                return;
            }
            t = decimal.Parse(txtTotal.Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat);
            ds = decimal.Parse(txtDeposit.Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat);
            r = t - ds;
            txtRemain.Text = string.Format("{0:c}", decimal.Parse(r.ToString()));
        }
        
        /* 
         * 
        private void cboOrderID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                using (SqlCommand com = new SqlCommand("spGetPayment", d.con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@oc", cboOrderID.SelectedValue.ToString());

                    using (var dr = com.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            txtTotal.Text = string.Format("{0:C}", ParseCurrency(dr[0].ToString()));
                            txtDeposit.Text = dr[1].ToString();

                            if (string.IsNullOrEmpty(txtDeposit.Text))
                            {
                                txtRemain.Text = txtTotal.Text;
                                txtDeposit.ReadOnly = false;
                            }
                            else
                            {
                                t = ParseCurrency(txtTotal.Text);
                                ds = ParseCurrency(txtDeposit.Text);
                                r = t - ds;
                                txtRemain.Text = string.Format("{0:c}", r);
                                txtDeposit.ReadOnly = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("No payment found for the selected order code.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading order details: {ex.Message}");
            }
        }
        private void btnPay_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrEmpty(cboOrderID.Text) || string.IsNullOrEmpty(cboStaffID.Text))
            {
                MessageBox.Show("Please select both Order ID and Staff ID");
                return;
            }

            try
            {
                using (SqlCommand com = new SqlCommand("spPayment", d.con))
                {
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.AddWithValue("@PD", dtp.Value);
                    com.Parameters.AddWithValue("@SI", cboStaffID.Text);
                    com.Parameters.AddWithValue("@FN", txtStaffName.Text);
                    com.Parameters.AddWithValue("@IC", int.Parse(cboOrderID.SelectedValue.ToString()));

                    decimal paymentAmount = txtDeposit.ReadOnly
                        ? ParseCurrency(txtRemain.Text)
                        : ParseCurrency(txtDeposit.Text);

                    // Validate payment amount
                    if (paymentAmount <= 0)
                    {
                        MessageBox.Show("Payment amount must be greater than zero");
                        return;
                    }

                    com.Parameters.AddWithValue("@Dep", paymentAmount);
                    com.Parameters.AddWithValue("@A", ParseCurrency(txtTotal.Text));

                    int rowsAffected = com.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Payment has been successfully recorded.", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Consider clearing/resetting the form here
                        ClearForm();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing payment: {ex.Message}");
            }
        }

        */

        // clear the form fields
        private void ClearForm()
        {
            cboStaffID.SelectedIndex = -1;
            txtStaffName.Clear();
            cboOrderID.SelectedIndex = -1;
            txtTotal.Clear();
            txtDeposit.Clear();
            txtRemain.Clear();
            //dtp.Value = DateTime.Now; // Reset to current date
        }

        
        private void cboOrderID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("spGetPayment", d.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@oc", cboOrderID.SelectedValue.ToString());

            var dr = com.ExecuteReader();

            if (dr.Read())
            {

                txtTotal.Text = string.Format("{0:C}", Decimal.Parse(dr[0].ToString()));
                txtDeposit.Text = dr[1].ToString();
                if (string.IsNullOrEmpty(txtDeposit.Text))
                {
                    txtDeposit.Enabled = true;
                    txtRemain.Text = txtTotal.Text; // If Deposit is empty, set Remaining to Total
                }
                else
                {
                    
                    t = decimal.Parse(txtTotal.Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat);
                    ds = decimal.Parse(txtDeposit.Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat);
                    r = t - ds;
                    txtRemain.Text = string.Format("{0:c}", decimal.Parse(r.ToString()));
                    txtDeposit.ReadOnly = true;
                }

                txtDeposit.Enabled = true;
                btnPay.Enabled = true;

                dr.Dispose();
                //txtOrderCode.Text = dr["OrdCode"].ToString();
                //txtAmount.Text = dr["Amount"].ToString();
                //txtPaymentDate.Text = dr["PaymentDate"].ToString();
                //txtPaymentMethod.Text = dr["PaymentMethod"].ToString();
            }
            else
            {
                MessageBox.Show("No payment found for the selected order code.");
            }
        }
        
        


        
        private void btnPay_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("spPayment", d.con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.AddWithValue("@PD", dtp.Value);
            com.Parameters.AddWithValue("@SI", cboStaffID.Text);
            com.Parameters.AddWithValue("@FN", txtStaffName.Text);
            com.Parameters.AddWithValue("@IC", int.Parse(cboOrderID.SelectedValue.ToString()));

            if (txtDeposit.ReadOnly == false)
            {
                com.Parameters.AddWithValue("@Dep", decimal.Parse(txtDeposit.Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat));
            }
            else
            {
                // Remove currency symbol and commas
                //string remainText = txtRemain.Text.Replace("$", "").Replace(",", "").Trim(); // Remove currency symbol and commas
                com.Parameters.AddWithValue("@Dep", decimal.Parse(txtRemain.Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat)); // If Deposit is not provided
            }
            //string totalText = txtTotal.Text.Replace("$", "").Replace(",", "").Trim(); // Remove currency symbol and commas
            com.Parameters.AddWithValue("@A", decimal.Parse(txtTotal.Text, NumberStyles.Currency, CultureInfo.CurrentCulture.NumberFormat));

            com.ExecuteNonQuery();

            MessageBox.Show("Payment has been successfully recorded.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearForm();

        }
       



    }
}
