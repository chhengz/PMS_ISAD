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
    public partial class StaffForm: Form
    {
        public StaffForm()
        {
            InitializeComponent();
        }

        private void StaffForm_Load(object sender, EventArgs e)
        {
            
        }

        //private void button7_Click(object sender, EventArgs e)
        //{
        //    PaymentForm pay = new PaymentForm();
        //    pay.Show();
        //    //this.Hide();
        //}

        // Exit Button
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // browse staff picture
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // add new staff
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // edit
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // preview
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // search
        }
    }
}
