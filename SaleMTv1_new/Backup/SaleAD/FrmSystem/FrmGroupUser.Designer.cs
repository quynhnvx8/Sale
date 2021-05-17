namespace SaleAD.FrmSystem
{
    partial class FrmGroupUser
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGroupUser));
            this.tabUser = new System.Windows.Forms.TabControl();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.rbtGroupManagement = new System.Windows.Forms.RadioButton();
            this.rbtGroupStore = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.btnUpdateStore = new System.Windows.Forms.Button();
            this.btnCloseTabUser = new System.Windows.Forms.Button();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.btnDeleteTabUser = new System.Windows.Forms.Button();
            this.btnInsertTabUser = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvwShop = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.ACCOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnStore = new System.Windows.Forms.Button();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDateCreate = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFirtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabGroup = new System.Windows.Forms.TabPage();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.dgvGroupUser = new System.Windows.Forms.DataGridView();
            this.txtContents = new System.Windows.Forms.TextBox();
            this.txtGroupCode = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvGroupTab3 = new System.Windows.Forms.DataGridView();
            this.dgvUserTab3 = new System.Windows.Forms.DataGridView();
            this.btnStoreTab3 = new System.Windows.Forms.Button();
            this.txtSearchNameTab3 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tabUser.SuspendLayout();
            this.tabUsers.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.tabGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupUser)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupTab3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserTab3)).BeginInit();
            this.SuspendLayout();
            // 
            // tabUser
            // 
            this.tabUser.Controls.Add(this.tabUsers);
            this.tabUser.Controls.Add(this.tabGroup);
            this.tabUser.Controls.Add(this.tabPage3);
            this.tabUser.Location = new System.Drawing.Point(2, 3);
            this.tabUser.Name = "tabUser";
            this.tabUser.SelectedIndex = 0;
            this.tabUser.Size = new System.Drawing.Size(1019, 672);
            this.tabUser.TabIndex = 0;
            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.rbtGroupManagement);
            this.tabUsers.Controls.Add(this.rbtGroupStore);
            this.tabUsers.Controls.Add(this.label5);
            this.tabUsers.Controls.Add(this.btnUpdateStore);
            this.tabUsers.Controls.Add(this.btnCloseTabUser);
            this.tabUsers.Controls.Add(this.btnChangePass);
            this.tabUsers.Controls.Add(this.btnDeleteTabUser);
            this.tabUsers.Controls.Add(this.btnInsertTabUser);
            this.tabUsers.Controls.Add(this.groupBox2);
            this.tabUsers.Controls.Add(this.groupBox1);
            this.tabUsers.Controls.Add(this.txtRemark);
            this.tabUsers.Controls.Add(this.label6);
            this.tabUsers.Controls.Add(this.txtPhone);
            this.tabUsers.Controls.Add(this.label7);
            this.tabUsers.Controls.Add(this.txtDateCreate);
            this.tabUsers.Controls.Add(this.label8);
            this.tabUsers.Controls.Add(this.txtEmail);
            this.tabUsers.Controls.Add(this.label4);
            this.tabUsers.Controls.Add(this.txtLastName);
            this.tabUsers.Controls.Add(this.label3);
            this.tabUsers.Controls.Add(this.txtFirtName);
            this.tabUsers.Controls.Add(this.label2);
            this.tabUsers.Controls.Add(this.txtUserName);
            this.tabUsers.Controls.Add(this.label1);
            this.tabUsers.Location = new System.Drawing.Point(4, 25);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsers.Size = new System.Drawing.Size(1011, 643);
            this.tabUsers.TabIndex = 0;
            this.tabUsers.Text = "Người dùng";
            this.tabUsers.UseVisualStyleBackColor = true;
            // 
            // rbtGroupManagement
            // 
            this.rbtGroupManagement.AutoSize = true;
            this.rbtGroupManagement.Checked = true;
            this.rbtGroupManagement.Location = new System.Drawing.Point(737, 95);
            this.rbtGroupManagement.Name = "rbtGroupManagement";
            this.rbtGroupManagement.Size = new System.Drawing.Size(108, 20);
            this.rbtGroupManagement.TabIndex = 23;
            this.rbtGroupManagement.TabStop = true;
            this.rbtGroupManagement.Text = "Nhóm quản lý";
            this.rbtGroupManagement.UseVisualStyleBackColor = true;
            // 
            // rbtGroupStore
            // 
            this.rbtGroupStore.AutoSize = true;
            this.rbtGroupStore.Location = new System.Drawing.Point(599, 93);
            this.rbtGroupStore.Name = "rbtGroupStore";
            this.rbtGroupStore.Size = new System.Drawing.Size(120, 20);
            this.rbtGroupStore.TabIndex = 22;
            this.rbtGroupStore.Text = "Nhóm cửa hàng";
            this.rbtGroupStore.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(479, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Nhóm người dùng";
            // 
            // btnUpdateStore
            // 
            this.btnUpdateStore.Location = new System.Drawing.Point(823, 602);
            this.btnUpdateStore.Name = "btnUpdateStore";
            this.btnUpdateStore.Size = new System.Drawing.Size(179, 25);
            this.btnUpdateStore.TabIndex = 20;
            this.btnUpdateStore.Text = "Cập nhật cửa hàng";
            this.btnUpdateStore.UseVisualStyleBackColor = true;
            this.btnUpdateStore.Click += new System.EventHandler(this.btnUpdateStore_Click);
            // 
            // btnCloseTabUser
            // 
            this.btnCloseTabUser.Location = new System.Drawing.Point(333, 602);
            this.btnCloseTabUser.Name = "btnCloseTabUser";
            this.btnCloseTabUser.Size = new System.Drawing.Size(100, 28);
            this.btnCloseTabUser.TabIndex = 19;
            this.btnCloseTabUser.Text = "Đóng";
            this.btnCloseTabUser.UseVisualStyleBackColor = true;
            // 
            // btnChangePass
            // 
            this.btnChangePass.Location = new System.Drawing.Point(216, 602);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(111, 28);
            this.btnChangePass.TabIndex = 18;
            this.btnChangePass.Text = "Đổi mật khẩu";
            this.btnChangePass.UseVisualStyleBackColor = true;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // btnDeleteTabUser
            // 
            this.btnDeleteTabUser.Location = new System.Drawing.Point(110, 602);
            this.btnDeleteTabUser.Name = "btnDeleteTabUser";
            this.btnDeleteTabUser.Size = new System.Drawing.Size(100, 28);
            this.btnDeleteTabUser.TabIndex = 17;
            this.btnDeleteTabUser.Text = "Xóa";
            this.btnDeleteTabUser.UseVisualStyleBackColor = true;
            this.btnDeleteTabUser.Click += new System.EventHandler(this.btnDeleteTabUser_Click);
            // 
            // btnInsertTabUser
            // 
            this.btnInsertTabUser.Location = new System.Drawing.Point(4, 602);
            this.btnInsertTabUser.Name = "btnInsertTabUser";
            this.btnInsertTabUser.Size = new System.Drawing.Size(100, 28);
            this.btnInsertTabUser.TabIndex = 16;
            this.btnInsertTabUser.Text = "Thêm mới";
            this.btnInsertTabUser.UseVisualStyleBackColor = true;
            this.btnInsertTabUser.Click += new System.EventHandler(this.btnInsertTabUser_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvwShop);
            this.groupBox2.Location = new System.Drawing.Point(555, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(447, 469);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách cửa hàng";
            // 
            // lvwShop
            // 
            this.lvwShop.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwShop.FullRowSelect = true;
            this.lvwShop.GridLines = true;
            this.lvwShop.Location = new System.Drawing.Point(6, 21);
            this.lvwShop.MultiSelect = false;
            this.lvwShop.Name = "lvwShop";
            this.lvwShop.Size = new System.Drawing.Size(433, 442);
            this.lvwShop.TabIndex = 0;
            this.lvwShop.UseCompatibleStateImageBehavior = false;
            this.lvwShop.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Người dùng";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Cửa hàng";
            this.columnHeader2.Width = 500;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvUsers);
            this.groupBox1.Controls.Add(this.btnStore);
            this.groupBox1.Controls.Add(this.txtSearchName);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(7, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 469);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách";
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToResizeRows = false;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ACCOUNT,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            this.dgvUsers.Location = new System.Drawing.Point(7, 55);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(528, 408);
            this.dgvUsers.TabIndex = 25;
            this.dgvUsers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellDoubleClick);
            this.dgvUsers.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvUsers_DataBindingComplete);
            this.dgvUsers.SelectionChanged += new System.EventHandler(this.dgvUsers_SelectionChanged);
            // 
            // ACCOUNT
            // 
            this.ACCOUNT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ACCOUNT.DataPropertyName = "ACCOUNT";
            this.ACCOUNT.HeaderText = "Người dùng";
            this.ACCOUNT.Name = "ACCOUNT";
            this.ACCOUNT.ReadOnly = true;
            this.ACCOUNT.Width = 102;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column2.DataPropertyName = "FIRSTNAME";
            this.Column2.HeaderText = "Tên";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 57;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column3.DataPropertyName = "LASTNAME";
            this.Column3.HeaderText = "Họ";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 51;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column4.DataPropertyName = "PHONE";
            this.Column4.HeaderText = "Điện thoại";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 92;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column5.DataPropertyName = "EMAIL";
            this.Column5.HeaderText = "Email";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 67;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column6.DataPropertyName = "CREATEDATE";
            dataGridViewCellStyle1.Format = "dd/MM/yyyy HH:mm:ss";
            this.Column6.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column6.HeaderText = "Ngày tạo";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 88;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column7.DataPropertyName = "REMARK";
            this.Column7.HeaderText = "Ghi chú";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 77;
            // 
            // btnStore
            // 
            this.btnStore.Location = new System.Drawing.Point(439, 16);
            this.btnStore.Name = "btnStore";
            this.btnStore.Size = new System.Drawing.Size(96, 25);
            this.btnStore.TabIndex = 24;
            this.btnStore.Text = "Cửa hàng";
            this.btnStore.UseVisualStyleBackColor = true;
            // 
            // txtSearchName
            // 
            this.txtSearchName.Location = new System.Drawing.Point(159, 20);
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(199, 22);
            this.txtSearchName.TabIndex = 9;
            this.txtSearchName.TextChanged += new System.EventHandler(this.txtSearchName_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 16);
            this.label9.TabIndex = 8;
            this.label9.Text = "Tìm nhanh theo tên";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(596, 65);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(398, 22);
            this.txtRemark.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(479, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Ghi chú";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(596, 37);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(398, 22);
            this.txtPhone.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(479, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Điện thoại";
            // 
            // txtDateCreate
            // 
            this.txtDateCreate.Location = new System.Drawing.Point(596, 10);
            this.txtDateCreate.Name = "txtDateCreate";
            this.txtDateCreate.Size = new System.Drawing.Size(398, 22);
            this.txtDateCreate.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(479, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "Ngày tạo";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(119, 92);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(335, 22);
            this.txtEmail.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Email";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(119, 65);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(335, 22);
            this.txtLastName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Họ";
            // 
            // txtFirtName
            // 
            this.txtFirtName.Location = new System.Drawing.Point(119, 37);
            this.txtFirtName.Name = "txtFirtName";
            this.txtFirtName.Size = new System.Drawing.Size(335, 22);
            this.txtFirtName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(119, 10);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(335, 22);
            this.txtUserName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Người dùng";
            // 
            // tabGroup
            // 
            this.tabGroup.BackColor = System.Drawing.Color.Transparent;
            this.tabGroup.Controls.Add(this.btnClose);
            this.tabGroup.Controls.Add(this.btnDelete);
            this.tabGroup.Controls.Add(this.btnSave);
            this.tabGroup.Controls.Add(this.btnInsert);
            this.tabGroup.Controls.Add(this.dgvGroupUser);
            this.tabGroup.Controls.Add(this.txtContents);
            this.tabGroup.Controls.Add(this.txtGroupCode);
            this.tabGroup.Controls.Add(this.label11);
            this.tabGroup.Controls.Add(this.label10);
            this.tabGroup.Location = new System.Drawing.Point(4, 25);
            this.tabGroup.Name = "tabGroup";
            this.tabGroup.Padding = new System.Windows.Forms.Padding(3);
            this.tabGroup.Size = new System.Drawing.Size(1011, 643);
            this.tabGroup.TabIndex = 1;
            this.tabGroup.Text = "Nhóm";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(697, 607);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(608, 607);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 25);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(520, 607);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(439, 608);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 25);
            this.btnInsert.TabIndex = 5;
            this.btnInsert.Text = "Thêm mới";
            this.btnInsert.UseVisualStyleBackColor = true;
            // 
            // dgvGroupUser
            // 
            this.dgvGroupUser.BackgroundColor = System.Drawing.Color.White;
            this.dgvGroupUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroupUser.Location = new System.Drawing.Point(10, 67);
            this.dgvGroupUser.Name = "dgvGroupUser";
            this.dgvGroupUser.Size = new System.Drawing.Size(994, 529);
            this.dgvGroupUser.TabIndex = 4;
            // 
            // txtContents
            // 
            this.txtContents.Location = new System.Drawing.Point(99, 35);
            this.txtContents.Name = "txtContents";
            this.txtContents.Size = new System.Drawing.Size(592, 22);
            this.txtContents.TabIndex = 3;
            // 
            // txtGroupCode
            // 
            this.txtGroupCode.Location = new System.Drawing.Point(99, 7);
            this.txtGroupCode.Name = "txtGroupCode";
            this.txtGroupCode.Size = new System.Drawing.Size(592, 22);
            this.txtGroupCode.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 16);
            this.label11.TabIndex = 1;
            this.label11.Text = "Mô tả";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Mã nhóm";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvGroupTab3);
            this.tabPage3.Controls.Add(this.dgvUserTab3);
            this.tabPage3.Controls.Add(this.btnStoreTab3);
            this.tabPage3.Controls.Add(this.txtSearchNameTab3);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1011, 643);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Đưa người dùng vào nhóm";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvGroupTab3
            // 
            this.dgvGroupTab3.BackgroundColor = System.Drawing.Color.White;
            this.dgvGroupTab3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroupTab3.Location = new System.Drawing.Point(414, 7);
            this.dgvGroupTab3.Name = "dgvGroupTab3";
            this.dgvGroupTab3.Size = new System.Drawing.Size(590, 630);
            this.dgvGroupTab3.TabIndex = 4;
            // 
            // dgvUserTab3
            // 
            this.dgvUserTab3.BackgroundColor = System.Drawing.Color.White;
            this.dgvUserTab3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserTab3.Location = new System.Drawing.Point(10, 36);
            this.dgvUserTab3.Name = "dgvUserTab3";
            this.dgvUserTab3.Size = new System.Drawing.Size(398, 601);
            this.dgvUserTab3.TabIndex = 3;
            // 
            // btnStoreTab3
            // 
            this.btnStoreTab3.Location = new System.Drawing.Point(333, 5);
            this.btnStoreTab3.Name = "btnStoreTab3";
            this.btnStoreTab3.Size = new System.Drawing.Size(75, 25);
            this.btnStoreTab3.TabIndex = 2;
            this.btnStoreTab3.Text = "Cửa hàng";
            this.btnStoreTab3.UseVisualStyleBackColor = true;
            // 
            // txtSearchNameTab3
            // 
            this.txtSearchNameTab3.Location = new System.Drawing.Point(134, 7);
            this.txtSearchNameTab3.Name = "txtSearchNameTab3";
            this.txtSearchNameTab3.Size = new System.Drawing.Size(178, 22);
            this.txtSearchNameTab3.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 7);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Tìm nhanh theo tên";
            // 
            // FrmGroupUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 680);
            this.Controls.Add(this.tabUser);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGroupUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý người dùng và nhóm người dùng";
            this.Load += new System.EventHandler(this.FrmGroupUser_Load);
            this.tabUser.ResumeLayout(false);
            this.tabUsers.ResumeLayout(false);
            this.tabUsers.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.tabGroup.ResumeLayout(false);
            this.tabGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupUser)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupTab3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserTab3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabUser;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.TabPage tabGroup;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtFirtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDateCreate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnUpdateStore;
        private System.Windows.Forms.Button btnCloseTabUser;
        private System.Windows.Forms.Button btnChangePass;
        private System.Windows.Forms.Button btnDeleteTabUser;
        private System.Windows.Forms.Button btnInsertTabUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbtGroupManagement;
        private System.Windows.Forms.RadioButton rbtGroupStore;
        private System.Windows.Forms.Button btnStore;
        private System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.TextBox txtContents;
        private System.Windows.Forms.TextBox txtGroupCode;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvGroupUser;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnStoreTab3;
        private System.Windows.Forms.TextBox txtSearchNameTab3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgvGroupTab3;
        private System.Windows.Forms.DataGridView dgvUserTab3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ACCOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.ListView lvwShop;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}