namespace SaleMTInterfaces.FrmInventoryManagement
{
    partial class frmDialogImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDialogImport));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnDownloadPO = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvHangNhap = new System.Windows.Forms.DataGridView();
            this.SaleOrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvHangKhuyenMai = new System.Windows.Forms.DataGridView();
            this.SaleOrderNumberKM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCodeKM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemNameKM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceKM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityKM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountKM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitKM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPO = new System.Windows.Forms.DataGridView();
            this.POCONumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoNoiBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkDetail = new System.Windows.Forms.CheckBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvSOPO = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.txtProductList = new System.Windows.Forms.TextBox();
            this.btnProduct = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.txtSO = new System.Windows.Forms.TextBox();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleOrderNumberCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCodeCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PONO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOQuantityCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POQuantityCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SOPOCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangNhap)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangKhuyenMai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPO)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSOPO)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1198, 538);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnDownloadPO);
            this.tabPage1.Controls.Add(this.tabControl2);
            this.tabPage1.Controls.Add(this.dgvPO);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1190, 509);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "PO";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // btnDownloadPO
            // 
            this.btnDownloadPO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownloadPO.Image = ((System.Drawing.Image)(resources.GetObject("btnDownloadPO.Image")));
            this.btnDownloadPO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDownloadPO.Location = new System.Drawing.Point(1035, 6);
            this.btnDownloadPO.Name = "btnDownloadPO";
            this.btnDownloadPO.Size = new System.Drawing.Size(147, 25);
            this.btnDownloadPO.TabIndex = 2;
            this.btnDownloadPO.Text = "Tải dữ liệu từ server";
            this.btnDownloadPO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDownloadPO.UseVisualStyleBackColor = true;
            this.btnDownloadPO.Click += new System.EventHandler(this.btnDownloadPO_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(350, 34);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(840, 475);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvHangNhap);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(832, 446);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Hàng nhập";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvHangNhap
            // 
            this.dgvHangNhap.AllowUserToAddRows = false;
            this.dgvHangNhap.AllowUserToDeleteRows = false;
            this.dgvHangNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHangNhap.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvHangNhap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHangNhap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SaleOrderNumber,
            this.ItemCode,
            this.ItemName,
            this.Price,
            this.Quantity,
            this.Amount,
            this.Unit});
            this.dgvHangNhap.Location = new System.Drawing.Point(0, 0);
            this.dgvHangNhap.Name = "dgvHangNhap";
            this.dgvHangNhap.ReadOnly = true;
            this.dgvHangNhap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHangNhap.Size = new System.Drawing.Size(832, 444);
            this.dgvHangNhap.TabIndex = 0;
            // 
            // SaleOrderNumber
            // 
            this.SaleOrderNumber.DataPropertyName = "SaleOrderNumber";
            this.SaleOrderNumber.HeaderText = "SO No";
            this.SaleOrderNumber.Name = "SaleOrderNumber";
            this.SaleOrderNumber.ReadOnly = true;
            this.SaleOrderNumber.Width = 90;
            // 
            // ItemCode
            // 
            this.ItemCode.DataPropertyName = "ItemCode";
            this.ItemCode.HeaderText = "Mã sản phẩm";
            this.ItemCode.Name = "ItemCode";
            this.ItemCode.ReadOnly = true;
            // 
            // ItemName
            // 
            this.ItemName.DataPropertyName = "ItemName";
            this.ItemName.HeaderText = "Tên sản phẩm";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 180;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Giá";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 90;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Số lượng";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 80;
            // 
            // Amount
            // 
            this.Amount.DataPropertyName = "Amount";
            this.Amount.HeaderText = "Thành tiền";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            this.Amount.Width = 90;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "UNIT_NAME";
            this.Unit.HeaderText = "Unit";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            this.Unit.Visible = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvHangKhuyenMai);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(832, 446);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Hàng khuyến mãi";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvHangKhuyenMai
            // 
            this.dgvHangKhuyenMai.AllowUserToAddRows = false;
            this.dgvHangKhuyenMai.AllowUserToDeleteRows = false;
            this.dgvHangKhuyenMai.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHangKhuyenMai.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvHangKhuyenMai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHangKhuyenMai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SaleOrderNumberKM,
            this.ItemCodeKM,
            this.ItemNameKM,
            this.PriceKM,
            this.QuantityKM,
            this.AmountKM,
            this.UnitKM});
            this.dgvHangKhuyenMai.Location = new System.Drawing.Point(0, 0);
            this.dgvHangKhuyenMai.Name = "dgvHangKhuyenMai";
            this.dgvHangKhuyenMai.ReadOnly = true;
            this.dgvHangKhuyenMai.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHangKhuyenMai.Size = new System.Drawing.Size(832, 459);
            this.dgvHangKhuyenMai.TabIndex = 1;
            // 
            // SaleOrderNumberKM
            // 
            this.SaleOrderNumberKM.DataPropertyName = "SaleOrderNumber";
            this.SaleOrderNumberKM.HeaderText = "SO No";
            this.SaleOrderNumberKM.Name = "SaleOrderNumberKM";
            this.SaleOrderNumberKM.ReadOnly = true;
            this.SaleOrderNumberKM.Width = 90;
            // 
            // ItemCodeKM
            // 
            this.ItemCodeKM.DataPropertyName = "ItemCode";
            this.ItemCodeKM.HeaderText = "Mã sản phẩm";
            this.ItemCodeKM.Name = "ItemCodeKM";
            this.ItemCodeKM.ReadOnly = true;
            // 
            // ItemNameKM
            // 
            this.ItemNameKM.DataPropertyName = "ItemName";
            this.ItemNameKM.HeaderText = "Tên sản phẩm";
            this.ItemNameKM.Name = "ItemNameKM";
            this.ItemNameKM.ReadOnly = true;
            this.ItemNameKM.Width = 180;
            // 
            // PriceKM
            // 
            this.PriceKM.DataPropertyName = "Price";
            this.PriceKM.HeaderText = "Giá";
            this.PriceKM.Name = "PriceKM";
            this.PriceKM.ReadOnly = true;
            this.PriceKM.Width = 90;
            // 
            // QuantityKM
            // 
            this.QuantityKM.DataPropertyName = "Quantity";
            this.QuantityKM.HeaderText = "Số lượng";
            this.QuantityKM.Name = "QuantityKM";
            this.QuantityKM.ReadOnly = true;
            this.QuantityKM.Width = 80;
            // 
            // AmountKM
            // 
            this.AmountKM.DataPropertyName = "Amount";
            this.AmountKM.HeaderText = "Thành tiền";
            this.AmountKM.Name = "AmountKM";
            this.AmountKM.ReadOnly = true;
            this.AmountKM.Width = 90;
            // 
            // UnitKM
            // 
            this.UnitKM.DataPropertyName = "UNIT_NAME";
            this.UnitKM.HeaderText = "Unit";
            this.UnitKM.Name = "UnitKM";
            this.UnitKM.ReadOnly = true;
            this.UnitKM.Visible = false;
            // 
            // dgvPO
            // 
            this.dgvPO.AllowUserToAddRows = false;
            this.dgvPO.AllowUserToDeleteRows = false;
            this.dgvPO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvPO.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.POCONumber,
            this.SoNoiBo,
            this.OrderDate});
            this.dgvPO.Location = new System.Drawing.Point(3, 38);
            this.dgvPO.MultiSelect = false;
            this.dgvPO.Name = "dgvPO";
            this.dgvPO.ReadOnly = true;
            this.dgvPO.Size = new System.Drawing.Size(344, 465);
            this.dgvPO.TabIndex = 0;
            this.dgvPO.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvPO_RowPostPaint);
            this.dgvPO.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPO_CellClick);
            this.dgvPO.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPO_CellContentClick);
            // 
            // POCONumber
            // 
            this.POCONumber.DataPropertyName = "POCONumber";
            this.POCONumber.HeaderText = "PO No";
            this.POCONumber.Name = "POCONumber";
            this.POCONumber.ReadOnly = true;
            // 
            // SoNoiBo
            // 
            this.SoNoiBo.DataPropertyName = "SoNoiBo";
            this.SoNoiBo.HeaderText = "Số nội bộ";
            this.SoNoiBo.Name = "SoNoiBo";
            this.SoNoiBo.ReadOnly = true;
            // 
            // OrderDate
            // 
            this.OrderDate.DataPropertyName = "OrderDate";
            this.OrderDate.HeaderText = "Ngày";
            this.OrderDate.Name = "OrderDate";
            this.OrderDate.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkDetail);
            this.tabPage2.Controls.Add(this.btnSearch);
            this.tabPage2.Controls.Add(this.btnClose);
            this.tabPage2.Controls.Add(this.btnExcel);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1190, 509);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "So sánh SO - PO";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkDetail
            // 
            this.chkDetail.AutoSize = true;
            this.chkDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkDetail.Location = new System.Drawing.Point(8, 104);
            this.chkDetail.Name = "chkDetail";
            this.chkDetail.Size = new System.Drawing.Size(94, 20);
            this.chkDetail.TabIndex = 11;
            this.chkDetail.Text = "Xem chi tiết";
            this.chkDetail.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(889, 104);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 25);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1089, 104);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 25);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Enabled = false;
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(992, 104);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(94, 25);
            this.btnExcel.TabIndex = 9;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvSOPO);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox2.Location = new System.Drawing.Point(8, 131);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1174, 369);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dữ liệu khác nhau";
            // 
            // dgvSOPO
            // 
            this.dgvSOPO.AllowUserToAddRows = false;
            this.dgvSOPO.AllowUserToDeleteRows = false;
            this.dgvSOPO.AllowUserToResizeColumns = false;
            this.dgvSOPO.AllowUserToResizeRows = false;
            this.dgvSOPO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSOPO.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvSOPO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSOPO.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.SaleOrderNumberCol,
            this.ItemCodeCol,
            this.PONO,
            this.SOQuantityCol,
            this.POQuantityCol,
            this.SOPOCol,
            this.NameCol,
            this.UnitCol,
            this.PriceCol});
            this.dgvSOPO.Location = new System.Drawing.Point(6, 21);
            this.dgvSOPO.Name = "dgvSOPO";
            this.dgvSOPO.ReadOnly = true;
            this.dgvSOPO.Size = new System.Drawing.Size(1162, 339);
            this.dgvSOPO.TabIndex = 10;
            this.dgvSOPO.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvSOPO_DataBindingComplete);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.txtProduct);
            this.groupBox1.Controls.Add(this.txtProductList);
            this.groupBox1.Controls.Add(this.btnProduct);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpDateTo);
            this.groupBox1.Controls.Add(this.txtSO);
            this.groupBox1.Controls.Add(this.dtpDateFrom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1174, 97);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(1139, 64);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(29, 25);
            this.btnClear.TabIndex = 7;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtProduct
            // 
            this.txtProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtProduct.Location = new System.Drawing.Point(81, 66);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(140, 22);
            this.txtProduct.TabIndex = 4;
            this.txtProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lblProduct_KeyDown);
            // 
            // txtProductList
            // 
            this.txtProductList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProductList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtProductList.Location = new System.Drawing.Point(227, 66);
            this.txtProductList.Name = "txtProductList";
            this.txtProductList.ReadOnly = true;
            this.txtProductList.Size = new System.Drawing.Size(871, 22);
            this.txtProductList.TabIndex = 6;
            // 
            // btnProduct
            // 
            this.btnProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProduct.Location = new System.Drawing.Point(1104, 64);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(29, 25);
            this.btnProduct.TabIndex = 5;
            this.btnProduct.Text = "...";
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label4.Location = new System.Drawing.Point(220, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Đến";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.Location = new System.Drawing.Point(4, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "SO No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.Location = new System.Drawing.Point(4, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sản phẩm";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(262, 12);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(126, 22);
            this.dtpDateTo.TabIndex = 2;
            // 
            // txtSO
            // 
            this.txtSO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtSO.Location = new System.Drawing.Point(81, 39);
            this.txtSO.Name = "txtSO";
            this.txtSO.Size = new System.Drawing.Size(307, 22);
            this.txtSO.TabIndex = 3;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(81, 12);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpDateFrom.Size = new System.Drawing.Size(126, 22);
            this.dtpDateFrom.TabIndex = 1;
            this.dtpDateFrom.Value = new System.DateTime(2013, 3, 3, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(4, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày";
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.Location = new System.Drawing.Point(870, 544);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(113, 25);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "Nhập hàng";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportExcel.Image")));
            this.btnExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportExcel.Location = new System.Drawing.Point(989, 544);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(106, 25);
            this.btnExportExcel.TabIndex = 2;
            this.btnExportExcel.Text = "Xuất Excel";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(1101, 543);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(89, 25);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Đóng";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "STT";
            this.Column1.HeaderText = "STT";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // SaleOrderNumberCol
            // 
            this.SaleOrderNumberCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SaleOrderNumberCol.DataPropertyName = "SaleOrderNumber";
            this.SaleOrderNumberCol.HeaderText = "SO No.";
            this.SaleOrderNumberCol.Name = "SaleOrderNumberCol";
            this.SaleOrderNumberCol.ReadOnly = true;
            this.SaleOrderNumberCol.Width = 76;
            // 
            // ItemCodeCol
            // 
            this.ItemCodeCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ItemCodeCol.DataPropertyName = "ItemCode";
            this.ItemCodeCol.HeaderText = "MÃ SP";
            this.ItemCodeCol.Name = "ItemCodeCol";
            this.ItemCodeCol.ReadOnly = true;
            this.ItemCodeCol.Width = 74;
            // 
            // PONO
            // 
            this.PONO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PONO.DataPropertyName = "PONO";
            this.PONO.HeaderText = "PO No.";
            this.PONO.Name = "PONO";
            this.PONO.ReadOnly = true;
            this.PONO.Visible = false;
            this.PONO.Width = 76;
            // 
            // SOQuantityCol
            // 
            this.SOQuantityCol.DataPropertyName = "SOQuantity";
            this.SOQuantityCol.HeaderText = "SL SO";
            this.SOQuantityCol.Name = "SOQuantityCol";
            this.SOQuantityCol.ReadOnly = true;
            this.SOQuantityCol.Width = 80;
            // 
            // POQuantityCol
            // 
            this.POQuantityCol.DataPropertyName = "POQuantity";
            this.POQuantityCol.HeaderText = "SL PO";
            this.POQuantityCol.Name = "POQuantityCol";
            this.POQuantityCol.ReadOnly = true;
            this.POQuantityCol.Width = 80;
            // 
            // SOPOCol
            // 
            this.SOPOCol.DataPropertyName = "SOPO";
            this.SOPOCol.HeaderText = "SO - PO";
            this.SOPOCol.Name = "SOPOCol";
            this.SOPOCol.ReadOnly = true;
            this.SOPOCol.Width = 80;
            // 
            // NameCol
            // 
            this.NameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.NameCol.DataPropertyName = "Name";
            this.NameCol.HeaderText = "TÊN SP";
            this.NameCol.Name = "NameCol";
            this.NameCol.ReadOnly = true;
            this.NameCol.Width = 82;
            // 
            // UnitCol
            // 
            this.UnitCol.DataPropertyName = "Unit";
            this.UnitCol.HeaderText = "ĐVT";
            this.UnitCol.Name = "UnitCol";
            this.UnitCol.ReadOnly = true;
            this.UnitCol.Width = 80;
            // 
            // PriceCol
            // 
            this.PriceCol.DataPropertyName = "Price";
            this.PriceCol.HeaderText = "GIÁ";
            this.PriceCol.Name = "PriceCol";
            this.PriceCol.ReadOnly = true;
            this.PriceCol.Width = 80;
            // 
            // frmDialogImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 580);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDialogImport";
            this.Text = "Import";
            this.Load += new System.EventHandler(this.frmNhapHangImport_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangNhap)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangKhuyenMai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPO)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSOPO)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvPO;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dgvHangNhap;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn POCONumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoNoiBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderDate;
        private System.Windows.Forms.DataGridView dgvHangKhuyenMai;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOrderNumberKM;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCodeKM;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemNameKM;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceKM;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityKM;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountKM;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitKM;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.TextBox txtSO;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.TextBox txtProductList;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridView dgvSOPO;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox chkDetail;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnDownloadPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleOrderNumberCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCodeCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PONO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOQuantityCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn POQuantityCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SOPOCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceCol;
    }
}