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
    public partial class LoginForm: Form
    {

        private string enteredPassword = "";
        Form1 form = new Form1();

        public LoginForm()
        {
            InitializeComponent();
            textBox1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1
            enteredPassword += "1";  
            UpdatePasswordDisplay();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 2
            enteredPassword += "2";
            UpdatePasswordDisplay();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // 3
            enteredPassword += "3";
            UpdatePasswordDisplay();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 4
            enteredPassword += "4";
            UpdatePasswordDisplay();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 5
            enteredPassword += "5";
            UpdatePasswordDisplay();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //6 
            enteredPassword += "6";
            UpdatePasswordDisplay();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //7
            enteredPassword += "7";
            UpdatePasswordDisplay();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //8
            enteredPassword += "8";
            UpdatePasswordDisplay();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //9
            enteredPassword += "9";
            UpdatePasswordDisplay();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //0
            enteredPassword += "0";
            UpdatePasswordDisplay();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Display a confirmation message box
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Warning",
                 MessageBoxButtons.YesNo, // Offer Yes and No buttons
                 MessageBoxIcon.Warning);

            // Check the result
            if (result == DialogResult.Yes)
            {
                // Exit the application if the user clicks Yes
                Application.Exit();
            }
            else
            {
                // try again
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Buttom Go
            // Go button logic to validate the entered password
            if (enteredPassword == "1903")
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Proceed to the next screen or logic for successful login
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                enteredPassword = "";  // Reset password after failed attempt
                UpdatePasswordDisplay();
            }
        }

        private void UpdatePasswordDisplay()
        {
            // Update the TextBox (you already have it on the top of the form)
            textBox1.Text = enteredPassword; // Assuming passwordTextBox is your TextBox
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // back or remove a number back
            // Remove the last character from the entered password if it's not empty
            if (enteredPassword.Length > 0)
            {
                enteredPassword = enteredPassword.Substring(0, enteredPassword.Length - 1);
                UpdatePasswordDisplay();
            }
        }
    }
}
