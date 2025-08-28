using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * [Point of Sale System]
 * 
 * PMS_ISAD - Prodct Management System - Information System Analysis and Design
 * LECTURER: [Var SOVANNDARA]
 * STUDENT NAME: [VANG SOKCHHENG]
 * ROOM: A6(202)
 * 
 * 
*/
namespace PMS_ISAD
{
    public partial class main : Form
    {

        frmStaffs staffForm = new frmStaffs();
        frmSuppliers supllierForm = new frmSuppliers();
        frmImportDetail IDForm = new frmImportDetail();
        //frmOrders orderForm = new frmOrders();
        frmOrderDetail orderDetailForm = new frmOrderDetail();
        frmPayments frmPayments = new frmPayments();
        frmProducts productForm = new frmProducts();
        frmCustomers cusForm = new frmCustomers();

        public main()
        {
            InitializeComponent();
        }

        private void btn_openStaff_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide the main form
            staffForm.ShowDialog(); // Show the staff form as a dialog
            this.Show(); // Show the main form again after the dialog is closed
        }

        private void btn_openSupplier_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide the main form
            supllierForm.ShowDialog(); // Show the supplier form as a dialog
            this.Show();
        }

        private void btn_openImportDetail_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide the main form
            IDForm.ShowDialog();
            this.Show(); // Show the main form again after the dialog is closed
        }

        //private void btn_openOrder_Click(object sender, EventArgs e)
        //{
        //    this.Hide(); // Hide the main form
        //    orderForm.ShowDialog(); // Show the order form as a dialog
        //    this.Show(); // Show the main form again after the dialog is closed
        //}

        private void btn_openOrderDetail_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide the main form
            orderDetailForm.ShowDialog(); // Show the order detail form as a dialog
            this.Show();
        }

        private void btn_openPayment_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmPayments.ShowDialog();
            this.Show();
        }

        private void btn_openProduct_Click(object sender, EventArgs e)
        {
            this.Hide();
            productForm.ShowDialog();
            this.Show();

        }

        private void btn_openCustomer_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide the main form
            cusForm.ShowDialog();
            this.Show(); // Show the main form again after the dialog is closed
        }



        //private void btn_openStaff_MouseEnter(object sender, EventArgs e)
        //{
        //    btn_openStaff.BackColor = Color.LightBlue;
        //}

        //private void btn_openStaff_MouseLeave(object sender, EventArgs e)
        //{
        //    btn_openStaff.BackColor = SystemColors.ActiveCaption;
        //}
    }
}
