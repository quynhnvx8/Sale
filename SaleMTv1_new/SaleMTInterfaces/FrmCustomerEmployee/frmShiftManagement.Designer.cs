namespace SaleMTInterfaces.FrmCustomerEmployee
{
    partial class frmShiftManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShiftManagement));
            this.gbxDanhSachNV = new System.Windows.Forms.GroupBox();
            this.btnView = new System.Windows.Forms.Button();
            this.chkAllEmployee = new System.Windows.Forms.CheckBox();
            this.lvwEmployee = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbxShift = new System.Windows.Forms.GroupBox();
            this.cboShift = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.label27 = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label42 = new System.Windows.Forms.Label();
            this.gbxLich = new System.Windows.Forms.GroupBox();
            this.dgvShift = new System.Windows.Forms.DataGridView();
            this.gbxDanhSachNV.SuspendLayout();
            this.gbxShift.SuspendLayout();
            this.gbxLich.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShift)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxDanhSachNV
            // 
            this.gbxDanhSachNV.Controls.Add(this.btnView);
            this.gbxDanhSachNV.Controls.Add(this.chkAllEmployee);
            this.gbxDanhSachNV.Controls.Add(this.lvwEmployee);
            this.gbxDanhSachNV.Location = new System.Drawing.Point(12, 12);
            this.gbxDanhSachNV.Name = "gbxDanhSachNV";
            this.gbxDanhSachNV.Size = new System.Drawing.Size(290, 520);
            this.gbxDanhSachNV.TabIndex = 4;
            this.gbxDanhSachNV.TabStop = false;
            this.gbxDanhSachNV.Text = "Danh sách nhân viên";
            // 
            // btnView
            // 
            this.btnView.Image = ((System.Drawing.Image)(resources.GetObject("btnView.Image")));
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(195, 462);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(87, 23);
            this.btnView.TabIndex = 4;
            this.btnView.Text = "Xem lịch";
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // chkAllEmployee
            // 
            this.chkAllEmployee.AutoSize = true;
            this.chkAllEmployee.Location = new System.Drawing.Point(8, 466);
            this.chkAllEmployee.Name = "chkAllEmployee";
            this.chkAllEmployee.Size = new System.Drawing.Size(131, 17);
            this.chkAllEmployee.TabIndex = 3;
            this.chkAllEmployee.Text = "Chọn tất cả nhân viên";
            this.chkAllEmployee.UseVisualStyleBackColor = true;
            // 
            // lvwEmployee
            // 
            this.lvwEmployee.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwEmployee.GridLines = true;
            this.lvwEmployee.Location = new System.Drawing.Point(7, 20);
            this.lvwEmployee.Name = "lvwEmployee";
            this.lvwEmployee.Size = new System.Drawing.Size(275, 436);
            this.lvwEmployee.TabIndex = 0;
            this.lvwEmployee.UseCompatibleStateImageBehavior = false;
            this.lvwEmployee.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã nhân viên";
            this.columnHeader1.Width = 105;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Họ ";
            this.columnHeader2.Width = 64;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tên";
            this.columnHeader3.Width = 102;
            // 
            // gbxShift
            // 
            this.gbxShift.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxShift.Controls.Add(this.cboShift);
            this.gbxShift.Controls.Add(this.label1);
            this.gbxShift.Controls.Add(this.dtpDateTo);
            this.gbxShift.Controls.Add(this.label27);
            this.gbxShift.Controls.Add(this.dtpDateFrom);
            this.gbxShift.Controls.Add(this.label42);
            this.gbxShift.Location = new System.Drawing.Point(309, 13);
            this.gbxShift.Name = "gbxShift";
            this.gbxShift.Size = new System.Drawing.Size(947, 60);
            this.gbxShift.TabIndex = 5;
            this.gbxShift.TabStop = false;
            this.gbxShift.Text = "Cài đặt lịch làm việc";
            // 
            // cboShift
            // 
            this.cboShift.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboShift.FormattingEnabled = true;
            this.cboShift.Location = new System.Drawing.Point(626, 23);
            this.cboShift.Name = "cboShift";
            this.cboShift.Size = new System.Drawing.Size(315, 21);
            this.cboShift.TabIndex = 137;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(533, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 136;
            this.label1.Text = "Chọn ca";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(351, 23);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.ShowCheckBox = true;
            this.dtpDateTo.Size = new System.Drawing.Size(164, 20);
            this.dtpDateTo.TabIndex = 135;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(261, 26);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(53, 13);
            this.label27.TabIndex = 134;
            this.label27.Text = "Đến ngày";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(81, 22);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.ShowCheckBox = true;
            this.dtpDateFrom.Size = new System.Drawing.Size(164, 20);
            this.dtpDateFrom.TabIndex = 129;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(6, 25);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(46, 13);
            this.label42.TabIndex = 128;
            this.label42.Text = "Từ ngày";
            // 
            // gbxLich
            // 
            this.gbxLich.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxLich.Controls.Add(this.dgvShift);
            this.gbxLich.Location = new System.Drawing.Point(309, 80);
            this.gbxLich.Name = "gbxLich";
            this.gbxLich.Size = new System.Drawing.Size(947, 452);
            this.gbxLich.TabIndex = 6;
            this.gbxLich.TabStop = false;
            this.gbxLich.Text = "Lịch làm việc";
            // 
            // dgvShift
            // 
            this.dgvShift.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvShift.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShift.Location = new System.Drawing.Point(7, 20);
            this.dgvShift.Name = "dgvShift";
            this.dgvShift.Size = new System.Drawing.Size(934, 426);
            this.dgvShift.TabIndex = 0;
            // 
            // frmShiftManagement
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1268, 541);
            this.Controls.Add(this.gbxLich);
            this.Controls.Add(this.gbxShift);
            this.Controls.Add(this.gbxDanhSachNV);
            this.Name = "frmShiftManagement";
            this.Text = "Lịch trực bán hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gbxDanhSachNV.ResumeLayout(false);
            this.gbxDanhSachNV.PerformLayout();
            this.gbxShift.ResumeLayout(false);
            this.gbxShift.PerformLayout();
            this.gbxLich.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShift)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxDanhSachNV;
        private System.Windows.Forms.ListView lvwEmployee;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.CheckBox chkAllEmployee;
        private System.Windows.Forms.GroupBox gbxShift;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox cboShift;
        private System.Windows.Forms.GroupBox gbxLich;
        private System.Windows.Forms.DataGridView dgvShift;
    }
}