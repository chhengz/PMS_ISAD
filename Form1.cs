using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            pic_header.Parent = picBoxBanner;
            pic_header.BackColor = Color.Transparent;

            // Button Picture
            pic_staff_button.Parent = picBoxBanner;
            pic_staff_button.BackColor = Color.Transparent;
            pic_payment_button.Parent = picBoxBanner;
            pic_payment_button.BackColor = Color.Transparent;
            pic_customer_button.Parent = picBoxBanner;
            pic_customer_button.BackColor = Color.Transparent;
            pic_supplier_button.Parent = picBoxBanner;
            pic_supplier_button.BackColor = Color.Transparent;
            pic_product_button.Parent = picBoxBanner;
            pic_product_button.BackColor = Color.Transparent;

            
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    staff.ShowDialog();
        //    this.Show();
        //}

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    pay.ShowDialog();
        //    this.Show();
        //}

        //private void button4_Click(object sender, EventArgs e)
        //{

        //}

        //private void button3_Click(object sender, EventArgs e)
        //{

        //}

        // Customer Form
        //private void button3_Click_1(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    cus.ShowDialog();
        //    this.Show();
        //}

        // Supplier Form
        //private void button6_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    sup.ShowDialog();
        //    this.Show();
        //}

        // Product Form
        //private void button5_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    pro.ShowDialog();
        //    this.Show();
        //}

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            cus.ShowDialog();
            this.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            staff.ShowDialog();
            this.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            pay.ShowDialog();
            this.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            cus.ShowDialog();
            this.Show();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            sup.ShowDialog();
            this.Show();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            pro.ShowDialog();
            this.Show();
        }


        // // Mouse Hover on Staff Button
        private void pic_staff_button_MouseHover(object sender, EventArgs e)
        {
            //pic_staff_button.

        }

        private void pic_staff_button_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            using (var ms = new MemoryStream(Properties.Resources.Staff))
            {
                pictureBox.Image = Image.FromStream(ms);
            }
        }

        private void pic_staff_button_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            using (var ms = new MemoryStream(Properties.Resources.StaffHover))
            {
                pictureBox.Image = Image.FromStream(ms);
            }
        }


        // Mouse Hover on Payment Button
        private void pic_payment_button_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            using (var ms = new MemoryStream(Properties.Resources.Payment))
            {
                pictureBox.Image = Image.FromStream(ms);
            }
        }

        private void pic_payment_button_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            using (var ms = new MemoryStream(Properties.Resources.PaymentHover))
            {
                pictureBox.Image = Image.FromStream(ms);
            }
        }

        // Mouse Hover on Customer Button
        private void pic_customer_button_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            using (var ms = new MemoryStream(Properties.Resources.Customer))
            {
                pictureBox.Image = Image.FromStream(ms);
            }
        }


        
        private void pic_customer_button_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            using (var ms = new MemoryStream(Properties.Resources.CustomerHover))
            {
                pictureBox.Image = Image.FromStream(ms);
            }
        }

        // Mouse Hover on Supplier Button
        private void pic_supplier_button_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            using (var ms = new MemoryStream(Properties.Resources.SupplierHover))
            {
                pictureBox.Image = Image.FromStream(ms);
            }
        }
        
        private void pic_supplier_button_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            using (var ms = new MemoryStream(Properties.Resources.Supplier))
            {
                pictureBox.Image = Image.FromStream(ms);
            }
        }

        // Mouse Hover on Product Button
        private void pic_product_button_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            using (var ms = new MemoryStream(Properties.Resources.ProductHover))
            {
                pictureBox.Image = Image.FromStream(ms);
            }
        }

        private void pic_product_button_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;
            using (var ms = new MemoryStream(Properties.Resources.Product))
            {
                pictureBox.Image = Image.FromStream(ms);
            }
        }
    }
}
