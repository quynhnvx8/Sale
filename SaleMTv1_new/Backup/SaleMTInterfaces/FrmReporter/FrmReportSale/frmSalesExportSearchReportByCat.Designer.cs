namespace SaleMTInterfaces.FrmReporter.FrmReportSale
{
    partial class frmSalesExportSearchReportByCat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesExportSearchReportByCat));
            this.btnDownList = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.dtpdateTo = new System.Windows.Forms.DateTimePicker();
            this.btnExport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSeach = new System.Windows.Forms.Button();
            this.dtpdateFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvCAT = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblCurrentPage = new System.Windows.Forms.Label();
            this.lblTotalPage = new System.Windows.Forms.Label();
            this.lblSpace = new System.Windows.Forms.Label();
            this.lblPage = new System.Windows.Forms.Label();
            this.lblScount = new System.Windows.Forms.Label();
            this.btnChoosePage = new System.Windows.Forms.Button();
            this.txtGoPage = new System.Windows.Forms.TextBox();
            this.btnEndPage = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnTopPage = new System.Windows.Forms.Button();
            this.cboRows = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pnlStore = new System.Windows.Forms.Panel();
            this.treStore = new System.Windows.Forms.TreeView();
            this.imgUpDown = new System.Windows.Forms.ImageList(this.components);
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.ctlInfoStore1 = new SaleMTCommon.ctlInfoStore();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDownList.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCAT)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.pnlStore.SuspendLayout();
            this.pnlStoreS.SuspendLayout();
            this.pnlPlace.SuspendLayout();
            this.pnlPlaceP.SuspendLayout();
            this.pnlStoreList.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDownList
            // 
            this.btnDownList.Controls.Add(this.btnPrint);
            this.btnDownList.Controls.Add(this.btnExit);
            this.btnDownList.Controls.Add(this.dtpdateTo);
            this.btnDownList.Controls.Add(this.btnExport);
            this.btnDownList.Controls.Add(this.label2);
            this.btnDownList.Controls.Add(this.btnSeach);
            this.btnDownList.Controls.Add(this.dtpdateFrom);
            this.btnDownList.Controls.Add(this.label1);
            this.btnDownList.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDownList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownList.Location = new System.Drawing.Point(0, 0);
            this.btnDownList.Margin = new System.Windows.Forms.Padding(4);
            this.btnDownList.Name = "btnDownList";
            this.btnDownList.Padding = new System.Windows.Forms.Padding(4);
            this.btnDownList.Size = new System.Drawing.Size(734, 62);
            this.btnDownList.TabIndex = 0;
            this.btnDownList.TabStop = false;
            this.btnDownList.Text = "Thông tin tìm kiếm báo cáo";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(492, 21);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(61, 28);
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
            this.btnExit.Location = new System.Drawing.Point(645, 21);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(85, 28);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Đóng";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dtpdateTo
            // 
            this.dtpdateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpdateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdateTo.Location = new System.Drawing.Point(294, 24);
            this.dtpdateTo.Margin = new System.Windows.Forms.Padding(4);
            this.dtpdateTo.Name = "dtpdateTo";
            this.dtpdateTo.Size = new System.Drawing.Size(125, 22);
            this.dtpdateTo.TabIndex = 3;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(559, 21);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(82, 28);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến ngày";
            // 
            // btnSeach
            // 
            this.btnSeach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeach.Image = ((System.Drawing.Image)(resources.GetObject("btnSeach.Image")));
            this.btnSeach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeach.Location = new System.Drawing.Point(423, 21);
            this.btnSeach.Margin = new System.Windows.Forms.Padding(4);
            this.btnSeach.Name = "btnSeach";
            this.btnSeach.Size = new System.Drawing.Size(61, 28);
            this.btnSeach.TabIndex = 4;
            this.btnSeach.Text = "Tìm";
            this.btnSeach.UseVisualStyleBackColor = true;
            this.btnSeach.Click += new System.EventHandler(this.btnSeach_Click);
            // 
            // dtpdateFrom
            // 
            this.dtpdateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpdateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdateFrom.Location = new System.Drawing.Point(79, 21);
            this.dtpdateFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dtpdateFrom.Name = "dtpdateFrom";
            this.dtpdateFrom.Size = new System.Drawing.Size(125, 22);
            this.dtpdateFrom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvCAT);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox2.Location = new System.Drawing.Point(0, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(734, 488);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách";
            // 
            // dgvCAT
            // 
            this.dgvCAT.AllowUserToAddRows = false;
            this.dgvCAT.AllowUserToDeleteRows = false;
            this.dgvCAT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCAT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvCAT.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvCAT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCAT.ColumnHeadersVisible = false;
            this.dgvCAT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT});
            this.dgvCAT.Location = new System.Drawing.Point(6, 19);
            this.dgvCAT.Name = "dgvCAT";
            this.dgvCAT.Size = new System.Drawing.Size(722, 465);
            this.dgvCAT.TabIndex = 0;
            this.dgvCAT.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCAT_DataBindingComplete);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblCurrentPage);
            this.groupBox3.Controls.Add(this.lblTotalPage);
            this.groupBox3.Controls.Add(this.lblSpace);
            this.groupBox3.Controls.Add(this.lblPage);
            this.groupBox3.Controls.Add(this.lblScount);
            this.groupBox3.Controls.Add(this.btnChoosePage);
            this.groupBox3.Controls.Add(this.txtGoPage);
            this.groupBox3.Controls.Add(this.btnEndPage);
            this.groupBox3.Controls.Add(this.btnNext);
            this.groupBox3.Controls.Add(this.btnPrev);
            this.groupBox3.Controls.Add(this.btnTopPage);
            this.groupBox3.Controls.Add(this.cboRows);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(734, 45);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.AutoSize = true;
            this.lblCurrentPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblCurrentPage.Location = new System.Drawing.Point(357, 19);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(15, 16);
            this.lblCurrentPage.TabIndex = 15;
            this.lblCurrentPage.Text = "1";
            // 
            // lblTotalPage
            // 
            this.lblTotalPage.AutoSize = true;
            this.lblTotalPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblTotalPage.Location = new System.Drawing.Point(389, 19);
            this.lblTotalPage.Name = "lblTotalPage";
            this.lblTotalPage.Size = new System.Drawing.Size(15, 16);
            this.lblTotalPage.TabIndex = 16;
            this.lblTotalPage.Text = "1";
            // 
            // lblSpace
            // 
            this.lblSpace.AutoSize = true;
            this.lblSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblSpace.Location = new System.Drawing.Point(375, 19);
            this.lblSpace.Name = "lblSpace";
            this.lblSpace.Size = new System.Drawing.Size(12, 16);
            this.lblSpace.TabIndex = 28;
            this.lblSpace.Text = "/";
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblPage.Location = new System.Drawing.Point(305, 18);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(50, 16);
            this.lblPage.TabIndex = 14;
            this.lblPage.Text = "Trang :";
            // 
            // lblScount
            // 
            this.lblScount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScount.AutoSize = true;
            this.lblScount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblScount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblScount.Location = new System.Drawing.Point(419, 18);
            this.lblScount.Name = "lblScount";
            this.lblScount.Size = new System.Drawing.Size(43, 16);
            this.lblScount.TabIndex = 17;
            this.lblScount.Text = "Tổng:";
            // 
            // btnChoosePage
            // 
            this.btnChoosePage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChoosePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnChoosePage.Image = ((System.Drawing.Image)(resources.GetObject("btnChoosePage.Image")));
            this.btnChoosePage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChoosePage.Location = new System.Drawing.Point(639, 13);
            this.btnChoosePage.Name = "btnChoosePage";
            this.btnChoosePage.Size = new System.Drawing.Size(89, 25);
            this.btnChoosePage.TabIndex = 19;
            this.btnChoosePage.Text = "Tới trang";
            this.btnChoosePage.UseVisualStyleBackColor = true;
            this.btnChoosePage.Click += new System.EventHandler(this.btnChoosePage_Click);
            // 
            // txtGoPage
            // 
            this.txtGoPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGoPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtGoPage.Location = new System.Drawing.Point(552, 15);
            this.txtGoPage.Name = "txtGoPage";
            this.txtGoPage.Size = new System.Drawing.Size(81, 22);
            this.txtGoPage.TabIndex = 18;
            // 
            // btnEndPage
            // 
            this.btnEndPage.Image = ((System.Drawing.Image)(resources.GetObject("btnEndPage.Image")));
            this.btnEndPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEndPage.Location = new System.Drawing.Point(259, 15);
            this.btnEndPage.Name = "btnEndPage";
            this.btnEndPage.Size = new System.Drawing.Size(29, 23);
            this.btnEndPage.TabIndex = 13;
            this.btnEndPage.UseVisualStyleBackColor = true;
            this.btnEndPage.Click += new System.EventHandler(this.btnEndPage_Click);
            // 
            // btnNext
            // 
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(224, 15);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(29, 23);
            this.btnNext.TabIndex = 12;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Image")));
            this.btnPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrev.Location = new System.Drawing.Point(189, 14);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(29, 23);
            this.btnPrev.TabIndex = 11;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnTopPage
            // 
            this.btnTopPage.Image = ((System.Drawing.Image)(resources.GetObject("btnTopPage.Image")));
            this.btnTopPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTopPage.Location = new System.Drawing.Point(154, 14);
            this.btnTopPage.Name = "btnTopPage";
            this.btnTopPage.Size = new System.Drawing.Size(29, 23);
            this.btnTopPage.TabIndex = 10;
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
            this.cboRows.Location = new System.Drawing.Point(93, 14);
            this.cboRows.Name = "cboRows";
            this.cboRows.Size = new System.Drawing.Size(55, 24);
            this.cboRows.TabIndex = 9;
            this.cboRows.SelectedIndexChanged += new System.EventHandler(this.cboRows_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label6.Location = new System.Drawing.Point(11, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Dòng / trang";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.pnlStore);
            this.groupBox4.Controls.Add(this.pnlPlace);
            this.groupBox4.Controls.Add(this.pnlStoreList);
            this.groupBox4.Location = new System.Drawing.Point(48, 156);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(102, 53);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Visible = false;
            // 
            // pnlStore
            // 
            this.pnlStore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStore.Controls.Add(this.treStore);
            this.pnlStore.Controls.Add(this.pnlStoreS);
            this.pnlStore.Location = new System.Drawing.Point(4, 290);
            this.pnlStore.Name = "pnlStore";
            this.pnlStore.Size = new System.Drawing.Size(217, 284);
            this.pnlStore.TabIndex = 2;
            // 
            // treStore
            // 
            this.treStore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treStore.CheckBoxes = true;
            this.treStore.ImageIndex = 2;
            this.treStore.ImageList = this.imgUpDown;
            this.treStore.Location = new System.Drawing.Point(0, 25);
            this.treStore.Name = "treStore";
            this.treStore.SelectedImageIndex = 0;
            this.treStore.Size = new System.Drawing.Size(215, 257);
            this.treStore.TabIndex = 3;
            // 
            // imgUpDown
            // 
            this.imgUpDown.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgUpDown.ImageStream")));
            this.imgUpDown.TransparentColor = System.Drawing.Color.Transparent;
            this.imgUpDown.Images.SetKeyName(0, "1.png");
            this.imgUpDown.Images.SetKeyName(1, "2.png");
            this.imgUpDown.Images.SetKeyName(2, "tree.bmp");
            // 
            // pnlStoreS
            // 
            this.pnlStoreS.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlStoreS.BackgroundImage")));
            this.pnlStoreS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlStoreS.Controls.Add(this.btnStore);
            this.pnlStoreS.Location = new System.Drawing.Point(0, -1);
            this.pnlStoreS.Name = "pnlStoreS";
            this.pnlStoreS.Size = new System.Drawing.Size(215, 26);
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
            // 
            // pnlPlace
            // 
            this.pnlPlace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPlace.Controls.Add(this.trePlace);
            this.pnlPlace.Controls.Add(this.pnlPlaceP);
            this.pnlPlace.Location = new System.Drawing.Point(4, 151);
            this.pnlPlace.Name = "pnlPlace";
            this.pnlPlace.Size = new System.Drawing.Size(217, 139);
            this.pnlPlace.TabIndex = 1;
            // 
            // trePlace
            // 
            this.trePlace.CheckBoxes = true;
            this.trePlace.ImageIndex = 2;
            this.trePlace.ImageList = this.imgUpDown;
            this.trePlace.Location = new System.Drawing.Point(-1, 24);
            this.trePlace.Name = "trePlace";
            this.trePlace.SelectedImageIndex = 0;
            this.trePlace.Size = new System.Drawing.Size(216, 113);
            this.trePlace.TabIndex = 2;
            // 
            // pnlPlaceP
            // 
            this.pnlPlaceP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlPlaceP.BackgroundImage")));
            this.pnlPlaceP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlPlaceP.Controls.Add(this.btnPlace);
            this.pnlPlaceP.Location = new System.Drawing.Point(0, -2);
            this.pnlPlaceP.Name = "pnlPlaceP";
            this.pnlPlaceP.Size = new System.Drawing.Size(215, 26);
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
            // 
            // pnlStoreList
            // 
            this.pnlStoreList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStoreList.Controls.Add(this.treStoreList);
            this.pnlStoreList.Controls.Add(this.panel1);
            this.pnlStoreList.Location = new System.Drawing.Point(4, 12);
            this.pnlStoreList.Name = "pnlStoreList";
            this.pnlStoreList.Size = new System.Drawing.Size(217, 139);
            this.pnlStoreList.TabIndex = 0;
            // 
            // treStoreList
            // 
            this.treStoreList.CheckBoxes = true;
            this.treStoreList.ImageIndex = 2;
            this.treStoreList.ImageList = this.imgUpDown;
            this.treStoreList.Location = new System.Drawing.Point(0, 26);
            this.treStoreList.Name = "treStoreList";
            this.treStoreList.SelectedImageIndex = 0;
            this.treStoreList.Size = new System.Drawing.Size(215, 112);
            this.treStoreList.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.btnStoreList);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 26);
            this.panel1.TabIndex = 0;
            // 
            // btnStoreList
            // 
            this.btnStoreList.ImageIndex = 1;
            this.btnStoreList.ImageList = this.imgUpDown;
            this.btnStoreList.Location = new System.Drawing.Point(190, 6);
            this.btnStoreList.Name = "btnStoreList";
            this.btnStoreList.Size = new System.Drawing.Size(16, 16);
            this.btnStoreList.TabIndex = 0;
            this.btnStoreList.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctlInfoStore1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(274, 610);
            this.panel2.TabIndex = 15;
            // 
            // ctlInfoStore1
            // 
            this.ctlInfoStore1.BackColor = System.Drawing.SystemColors.Control;
            this.ctlInfoStore1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlInfoStore1.Location = new System.Drawing.Point(0, 0);
            this.ctlInfoStore1.Name = "ctlInfoStore1";
            this.ctlInfoStore1.Size = new System.Drawing.Size(274, 610);
            this.ctlInfoStore1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(274, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(734, 610);
            this.panel3.TabIndex = 16;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnDownList);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(734, 66);
            this.panel6.TabIndex = 25;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox3);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 554);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(734, 56);
            this.panel4.TabIndex = 24;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 51);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(734, 5);
            this.panel5.TabIndex = 22;
            // 
            // STT
            // 
            this.STT.DataPropertyName = "STT";
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.Visible = false;
            // 
            // frmSalesExportSearchReportByCat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 610);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSalesExportSearchReportByCat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "06.03 Báo cáo doanh số theo CAT";
            this.Load += new System.EventHandler(this.frmReportSale_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReportSale_KeyDown);
            this.btnDownList.ResumeLayout(false);
            this.btnDownList.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCAT)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.pnlStore.ResumeLayout(false);
            this.pnlStoreS.ResumeLayout(false);
            this.pnlPlace.ResumeLayout(false);
            this.pnlPlaceP.ResumeLayout(false);
            this.pnlStoreList.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox btnDownList;
        private System.Windows.Forms.DateTimePicker dtpdateFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSeach;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DateTimePicker dtpdateTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvCAT;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnChoosePage;
        private System.Windows.Forms.TextBox txtGoPage;
        private System.Windows.Forms.Button btnEndPage;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnTopPage;
        private System.Windows.Forms.ComboBox cboRows;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel pnlStoreList;
        private System.Windows.Forms.Button btnStoreList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlStore;
        private System.Windows.Forms.Panel pnlStoreS;
        private System.Windows.Forms.Button btnStore;
        private System.Windows.Forms.Panel pnlPlace;
        private System.Windows.Forms.Panel pnlPlaceP;
        private System.Windows.Forms.Button btnPlace;
        private System.Windows.Forms.TreeView trePlace;
        private System.Windows.Forms.TreeView treStoreList;
        private System.Windows.Forms.TreeView treStore;
        private System.Windows.Forms.ImageList imgUpDown;
        private System.Windows.Forms.Label lblCurrentPage;
        private System.Windows.Forms.Label lblTotalPage;
        private System.Windows.Forms.Label lblSpace;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Label lblScount;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private SaleMTCommon.ctlInfoStore ctlInfoStore1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
    }
}