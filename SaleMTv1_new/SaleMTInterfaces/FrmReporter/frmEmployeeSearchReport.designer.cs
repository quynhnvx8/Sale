namespace SaleMTInterfaces.FrmReporter
{
    partial class frmEmployeeSearchReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployeeSearchReport));
            this.gbxToChuc = new System.Windows.Forms.GroupBox();
            this.btnEmployeeSearch = new System.Windows.Forms.Button();
            this.treOrganization = new System.Windows.Forms.TreeView();
            this.gbxNhanVien = new System.Windows.Forms.GroupBox();
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
            this.gbxToChuc.SuspendLayout();
            this.gbxNhanVien.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxToChuc
            // 
            this.gbxToChuc.Controls.Add(this.btnEmployeeSearch);
            this.gbxToChuc.Controls.Add(this.treOrganization);
            this.gbxToChuc.Location = new System.Drawing.Point(13, 13);
            this.gbxToChuc.Name = "gbxToChuc";
            this.gbxToChuc.Size = new System.Drawing.Size(299, 354);
            this.gbxToChuc.TabIndex = 0;
            this.gbxToChuc.TabStop = false;
            this.gbxToChuc.Text = "Tổ chức";
            // 
            // btnEmployeeSearch
            // 
            this.btnEmployeeSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployeeSearch.Image")));
            this.btnEmployeeSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmployeeSearch.Location = new System.Drawing.Point(207, 325);
            this.btnEmployeeSearch.Name = "btnEmployeeSearch";
            this.btnEmployeeSearch.Size = new System.Drawing.Size(86, 29);
            this.btnEmployeeSearch.TabIndex = 55;
            this.btnEmployeeSearch.Text = "Tìm";
            this.btnEmployeeSearch.UseVisualStyleBackColor = true;
            // 
            // treOrganization
            // 
            this.treOrganization.CheckBoxes = true;
            this.treOrganization.Location = new System.Drawing.Point(7, 19);
            this.treOrganization.Name = "treOrganization";
            this.treOrganization.Size = new System.Drawing.Size(286, 302);
            this.treOrganization.TabIndex = 0;
            // 
            // gbxNhanVien
            // 
            this.gbxNhanVien.Controls.Add(this.btnEndPage);
            this.gbxNhanVien.Controls.Add(this.btnNext);
            this.gbxNhanVien.Controls.Add(this.btnBack);
            this.gbxNhanVien.Controls.Add(this.btnTopPage);
            this.gbxNhanVien.Controls.Add(this.btnDown);
            this.gbxNhanVien.Controls.Add(this.lvwEmployee);
            this.gbxNhanVien.Location = new System.Drawing.Point(319, 13);
            this.gbxNhanVien.Name = "gbxNhanVien";
            this.gbxNhanVien.Size = new System.Drawing.Size(441, 354);
            this.gbxNhanVien.TabIndex = 1;
            this.gbxNhanVien.TabStop = false;
            this.gbxNhanVien.Text = "Nhân viên";
            // 
            // btnEndPage
            // 
            this.btnEndPage.Image = ((System.Drawing.Image)(resources.GetObject("btnEndPage.Image")));
            this.btnEndPage.Location = new System.Drawing.Point(398, 322);
            this.btnEndPage.Name = "btnEndPage";
            this.btnEndPage.Size = new System.Drawing.Size(38, 29);
            this.btnEndPage.TabIndex = 60;
            this.btnEndPage.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(354, 322);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(38, 29);
            this.btnNext.TabIndex = 59;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(221, 323);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(38, 29);
            this.btnBack.TabIndex = 58;
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnTopPage
            // 
            this.btnTopPage.Image = ((System.Drawing.Image)(resources.GetObject("btnTopPage.Image")));
            this.btnTopPage.Location = new System.Drawing.Point(177, 322);
            this.btnTopPage.Name = "btnTopPage";
            this.btnTopPage.Size = new System.Drawing.Size(38, 30);
            this.btnTopPage.TabIndex = 57;
            this.btnTopPage.UseVisualStyleBackColor = true;
            // 
            // btnDown
            // 
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(110, 322);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(38, 29);
            this.btnDown.TabIndex = 56;
            this.btnDown.UseVisualStyleBackColor = true;
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
            this.lvwEmployee.Size = new System.Drawing.Size(428, 299);
            this.lvwEmployee.TabIndex = 0;
            this.lvwEmployee.UseCompatibleStateImageBehavior = false;
            this.lvwEmployee.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã nhân viên";
            this.columnHeader1.Width = 91;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên ";
            this.columnHeader2.Width = 85;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Họ";
            this.columnHeader3.Width = 106;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lvwEmployeeChoose);
            this.groupBox3.Location = new System.Drawing.Point(13, 374);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(747, 189);
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
            this.lvwEmployeeChoose.Size = new System.Drawing.Size(734, 160);
            this.lvwEmployeeChoose.TabIndex = 0;
            this.lvwEmployeeChoose.UseCompatibleStateImageBehavior = false;
            this.lvwEmployeeChoose.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Mã nhân viên";
            this.columnHeader4.Width = 109;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Tên";
            this.columnHeader5.Width = 102;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Họ";
            this.columnHeader6.Width = 80;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Phòng ban";
            this.columnHeader7.Width = 223;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(310, 560);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(86, 23);
            this.btnOK.TabIndex = 56;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(402, 560);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 23);
            this.btnCancel.TabIndex = 57;
            this.btnCancel.Text = "Đóng";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // frmEmployeeSearch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(772, 590);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbxNhanVien);
            this.Controls.Add(this.gbxToChuc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmEmployeeSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm nhân viên";
            this.Load += new System.EventHandler(this.frmEmployeeSearch_Load);
            this.gbxToChuc.ResumeLayout(false);
            this.gbxNhanVien.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxToChuc;
        private System.Windows.Forms.TreeView treOrganization;
        private System.Windows.Forms.GroupBox gbxNhanVien;
        private System.Windows.Forms.ListView lvwEmployee;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lvwEmployeeChoose;
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
    }
}