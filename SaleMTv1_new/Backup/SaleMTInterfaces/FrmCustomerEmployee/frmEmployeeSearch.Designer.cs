namespace SaleMTInterfaces.FrmCustomerEmployee
{
    partial class frmEmployeeSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployeeSearch));
            this.gbxToChuc = new System.Windows.Forms.GroupBox();
            this.btnEmployeeSearch = new System.Windows.Forms.Button();
            this.treOrganization = new System.Windows.Forms.TreeView();
            this.imgTreeview = new System.Windows.Forms.ImageList(this.components);
            this.gbxNhanVien = new System.Windows.Forms.GroupBox();
            this.lblPage = new System.Windows.Forms.Label();
            this.lblRowlist = new System.Windows.Forms.Label();
            this.btnEndPage = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnTopPage = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.lvwEmployee = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lvwEmployeeChoose = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbxToChuc.SuspendLayout();
            this.gbxNhanVien.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxToChuc
            // 
            this.gbxToChuc.Controls.Add(this.btnEmployeeSearch);
            this.gbxToChuc.Controls.Add(this.treOrganization);
            this.gbxToChuc.Location = new System.Drawing.Point(7, 6);
            this.gbxToChuc.Name = "gbxToChuc";
            this.gbxToChuc.Size = new System.Drawing.Size(277, 356);
            this.gbxToChuc.TabIndex = 0;
            this.gbxToChuc.TabStop = false;
            this.gbxToChuc.Text = "Tổ chức";
            // 
            // btnEmployeeSearch
            // 
            this.btnEmployeeSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployeeSearch.Image")));
            this.btnEmployeeSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployeeSearch.Location = new System.Drawing.Point(185, 325);
            this.btnEmployeeSearch.Name = "btnEmployeeSearch";
            this.btnEmployeeSearch.Size = new System.Drawing.Size(86, 25);
            this.btnEmployeeSearch.TabIndex = 55;
            this.btnEmployeeSearch.Text = "Tìm";
            this.btnEmployeeSearch.UseVisualStyleBackColor = true;
            this.btnEmployeeSearch.Click += new System.EventHandler(this.btnEmployeeSearch_Click);
            // 
            // treOrganization
            // 
            this.treOrganization.CheckBoxes = true;
            this.treOrganization.ImageIndex = 0;
            this.treOrganization.ImageList = this.imgTreeview;
            this.treOrganization.Location = new System.Drawing.Point(7, 19);
            this.treOrganization.Name = "treOrganization";
            this.treOrganization.SelectedImageIndex = 0;
            this.treOrganization.Size = new System.Drawing.Size(265, 300);
            this.treOrganization.TabIndex = 0;
            this.treOrganization.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treOrganization_AfterCheck);
            // 
            // imgTreeview
            // 
            this.imgTreeview.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTreeview.ImageStream")));
            this.imgTreeview.TransparentColor = System.Drawing.Color.Transparent;
            this.imgTreeview.Images.SetKeyName(0, "tree.bmp");
            // 
            // gbxNhanVien
            // 
            this.gbxNhanVien.Controls.Add(this.lblPage);
            this.gbxNhanVien.Controls.Add(this.lblRowlist);
            this.gbxNhanVien.Controls.Add(this.btnEndPage);
            this.gbxNhanVien.Controls.Add(this.btnNext);
            this.gbxNhanVien.Controls.Add(this.btnBack);
            this.gbxNhanVien.Controls.Add(this.btnTopPage);
            this.gbxNhanVien.Controls.Add(this.btnDown);
            this.gbxNhanVien.Controls.Add(this.lvwEmployee);
            this.gbxNhanVien.Location = new System.Drawing.Point(290, 6);
            this.gbxNhanVien.Name = "gbxNhanVien";
            this.gbxNhanVien.Size = new System.Drawing.Size(388, 356);
            this.gbxNhanVien.TabIndex = 1;
            this.gbxNhanVien.TabStop = false;
            this.gbxNhanVien.Text = "Nhân viên";
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Location = new System.Drawing.Point(237, 331);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(44, 16);
            this.lblPage.TabIndex = 62;
            this.lblPage.Text = "Trang";
            // 
            // lblRowlist
            // 
            this.lblRowlist.AutoSize = true;
            this.lblRowlist.Location = new System.Drawing.Point(6, 329);
            this.lblRowlist.Name = "lblRowlist";
            this.lblRowlist.Size = new System.Drawing.Size(73, 16);
            this.lblRowlist.TabIndex = 61;
            this.lblRowlist.Text = "Tổng cộng";
            // 
            // btnEndPage
            // 
            this.btnEndPage.Image = ((System.Drawing.Image)(resources.GetObject("btnEndPage.Image")));
            this.btnEndPage.Location = new System.Drawing.Point(352, 325);
            this.btnEndPage.Name = "btnEndPage";
            this.btnEndPage.Size = new System.Drawing.Size(30, 25);
            this.btnEndPage.TabIndex = 60;
            this.btnEndPage.UseVisualStyleBackColor = true;
            this.btnEndPage.Click += new System.EventHandler(this.btnEndPage_Click);
            // 
            // btnNext
            // 
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(316, 325);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(30, 25);
            this.btnNext.TabIndex = 59;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(201, 325);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(30, 25);
            this.btnBack.TabIndex = 58;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnTopPage
            // 
            this.btnTopPage.Image = ((System.Drawing.Image)(resources.GetObject("btnTopPage.Image")));
            this.btnTopPage.Location = new System.Drawing.Point(165, 325);
            this.btnTopPage.Name = "btnTopPage";
            this.btnTopPage.Size = new System.Drawing.Size(30, 25);
            this.btnTopPage.TabIndex = 57;
            this.btnTopPage.UseVisualStyleBackColor = true;
            this.btnTopPage.Click += new System.EventHandler(this.btnTopPage_Click);
            // 
            // btnDown
            // 
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(129, 325);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(30, 25);
            this.btnDown.TabIndex = 56;
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // lvwEmployee
            // 
            this.lvwEmployee.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwEmployee.FullRowSelect = true;
            this.lvwEmployee.GridLines = true;
            this.lvwEmployee.Location = new System.Drawing.Point(7, 20);
            this.lvwEmployee.Name = "lvwEmployee";
            this.lvwEmployee.Size = new System.Drawing.Size(375, 299);
            this.lvwEmployee.TabIndex = 0;
            this.lvwEmployee.UseCompatibleStateImageBehavior = false;
            this.lvwEmployee.View = System.Windows.Forms.View.Details;
            this.lvwEmployee.SelectedIndexChanged += new System.EventHandler(this.lvwEmployee_SelectedIndexChanged);
            this.lvwEmployee.DoubleClick += new System.EventHandler(this.lvwEmployee_DoubleClick);
            this.lvwEmployee.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwEmployee_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã nhân viên";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên ";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Họ";
            this.columnHeader3.Width = 150;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lvwEmployeeChoose);
            this.groupBox3.Location = new System.Drawing.Point(13, 416);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(692, 179);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Đã chọn";
            // 
            // lvwEmployeeChoose
            // 
            this.lvwEmployeeChoose.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvwEmployeeChoose.FullRowSelect = true;
            this.lvwEmployeeChoose.GridLines = true;
            this.lvwEmployeeChoose.Location = new System.Drawing.Point(7, 20);
            this.lvwEmployeeChoose.Name = "lvwEmployeeChoose";
            this.lvwEmployeeChoose.Size = new System.Drawing.Size(681, 148);
            this.lvwEmployeeChoose.TabIndex = 0;
            this.lvwEmployeeChoose.UseCompatibleStateImageBehavior = false;
            this.lvwEmployeeChoose.View = System.Windows.Forms.View.Details;
            this.lvwEmployeeChoose.SelectedIndexChanged += new System.EventHandler(this.lvwEmployeeChoose_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Mã nhân viên";
            this.columnHeader4.Width = 110;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Tên";
            this.columnHeader5.Width = 135;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Họ";
            this.columnHeader6.Width = 140;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Phòng ban";
            this.columnHeader7.Width = 313;
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(295, 595);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(86, 25);
            this.btnOK.TabIndex = 56;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(387, 595);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 25);
            this.btnCancel.TabIndex = 57;
            this.btnCancel.Text = "Đóng";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(692, 397);
            this.tabControl1.TabIndex = 58;
            // 
            // tabPage1
            // 
            this.tabPage1.AccessibleName = "tabEmployee";
            this.tabPage1.Controls.Add(this.gbxNhanVien);
            this.tabPage1.Controls.Add(this.gbxToChuc);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(684, 368);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Danh sách nhân viên";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // frmEmployeeSearch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(715, 625);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmEmployeeSearch";
            this.Text = "Tìm kiếm nhân viên";
            this.Load += new System.EventHandler(this.frmEmployeeSearch_Load);
            this.gbxToChuc.ResumeLayout(false);
            this.gbxNhanVien.ResumeLayout(false);
            this.gbxNhanVien.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxToChuc;
        private System.Windows.Forms.TreeView treOrganization;
        private System.Windows.Forms.GroupBox gbxNhanVien;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.ListView lvwEmployeeChoose;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button btnEmployeeSearch;
        private System.Windows.Forms.Button btnEndPage;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnTopPage;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblRowlist;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.ImageList imgTreeview;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView lvwEmployee;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;

       
    }
}