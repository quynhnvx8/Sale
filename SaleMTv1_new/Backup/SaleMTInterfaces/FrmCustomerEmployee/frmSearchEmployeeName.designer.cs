namespace SaleMTInterfaces.FrmCustomerEmployee
{
    partial class frmSearchEmployeeName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSearchEmployeeName));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnChoosePage = new System.Windows.Forms.Button();
            this.txtGoPage = new System.Windows.Forms.TextBox();
            this.lblPage = new System.Windows.Forms.Label();
            this.btnEndPage = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnTopPage = new System.Windows.Forms.Button();
            this.cboRows = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvwSearchEmName = new System.Windows.Forms.ListView();
            this.colEmployeeCode = new System.Windows.Forms.ColumnHeader();
            this.colEmploeeName = new System.Windows.Forms.ColumnHeader();
            this.colEmployeeFisrtName = new System.Windows.Forms.ColumnHeader();
            this.colRoom = new System.Windows.Forms.ColumnHeader();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnChoosePage);
            this.groupBox1.Controls.Add(this.txtGoPage);
            this.groupBox1.Controls.Add(this.lblPage);
            this.groupBox1.Controls.Add(this.btnEndPage);
            this.groupBox1.Controls.Add(this.btnNext);
            this.groupBox1.Controls.Add(this.btnPrev);
            this.groupBox1.Controls.Add(this.btnTopPage);
            this.groupBox1.Controls.Add(this.cboRows);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lvwSearchEmName);
            this.groupBox1.Location = new System.Drawing.Point(13, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(677, 421);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách nhân viên";
            // 
            // btnChoosePage
            // 
            this.btnChoosePage.Image = ((System.Drawing.Image)(resources.GetObject("btnChoosePage.Image")));
            this.btnChoosePage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChoosePage.Location = new System.Drawing.Point(582, 386);
            this.btnChoosePage.Name = "btnChoosePage";
            this.btnChoosePage.Size = new System.Drawing.Size(89, 25);
            this.btnChoosePage.TabIndex = 11;
            this.btnChoosePage.Text = "Tới trang";
            this.btnChoosePage.UseVisualStyleBackColor = true;
            this.btnChoosePage.Click += new System.EventHandler(this.btnChoosePage_Click);
            // 
            // txtGoPage
            // 
            this.txtGoPage.Location = new System.Drawing.Point(495, 388);
            this.txtGoPage.Name = "txtGoPage";
            this.txtGoPage.Size = new System.Drawing.Size(81, 22);
            this.txtGoPage.TabIndex = 10;
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Location = new System.Drawing.Point(352, 390);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(44, 16);
            this.lblPage.TabIndex = 9;
            this.lblPage.Text = "Trang";
            // 
            // btnEndPage
            // 
            this.btnEndPage.Image = ((System.Drawing.Image)(resources.GetObject("btnEndPage.Image")));
            this.btnEndPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEndPage.Location = new System.Drawing.Point(301, 388);
            this.btnEndPage.Name = "btnEndPage";
            this.btnEndPage.Size = new System.Drawing.Size(29, 23);
            this.btnEndPage.TabIndex = 8;
            this.btnEndPage.UseVisualStyleBackColor = true;
            this.btnEndPage.Click += new System.EventHandler(this.btnEndPage_Click);
            // 
            // btnNext
            // 
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(266, 388);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(29, 23);
            this.btnNext.TabIndex = 7;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Image")));
            this.btnPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrev.Location = new System.Drawing.Point(231, 387);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(29, 23);
            this.btnPrev.TabIndex = 6;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnTopPage
            // 
            this.btnTopPage.Image = ((System.Drawing.Image)(resources.GetObject("btnTopPage.Image")));
            this.btnTopPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTopPage.Location = new System.Drawing.Point(196, 387);
            this.btnTopPage.Name = "btnTopPage";
            this.btnTopPage.Size = new System.Drawing.Size(29, 23);
            this.btnTopPage.TabIndex = 5;
            this.btnTopPage.UseVisualStyleBackColor = true;
            this.btnTopPage.Click += new System.EventHandler(this.btnTopPage_Click);
            // 
            // cboRows
            // 
            this.cboRows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRows.FormattingEnabled = true;
            this.cboRows.Items.AddRange(new object[] {
            "20",
            "40",
            "60",
            "80",
            "100"});
            this.cboRows.Location = new System.Drawing.Point(114, 386);
            this.cboRows.Name = "cboRows";
            this.cboRows.Size = new System.Drawing.Size(75, 24);
            this.cboRows.TabIndex = 4;
            this.cboRows.SelectedIndexChanged += new System.EventHandler(this.cboRows_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Số dòng / trang";
            // 
            // lvwSearchEmName
            // 
            this.lvwSearchEmName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEmployeeCode,
            this.colEmploeeName,
            this.colEmployeeFisrtName,
            this.colRoom});
            this.lvwSearchEmName.FullRowSelect = true;
            this.lvwSearchEmName.GridLines = true;
            this.lvwSearchEmName.Location = new System.Drawing.Point(7, 22);
            this.lvwSearchEmName.Name = "lvwSearchEmName";
            this.lvwSearchEmName.Size = new System.Drawing.Size(664, 355);
            this.lvwSearchEmName.TabIndex = 0;
            this.lvwSearchEmName.UseCompatibleStateImageBehavior = false;
            this.lvwSearchEmName.View = System.Windows.Forms.View.Details;
            this.lvwSearchEmName.SelectedIndexChanged += new System.EventHandler(this.lvwSearchEmName_SelectedIndexChanged);
            this.lvwSearchEmName.DoubleClick += new System.EventHandler(this.lvwSearchEmName_DoubleClick);
            this.lvwSearchEmName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwSearchEmName_KeyDown);
            // 
            // colEmployeeCode
            // 
            this.colEmployeeCode.Text = "Mã nhân viên";
            this.colEmployeeCode.Width = 93;
            // 
            // colEmploeeName
            // 
            this.colEmploeeName.Text = "Tên";
            this.colEmploeeName.Width = 115;
            // 
            // colEmployeeFisrtName
            // 
            this.colEmployeeFisrtName.Text = "Họ";
            this.colEmployeeFisrtName.Width = 115;
            // 
            // colRoom
            // 
            this.colRoom.Text = "Phòng ban";
            this.colRoom.Width = 325;
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(279, 430);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 25);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(365, 430);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 25);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmSearchEmployeeName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 465);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmSearchEmployeeName";
            this.Text = "frmSearchEmployeeName";
            this.Load += new System.EventHandler(this.frmSearchEmployeeName_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSearchEmployeeName_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnChoosePage;
        private System.Windows.Forms.TextBox txtGoPage;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Button btnEndPage;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnTopPage;
        private System.Windows.Forms.ComboBox cboRows;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ListView lvwSearchEmName;
        private System.Windows.Forms.ColumnHeader colEmployeeCode;
        private System.Windows.Forms.ColumnHeader colEmploeeName;
        private System.Windows.Forms.ColumnHeader colEmployeeFisrtName;
        private System.Windows.Forms.ColumnHeader colRoom;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
    }
}