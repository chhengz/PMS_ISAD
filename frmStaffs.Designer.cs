namespace PMS_ISAD
{
    partial class frmStaffs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStaffs));
            //Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            //Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            //Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            //Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvStaff = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            //this.txtSearch = new Bunifu.UI.WinForms.BunifuTextBox();
            this.btnExit = new System.Windows.Forms.Button();
            //this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.picStaff = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            //this.dtpDOB = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.rdbtnMale = new System.Windows.Forms.RadioButton();
            this.rdbtnFemale = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSalary = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chbStop = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
            //this.bunifuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStaff)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Khmer OS Muol Light", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(259, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "ព័ត៌មានរបស់បុគ្គលិក";
            // 
            // dgvStaff
            // 
            this.dgvStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStaff.Location = new System.Drawing.Point(15, 274);
            this.dgvStaff.MultiSelect = false;
            this.dgvStaff.Name = "dgvStaff";
            this.dgvStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStaff.Size = new System.Drawing.Size(787, 198);
            this.dgvStaff.TabIndex = 33;
            this.dgvStaff.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStaff_CellClick);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSearch.Image = global::PMS_ISAD.Properties.Resources.search_30px;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(709, 231);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 37);
            this.btnSearch.TabIndex = 45;
            this.btnSearch.Text = "ស្វែងរក";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDelete.Image = global::PMS_ISAD.Properties.Resources.delete_bin_30px;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(336, 231);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(78, 37);
            this.btnDelete.TabIndex = 44;
            this.btnDelete.Text = "លុប";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.Transparent;
            this.btnPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreview.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPreview.Image = global::PMS_ISAD.Properties.Resources.preview_pane_30px;
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreview.Location = new System.Drawing.Point(222, 231);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(108, 37);
            this.btnPreview.TabIndex = 43;
            this.btnPreview.Text = "មើលជាមុន";
            this.btnPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPreview.UseVisualStyleBackColor = false;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEdit.Image = global::PMS_ISAD.Properties.Resources.edit_file_30px;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(108, 231);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(108, 37);
            this.btnEdit.TabIndex = 42;
            this.btnEdit.Text = "កែសម្រួល";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.Color.Transparent;
            this.btnAddNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNew.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddNew.Image = global::PMS_ISAD.Properties.Resources.add_30px;
            this.btnAddNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNew.Location = new System.Drawing.Point(12, 231);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(90, 37);
            this.btnAddNew.TabIndex = 41;
            this.btnAddNew.Text = "បន្ថែមថ្មី";
            this.btnAddNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // txtSearch
            // 
            //this.txtSearch.AcceptsReturn = false;
            //this.txtSearch.AcceptsTab = false;
            //this.txtSearch.AnimationSpeed = 200;
            //this.txtSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            //this.txtSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            //this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            //this.txtSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtSearch.BackgroundImage")));
            //this.txtSearch.BorderColorActive = System.Drawing.Color.DodgerBlue;
            //this.txtSearch.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            //this.txtSearch.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            //this.txtSearch.BorderColorIdle = System.Drawing.Color.Silver;
            //this.txtSearch.BorderRadius = 12;
            //this.txtSearch.BorderThickness = 1;
            //this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            //this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            //this.txtSearch.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            //this.txtSearch.DefaultText = "";
            //this.txtSearch.FillColor = System.Drawing.Color.White;
            //this.txtSearch.HideSelection = true;
            //this.txtSearch.IconLeft = null;
            //this.txtSearch.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            //this.txtSearch.IconPadding = 4;
            //this.txtSearch.IconRight = null;
            //this.txtSearch.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            //this.txtSearch.Lines = new string[0];
            //this.txtSearch.Location = new System.Drawing.Point(445, 231);
            //this.txtSearch.MaxLength = 32767;
            //this.txtSearch.MinimumSize = new System.Drawing.Size(1, 1);
            //this.txtSearch.Modified = false;
            //this.txtSearch.Multiline = false;
            //this.txtSearch.Name = "txtSearch";
            //stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            //stateProperties1.FillColor = System.Drawing.Color.Empty;
            //stateProperties1.ForeColor = System.Drawing.Color.Empty;
            //stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            //this.txtSearch.OnActiveState = stateProperties1;
            //stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            //stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            //stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            //stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            //this.txtSearch.OnDisabledState = stateProperties2;
            //stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            //stateProperties3.FillColor = System.Drawing.Color.Empty;
            //stateProperties3.ForeColor = System.Drawing.Color.Empty;
            //stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            //this.txtSearch.OnHoverState = stateProperties3;
            //stateProperties4.BorderColor = System.Drawing.Color.Silver;
            //stateProperties4.FillColor = System.Drawing.Color.White;
            //stateProperties4.ForeColor = System.Drawing.Color.Empty;
            //stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            //this.txtSearch.OnIdleState = stateProperties4;
            //this.txtSearch.Padding = new System.Windows.Forms.Padding(3);
            //this.txtSearch.PasswordChar = '\0';
            //this.txtSearch.PlaceholderForeColor = System.Drawing.Color.Silver;
            //this.txtSearch.PlaceholderText = "Enter text";
            //this.txtSearch.ReadOnly = false;
            //this.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            //this.txtSearch.SelectedText = "";
            //this.txtSearch.SelectionLength = 0;
            //this.txtSearch.SelectionStart = 0;
            //this.txtSearch.ShortcutsEnabled = true;
            //this.txtSearch.Size = new System.Drawing.Size(258, 37);
            //this.txtSearch.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            //this.txtSearch.TabIndex = 34;
            //this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            //this.txtSearch.TextMarginBottom = 0;
            //this.txtSearch.TextMarginLeft = 3;
            //this.txtSearch.TextMarginTop = 0;
            //this.txtSearch.TextPlaceholder = "Enter text";
            //this.txtSearch.UseSystemPasswordChar = false;
            //this.txtSearch.WordWrap = true;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnExit.Image = global::PMS_ISAD.Properties.Resources.close_window_30px;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(701, 9);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(98, 32);
            this.btnExit.TabIndex = 25;
            this.btnExit.Text = "ចាកចេញ";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.button4_Click);
            // 
            // bunifuPanel1
            // 
            //this.bunifuPanel1.BackgroundColor = System.Drawing.Color.Transparent;
            //this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            //this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            //this.bunifuPanel1.BorderColor = System.Drawing.Color.Gray;
            //this.bunifuPanel1.BorderRadius = 8;
            //this.bunifuPanel1.BorderThickness = 2;
            //this.bunifuPanel1.Controls.Add(this.picStaff);
            //this.bunifuPanel1.Controls.Add(this.label2);
            //this.bunifuPanel1.Controls.Add(this.label4);
            //this.bunifuPanel1.Controls.Add(this.txtID);
            //this.bunifuPanel1.Controls.Add(this.label3);
            //this.bunifuPanel1.Controls.Add(this.txtName);
            //this.bunifuPanel1.Controls.Add(this.dtpDOB);
            //this.bunifuPanel1.Controls.Add(this.label5);
            //this.bunifuPanel1.Controls.Add(this.label6);
            //this.bunifuPanel1.Controls.Add(this.txtPosition);
            //this.bunifuPanel1.Controls.Add(this.rdbtnMale);
            //this.bunifuPanel1.Controls.Add(this.rdbtnFemale);
            //this.bunifuPanel1.Controls.Add(this.label7);
            //this.bunifuPanel1.Controls.Add(this.txtSalary);
            //this.bunifuPanel1.Controls.Add(this.label8);
            //this.bunifuPanel1.Controls.Add(this.chbStop);
            //this.bunifuPanel1.Location = new System.Drawing.Point(11, 61);
            //this.bunifuPanel1.Name = "bunifuPanel1";
            //this.bunifuPanel1.ShowBorders = true;
            //this.bunifuPanel1.Size = new System.Drawing.Size(788, 164);
            //this.bunifuPanel1.TabIndex = 31;
            // 
            // picStaff
            // 
            this.picStaff.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picStaff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picStaff.Image = global::PMS_ISAD.Properties.Resources.person_48px;
            this.picStaff.Location = new System.Drawing.Point(13, 12);
            this.picStaff.Name = "picStaff";
            this.picStaff.Size = new System.Drawing.Size(120, 140);
            this.picStaff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picStaff.TabIndex = 34;
            this.picStaff.TabStop = false;
            this.picStaff.Click += new System.EventHandler(this.picStaff_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "លេខសម្គាល់";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 24);
            this.label4.TabIndex = 33;
            this.label4.Text = "ថ្ងៃកំណើត";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(223, 14);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(95, 32);
            this.txtID.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 24);
            this.label3.TabIndex = 32;
            this.label3.Text = "ឈ្មោះ";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(223, 50);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(203, 32);
            this.txtName.TabIndex = 5;
            // 
            // dtpDOB
            // 
            //this.dtpDOB.BackColor = System.Drawing.Color.Transparent;
            //this.dtpDOB.BorderRadius = 5;
            //this.dtpDOB.Color = System.Drawing.Color.Silver;
            //this.dtpDOB.CustomFormat = "dd-MM-yyyy";
            //this.dtpDOB.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            //this.dtpDOB.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            //this.dtpDOB.DisabledColor = System.Drawing.Color.Gray;
            //this.dtpDOB.DisplayWeekNumbers = false;
            //this.dtpDOB.DPHeight = 0;
            //this.dtpDOB.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            //this.dtpDOB.FillDatePicker = false;
            //this.dtpDOB.Font = new System.Drawing.Font("Segoe UI", 9F);
            //this.dtpDOB.ForeColor = System.Drawing.Color.Black;
            //this.dtpDOB.Icon = ((System.Drawing.Image)(resources.GetObject("dtpDOB.Icon")));
            //this.dtpDOB.IconColor = System.Drawing.Color.Gray;
            //this.dtpDOB.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            //this.dtpDOB.LeftTextMargin = 5;
            //this.dtpDOB.Location = new System.Drawing.Point(223, 88);
            //this.dtpDOB.MinDate = new System.DateTime(1960, 1, 1, 0, 0, 0, 0);
            //this.dtpDOB.MinimumSize = new System.Drawing.Size(4, 32);
            //this.dtpDOB.Name = "dtpDOB";
            //this.dtpDOB.Size = new System.Drawing.Size(203, 32);
            //this.dtpDOB.TabIndex = 30;
            //this.dtpDOB.Value = new System.DateTime(2025, 5, 18, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(141, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 24);
            this.label5.TabIndex = 8;
            this.label5.Text = "ភេទ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(463, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 24);
            this.label6.TabIndex = 13;
            this.label6.Text = "មុខតំណែង";
            // 
            // txtPosition
            // 
            this.txtPosition.Location = new System.Drawing.Point(545, 14);
            this.txtPosition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(203, 32);
            this.txtPosition.TabIndex = 14;
            // 
            // rdbtnMale
            // 
            this.rdbtnMale.AutoSize = true;
            this.rdbtnMale.Location = new System.Drawing.Point(223, 122);
            this.rdbtnMale.Name = "rdbtnMale";
            this.rdbtnMale.Size = new System.Drawing.Size(54, 28);
            this.rdbtnMale.TabIndex = 16;
            this.rdbtnMale.TabStop = true;
            this.rdbtnMale.Text = "ប្រស";
            this.rdbtnMale.UseVisualStyleBackColor = true;
            // 
            // rdbtnFemale
            // 
            this.rdbtnFemale.AutoSize = true;
            this.rdbtnFemale.Location = new System.Drawing.Point(287, 122);
            this.rdbtnFemale.Name = "rdbtnFemale";
            this.rdbtnFemale.Size = new System.Drawing.Size(45, 28);
            this.rdbtnFemale.TabIndex = 17;
            this.rdbtnFemale.TabStop = true;
            this.rdbtnFemale.Text = "ស្រី";
            this.rdbtnFemale.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(463, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 24);
            this.label7.TabIndex = 18;
            this.label7.Text = "ប្រាក់ខែ";
            // 
            // txtSalary
            // 
            this.txtSalary.Location = new System.Drawing.Point(545, 50);
            this.txtSalary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSalary.Name = "txtSalary";
            this.txtSalary.Size = new System.Drawing.Size(203, 32);
            this.txtSalary.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(463, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 24);
            this.label8.TabIndex = 21;
            this.label8.Text = "ឈប់ធ្វើការ";
            // 
            // chbStop
            // 
            this.chbStop.AutoSize = true;
            this.chbStop.Location = new System.Drawing.Point(545, 94);
            this.chbStop.Name = "chbStop";
            this.chbStop.Size = new System.Drawing.Size(15, 14);
            this.chbStop.TabIndex = 20;
            this.chbStop.UseVisualStyleBackColor = true;
            // 
            // frmStaffs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(814, 496);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAddNew);
            //this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvStaff);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            //this.Controls.Add(this.bunifuPanel1);
            this.Font = new System.Drawing.Font("Khmer OS Battambang", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStaffs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Staff";
            this.Load += new System.EventHandler(this.StaffForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
            //this.bunifuPanel1.ResumeLayout(false);
            //this.bunifuPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStaff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rdbtnMale;
        private System.Windows.Forms.RadioButton rdbtnFemale;
        private System.Windows.Forms.TextBox txtSalary;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chbStop;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnExit;
        //private Bunifu.UI.WinForms.BunifuDatePicker dtpDOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn staffIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn genDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dobDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salaryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn stopworkDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn photoDataGridViewImageColumn;
        //private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox picStaff;
        private System.Windows.Forms.DataGridView dgvStaff;
        //private Bunifu.UI.WinForms.BunifuTextBox txtSearch;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
    }
}