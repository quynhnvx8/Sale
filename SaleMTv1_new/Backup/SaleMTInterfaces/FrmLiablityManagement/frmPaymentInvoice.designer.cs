namespace SaleMTInterfaces.FrmLiablityManagement
{
    partial class frmPaymentInvoice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPaymentInvoice));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpDateToPayment = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDateToInvoice = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDatetFromPayment = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateFromInvoice = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvPaymentInvoice = new System.Windows.Forms.DataGridView();
            this.SoHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoNoiBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTienDaThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoThanhToan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTienconLai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnPhanBo = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.dtpDateCreate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTableStatementMoney = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentInvoice)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.dtpDateToPayment);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpDateToInvoice);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpDatetFromPayment);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpDateFromInvoice);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1029, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::SaleMTInterfaces.Properties.Resources.search_zoom;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(462, 38);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(102, 25);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpDateToPayment
            // 
            this.dtpDateToPayment.Checked = false;
            this.dtpDateToPayment.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
            this.dtpDateToPayment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateToPayment.Location = new System.Drawing.Point(336, 41);
            this.dtpDateToPayment.Name = "dtpDateToPayment";
            this.dtpDateToPayment.ShowCheckBox = true;
            this.dtpDateToPayment.Size = new System.Drawing.Size(121, 22);
            this.dtpDateToPayment.TabIndex = 7;
            this.dtpDateToPayment.ValueChanged += new System.EventHandler(this.dtpDateToPayment_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(300, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "đến";
            // 
            // dtpDateToInvoice
            // 
            this.dtpDateToInvoice.Checked = false;
            this.dtpDateToInvoice.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
            this.dtpDateToInvoice.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateToInvoice.Location = new System.Drawing.Point(336, 15);
            this.dtpDateToInvoice.Name = "dtpDateToInvoice";
            this.dtpDateToInvoice.ShowCheckBox = true;
            this.dtpDateToInvoice.Size = new System.Drawing.Size(121, 22);
            this.dtpDateToInvoice.TabIndex = 5;
            this.dtpDateToInvoice.ValueChanged += new System.EventHandler(this.dtpDateToInvoice_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(300, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "đến";
            // 
            // dtpDatetFromPayment
            // 
            this.dtpDatetFromPayment.Checked = false;
            this.dtpDatetFromPayment.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
            this.dtpDatetFromPayment.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatetFromPayment.Location = new System.Drawing.Point(171, 41);
            this.dtpDatetFromPayment.Name = "dtpDatetFromPayment";
            this.dtpDatetFromPayment.ShowCheckBox = true;
            this.dtpDatetFromPayment.Size = new System.Drawing.Size(119, 22);
            this.dtpDatetFromPayment.TabIndex = 3;
            this.dtpDatetFromPayment.ValueChanged += new System.EventHandler(this.dtpDatetFromPayment_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ngày thanh toán từ ngày";
            // 
            // dtpDateFromInvoice
            // 
            this.dtpDateFromInvoice.Checked = false;
            this.dtpDateFromInvoice.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
            this.dtpDateFromInvoice.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFromInvoice.Location = new System.Drawing.Point(171, 15);
            this.dtpDateFromInvoice.Name = "dtpDateFromInvoice";
            this.dtpDateFromInvoice.ShowCheckBox = true;
            this.dtpDateFromInvoice.Size = new System.Drawing.Size(119, 22);
            this.dtpDateFromInvoice.TabIndex = 1;
            this.dtpDateFromInvoice.ValueChanged += new System.EventHandler(this.dtpDateFromInvoice_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày hóa đơn từ ngày";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvPaymentInvoice);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(10, 79);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1029, 339);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách hóa đơn";
            // 
            // dgvPaymentInvoice
            // 
            this.dgvPaymentInvoice.AllowUserToAddRows = false;
            this.dgvPaymentInvoice.AllowUserToDeleteRows = false;
            this.dgvPaymentInvoice.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPaymentInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaymentInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SoHD,
            this.SoPO,
            this.SoNoiBo,
            this.NgayHD,
            this.SoTien,
            this.SoTienDaThanhToan,
            this.SoThanhToan,
            this.SoTienconLai});
            this.dgvPaymentInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPaymentInvoice.Location = new System.Drawing.Point(3, 18);
            this.dgvPaymentInvoice.Name = "dgvPaymentInvoice";
            this.dgvPaymentInvoice.Size = new System.Drawing.Size(1023, 318);
            this.dgvPaymentInvoice.TabIndex = 0;
            this.dgvPaymentInvoice.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvPaymentInvoice_CellBeginEdit);
            this.dgvPaymentInvoice.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPaymentInvoice_CellEndEdit);
            this.dgvPaymentInvoice.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPaymentInvoice_DataBindingComplete);
            // 
            // SoHD
            // 
            this.SoHD.DataPropertyName = "SoHD";
            this.SoHD.HeaderText = "Số hóa đơn";
            this.SoHD.Name = "SoHD";
            this.SoHD.ReadOnly = true;
            // 
            // SoPO
            // 
            this.SoPO.DataPropertyName = "SoPO";
            this.SoPO.HeaderText = "Số PO";
            this.SoPO.Name = "SoPO";
            this.SoPO.ReadOnly = true;
            this.SoPO.Width = 90;
            // 
            // SoNoiBo
            // 
            this.SoNoiBo.DataPropertyName = "SoNoiBo";
            this.SoNoiBo.HeaderText = "Số nội bộ";
            this.SoNoiBo.Name = "SoNoiBo";
            this.SoNoiBo.ReadOnly = true;
            this.SoNoiBo.Width = 95;
            // 
            // NgayHD
            // 
            this.NgayHD.DataPropertyName = "NgayHD";
            this.NgayHD.HeaderText = "Ngày hóa đơn";
            this.NgayHD.Name = "NgayHD";
            this.NgayHD.ReadOnly = true;
            this.NgayHD.Width = 120;
            // 
            // SoTien
            // 
            this.SoTien.DataPropertyName = "SoTien";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = "0";
            this.SoTien.DefaultCellStyle = dataGridViewCellStyle5;
            this.SoTien.HeaderText = "Số tiền";
            this.SoTien.Name = "SoTien";
            this.SoTien.ReadOnly = true;
            this.SoTien.Width = 130;
            // 
            // SoTienDaThanhToan
            // 
            this.SoTienDaThanhToan.DataPropertyName = "SoTienDaThanhToan";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = "0";
            this.SoTienDaThanhToan.DefaultCellStyle = dataGridViewCellStyle6;
            this.SoTienDaThanhToan.HeaderText = "Đã thanh toán";
            this.SoTienDaThanhToan.Name = "SoTienDaThanhToan";
            this.SoTienDaThanhToan.ReadOnly = true;
            this.SoTienDaThanhToan.Width = 120;
            // 
            // SoThanhToan
            // 
            this.SoThanhToan.DataPropertyName = "SoThanhToan";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = "0";
            this.SoThanhToan.DefaultCellStyle = dataGridViewCellStyle7;
            this.SoThanhToan.HeaderText = "Thanh toán";
            this.SoThanhToan.Name = "SoThanhToan";
            // 
            // SoTienconLai
            // 
            this.SoTienconLai.DataPropertyName = "SoTienconLai";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = "0";
            this.SoTienconLai.DefaultCellStyle = dataGridViewCellStyle8;
            this.SoTienconLai.HeaderText = "Số tiền chưa thanh toán";
            this.SoTienconLai.Name = "SoTienconLai";
            this.SoTienconLai.ReadOnly = true;
            this.SoTienconLai.Width = 170;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnPhanBo);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtMoney);
            this.groupBox3.Controls.Add(this.cboType);
            this.groupBox3.Controls.Add(this.dtpDateCreate);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.btnTableStatementMoney);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(10, 421);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1029, 48);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin nộp tiền";
            // 
            // btnPhanBo
            // 
            this.btnPhanBo.Image = global::SaleMTInterfaces.Properties.Resources.tick;
            this.btnPhanBo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPhanBo.Location = new System.Drawing.Point(890, 15);
            this.btnPhanBo.Name = "btnPhanBo";
            this.btnPhanBo.Size = new System.Drawing.Size(90, 25);
            this.btnPhanBo.TabIndex = 12;
            this.btnPhanBo.Text = "Phân bổ";
            this.btnPhanBo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPhanBo.UseVisualStyleBackColor = true;
            this.btnPhanBo.Click += new System.EventHandler(this.btnPhanBo_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(839, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "VNĐ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(576, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Số tiền(*)";
            // 
            // txtMoney
            // 
            this.txtMoney.Location = new System.Drawing.Point(651, 15);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.ReadOnly = true;
            this.txtMoney.Size = new System.Drawing.Size(169, 22);
            this.txtMoney.TabIndex = 9;
            this.txtMoney.Text = "0";
            this.txtMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMoney.TextChanged += new System.EventHandler(this.txtMoney_TextChanged);
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(394, 15);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(150, 24);
            this.cboType.TabIndex = 8;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // dtpDateCreate
            // 
            this.dtpDateCreate.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
            this.dtpDateCreate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateCreate.Location = new System.Drawing.Point(254, 15);
            this.dtpDateCreate.Name = "dtpDateCreate";
            this.dtpDateCreate.Size = new System.Drawing.Size(106, 22);
            this.dtpDateCreate.TabIndex = 7;
            this.dtpDateCreate.ValueChanged += new System.EventHandler(this.dtpDateCreate_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(206, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Ngày";
            // 
            // btnTableStatementMoney
            // 
            this.btnTableStatementMoney.Image = ((System.Drawing.Image)(resources.GetObject("btnTableStatementMoney.Image")));
            this.btnTableStatementMoney.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTableStatementMoney.Location = new System.Drawing.Point(33, 15);
            this.btnTableStatementMoney.Name = "btnTableStatementMoney";
            this.btnTableStatementMoney.Size = new System.Drawing.Size(140, 25);
            this.btnTableStatementMoney.TabIndex = 0;
            this.btnTableStatementMoney.Text = "Bảng kê nộp tiền";
            this.btnTableStatementMoney.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTableStatementMoney.UseVisualStyleBackColor = true;
            this.btnTableStatementMoney.Click += new System.EventHandler(this.btnTableStatementMoney_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::SaleMTInterfaces.Properties.Resources.save1;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(806, 479);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 25);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "&Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::SaleMTInterfaces.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(914, 479);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 25);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "&Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmPaymentInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 514);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPaymentInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh toán hóa đơn";
            this.Load += new System.EventHandler(this.frmPaymentInvoice_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentInvoice)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dtpDateToPayment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDateToInvoice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDatetFromPayment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDateFromInvoice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.DateTimePicker dtpDateCreate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTableStatementMoney;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.Button btnPhanBo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvPaymentInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPO;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoNoiBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTienDaThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoThanhToan;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTienconLai;
    }
}