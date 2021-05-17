namespace SaleMTInterfaces.FrmSaleManagement
{
    partial class frmExportDiscountVoucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExportDiscountVoucher));
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbxDanhSachKH = new System.Windows.Forms.GroupBox();
            this.lvwCustomers = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbxTimKiem = new System.Windows.Forms.GroupBox();
            this.btnDiscountVoucherSearch = new System.Windows.Forms.Button();
            this.chkDiscountVoucher = new System.Windows.Forms.CheckBox();
            this.txtDiscountVoucherSear = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dtpTimeExport = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpDateExport = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txtInvoicesCode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtExportVoucher = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.gbxThongTin = new System.Windows.Forms.GroupBox();
            this.lsvM = new System.Windows.Forms.ListView();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtIdentityCard = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPlaces = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtDateOfBirth = new System.Windows.Forms.TextBox();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gbxDanhSachPhieu = new System.Windows.Forms.GroupBox();
            this.lvwVouchers = new System.Windows.Forms.ListView();
            this.gbxDanhSachXuatPhieu = new System.Windows.Forms.GroupBox();
            this.lvwExportVoucher = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.gbxDanhSachKH.SuspendLayout();
            this.gbxTimKiem.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbxThongTin.SuspendLayout();
            this.panel3.SuspendLayout();
            this.gbxDanhSachPhieu.SuspendLayout();
            this.gbxDanhSachXuatPhieu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.gbxDanhSachKH);
            this.panel1.Controls.Add(this.gbxTimKiem);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 568);
            this.panel1.TabIndex = 21;
            // 
            // gbxDanhSachKH
            // 
            this.gbxDanhSachKH.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbxDanhSachKH.Controls.Add(this.lvwCustomers);
            this.gbxDanhSachKH.Location = new System.Drawing.Point(5, 71);
            this.gbxDanhSachKH.Name = "gbxDanhSachKH";
            this.gbxDanhSachKH.Size = new System.Drawing.Size(338, 495);
            this.gbxDanhSachKH.TabIndex = 4;
            this.gbxDanhSachKH.TabStop = false;
            this.gbxDanhSachKH.Text = "Danh sách khách hàng";
            // 
            // lvwCustomers
            // 
            this.lvwCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lvwCustomers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwCustomers.Location = new System.Drawing.Point(7, 19);
            this.lvwCustomers.Name = "lvwCustomers";
            this.lvwCustomers.Size = new System.Drawing.Size(325, 470);
            this.lvwCustomers.TabIndex = 0;
            this.lvwCustomers.UseCompatibleStateImageBehavior = false;
            this.lvwCustomers.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã KH";
            this.columnHeader1.Width = 104;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên";
            this.columnHeader2.Width = 119;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Họ";
            // 
            // gbxTimKiem
            // 
            this.gbxTimKiem.Controls.Add(this.btnDiscountVoucherSearch);
            this.gbxTimKiem.Controls.Add(this.chkDiscountVoucher);
            this.gbxTimKiem.Controls.Add(this.txtDiscountVoucherSear);
            this.gbxTimKiem.Location = new System.Drawing.Point(5, 6);
            this.gbxTimKiem.Name = "gbxTimKiem";
            this.gbxTimKiem.Size = new System.Drawing.Size(338, 61);
            this.gbxTimKiem.TabIndex = 3;
            this.gbxTimKiem.TabStop = false;
            this.gbxTimKiem.Text = "Tìm nhanh";
            // 
            // btnDiscountVoucherSearch
            // 
            this.btnDiscountVoucherSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnDiscountVoucherSearch.Image")));
            this.btnDiscountVoucherSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDiscountVoucherSearch.Location = new System.Drawing.Point(256, 23);
            this.btnDiscountVoucherSearch.Name = "btnDiscountVoucherSearch";
            this.btnDiscountVoucherSearch.Size = new System.Drawing.Size(75, 25);
            this.btnDiscountVoucherSearch.TabIndex = 2;
            this.btnDiscountVoucherSearch.Text = "Tìm";
            this.btnDiscountVoucherSearch.UseVisualStyleBackColor = true;
            // 
            // chkDiscountVoucher
            // 
            this.chkDiscountVoucher.AutoSize = true;
            this.chkDiscountVoucher.Location = new System.Drawing.Point(235, 27);
            this.chkDiscountVoucher.Name = "chkDiscountVoucher";
            this.chkDiscountVoucher.Size = new System.Drawing.Size(15, 14);
            this.chkDiscountVoucher.TabIndex = 1;
            this.chkDiscountVoucher.UseVisualStyleBackColor = true;
            // 
            // txtDiscountVoucherSear
            // 
            this.txtDiscountVoucherSear.Location = new System.Drawing.Point(10, 25);
            this.txtDiscountVoucherSear.Name = "txtDiscountVoucherSear";
            this.txtDiscountVoucherSear.Size = new System.Drawing.Size(179, 22);
            this.txtDiscountVoucherSear.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.txtNote);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.dtpTimeExport);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.dtpDateExport);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtInvoicesCode);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtExportVoucher);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.gbxThongTin);
            this.panel2.Location = new System.Drawing.Point(351, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(909, 220);
            this.panel2.TabIndex = 22;
            // 
            // txtNote
            // 
            this.txtNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNote.Location = new System.Drawing.Point(387, 160);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.ReadOnly = true;
            this.txtNote.Size = new System.Drawing.Size(517, 57);
            this.txtNote.TabIndex = 31;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(306, 164);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 16);
            this.label13.TabIndex = 30;
            this.label13.Text = "Ghi chú";
            // 
            // dtpTimeExport
            // 
            this.dtpTimeExport.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTimeExport.Location = new System.Drawing.Point(589, 136);
            this.dtpTimeExport.Name = "dtpTimeExport";
            this.dtpTimeExport.Size = new System.Drawing.Size(101, 22);
            this.dtpTimeExport.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(523, 139);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 16);
            this.label11.TabIndex = 28;
            this.label11.Text = "Giờ xuất";
            // 
            // dtpDateExport
            // 
            this.dtpDateExport.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateExport.Location = new System.Drawing.Point(387, 136);
            this.dtpDateExport.Name = "dtpDateExport";
            this.dtpDateExport.Size = new System.Drawing.Size(131, 22);
            this.dtpDateExport.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(306, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 16);
            this.label9.TabIndex = 26;
            this.label9.Text = "Ngày xuất";
            // 
            // txtInvoicesCode
            // 
            this.txtInvoicesCode.Location = new System.Drawing.Point(108, 160);
            this.txtInvoicesCode.Name = "txtInvoicesCode";
            this.txtInvoicesCode.Size = new System.Drawing.Size(194, 22);
            this.txtInvoicesCode.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 164);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 16);
            this.label10.TabIndex = 24;
            this.label10.Text = "Mã hóa đơn";
            // 
            // txtExportVoucher
            // 
            this.txtExportVoucher.Location = new System.Drawing.Point(108, 135);
            this.txtExportVoucher.Name = "txtExportVoucher";
            this.txtExportVoucher.ReadOnly = true;
            this.txtExportVoucher.Size = new System.Drawing.Size(194, 22);
            this.txtExportVoucher.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 139);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 16);
            this.label8.TabIndex = 22;
            this.label8.Text = "Mã xuất phiếu";
            // 
            // gbxThongTin
            // 
            this.gbxThongTin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxThongTin.Controls.Add(this.lsvM);
            this.gbxThongTin.Controls.Add(this.txtEmail);
            this.gbxThongTin.Controls.Add(this.txtIdentityCard);
            this.gbxThongTin.Controls.Add(this.txtCustomerName);
            this.gbxThongTin.Controls.Add(this.label7);
            this.gbxThongTin.Controls.Add(this.label6);
            this.gbxThongTin.Controls.Add(this.label5);
            this.gbxThongTin.Controls.Add(this.txtPlaces);
            this.gbxThongTin.Controls.Add(this.txtPhoneNumber);
            this.gbxThongTin.Controls.Add(this.txtDateOfBirth);
            this.gbxThongTin.Controls.Add(this.txtCustomerCode);
            this.gbxThongTin.Controls.Add(this.label4);
            this.gbxThongTin.Controls.Add(this.label3);
            this.gbxThongTin.Controls.Add(this.label2);
            this.gbxThongTin.Controls.Add(this.label1);
            this.gbxThongTin.Location = new System.Drawing.Point(5, 6);
            this.gbxThongTin.Name = "gbxThongTin";
            this.gbxThongTin.Size = new System.Drawing.Size(899, 126);
            this.gbxThongTin.TabIndex = 21;
            this.gbxThongTin.TabStop = false;
            // 
            // lsvM
            // 
            this.lsvM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvM.Location = new System.Drawing.Point(797, 14);
            this.lsvM.Name = "lsvM";
            this.lsvM.Size = new System.Drawing.Size(96, 104);
            this.lsvM.TabIndex = 14;
            this.lsvM.UseCompatibleStateImageBehavior = false;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(318, 71);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(473, 22);
            this.txtEmail.TabIndex = 13;
            // 
            // txtIdentityCard
            // 
            this.txtIdentityCard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdentityCard.Location = new System.Drawing.Point(318, 46);
            this.txtIdentityCard.Name = "txtIdentityCard";
            this.txtIdentityCard.ReadOnly = true;
            this.txtIdentityCard.Size = new System.Drawing.Size(473, 22);
            this.txtIdentityCard.TabIndex = 12;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerName.Location = new System.Drawing.Point(318, 22);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(473, 22);
            this.txtCustomerName.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(242, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(242, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Số CMND";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(242, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Họ tên";
            // 
            // txtPlaces
            // 
            this.txtPlaces.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlaces.Location = new System.Drawing.Point(103, 96);
            this.txtPlaces.Name = "txtPlaces";
            this.txtPlaces.ReadOnly = true;
            this.txtPlaces.Size = new System.Drawing.Size(688, 22);
            this.txtPlaces.TabIndex = 7;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(103, 70);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.ReadOnly = true;
            this.txtPhoneNumber.Size = new System.Drawing.Size(135, 22);
            this.txtPhoneNumber.TabIndex = 6;
            // 
            // txtDateOfBirth
            // 
            this.txtDateOfBirth.Location = new System.Drawing.Point(103, 45);
            this.txtDateOfBirth.Name = "txtDateOfBirth";
            this.txtDateOfBirth.ReadOnly = true;
            this.txtDateOfBirth.Size = new System.Drawing.Size(135, 22);
            this.txtDateOfBirth.TabIndex = 5;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Location = new System.Drawing.Point(103, 20);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.ReadOnly = true;
            this.txtCustomerCode.Size = new System.Drawing.Size(135, 22);
            this.txtCustomerCode.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nơi tạo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Điện thoại";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày sinh";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã KH";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.gbxDanhSachPhieu);
            this.panel3.Controls.Add(this.gbxDanhSachXuatPhieu);
            this.panel3.Location = new System.Drawing.Point(351, 221);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(909, 348);
            this.panel3.TabIndex = 23;
            // 
            // gbxDanhSachPhieu
            // 
            this.gbxDanhSachPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxDanhSachPhieu.Controls.Add(this.lvwVouchers);
            this.gbxDanhSachPhieu.Location = new System.Drawing.Point(380, 4);
            this.gbxDanhSachPhieu.Name = "gbxDanhSachPhieu";
            this.gbxDanhSachPhieu.Size = new System.Drawing.Size(523, 341);
            this.gbxDanhSachPhieu.TabIndex = 14;
            this.gbxDanhSachPhieu.TabStop = false;
            this.gbxDanhSachPhieu.Text = "Danh sách phiếu";
            // 
            // lvwVouchers
            // 
            this.lvwVouchers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwVouchers.Location = new System.Drawing.Point(7, 20);
            this.lvwVouchers.Name = "lvwVouchers";
            this.lvwVouchers.Size = new System.Drawing.Size(510, 313);
            this.lvwVouchers.TabIndex = 0;
            this.lvwVouchers.UseCompatibleStateImageBehavior = false;
            // 
            // gbxDanhSachXuatPhieu
            // 
            this.gbxDanhSachXuatPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbxDanhSachXuatPhieu.Controls.Add(this.lvwExportVoucher);
            this.gbxDanhSachXuatPhieu.Location = new System.Drawing.Point(5, 3);
            this.gbxDanhSachXuatPhieu.Name = "gbxDanhSachXuatPhieu";
            this.gbxDanhSachXuatPhieu.Size = new System.Drawing.Size(369, 342);
            this.gbxDanhSachXuatPhieu.TabIndex = 13;
            this.gbxDanhSachXuatPhieu.TabStop = false;
            this.gbxDanhSachXuatPhieu.Text = "Danh sách xuất phiếu giảm giá";
            // 
            // lvwExportVoucher
            // 
            this.lvwExportVoucher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lvwExportVoucher.Location = new System.Drawing.Point(7, 21);
            this.lvwExportVoucher.Name = "lvwExportVoucher";
            this.lvwExportVoucher.Size = new System.Drawing.Size(356, 313);
            this.lvwExportVoucher.TabIndex = 0;
            this.lvwExportVoucher.UseCompatibleStateImageBehavior = false;
            // 
            // frmExportDiscountVoucher
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1262, 573);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Name = "frmExportDiscountVoucher";
            this.Text = "Xuất phiếu giảm giá";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.gbxDanhSachKH.ResumeLayout(false);
            this.gbxTimKiem.ResumeLayout(false);
            this.gbxTimKiem.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gbxThongTin.ResumeLayout(false);
            this.gbxThongTin.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.gbxDanhSachPhieu.ResumeLayout(false);
            this.gbxDanhSachXuatPhieu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbxDanhSachKH;
        private System.Windows.Forms.ListView lvwCustomers;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox gbxTimKiem;
        private System.Windows.Forms.Button btnDiscountVoucherSearch;
        private System.Windows.Forms.CheckBox chkDiscountVoucher;
        private System.Windows.Forms.TextBox txtDiscountVoucherSear;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtpTimeExport;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpDateExport;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtInvoicesCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtExportVoucher;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox gbxThongTin;
        private System.Windows.Forms.ListView lsvM;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtIdentityCard;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPlaces;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.TextBox txtDateOfBirth;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox gbxDanhSachPhieu;
        private System.Windows.Forms.ListView lvwVouchers;
        private System.Windows.Forms.GroupBox gbxDanhSachXuatPhieu;
        private System.Windows.Forms.ListView lvwExportVoucher;

    }
}