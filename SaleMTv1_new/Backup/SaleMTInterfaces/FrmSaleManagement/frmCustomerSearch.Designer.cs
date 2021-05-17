namespace SaleMTInterfaces.FrmSaleManagement
{
    partial class frmCustomerSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerSearch));
            this.gbxTimKiem = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtAdress = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.txtPassport = new System.Windows.Forms.TextBox();
            this.txtIDNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboReligious = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboRace = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboBlood = new System.Windows.Forms.ComboBox();
            this.cboSex = new System.Windows.Forms.ComboBox();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBirthYear = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvCustomer = new System.Windows.Forms.DataGridView();
            this.clnSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnOldCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnBirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnIDNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTelephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnAdress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbPage = new System.Windows.Forms.GroupBox();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnGoPage = new System.Windows.Forms.Button();
            this.txtPageGo = new System.Windows.Forms.TextBox();
            this.lblTotalRow = new System.Windows.Forms.Label();
            this.lblPage = new System.Windows.Forms.Label();
            this.cboRowOnPage = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.gbxTimKiem.SuspendLayout();
            this.gbxDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            this.gbPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxTimKiem
            // 
            this.gbxTimKiem.Controls.Add(this.btnSearch);
            this.gbxTimKiem.Controls.Add(this.txtAdress);
            this.gbxTimKiem.Controls.Add(this.txtEmail);
            this.gbxTimKiem.Controls.Add(this.txtMobile);
            this.gbxTimKiem.Controls.Add(this.txtTel);
            this.gbxTimKiem.Controls.Add(this.txtPassport);
            this.gbxTimKiem.Controls.Add(this.txtIDNo);
            this.gbxTimKiem.Controls.Add(this.label11);
            this.gbxTimKiem.Controls.Add(this.label10);
            this.gbxTimKiem.Controls.Add(this.label9);
            this.gbxTimKiem.Controls.Add(this.label8);
            this.gbxTimKiem.Controls.Add(this.cboReligious);
            this.gbxTimKiem.Controls.Add(this.label7);
            this.gbxTimKiem.Controls.Add(this.cboRace);
            this.gbxTimKiem.Controls.Add(this.label6);
            this.gbxTimKiem.Controls.Add(this.cboBlood);
            this.gbxTimKiem.Controls.Add(this.cboSex);
            this.gbxTimKiem.Controls.Add(this.txtCustomerCode);
            this.gbxTimKiem.Controls.Add(this.label5);
            this.gbxTimKiem.Controls.Add(this.txtBirthYear);
            this.gbxTimKiem.Controls.Add(this.txtFullName);
            this.gbxTimKiem.Controls.Add(this.chkActive);
            this.gbxTimKiem.Controls.Add(this.label4);
            this.gbxTimKiem.Controls.Add(this.label3);
            this.gbxTimKiem.Controls.Add(this.label2);
            this.gbxTimKiem.Controls.Add(this.label1);
            this.gbxTimKiem.Location = new System.Drawing.Point(13, 5);
            this.gbxTimKiem.Name = "gbxTimKiem";
            this.gbxTimKiem.Size = new System.Drawing.Size(895, 141);
            this.gbxTimKiem.TabIndex = 0;
            this.gbxTimKiem.TabStop = false;
            this.gbxTimKiem.Text = "Điều kiện tìm kiếm";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(814, 112);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtAdress
            // 
            this.txtAdress.Location = new System.Drawing.Point(519, 89);
            this.txtAdress.Name = "txtAdress";
            this.txtAdress.Size = new System.Drawing.Size(370, 22);
            this.txtAdress.TabIndex = 24;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(519, 66);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(370, 22);
            this.txtEmail.TabIndex = 23;
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(704, 43);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(185, 22);
            this.txtMobile.TabIndex = 22;
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(519, 43);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(179, 22);
            this.txtTel.TabIndex = 21;
            // 
            // txtPassport
            // 
            this.txtPassport.Location = new System.Drawing.Point(704, 20);
            this.txtPassport.Name = "txtPassport";
            this.txtPassport.Size = new System.Drawing.Size(185, 22);
            this.txtPassport.TabIndex = 20;
            // 
            // txtIDNo
            // 
            this.txtIDNo.Location = new System.Drawing.Point(519, 20);
            this.txtIDNo.Name = "txtIDNo";
            this.txtIDNo.Size = new System.Drawing.Size(179, 22);
            this.txtIDNo.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(408, 94);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 16);
            this.label11.TabIndex = 18;
            this.label11.Text = "Địa chỉ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(408, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 16);
            this.label10.TabIndex = 17;
            this.label10.Text = "Địa chỉ Email";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(408, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "ĐT bàn-Di động";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(408, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "CMND-Hộ chiếu";
            // 
            // cboReligious
            // 
            this.cboReligious.FormattingEnabled = true;
            this.cboReligious.Location = new System.Drawing.Point(282, 90);
            this.cboReligious.Name = "cboReligious";
            this.cboReligious.Size = new System.Drawing.Size(111, 24);
            this.cboReligious.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(208, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Tôn giáo";
            // 
            // cboRace
            // 
            this.cboRace.FormattingEnabled = true;
            this.cboRace.Location = new System.Drawing.Point(101, 91);
            this.cboRace.Name = "cboRace";
            this.cboRace.Size = new System.Drawing.Size(100, 24);
            this.cboRace.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 11;
            this.label6.Text = "Nhóm máu";
            // 
            // cboBlood
            // 
            this.cboBlood.FormattingEnabled = true;
            this.cboBlood.Location = new System.Drawing.Point(282, 66);
            this.cboBlood.Name = "cboBlood";
            this.cboBlood.Size = new System.Drawing.Size(111, 24);
            this.cboBlood.TabIndex = 10;
            // 
            // cboSex
            // 
            this.cboSex.FormattingEnabled = true;
            this.cboSex.Location = new System.Drawing.Point(101, 66);
            this.cboSex.Name = "cboSex";
            this.cboSex.Size = new System.Drawing.Size(100, 24);
            this.cboSex.TabIndex = 9;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Location = new System.Drawing.Point(282, 43);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(111, 22);
            this.txtCustomerCode.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(208, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Mã KH";
            // 
            // txtBirthYear
            // 
            this.txtBirthYear.Location = new System.Drawing.Point(101, 43);
            this.txtBirthYear.Name = "txtBirthYear";
            this.txtBirthYear.Size = new System.Drawing.Size(100, 22);
            this.txtBirthYear.TabIndex = 6;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(101, 20);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(292, 22);
            this.txtFullName.TabIndex = 5;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(7, 118);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(193, 20);
            this.chkActive.TabIndex = 4;
            this.chkActive.Text = "Khách hàng ngưng kích hoạt";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Chủng tộc";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Giới tính";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Năm sinh";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ tên";
            // 
            // gbxDanhSach
            // 
            this.gbxDanhSach.Controls.Add(this.dgvCustomer);
            this.gbxDanhSach.Location = new System.Drawing.Point(13, 152);
            this.gbxDanhSach.Name = "gbxDanhSach";
            this.gbxDanhSach.Size = new System.Drawing.Size(895, 332);
            this.gbxDanhSach.TabIndex = 1;
            this.gbxDanhSach.TabStop = false;
            this.gbxDanhSach.Text = "Danh sách khách hàng";
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.AllowUserToAddRows = false;
            this.dgvCustomer.AllowUserToDeleteRows = false;
            this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnSTT,
            this.clnCustomerCode,
            this.clnOldCode,
            this.clnFirstName,
            this.clnLastName,
            this.clnPhoneNumber,
            this.clnBirthDate,
            this.clnIDNO,
            this.clnTelephone,
            this.clnEmail,
            this.clnAdress,
            this.clnPlace});
            this.dgvCustomer.Location = new System.Drawing.Point(7, 16);
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.ReadOnly = true;
            this.dgvCustomer.Size = new System.Drawing.Size(882, 307);
            this.dgvCustomer.TabIndex = 1;
            this.dgvCustomer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomer_CellDoubleClick);
            this.dgvCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCustomer_KeyDown);
            this.dgvCustomer.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCustomer_DataBindingComplete);
            // 
            // clnSTT
            // 
            this.clnSTT.DataPropertyName = "STT";
            this.clnSTT.HeaderText = "STT";
            this.clnSTT.Name = "clnSTT";
            this.clnSTT.ReadOnly = true;
            this.clnSTT.Visible = false;
            // 
            // clnCustomerCode
            // 
            this.clnCustomerCode.DataPropertyName = "CUSTOMER_ID";
            this.clnCustomerCode.HeaderText = "Mã KH";
            this.clnCustomerCode.Name = "clnCustomerCode";
            this.clnCustomerCode.ReadOnly = true;
            this.clnCustomerCode.Width = 120;
            // 
            // clnOldCode
            // 
            this.clnOldCode.DataPropertyName = "MACU";
            this.clnOldCode.HeaderText = "Mã cũ";
            this.clnOldCode.Name = "clnOldCode";
            this.clnOldCode.ReadOnly = true;
            // 
            // clnFirstName
            // 
            this.clnFirstName.DataPropertyName = "FIRST_NAME";
            this.clnFirstName.HeaderText = "Tên";
            this.clnFirstName.Name = "clnFirstName";
            this.clnFirstName.ReadOnly = true;
            this.clnFirstName.Width = 150;
            // 
            // clnLastName
            // 
            this.clnLastName.DataPropertyName = "LAST_NAME";
            this.clnLastName.HeaderText = "Họ";
            this.clnLastName.Name = "clnLastName";
            this.clnLastName.ReadOnly = true;
            this.clnLastName.Width = 120;
            // 
            // clnPhoneNumber
            // 
            this.clnPhoneNumber.DataPropertyName = "MOBILE_PHONE";
            this.clnPhoneNumber.HeaderText = "ĐT di động";
            this.clnPhoneNumber.Name = "clnPhoneNumber";
            this.clnPhoneNumber.ReadOnly = true;
            // 
            // clnBirthDate
            // 
            this.clnBirthDate.DataPropertyName = "DATE_OF_BIRTH";
            this.clnBirthDate.HeaderText = "Ngày sinh";
            this.clnBirthDate.Name = "clnBirthDate";
            this.clnBirthDate.ReadOnly = true;
            // 
            // clnIDNO
            // 
            this.clnIDNO.DataPropertyName = "ID_NO";
            this.clnIDNO.HeaderText = "CMND";
            this.clnIDNO.Name = "clnIDNO";
            this.clnIDNO.ReadOnly = true;
            // 
            // clnTelephone
            // 
            this.clnTelephone.DataPropertyName = "TEL";
            this.clnTelephone.HeaderText = "ĐT bàn";
            this.clnTelephone.Name = "clnTelephone";
            this.clnTelephone.ReadOnly = true;
            // 
            // clnEmail
            // 
            this.clnEmail.DataPropertyName = "EMAIL_ADDRESS";
            this.clnEmail.HeaderText = "Email";
            this.clnEmail.Name = "clnEmail";
            this.clnEmail.ReadOnly = true;
            // 
            // clnAdress
            // 
            this.clnAdress.DataPropertyName = "ADDRESS";
            this.clnAdress.HeaderText = "Địa chỉ";
            this.clnAdress.Name = "clnAdress";
            this.clnAdress.ReadOnly = true;
            this.clnAdress.Width = 200;
            // 
            // clnPlace
            // 
            this.clnPlace.DataPropertyName = "DEPT_CODE";
            this.clnPlace.HeaderText = "CH";
            this.clnPlace.Name = "clnPlace";
            this.clnPlace.ReadOnly = true;
            this.clnPlace.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(358, 539);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 26);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::SaleMTInterfaces.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(435, 539);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 26);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbPage
            // 
            this.gbPage.Controls.Add(this.btnLast);
            this.gbPage.Controls.Add(this.btnNext);
            this.gbPage.Controls.Add(this.btnPrev);
            this.gbPage.Controls.Add(this.btnFirst);
            this.gbPage.Controls.Add(this.btnGoPage);
            this.gbPage.Controls.Add(this.txtPageGo);
            this.gbPage.Controls.Add(this.lblTotalRow);
            this.gbPage.Controls.Add(this.lblPage);
            this.gbPage.Controls.Add(this.cboRowOnPage);
            this.gbPage.Controls.Add(this.label12);
            this.gbPage.Location = new System.Drawing.Point(12, 487);
            this.gbPage.Name = "gbPage";
            this.gbPage.Size = new System.Drawing.Size(896, 48);
            this.gbPage.TabIndex = 5;
            this.gbPage.TabStop = false;
            // 
            // btnLast
            // 
            this.btnLast.Image = global::SaleMTInterfaces.Properties.Resources.p2;
            this.btnLast.Location = new System.Drawing.Point(219, 16);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(31, 23);
            this.btnLast.TabIndex = 9;
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.Image = global::SaleMTInterfaces.Properties.Resources.p3;
            this.btnNext.Location = new System.Drawing.Point(192, 16);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(27, 23);
            this.btnNext.TabIndex = 8;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Image = global::SaleMTInterfaces.Properties.Resources.p1;
            this.btnPrev.Location = new System.Drawing.Point(165, 16);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(27, 23);
            this.btnPrev.TabIndex = 7;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Image = global::SaleMTInterfaces.Properties.Resources.p4;
            this.btnFirst.Location = new System.Drawing.Point(134, 16);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(31, 23);
            this.btnFirst.TabIndex = 6;
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnGoPage
            // 
            this.btnGoPage.Image = global::SaleMTInterfaces.Properties.Resources.next;
            this.btnGoPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGoPage.Location = new System.Drawing.Point(800, 15);
            this.btnGoPage.Name = "btnGoPage";
            this.btnGoPage.Size = new System.Drawing.Size(90, 25);
            this.btnGoPage.TabIndex = 5;
            this.btnGoPage.Text = "Tới trang";
            this.btnGoPage.UseVisualStyleBackColor = true;
            this.btnGoPage.Click += new System.EventHandler(this.btnGoPage_Click);
            // 
            // txtPageGo
            // 
            this.txtPageGo.Location = new System.Drawing.Point(736, 17);
            this.txtPageGo.Name = "txtPageGo";
            this.txtPageGo.Size = new System.Drawing.Size(60, 22);
            this.txtPageGo.TabIndex = 4;
            this.txtPageGo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPageGo_KeyPress);
            // 
            // lblTotalRow
            // 
            this.lblTotalRow.AutoSize = true;
            this.lblTotalRow.Location = new System.Drawing.Point(610, 20);
            this.lblTotalRow.Name = "lblTotalRow";
            this.lblTotalRow.Size = new System.Drawing.Size(64, 16);
            this.lblTotalRow.TabIndex = 3;
            this.lblTotalRow.Text = "Tổng số :";
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Location = new System.Drawing.Point(273, 20);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(44, 16);
            this.lblPage.TabIndex = 2;
            this.lblPage.Text = "Trang";
            // 
            // cboRowOnPage
            // 
            this.cboRowOnPage.FormattingEnabled = true;
            this.cboRowOnPage.Items.AddRange(new object[] {
            "20",
            "40",
            "60",
            "80",
            "100",
            "200",
            "300",
            "500",
            ""});
            this.cboRowOnPage.Location = new System.Drawing.Point(82, 16);
            this.cboRowOnPage.Name = "cboRowOnPage";
            this.cboRowOnPage.Size = new System.Drawing.Size(43, 24);
            this.cboRowOnPage.TabIndex = 1;
            this.cboRowOnPage.SelectedIndexChanged += new System.EventHandler(this.cboRowOnPage_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Dòng/ trang";
            // 
            // frmCustomerSearch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(920, 583);
            this.Controls.Add(this.gbPage);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbxDanhSach);
            this.Controls.Add(this.gbxTimKiem);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCustomerSearch";
            this.Text = "Tìm kiếm khách hàng";
            this.Load += new System.EventHandler(this.frmCustomerSearch_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCustomerSearch_FormClosed);
            this.gbxTimKiem.ResumeLayout(false);
            this.gbxTimKiem.PerformLayout();
            this.gbxDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            this.gbPage.ResumeLayout(false);
            this.gbPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxTimKiem;
        private System.Windows.Forms.TextBox txtAdress;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.TextBox txtPassport;
        private System.Windows.Forms.TextBox txtIDNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboReligious;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboRace;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboBlood;
        private System.Windows.Forms.ComboBox cboSex;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBirthYear;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbxDanhSach;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox gbPage;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnGoPage;
        private System.Windows.Forms.TextBox txtPageGo;
        private System.Windows.Forms.Label lblTotalRow;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.ComboBox cboRowOnPage;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgvCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnOldCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnBirthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnIDNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTelephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAdress;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPlace;
    }
}