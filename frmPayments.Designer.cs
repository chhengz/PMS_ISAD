namespace PMS_ISAD
{
    partial class frmPayments
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayments));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStaffName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDeposit = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRemain = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            //this.dtp = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.cboStaffID = new System.Windows.Forms.ComboBox();
            this.cboOrderID = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 24);
            this.label1.TabIndex = 29;
            this.label1.Text = "កាលបរិច្ឆេទបង់ប្រាក់";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 24);
            this.label3.TabIndex = 31;
            this.label3.Text = "លេខសម្គាល់បុគ្គលិក";
            // 
            // txtStaffName
            // 
            this.txtStaffName.Location = new System.Drawing.Point(151, 117);
            this.txtStaffName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.ReadOnly = true;
            this.txtStaffName.Size = new System.Drawing.Size(244, 32);
            this.txtStaffName.TabIndex = 34;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(147, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 24);
            this.label4.TabIndex = 33;
            this.label4.Text = "ឈ្មោះបុគ្គលិក";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 24);
            this.label5.TabIndex = 35;
            this.label5.Text = "លេខកូដបញ្ជាទិញ";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(151, 185);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(119, 32);
            this.txtTotal.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(147, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 24);
            this.label6.TabIndex = 37;
            this.label6.Text = "សរុប";
            // 
            // txtDeposit
            // 
            this.txtDeposit.Location = new System.Drawing.Point(276, 185);
            this.txtDeposit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDeposit.Name = "txtDeposit";
            this.txtDeposit.Size = new System.Drawing.Size(119, 32);
            this.txtDeposit.TabIndex = 40;
            this.txtDeposit.Leave += new System.EventHandler(this.txtDeposit_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(272, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 24);
            this.label7.TabIndex = 39;
            this.label7.Text = "ប្រាក់កក់";
            // 
            // txtRemain
            // 
            this.txtRemain.Location = new System.Drawing.Point(401, 185);
            this.txtRemain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtRemain.Name = "txtRemain";
            this.txtRemain.ReadOnly = true;
            this.txtRemain.Size = new System.Drawing.Size(118, 32);
            this.txtRemain.TabIndex = 42;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(397, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 24);
            this.label8.TabIndex = 41;
            this.label8.Text = "នៅសល់";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.PowderBlue;
            this.label9.Font = new System.Drawing.Font("Khmer OS Muol Light", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label9.Location = new System.Drawing.Point(188, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 49);
            this.label9.TabIndex = 45;
            this.label9.Text = "ការទូទាត់";
            // 
            // dtp
            // 
            //this.dtp.BackColor = System.Drawing.Color.Moccasin;
            //this.dtp.BorderRadius = 1;
            //this.dtp.Color = System.Drawing.Color.Black;
            //this.dtp.CustomFormat = "dd-MM-yyyy";
            //this.dtp.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            //this.dtp.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            //this.dtp.DisabledColor = System.Drawing.Color.Gray;
            //this.dtp.DisplayWeekNumbers = false;
            //this.dtp.DPHeight = 0;
            //this.dtp.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            //this.dtp.FillDatePicker = false;
            //this.dtp.Font = new System.Drawing.Font("Segoe UI", 9F);
            //this.dtp.ForeColor = System.Drawing.Color.Black;
            //this.dtp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            //this.dtp.Icon = ((System.Drawing.Image)(resources.GetObject("dtp.Icon")));
            //this.dtp.IconColor = System.Drawing.Color.Gray;
            //this.dtp.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            //this.dtp.LeftTextMargin = 5;
            //this.dtp.Location = new System.Drawing.Point(12, 38);
            //this.dtp.MinimumSize = new System.Drawing.Size(4, 32);
            //this.dtp.Name = "dtp";
            //this.dtp.Size = new System.Drawing.Size(118, 32);
            //this.dtp.TabIndex = 47;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Image = global::PMS_ISAD.Properties.Resources.close_window_30px;
            this.button1.Location = new System.Drawing.Point(485, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 46;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.GreenYellow;
            this.btnPay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPay.Font = new System.Drawing.Font("Khmer OS Muol Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPay.Image = global::PMS_ISAD.Properties.Resources.icons8_checkout_32;
            this.btnPay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPay.Location = new System.Drawing.Point(207, 228);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(119, 39);
            this.btnPay.TabIndex = 44;
            this.btnPay.Text = "ទូទាត់";
            this.btnPay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // cboStaffID
            // 
            this.cboStaffID.FormattingEnabled = true;
            this.cboStaffID.Location = new System.Drawing.Point(12, 118);
            this.cboStaffID.Name = "cboStaffID";
            this.cboStaffID.Size = new System.Drawing.Size(118, 32);
            this.cboStaffID.TabIndex = 48;
            this.cboStaffID.SelectionChangeCommitted += new System.EventHandler(this.cboStaffID_SelectionChangeCommitted);
            // 
            // cboOrderID
            // 
            this.cboOrderID.FormattingEnabled = true;
            this.cboOrderID.Location = new System.Drawing.Point(12, 185);
            this.cboOrderID.Name = "cboOrderID";
            this.cboOrderID.Size = new System.Drawing.Size(118, 32);
            this.cboOrderID.TabIndex = 49;
            this.cboOrderID.SelectionChangeCommitted += new System.EventHandler(this.cboOrderID_SelectionChangeCommitted);
            // 
            // frmPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(529, 279);
            this.Controls.Add(this.cboOrderID);
            this.Controls.Add(this.cboStaffID);
            //this.Controls.Add(this.dtp);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.txtRemain);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDeposit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtStaffName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(545, 318);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(545, 318);
            this.Name = "frmPayments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PaymentForm";
            this.Load += new System.EventHandler(this.frmPayments_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStaffName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDeposit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRemain;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        //private Bunifu.UI.WinForms.BunifuDatePicker dtp;
        private System.Windows.Forms.ComboBox cboStaffID;
        private System.Windows.Forms.ComboBox cboOrderID;
    }
}