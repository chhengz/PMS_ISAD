using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMS_ISAD
{
    public partial class Form1: Form
    {

        StaffForm staff = new StaffForm();
        PaymentForm pay = new PaymentForm();
        CustomerForm cus = new CustomerForm();
        ProductForm pro = new ProductForm();
        SupplierForm sup = new SupplierForm();

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            staff.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            pay.ShowDialog();
            this.Show();
        }

        //private void button4_Click(object sender, EventArgs e)
        //{

        //}

        //private void button3_Click(object sender, EventArgs e)
        //{

        //}

        // Customer Form
        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            cus.ShowDialog();
            this.Show();
        }

        // Supplier Form
        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            sup.ShowDialog();
            this.Show();
        }

        // Product Form
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            pro.ShowDialog();
            this.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            cus.ShowDialog();
            this.Show();
        }
    }
}
