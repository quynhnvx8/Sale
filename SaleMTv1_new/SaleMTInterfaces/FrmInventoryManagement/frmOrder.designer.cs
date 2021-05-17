namespace SaleMTInterfaces.FrmInventoryManagement
{
    partial class frmOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrder));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnSendOrder = new System.Windows.Forms.Button();
            this.gbxDanhSach = new System.Windows.Forms.GroupBox();
            this.lvwOrders = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.btnSoManagement = new System.Windows.Forms.Button();
            this.btnCreateAutoOrder = new System.Windows.Forms.Button();
            this.gbxSanPham = new System.Windows.Forms.GroupBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblTotalMoney = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.clnProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnProductPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTotalMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkChoose = new System.Windows.Forms.CheckBox();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnTop = new System.Windows.Forms.Button();
            this.lsvSanPham = new System.Windows.Forms.ListView();
            this.gbxXuat = new System.Windows.Forms.GroupBox();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.txtOrderCodeSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxTTDatHang = new System.Windows.Forms.GroupBox();
            this.rtfRemarks = new System.Windows.Forms.TextBox();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txtOrderCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTTDatHang = new System.Windows.Forms.Label();
            this.panel5.SuspendLayout();
            this.gbxDanhSach.SuspendLayout();
            this.gbxSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbxXuat.SuspendLayout();
            this.gbxTTDatHang.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.btnSearch);
            this.panel5.Controls.Add(this.btnSendOrder);
            this.panel5.Controls.Add(this.gbxDanhSach);
            this.panel5.Controls.Add(this.btnSoManagement);
            this.panel5.Controls.Add(this.btnCreateAutoOrder);
            this.panel5.Controls.Add(this.gbxSanPham);
            this.panel5.Location = new System.Drawing.Point(0, 139);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1204, 460);
            this.panel5.TabIndex = 18;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(12, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(105, 25);
            this.btnSearch.TabIndex = 22;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnSendOrder
            // 
            this.btnSendOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSendOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnSendOrder.Image")));
            this.btnSendOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSendOrder.Location = new System.Drawing.Point(225, 2);
            this.btnSendOrder.Name = "btnSendOrder";
            this.btnSendOrder.Size = new System.Drawing.Size(112, 25);
            this.btnSendOrder.TabIndex = 20;
            this.btnSendOrder.Text = "Gửi đơn hàng";
            this.btnSendOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSendOrder.UseVisualStyleBackColor = true;
            this.btnSendOrder.Click += new System.EventHandler(this.btnSendOrder_Click);
            // 
            // gbxDanhSach
            // 
            this.gbxDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbxDanhSach.Controls.Add(this.lvwOrders);
            this.gbxDanhSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gbxDanhSach.Location = new System.Drawing.Point(12, 32);
            this.gbxDanhSach.Name = "gbxDanhSach";
            this.gbxDanhSach.Size = new System.Drawing.Size(325, 425);
            this.gbxDanhSach.TabIndex = 23;
            this.gbxDanhSach.TabStop = false;
            this.gbxDanhSach.Text = "Danh sách";
            // 
            // lvwOrders
            // 
            this.lvwOrders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lvwOrders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvwOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lvwOrders.FullRowSelect = true;
            this.lvwOrders.GridLines = true;
            this.lvwOrders.Location = new System.Drawing.Point(4, 17);
            this.lvwOrders.Name = "lvwOrders";
            this.lvwOrders.Size = new System.Drawing.Size(318, 402);
            this.lvwOrders.TabIndex = 0;
            this.lvwOrders.UseCompatibleStateImageBehavior = false;
            this.lvwOrders.View = System.Windows.Forms.View.Details;
            this.lvwOrders.SelectedIndexChanged += new System.EventHandler(this.lvwOrders_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ngày đặt hàng";
            this.columnHeader1.Width = 168;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Mã đặt hàng";
            this.columnHeader2.Width = 146;
            // 
            // btnSoManagement
            // 
            this.btnSoManagement.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSoManagement.Image = ((System.Drawing.Image)(resources.GetObject("btnSoManagement.Image")));
            this.btnSoManagement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSoManagement.Location = new System.Drawing.Point(120, 2);
            this.btnSoManagement.Name = "btnSoManagement";
            this.btnSoManagement.Size = new System.Drawing.Size(101, 25);
            this.btnSoManagement.TabIndex = 21;
            this.btnSoManagement.Text = "Quản lý SO";
            this.btnSoManagement.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSoManagement.UseVisualStyleBackColor = true;
            this.btnSoManagement.Click += new System.EventHandler(this.btnSoManagement_Click);
            // 
            // btnCreateAutoOrder
            // 
            this.btnCreateAutoOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateAutoOrder.Enabled = false;
            this.btnCreateAutoOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCreateAutoOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateAutoOrder.Image")));
            this.btnCreateAutoOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateAutoOrder.Location = new System.Drawing.Point(891, 2);
            this.btnCreateAutoOrder.Name = "btnCreateAutoOrder";
            this.btnCreateAutoOrder.Size = new System.Drawing.Size(164, 25);
            this.btnCreateAutoOrder.TabIndex = 17;
            this.btnCreateAutoOrder.Text = "Tạo đơn hàng tự động";
            this.btnCreateAutoOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreateAutoOrder.UseVisualStyleBackColor = true;
            this.btnCreateAutoOrder.Click += new System.EventHandler(this.btnCreateAutoOrder_Click);
            // 
            // gbxSanPham
            // 
            this.gbxSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxSanPham.Controls.Add(this.lblCount);
            this.gbxSanPham.Controls.Add(this.lblTotalMoney);
            this.gbxSanPham.Controls.Add(this.lblQuantity);
            this.gbxSanPham.Controls.Add(this.label18);
            this.gbxSanPham.Controls.Add(this.dgvProducts);
            this.gbxSanPham.Controls.Add(this.label17);
            this.gbxSanPham.Controls.Add(this.label16);
            this.gbxSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gbxSanPham.Location = new System.Drawing.Point(345, 32);
            this.gbxSanPham.Name = "gbxSanPham";
            this.gbxSanPham.Size = new System.Drawing.Size(851, 425);
            this.gbxSanPham.TabIndex = 14;
            this.gbxSanPham.TabStop = false;
            this.gbxSanPham.Text = "Sản phẩm";
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblCount.Location = new System.Drawing.Point(794, 403);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(16, 16);
            this.lblCount.TabIndex = 19;
            this.lblCount.Text = "0";
            // 
            // lblTotalMoney
            // 
            this.lblTotalMoney.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTotalMoney.AutoSize = true;
            this.lblTotalMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTotalMoney.Location = new System.Drawing.Point(287, 403);
            this.lblTotalMoney.Name = "lblTotalMoney";
            this.lblTotalMoney.Size = new System.Drawing.Size(16, 16);
            this.lblTotalMoney.TabIndex = 18;
            this.lblTotalMoney.Text = "0";
            // 
            // lblQuantity
            // 
            this.lblQuantity.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblQuantity.Location = new System.Drawing.Point(60, 403);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(16, 16);
            this.lblQuantity.TabIndex = 17;
            this.lblQuantity.Text = "0";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label18.Location = new System.Drawing.Point(735, 403);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(62, 16);
            this.label18.TabIndex = 16;
            this.label18.Text = "Số dòng:";
            this.label18.Click += new System.EventHandler(this.label18_Click);
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnProductId,
            this.clnQuantity,
            this.clnProductPrice,
            this.clnProductName,
            this.clnUnit,
            this.clnTotalMoney,
            this.Column1});
            this.dgvProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvProducts.Location = new System.Drawing.Point(3, 18);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.Size = new System.Drawing.Size(844, 380);
            this.dgvProducts.TabIndex = 0;
            this.dgvProducts.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvProducts_UserAddedRow);
            this.dgvProducts.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvProducts_UserDeletedRow);
            this.dgvProducts.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvProducts_RowsAdded);
            this.dgvProducts.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvProducts_DataBindingComplete);
            this.dgvProducts.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvProducts_RowsRemoved);
            // 
            // clnProductId
            // 
            this.clnProductId.DataPropertyName = "ProductId";
            this.clnProductId.HeaderText = "Mã hàng";
            this.clnProductId.Name = "clnProductId";
            this.clnProductId.ReadOnly = true;
            // 
            // clnQuantity
            // 
            this.clnQuantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.clnQuantity.DefaultCellStyle = dataGridViewCellStyle4;
            this.clnQuantity.HeaderText = "Số lượng";
            this.clnQuantity.Name = "clnQuantity";
            this.clnQuantity.ReadOnly = true;
            // 
            // clnProductPrice
            // 
            this.clnProductPrice.DataPropertyName = "ProductPrice";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.clnProductPrice.DefaultCellStyle = dataGridViewCellStyle5;
            this.clnProductPrice.HeaderText = "Giá";
            this.clnProductPrice.Name = "clnProductPrice";
            this.clnProductPrice.ReadOnly = true;
            // 
            // clnProductName
            // 
            this.clnProductName.DataPropertyName = "ProductName";
            this.clnProductName.HeaderText = "Tên hàng";
            this.clnProductName.Name = "clnProductName";
            this.clnProductName.ReadOnly = true;
            this.clnProductName.Width = 200;
            // 
            // clnUnit
            // 
            this.clnUnit.DataPropertyName = "Unit";
            this.clnUnit.HeaderText = "ĐVT";
            this.clnUnit.Name = "clnUnit";
            this.clnUnit.ReadOnly = true;
            this.clnUnit.Width = 50;
            // 
            // clnTotalMoney
            // 
            this.clnTotalMoney.DataPropertyName = "TotalMoney";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            this.clnTotalMoney.DefaultCellStyle = dataGridViewCellStyle6;
            this.clnTotalMoney.HeaderText = "Thành tiền";
            this.clnTotalMoney.Name = "clnTotalMoney";
            this.clnTotalMoney.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "RED_INVOICE_CAT";
            this.Column1.HeaderText = "CAT";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(220, 403);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 16);
            this.label17.TabIndex = 15;
            this.label17.Text = "Tổng TT:";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1, 403);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 16);
            this.label16.TabIndex = 14;
            this.label16.Text = "Tổng SL:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.gbxXuat);
            this.panel3.Controls.Add(this.gbxTTDatHang);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1204, 142);
            this.panel3.TabIndex = 16;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.chkChoose);
            this.groupBox3.Controls.Add(this.btnEnd);
            this.groupBox3.Controls.Add(this.btnNext);
            this.groupBox3.Controls.Add(this.btnPrev);
            this.groupBox3.Controls.Add(this.btnTop);
            this.groupBox3.Controls.Add(this.lsvSanPham);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox3.Location = new System.Drawing.Point(1061, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(135, 125);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            // 
            // chkChoose
            // 
            this.chkChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkChoose.AutoSize = true;
            this.chkChoose.Location = new System.Drawing.Point(12, 104);
            this.chkChoose.Name = "chkChoose";
            this.chkChoose.Size = new System.Drawing.Size(15, 14);
            this.chkChoose.TabIndex = 5;
            this.chkChoose.UseVisualStyleBackColor = true;
            // 
            // btnEnd
            // 
            this.btnEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnd.Image = ((System.Drawing.Image)(resources.GetObject("btnEnd.Image")));
            this.btnEnd.Location = new System.Drawing.Point(104, 99);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(23, 23);
            this.btnEnd.TabIndex = 4;
            this.btnEnd.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(80, 99);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(25, 23);
            this.btnNext.TabIndex = 3;
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Image")));
            this.btnPrev.Location = new System.Drawing.Point(57, 99);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(24, 23);
            this.btnPrev.TabIndex = 2;
            this.btnPrev.UseVisualStyleBackColor = true;
            // 
            // btnTop
            // 
            this.btnTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTop.Image = ((System.Drawing.Image)(resources.GetObject("btnTop.Image")));
            this.btnTop.Location = new System.Drawing.Point(33, 99);
            this.btnTop.Name = "btnTop";
            this.btnTop.Size = new System.Drawing.Size(24, 24);
            this.btnTop.TabIndex = 1;
            this.btnTop.UseVisualStyleBackColor = true;
            // 
            // lsvSanPham
            // 
            this.lsvSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lsvSanPham.Location = new System.Drawing.Point(9, 15);
            this.lsvSanPham.Name = "lsvSanPham";
            this.lsvSanPham.Size = new System.Drawing.Size(118, 83);
            this.lsvSanPham.TabIndex = 0;
            this.lsvSanPham.UseCompatibleStateImageBehavior = false;
            // 
            // gbxXuat
            // 
            this.gbxXuat.Controls.Add(this.dtpDateTo);
            this.gbxXuat.Controls.Add(this.dtpDateFrom);
            this.gbxXuat.Controls.Add(this.txtOrderCodeSearch);
            this.gbxXuat.Controls.Add(this.label3);
            this.gbxXuat.Controls.Add(this.label2);
            this.gbxXuat.Controls.Add(this.label1);
            this.gbxXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gbxXuat.Location = new System.Drawing.Point(12, 12);
            this.gbxXuat.Name = "gbxXuat";
            this.gbxXuat.Size = new System.Drawing.Size(325, 125);
            this.gbxXuat.TabIndex = 19;
            this.gbxXuat.TabStop = false;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(106, 80);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.ShowCheckBox = true;
            this.dtpDateTo.Size = new System.Drawing.Size(213, 22);
            this.dtpDateTo.TabIndex = 6;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(106, 53);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.ShowCheckBox = true;
            this.dtpDateFrom.Size = new System.Drawing.Size(213, 22);
            this.dtpDateFrom.TabIndex = 5;
            // 
            // txtOrderCodeSearch
            // 
            this.txtOrderCodeSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderCodeSearch.Location = new System.Drawing.Point(106, 27);
            this.txtOrderCodeSearch.Name = "txtOrderCodeSearch";
            this.txtOrderCodeSearch.Size = new System.Drawing.Size(213, 22);
            this.txtOrderCodeSearch.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đến ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày đặt từ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã đặt hàng";
            // 
            // gbxTTDatHang
            // 
            this.gbxTTDatHang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxTTDatHang.Controls.Add(this.rtfRemarks);
            this.gbxTTDatHang.Controls.Add(this.dtpOrderDate);
            this.gbxTTDatHang.Controls.Add(this.label11);
            this.gbxTTDatHang.Controls.Add(this.txtOrderCode);
            this.gbxTTDatHang.Controls.Add(this.label9);
            this.gbxTTDatHang.Controls.Add(this.txtTTDatHang);
            this.gbxTTDatHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gbxTTDatHang.Location = new System.Drawing.Point(345, 12);
            this.gbxTTDatHang.Name = "gbxTTDatHang";
            this.gbxTTDatHang.Size = new System.Drawing.Size(710, 125);
            this.gbxTTDatHang.TabIndex = 11;
            this.gbxTTDatHang.TabStop = false;
            this.gbxTTDatHang.Text = "Thông tin đặt hàng";
            // 
            // rtfRemarks
            // 
            this.rtfRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtfRemarks.Enabled = false;
            this.rtfRemarks.Location = new System.Drawing.Point(118, 78);
            this.rtfRemarks.Multiline = true;
            this.rtfRemarks.Name = "rtfRemarks";
            this.rtfRemarks.Size = new System.Drawing.Size(586, 39);
            this.rtfRemarks.TabIndex = 13;
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Enabled = false;
            this.dtpOrderDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpOrderDate.Location = new System.Drawing.Point(118, 53);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(222, 22);
            this.dtpOrderDate.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 16);
            this.label11.TabIndex = 11;
            this.label11.Text = "Ngày đặt hàng";
            // 
            // txtOrderCode
            // 
            this.txtOrderCode.Location = new System.Drawing.Point(118, 26);
            this.txtOrderCode.Name = "txtOrderCode";
            this.txtOrderCode.ReadOnly = true;
            this.txtOrderCode.Size = new System.Drawing.Size(222, 22);
            this.txtOrderCode.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "Ghi chú";
            // 
            // txtTTDatHang
            // 
            this.txtTTDatHang.AutoSize = true;
            this.txtTTDatHang.Location = new System.Drawing.Point(7, 28);
            this.txtTTDatHang.Name = "txtTTDatHang";
            this.txtTTDatHang.Size = new System.Drawing.Size(82, 16);
            this.txtTTDatHang.TabIndex = 0;
            this.txtTTDatHang.Text = "Mã đặt hàng";
            // 
            // frmOrder
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1204, 603);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOrder";
            this.Text = "Đặt hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.evAddNew += new System.EventHandler(this.frmOrder_evAddNew);
            this.evDelete += new System.EventHandler(this.frmOrder_evDelete);
            this.Load += new System.EventHandler(this.frmOrder_Load);
            this.Activated += new System.EventHandler(this.frmOrder_Activated);
            this.evPrint += new System.EventHandler(this.frmOrder_evPrint);
            this.evCancel += new System.EventHandler(this.frmOrder_evCancel);
            this.evSave += new System.EventHandler(this.frmOrder_evSave);
            this.panel5.ResumeLayout(false);
            this.gbxDanhSach.ResumeLayout(false);
            this.gbxSanPham.ResumeLayout(false);
            this.gbxSanPham.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbxXuat.ResumeLayout(false);
            this.gbxXuat.PerformLayout();
            this.gbxTTDatHang.ResumeLayout(false);
            this.gbxTTDatHang.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox gbxTTDatHang;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtOrderCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label txtTTDatHang;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.GroupBox gbxSanPham;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lsvSanPham;
        private System.Windows.Forms.GroupBox gbxXuat;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.TextBox txtOrderCodeSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnSendOrder;
        private System.Windows.Forms.GroupBox gbxDanhSach;
        private System.Windows.Forms.ListView lvwOrders;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnSoManagement;
        private System.Windows.Forms.Button btnCreateAutoOrder;
        private System.Windows.Forms.TextBox rtfRemarks;
        private System.Windows.Forms.CheckBox chkChoose;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnTop;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblTotalMoney;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnProductPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTotalMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;

    }
}