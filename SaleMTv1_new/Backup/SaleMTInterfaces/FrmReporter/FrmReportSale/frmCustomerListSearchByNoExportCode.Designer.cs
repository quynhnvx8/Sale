namespace SaleMTInterfaces.FrmReporter.FrmReportSale
{
    partial class frmCustomerListSearchByNoExportCode
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerListSearchByNoExportCode));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dtpdateTo = new System.Windows.Forms.DateTimePicker();
            this.btnExport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSeach = new System.Windows.Forms.Button();
            this.dtpdateFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.imgUpDown = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvListCus = new System.Windows.Forms.DataGridView();
            this.CUSTOMER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ADDRESSS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblSpace = new System.Windows.Forms.Label();
            this.lblCurrentPage = new System.Windows.Forms.Label();
            this.btnChoosePage = new System.Windows.Forms.Button();
            this.lblTotalPage = new System.Windows.Forms.Label();
            this.txtGoPage = new System.Windows.Forms.TextBox();
            this.lblPage = new System.Windows.Forms.Label();
            this.btnEndPage = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnTopPage = new System.Windows.Forms.Button();
            this.cboRows = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctlInfoStore1 = new SaleMTCommon.ctlInfoStore();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pnlStore = new System.Windows.Forms.Panel();
            this.treStore = new System.Windows.Forms.TreeView();
            this.pnlStoreS = new System.Windows.Forms.Panel();
            this.btnStore = new System.Windows.Forms.Button();
            this.pnlPlace = new System.Windows.Forms.Panel();
            this.trePlace = new System.Windows.Forms.TreeView();
            this.pnlPlaceP = new System.Windows.Forms.Panel();
            this.btnPlace = new System.Windows.Forms.Button();
            this.pnlStoreList = new System.Windows.Forms.Panel();
            this.treStoreList = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStoreList = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListCus)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.pnlStore.SuspendLayout();
            this.pnlStoreS.SuspendLayout();
            this.pnlPlace.SuspendLayout();
            this.pnlPlaceP.SuspendLayout();
            this.pnlStoreList.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.dtpdateTo);
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSeach);
            this.groupBox1.Controls.Add(this.dtpdateFrom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(770, 69);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tìm kiếm báo cáo";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(512, 18);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(74, 27);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "In";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(676, 18);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(89, 27);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Đóng";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dtpdateTo
            // 
            this.dtpdateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpdateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdateTo.Location = new System.Drawing.Point(301, 20);
            this.dtpdateTo.Name = "dtpdateTo";
            this.dtpdateTo.Size = new System.Drawing.Size(122, 22);
            this.dtpdateTo.TabIndex = 3;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(592, 18);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(78, 27);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "đến ngày";
            // 
            // btnSeach
            // 
            this.btnSeach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeach.Image = ((System.Drawing.Image)(resources.GetObject("btnSeach.Image")));
            this.btnSeach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeach.Location = new System.Drawing.Point(428, 18);
            this.btnSeach.Name = "btnSeach";
            this.btnSeach.Size = new System.Drawing.Size(78, 27);
            this.btnSeach.TabIndex = 4;
            this.btnSeach.Text = "Tìm";
            this.btnSeach.UseVisualStyleBackColor = true;
            this.btnSeach.Click += new System.EventHandler(this.btnSeach_Click);
            // 
            // dtpdateFrom
            // 
            this.dtpdateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpdateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdateFrom.Location = new System.Drawing.Point(76, 20);
            this.dtpdateFrom.Name = "dtpdateFrom";
            this.dtpdateFrom.Size = new System.Drawing.Size(146, 22);
            this.dtpdateFrom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày:";
            // 
            // imgUpDown
            // 
            this.imgUpDown.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgUpDown.ImageStream")));
            this.imgUpDown.TransparentColor = System.Drawing.Color.Transparent;
            this.imgUpDown.Images.SetKeyName(0, "1.png");
            this.imgUpDown.Images.SetKeyName(1, "2.png");
            this.imgUpDown.Images.SetKeyName(2, "tree.bmp");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvListCus);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox2.Location = new System.Drawing.Point(268, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(770, 474);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách";
            // 
            // dgvListCus
            // 
            this.dgvListCus.AllowUserToAddRows = false;
            this.dgvListCus.AllowUserToDeleteRows = false;
            this.dgvListCus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListCus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CUSTOMER_ID,
            this.CUSTOMER_NAME,
            this.ADDRESSS});
            this.dgvListCus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListCus.Location = new System.Drawing.Point(3, 18);
            this.dgvListCus.Name = "dgvListCus";
            this.dgvListCus.Size = new System.Drawing.Size(764, 453);
            this.dgvListCus.TabIndex = 0;
            this.dgvListCus.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvListCus_DataBindingComplete);
            // 
            // CUSTOMER_ID
            // 
            this.CUSTOMER_ID.DataPropertyName = "CUSTOMER_ID";
            this.CUSTOMER_ID.HeaderText = "Mã khách hàng";
            this.CUSTOMER_ID.Name = "CUSTOMER_ID";
            this.CUSTOMER_ID.Width = 150;
            // 
            // CUSTOMER_NAME
            // 
            this.CUSTOMER_NAME.DataPropertyName = "CUSTOMER_NAME";
            this.CUSTOMER_NAME.HeaderText = "Tên khách hàng";
            this.CUSTOMER_NAME.Name = "CUSTOMER_NAME";
            this.CUSTOMER_NAME.Width = 260;
            // 
            // ADDRESSS
            // 
            this.ADDRESSS.DataPropertyName = "ADDRESSS";
            this.ADDRESSS.HeaderText = "Địa chỉ";
            this.ADDRESSS.Name = "ADDRESSS";
            this.ADDRESSS.Width = 400;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblCount);
            this.groupBox3.Controls.Add(this.lblSpace);
            this.groupBox3.Controls.Add(this.lblCurrentPage);
            this.groupBox3.Controls.Add(this.btnChoosePage);
            this.groupBox3.Controls.Add(this.lblTotalPage);
            this.groupBox3.Controls.Add(this.txtGoPage);
            this.groupBox3.Controls.Add(this.lblPage);
            this.groupBox3.Controls.Add(this.btnEndPage);
            this.groupBox3.Controls.Add(this.btnNext);
            this.groupBox3.Controls.Add(this.btnPrev);
            this.groupBox3.Controls.Add(this.btnTopPage);
            this.groupBox3.Controls.Add(this.cboRows);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(770, 46);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblCount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCount.Location = new System.Drawing.Point(447, 20);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(43, 16);
            this.lblCount.TabIndex = 22;
            this.lblCount.Text = "Tổng:";
            // 
            // lblSpace
            // 
            this.lblSpace.AutoSize = true;
            this.lblSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblSpace.Location = new System.Drawing.Point(378, 20);
            this.lblSpace.Name = "lblSpace";
            this.lblSpace.Size = new System.Drawing.Size(12, 16);
            this.lblSpace.TabIndex = 29;
            this.lblSpace.Text = "/";
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.AutoSize = true;
            this.lblCurrentPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblCurrentPage.Location = new System.Drawing.Point(360, 20);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(15, 16);
            this.lblCurrentPage.TabIndex = 28;
            this.lblCurrentPage.Text = "1";
            // 
            // btnChoosePage
            // 
            this.btnChoosePage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChoosePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnChoosePage.Image = ((System.Drawing.Image)(resources.GetObject("btnChoosePage.Image")));
            this.btnChoosePage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChoosePage.Location = new System.Drawing.Point(675, 15);
            this.btnChoosePage.Name = "btnChoosePage";
            this.btnChoosePage.Size = new System.Drawing.Size(89, 25);
            this.btnChoosePage.TabIndex = 20;
            this.btnChoosePage.Text = "Tới trang";
            this.btnChoosePage.UseVisualStyleBackColor = true;
            this.btnChoosePage.Click += new System.EventHandler(this.btnChoosePage_Click);
            // 
            // lblTotalPage
            // 
            this.lblTotalPage.AutoSize = true;
            this.lblTotalPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblTotalPage.Location = new System.Drawing.Point(388, 20);
            this.lblTotalPage.Name = "lblTotalPage";
            this.lblTotalPage.Size = new System.Drawing.Size(15, 16);
            this.lblTotalPage.TabIndex = 27;
            this.lblTotalPage.Text = "1";
            // 
            // txtGoPage
            // 
            this.txtGoPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGoPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtGoPage.Location = new System.Drawing.Point(587, 17);
            this.txtGoPage.Name = "txtGoPage";
            this.txtGoPage.Size = new System.Drawing.Size(81, 22);
            this.txtGoPage.TabIndex = 19;
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblPage.Location = new System.Drawing.Point(304, 19);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(50, 16);
            this.lblPage.TabIndex = 26;
            this.lblPage.Text = "Trang :";
            // 
            // btnEndPage
            // 
            this.btnEndPage.Image = ((System.Drawing.Image)(resources.GetObject("btnEndPage.Image")));
            this.btnEndPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEndPage.Location = new System.Drawing.Point(269, 14);
            this.btnEndPage.Name = "btnEndPage";
            this.btnEndPage.Size = new System.Drawing.Size(29, 23);
            this.btnEndPage.TabIndex = 17;
            this.btnEndPage.UseVisualStyleBackColor = true;
            this.btnEndPage.Click += new System.EventHandler(this.btnEndPage_Click);
            // 
            // btnNext
            // 
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(234, 14);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(29, 23);
            this.btnNext.TabIndex = 16;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Image")));
            this.btnPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrev.Location = new System.Drawing.Point(199, 14);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(29, 23);
            this.btnPrev.TabIndex = 15;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnTopPage
            // 
            this.btnTopPage.Image = ((System.Drawing.Image)(resources.GetObject("btnTopPage.Image")));
            this.btnTopPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTopPage.Location = new System.Drawing.Point(164, 14);
            this.btnTopPage.Name = "btnTopPage";
            this.btnTopPage.Size = new System.Drawing.Size(29, 23);
            this.btnTopPage.TabIndex = 14;
            this.btnTopPage.UseVisualStyleBackColor = true;
            this.btnTopPage.Click += new System.EventHandler(this.btnTopPage_Click);
            // 
            // cboRows
            // 
            this.cboRows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.755F);
            this.cboRows.FormattingEnabled = true;
            this.cboRows.Items.AddRange(new object[] {
            "20",
            "40",
            "60",
            "80",
            "100"});
            this.cboRows.Location = new System.Drawing.Point(103, 14);
            this.cboRows.Name = "cboRows";
            this.cboRows.Size = new System.Drawing.Size(55, 24);
            this.cboRows.TabIndex = 13;
            this.cboRows.SelectedIndexChanged += new System.EventHandler(this.cboRows_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label6.Location = new System.Drawing.Point(11, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Dòng / trang";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctlInfoStore1);
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 599);
            this.panel2.TabIndex = 20;
            // 
            // ctlInfoStore1
            // 
            this.ctlInfoStore1.BackColor = System.Drawing.SystemColors.Control;
            this.ctlInfoStore1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlInfoStore1.Location = new System.Drawing.Point(0, 0);
            this.ctlInfoStore1.Name = "ctlInfoStore1";
            this.ctlInfoStore1.Size = new System.Drawing.Size(268, 599);
            this.ctlInfoStore1.TabIndex = 17;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pnlStore);
            this.groupBox4.Controls.Add(this.pnlPlace);
            this.groupBox4.Controls.Add(this.pnlStoreList);
            this.groupBox4.Location = new System.Drawing.Point(26, 60);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(33, 31);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Visible = false;
            // 
            // pnlStore
            // 
            this.pnlStore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStore.Controls.Add(this.treStore);
            this.pnlStore.Controls.Add(this.pnlStoreS);
            this.pnlStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlStore.Location = new System.Drawing.Point(3, 343);
            this.pnlStore.Name = "pnlStore";
            this.pnlStore.Size = new System.Drawing.Size(27, 0);
            this.pnlStore.TabIndex = 2;
            // 
            // treStore
            // 
            this.treStore.CheckBoxes = true;
            this.treStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.treStore.ImageIndex = 2;
            this.treStore.ImageList = this.imgUpDown;
            this.treStore.Location = new System.Drawing.Point(0, 26);
            this.treStore.Name = "treStore";
            this.treStore.SelectedImageIndex = 2;
            this.treStore.Size = new System.Drawing.Size(25, 0);
            this.treStore.TabIndex = 3;
            // 
            // pnlStoreS
            // 
            this.pnlStoreS.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlStoreS.BackgroundImage")));
            this.pnlStoreS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlStoreS.Controls.Add(this.btnStore);
            this.pnlStoreS.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStoreS.Location = new System.Drawing.Point(0, 0);
            this.pnlStoreS.Name = "pnlStoreS";
            this.pnlStoreS.Size = new System.Drawing.Size(25, 26);
            this.pnlStoreS.TabIndex = 0;
            // 
            // btnStore
            // 
            this.btnStore.ImageIndex = 1;
            this.btnStore.ImageList = this.imgUpDown;
            this.btnStore.Location = new System.Drawing.Point(190, 4);
            this.btnStore.Name = "btnStore";
            this.btnStore.Size = new System.Drawing.Size(16, 16);
            this.btnStore.TabIndex = 0;
            this.btnStore.UseVisualStyleBackColor = true;
            this.btnStore.Click += new System.EventHandler(this.btnStore_Click);
            // 
            // pnlPlace
            // 
            this.pnlPlace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPlace.Controls.Add(this.trePlace);
            this.pnlPlace.Controls.Add(this.pnlPlaceP);
            this.pnlPlace.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPlace.Location = new System.Drawing.Point(3, 155);
            this.pnlPlace.Name = "pnlPlace";
            this.pnlPlace.Size = new System.Drawing.Size(27, 188);
            this.pnlPlace.TabIndex = 1;
            // 
            // trePlace
            // 
            this.trePlace.CheckBoxes = true;
            this.trePlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trePlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.755F);
            this.trePlace.ImageIndex = 2;
            this.trePlace.ImageList = this.imgUpDown;
            this.trePlace.Location = new System.Drawing.Point(0, 26);
            this.trePlace.Name = "trePlace";
            this.trePlace.SelectedImageIndex = 2;
            this.trePlace.Size = new System.Drawing.Size(25, 160);
            this.trePlace.TabIndex = 2;
            // 
            // pnlPlaceP
            // 
            this.pnlPlaceP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlPlaceP.BackgroundImage")));
            this.pnlPlaceP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlPlaceP.Controls.Add(this.btnPlace);
            this.pnlPlaceP.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPlaceP.Location = new System.Drawing.Point(0, 0);
            this.pnlPlaceP.Name = "pnlPlaceP";
            this.pnlPlaceP.Size = new System.Drawing.Size(25, 26);
            this.pnlPlaceP.TabIndex = 0;
            // 
            // btnPlace
            // 
            this.btnPlace.ImageIndex = 1;
            this.btnPlace.ImageList = this.imgUpDown;
            this.btnPlace.Location = new System.Drawing.Point(190, 4);
            this.btnPlace.Name = "btnPlace";
            this.btnPlace.Size = new System.Drawing.Size(16, 16);
            this.btnPlace.TabIndex = 0;
            this.btnPlace.UseVisualStyleBackColor = true;
            this.btnPlace.Click += new System.EventHandler(this.btnPlace_Click);
            // 
            // pnlStoreList
            // 
            this.pnlStoreList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStoreList.Controls.Add(this.treStoreList);
            this.pnlStoreList.Controls.Add(this.panel1);
            this.pnlStoreList.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStoreList.Location = new System.Drawing.Point(3, 16);
            this.pnlStoreList.Name = "pnlStoreList";
            this.pnlStoreList.Size = new System.Drawing.Size(27, 139);
            this.pnlStoreList.TabIndex = 0;
            // 
            // treStoreList
            // 
            this.treStoreList.CheckBoxes = true;
            this.treStoreList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treStoreList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.treStoreList.ImageIndex = 2;
            this.treStoreList.ImageList = this.imgUpDown;
            this.treStoreList.Location = new System.Drawing.Point(0, 26);
            this.treStoreList.Name = "treStoreList";
            this.treStoreList.SelectedImageIndex = 2;
            this.treStoreList.Size = new System.Drawing.Size(25, 111);
            this.treStoreList.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.btnStoreList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(25, 26);
            this.panel1.TabIndex = 0;
            // 
            // btnStoreList
            // 
            this.btnStoreList.ImageIndex = 1;
            this.btnStoreList.ImageList = this.imgUpDown;
            this.btnStoreList.Location = new System.Drawing.Point(190, 5);
            this.btnStoreList.Name = "btnStoreList";
            this.btnStoreList.Size = new System.Drawing.Size(16, 16);
            this.btnStoreList.TabIndex = 0;
            this.btnStoreList.UseVisualStyleBackColor = true;
            this.btnStoreList.Click += new System.EventHandler(this.btnStoreList_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.groupBox1);
            this.panel6.Controls.Add(this.panel9);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(268, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(770, 74);
            this.panel6.TabIndex = 22;
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(770, 5);
            this.panel9.TabIndex = 3;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.panel13);
            this.panel11.Controls.Add(this.groupBox3);
            this.panel11.Controls.Add(this.panel12);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Location = new System.Drawing.Point(268, 548);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(770, 51);
            this.panel11.TabIndex = 23;
            // 
            // panel13
            // 
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(0, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(770, 5);
            this.panel13.TabIndex = 20;
            // 
            // panel12
            // 
            this.panel12.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel12.Location = new System.Drawing.Point(0, 46);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(770, 5);
            this.panel12.TabIndex = 18;
            // 
            // frmCustomerListSearchByNoExportCode
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1038, 599);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmCustomerListSearchByNoExportCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "06.07 Báo cáo danh sách khách hàng không có giao dịch";
            this.Load += new System.EventHandler(this.frmCustomerListSearchByNoExportCode_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReportSale_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListCus)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.pnlStore.ResumeLayout(false);
            this.pnlStoreS.ResumeLayout(false);
            this.pnlPlace.ResumeLayout(false);
            this.pnlPlaceP.ResumeLayout(false);
            this.pnlStoreList.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpdateFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSeach;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DateTimePicker dtpdateTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imgUpDown;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvListCus;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblSpace;
        private System.Windows.Forms.Label lblCurrentPage;
        private System.Windows.Forms.Button btnChoosePage;
        private System.Windows.Forms.Label lblTotalPage;
        private System.Windows.Forms.TextBox txtGoPage;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Button btnEndPage;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnTopPage;
        private System.Windows.Forms.ComboBox cboRows;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn ADDRESSS;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel13;
        private SaleMTCommon.ctlInfoStore ctlInfoStore1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel pnlStore;
        private System.Windows.Forms.TreeView treStore;
        private System.Windows.Forms.Panel pnlStoreS;
        private System.Windows.Forms.Button btnStore;
        private System.Windows.Forms.Panel pnlPlace;
        private System.Windows.Forms.TreeView trePlace;
        private System.Windows.Forms.Panel pnlPlaceP;
        private System.Windows.Forms.Button btnPlace;
        private System.Windows.Forms.Panel pnlStoreList;
        private System.Windows.Forms.TreeView treStoreList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnStoreList;
    }
}