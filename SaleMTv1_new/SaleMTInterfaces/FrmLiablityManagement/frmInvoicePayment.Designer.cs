namespace SaleMTInterfaces.FrmLiablityManagement
{
    partial class frmInvoicePayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInvoicePayment));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label28 = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.label27 = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label42 = new System.Windows.Forms.Label();
            this.btnPaymentSearch = new System.Windows.Forms.Button();
            this.gbxDanhSach = new System.Windows.Forms.GroupBox();
            this.dgvpayment = new System.Windows.Forms.DataGridView();
            this.MaTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MASTER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxChiTietTT = new System.Windows.Forms.GroupBox();
            this.dgvDetailPayment = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoNoiBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTienDaThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTienconLai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxThanhToanHD = new System.Windows.Forms.GroupBox();
            this.dgvPaymentInvoince = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MASTERNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sSoThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.gbxDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvpayment)).BeginInit();
            this.gbxChiTietTT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailPayment)).BeginInit();
            this.gbxThanhToanHD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentInvoince)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Gainsboro;
            this.label28.Dock = System.Windows.Forms.DockStyle.Top;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(0, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(345, 23);
            this.label28.TabIndex = 139;
            this.label28.Text = "Các lần thanh toán";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
            this.dtpDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(85, 32);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.ShowCheckBox = true;
            this.dtpDateTo.Size = new System.Drawing.Size(112, 22);
            this.dtpDateTo.TabIndex = 143;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(10, 35);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(65, 16);
            this.label27.TabIndex = 142;
            this.label27.Text = "Đến ngày";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
            this.dtpDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(85, 9);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.ShowCheckBox = true;
            this.dtpDateFrom.Size = new System.Drawing.Size(112, 22);
            this.dtpDateFrom.TabIndex = 141;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(10, 12);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(57, 16);
            this.label42.TabIndex = 140;
            this.label42.Text = "Từ ngày";
            // 
            // btnPaymentSearch
            // 
            this.btnPaymentSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaymentSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnPaymentSearch.Image")));
            this.btnPaymentSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPaymentSearch.Location = new System.Drawing.Point(221, 28);
            this.btnPaymentSearch.Name = "btnPaymentSearch";
            this.btnPaymentSearch.Size = new System.Drawing.Size(86, 24);
            this.btnPaymentSearch.TabIndex = 144;
            this.btnPaymentSearch.Text = "Tìm kiếm";
            this.btnPaymentSearch.UseVisualStyleBackColor = true;
            this.btnPaymentSearch.Click += new System.EventHandler(this.btnPaymentSearch_Click);
            // 
            // gbxDanhSach
            // 
            this.gbxDanhSach.Controls.Add(this.dgvpayment);
            this.gbxDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxDanhSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDanhSach.Location = new System.Drawing.Point(10, 0);
            this.gbxDanhSach.Name = "gbxDanhSach";
            this.gbxDanhSach.Size = new System.Drawing.Size(329, 415);
            this.gbxDanhSach.TabIndex = 145;
            this.gbxDanhSach.TabStop = false;
            this.gbxDanhSach.Text = "Danh sách thanh toán";
            // 
            // dgvpayment
            // 
            this.dgvpayment.AllowUserToAddRows = false;
            this.dgvpayment.AllowUserToDeleteRows = false;
            this.dgvpayment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvpayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvpayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaTT,
            this.Ngay,
            this.MASTER_NAME});
            this.dgvpayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvpayment.Location = new System.Drawing.Point(3, 18);
            this.dgvpayment.Name = "dgvpayment";
            this.dgvpayment.ReadOnly = true;
            this.dgvpayment.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvpayment.Size = new System.Drawing.Size(323, 394);
            this.dgvpayment.TabIndex = 0;
            this.dgvpayment.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvpayment_DataBindingComplete);
            this.dgvpayment.SelectionChanged += new System.EventHandler(this.dgvpayment_SelectionChanged);
            // 
            // MaTT
            // 
            this.MaTT.DataPropertyName = "MaTT";
            this.MaTT.HeaderText = "Mã";
            this.MaTT.Name = "MaTT";
            this.MaTT.ReadOnly = true;
            this.MaTT.Width = 52;
            // 
            // Ngay
            // 
            this.Ngay.DataPropertyName = "Ngay";
            dataGridViewCellStyle1.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate + " " + SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptHour;
            this.Ngay.DefaultCellStyle = dataGridViewCellStyle1;
            this.Ngay.HeaderText = "Ngày";
            this.Ngay.Name = "Ngay";
            this.Ngay.ReadOnly = true;
            this.Ngay.Width = 66;
            // 
            // MASTER_NAME
            // 
            this.MASTER_NAME.DataPropertyName = "MASTER_NAME";
            this.MASTER_NAME.HeaderText = "Loại";
            this.MASTER_NAME.Name = "MASTER_NAME";
            this.MASTER_NAME.ReadOnly = true;
            this.MASTER_NAME.Width = 59;
            // 
            // gbxChiTietTT
            // 
            this.gbxChiTietTT.Controls.Add(this.dgvDetailPayment);
            this.gbxChiTietTT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxChiTietTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxChiTietTT.Location = new System.Drawing.Point(0, 0);
            this.gbxChiTietTT.Name = "gbxChiTietTT";
            this.gbxChiTietTT.Size = new System.Drawing.Size(814, 247);
            this.gbxChiTietTT.TabIndex = 146;
            this.gbxChiTietTT.TabStop = false;
            this.gbxChiTietTT.Text = "Chi tiết thanh toán";
            // 
            // dgvDetailPayment
            // 
            this.dgvDetailPayment.AllowUserToAddRows = false;
            this.dgvDetailPayment.AllowUserToDeleteRows = false;
            this.dgvDetailPayment.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetailPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetailPayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.SoPO,
            this.SoNoiBo,
            this.NgayHD,
            this.NgayTT,
            this.SoTien,
            this.SoThanhToan,
            this.SoTienDaThanhToan,
            this.SoTienconLai});
            this.dgvDetailPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetailPayment.Location = new System.Drawing.Point(3, 18);
            this.dgvDetailPayment.Name = "dgvDetailPayment";
            this.dgvDetailPayment.ReadOnly = true;
            this.dgvDetailPayment.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvDetailPayment.Size = new System.Drawing.Size(808, 226);
            this.dgvDetailPayment.TabIndex = 0;
            this.dgvDetailPayment.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDetailPayment_CellFormatting);
            this.dgvDetailPayment.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDetailPayment_DataBindingComplete);
            this.dgvDetailPayment.SelectionChanged += new System.EventHandler(this.dgvDetailPayment_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "SoHD";
            this.Column1.HeaderText = "Số hóa đơn";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 80;
            // 
            // SoPO
            // 
            this.SoPO.DataPropertyName = "SoPO";
            this.SoPO.HeaderText = "Số PO";
            this.SoPO.Name = "SoPO";
            this.SoPO.ReadOnly = true;
            this.SoPO.Width = 80;
            // 
            // SoNoiBo
            // 
            this.SoNoiBo.DataPropertyName = "SoNoiBo";
            this.SoNoiBo.HeaderText = "Sô nội bộ";
            this.SoNoiBo.Name = "SoNoiBo";
            this.SoNoiBo.ReadOnly = true;
            this.SoNoiBo.Width = 80;
            // 
            // NgayHD
            // 
            this.NgayHD.DataPropertyName = "NgayHD";
            this.NgayHD.HeaderText = "Ngày hóa đơn";
            this.NgayHD.Name = "NgayHD";
            this.NgayHD.ReadOnly = true;
            this.NgayHD.Width = 120;
            // 
            // NgayTT
            // 
            this.NgayTT.DataPropertyName = "NgayTT";
            dataGridViewCellStyle2.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
            this.NgayTT.DefaultCellStyle = dataGridViewCellStyle2;
            this.NgayTT.HeaderText = "Ngày đến hạn";
            this.NgayTT.Name = "NgayTT";
            this.NgayTT.ReadOnly = true;
            this.NgayTT.Width = 120;
            // 
            // SoTien
            // 
            this.SoTien.DataPropertyName = "SoTien";
            this.SoTien.HeaderText = "Số tiền";
            this.SoTien.Name = "SoTien";
            this.SoTien.ReadOnly = true;
            // 
            // SoThanhToan
            // 
            this.SoThanhToan.DataPropertyName = "SoThanhToan";
            this.SoThanhToan.HeaderText = "Thanh toán";
            this.SoThanhToan.Name = "SoThanhToan";
            this.SoThanhToan.ReadOnly = true;
            // 
            // SoTienDaThanhToan
            // 
            this.SoTienDaThanhToan.DataPropertyName = "SoTienDaThanhToan";
            this.SoTienDaThanhToan.HeaderText = "TC. Đã thanh toán";
            this.SoTienDaThanhToan.Name = "SoTienDaThanhToan";
            this.SoTienDaThanhToan.ReadOnly = true;
            this.SoTienDaThanhToan.Width = 140;
            // 
            // SoTienconLai
            // 
            this.SoTienconLai.DataPropertyName = "SoTienconLai";
            this.SoTienconLai.HeaderText = "Số tiền chưa thanh toán";
            this.SoTienconLai.Name = "SoTienconLai";
            this.SoTienconLai.ReadOnly = true;
            this.SoTienconLai.Width = 150;
            // 
            // gbxThanhToanHD
            // 
            this.gbxThanhToanHD.Controls.Add(this.dgvPaymentInvoince);
            this.gbxThanhToanHD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxThanhToanHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxThanhToanHD.Location = new System.Drawing.Point(0, 0);
            this.gbxThanhToanHD.Name = "gbxThanhToanHD";
            this.gbxThanhToanHD.Size = new System.Drawing.Size(814, 252);
            this.gbxThanhToanHD.TabIndex = 147;
            this.gbxThanhToanHD.TabStop = false;
            this.gbxThanhToanHD.Text = "Chi tiết thanh toán theo HĐ";
            // 
            // dgvPaymentInvoince
            // 
            this.dgvPaymentInvoince.AllowUserToAddRows = false;
            this.dgvPaymentInvoince.AllowUserToDeleteRows = false;
            this.dgvPaymentInvoince.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaymentInvoince.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.MASTERNAME,
            this.sSoThanhToan,
            this.GhiChu});
            this.dgvPaymentInvoince.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPaymentInvoince.Location = new System.Drawing.Point(3, 18);
            this.dgvPaymentInvoince.Name = "dgvPaymentInvoince";
            this.dgvPaymentInvoince.ReadOnly = true;
            this.dgvPaymentInvoince.Size = new System.Drawing.Size(808, 231);
            this.dgvPaymentInvoince.TabIndex = 0;
            this.dgvPaymentInvoince.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPaymentInvoince_CellFormatting);
            this.dgvPaymentInvoince.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPaymentInvoince_DataBindingComplete);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "SoHD";
            this.dataGridViewTextBoxColumn1.HeaderText = "Số hóa đơn";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 94;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "NgayHD";
            dataGridViewCellStyle3.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn2.HeaderText = "Ngày hóa đơn";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 88;
            // 
            // MASTERNAME
            // 
            this.MASTERNAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.MASTERNAME.DataPropertyName = "MASTER_NAME";
            this.MASTERNAME.HeaderText = "Loại thanh toán";
            this.MASTERNAME.Name = "MASTERNAME";
            this.MASTERNAME.ReadOnly = true;
            this.MASTERNAME.Width = 113;
            // 
            // sSoThanhToan
            // 
            this.sSoThanhToan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.sSoThanhToan.DataPropertyName = "SoThanhToan";
            this.sSoThanhToan.HeaderText = "Số tiền";
            this.sSoThanhToan.Name = "sSoThanhToan";
            this.sSoThanhToan.ReadOnly = true;
            this.sSoThanhToan.Width = 69;
            // 
            // GhiChu
            // 
            this.GhiChu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.ReadOnly = true;
            this.GhiChu.Width = 71;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label28);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 505);
            this.panel1.TabIndex = 148;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gbxDanhSach);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 84);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(345, 421);
            this.panel3.TabIndex = 141;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(339, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(6, 415);
            this.panel6.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(10, 415);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(335, 6);
            this.panel5.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 421);
            this.panel4.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnPaymentSearch);
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.dtpDateFrom);
            this.panel2.Controls.Add(this.label42);
            this.panel2.Controls.Add(this.dtpDateTo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(345, 61);
            this.panel2.TabIndex = 140;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.panel11);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(345, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(820, 505);
            this.panel7.TabIndex = 149;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.gbxChiTietTT);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(814, 247);
            this.panel9.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.gbxThanhToanHD);
            this.panel8.Controls.Add(this.panel10);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 247);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(814, 258);
            this.panel8.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(0, 252);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(814, 6);
            this.panel10.TabIndex = 148;
            // 
            // panel11
            // 
            this.panel11.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel11.Location = new System.Drawing.Point(814, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(6, 505);
            this.panel11.TabIndex = 4;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // frmInvoicePayment
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1165, 505);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInvoicePayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh toán đơn hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmInvoicePayment_Load);
            this.Activated += new System.EventHandler(this.frmInvoicePayment_Activated);
            this.gbxDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvpayment)).EndInit();
            this.gbxChiTietTT.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailPayment)).EndInit();
            this.gbxThanhToanHD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentInvoince)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Button btnPaymentSearch;
        private System.Windows.Forms.GroupBox gbxDanhSach;
        private System.Windows.Forms.GroupBox gbxChiTietTT;
        private System.Windows.Forms.GroupBox gbxThanhToanHD;
        private System.Windows.Forms.DataGridView dgvPaymentInvoince;
        private System.Windows.Forms.DataGridView dgvpayment;
        private System.Windows.Forms.DataGridView dgvDetailPayment;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngay;
        private System.Windows.Forms.DataGridViewTextBoxColumn MASTER_NAME;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MASTERNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn sSoThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoNoiBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTienDaThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTienconLai;
    }
}