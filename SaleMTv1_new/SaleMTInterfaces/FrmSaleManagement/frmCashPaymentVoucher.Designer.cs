namespace SaleMTInterfaces.FrmSaleManagement
{
    partial class frmCashPaymentVoucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCashPaymentVoucher));
            this.gbxTTChiTien = new System.Windows.Forms.GroupBox();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboAmountType = new System.Windows.Forms.ComboBox();
            this.dtpPaymentTime = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.cboPaymentType = new System.Windows.Forms.ComboBox();
            this.cboPerson = new System.Windows.Forms.ComboBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtPersonReceipt = new System.Windows.Forms.TextBox();
            this.txtPaymentCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxDanhSach = new System.Windows.Forms.GroupBox();
            this.lvwPayment = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.btnPrintVoucher = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.imgInsert = new System.Windows.Forms.ImageList(this.components);
            this.gbxTTChiTien.SuspendLayout();
            this.gbxDanhSach.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxTTChiTien
            // 
            this.gbxTTChiTien.Controls.Add(this.txtRate);
            this.gbxTTChiTien.Controls.Add(this.label9);
            this.gbxTTChiTien.Controls.Add(this.cboAmountType);
            this.gbxTTChiTien.Controls.Add(this.dtpPaymentTime);
            this.gbxTTChiTien.Controls.Add(this.label8);
            this.gbxTTChiTien.Controls.Add(this.lblDate);
            this.gbxTTChiTien.Controls.Add(this.cboPaymentType);
            this.gbxTTChiTien.Controls.Add(this.cboPerson);
            this.gbxTTChiTien.Controls.Add(this.txtNote);
            this.gbxTTChiTien.Controls.Add(this.txtAmount);
            this.gbxTTChiTien.Controls.Add(this.txtPersonReceipt);
            this.gbxTTChiTien.Controls.Add(this.txtPaymentCode);
            this.gbxTTChiTien.Controls.Add(this.label6);
            this.gbxTTChiTien.Controls.Add(this.label5);
            this.gbxTTChiTien.Controls.Add(this.label4);
            this.gbxTTChiTien.Controls.Add(this.label3);
            this.gbxTTChiTien.Controls.Add(this.label2);
            this.gbxTTChiTien.Controls.Add(this.label1);
            this.gbxTTChiTien.Location = new System.Drawing.Point(13, 10);
            this.gbxTTChiTien.Name = "gbxTTChiTien";
            this.gbxTTChiTien.Size = new System.Drawing.Size(565, 172);
            this.gbxTTChiTien.TabIndex = 0;
            this.gbxTTChiTien.TabStop = false;
            this.gbxTTChiTien.Text = "Thông tin chi tiền";
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(481, 123);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(68, 22);
            this.txtRate.TabIndex = 15;
            this.txtRate.Text = "1";
            this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRate.TextChanged += new System.EventHandler(this.txtRate_TextChanged);
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(429, 127);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "Tỷ giá";
            // 
            // cboAmountType
            // 
            this.cboAmountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAmountType.FormattingEnabled = true;
            this.cboAmountType.Location = new System.Drawing.Point(345, 122);
            this.cboAmountType.Name = "cboAmountType";
            this.cboAmountType.Size = new System.Drawing.Size(84, 24);
            this.cboAmountType.TabIndex = 13;
            //this.cboAmountType.SelectedIndexChanged += new System.EventHandler(this.cboAmountType_SelectedIndexChanged);
            // 
            // dtpPaymentTime
            // 
            this.dtpPaymentTime.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptHour;
            this.dtpPaymentTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPaymentTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPaymentTime.Location = new System.Drawing.Point(465, 19);
            this.dtpPaymentTime.Name = "dtpPaymentTime";
            this.dtpPaymentTime.ShowUpDown = true;
            this.dtpPaymentTime.Size = new System.Drawing.Size(84, 23);
            this.dtpPaymentTime.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(416, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 17);
            this.label8.TabIndex = 3;
            this.label8.Text = "Giờ:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblDate.Location = new System.Drawing.Point(265, 22);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(50, 17);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Ngày:";
            // 
            // cboPaymentType
            // 
            this.cboPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentType.FormattingEnabled = true;
            this.cboPaymentType.Location = new System.Drawing.Point(96, 72);
            this.cboPaymentType.Name = "cboPaymentType";
            this.cboPaymentType.Size = new System.Drawing.Size(453, 24);
            this.cboPaymentType.TabIndex = 8;
            //this.cboPaymentType.SelectedIndexChanged += new System.EventHandler(this.cboPaymentType_SelectedIndexChanged);
            // 
            // cboPerson
            // 
            this.cboPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPerson.FormattingEnabled = true;
            this.cboPerson.Location = new System.Drawing.Point(96, 46);
            this.cboPerson.Name = "cboPerson";
            this.cboPerson.Size = new System.Drawing.Size(453, 24);
            this.cboPerson.TabIndex = 6;
            //this.cboPerson.SelectedIndexChanged += new System.EventHandler(this.cboPerson_SelectedIndexChanged);
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(96, 147);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(453, 22);
            this.txtNote.TabIndex = 17;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(96, 122);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(243, 22);
            this.txtAmount.TabIndex = 12;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // txtPersonReceipt
            // 
            this.txtPersonReceipt.Location = new System.Drawing.Point(96, 98);
            this.txtPersonReceipt.Name = "txtPersonReceipt";
            this.txtPersonReceipt.Size = new System.Drawing.Size(453, 22);
            this.txtPersonReceipt.TabIndex = 10;
            // 
            // txtPaymentCode
            // 
            this.txtPaymentCode.BackColor = System.Drawing.Color.White;
            this.txtPaymentCode.Enabled = false;
            this.txtPaymentCode.Location = new System.Drawing.Point(96, 20);
            this.txtPaymentCode.Name = "txtPaymentCode";
            this.txtPaymentCode.Size = new System.Drawing.Size(160, 22);
            this.txtPaymentCode.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Ghi chú";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Số tiền";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Người nhận";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Loại chi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Người chi";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã chi tiền";
            // 
            // gbxDanhSach
            // 
            this.gbxDanhSach.Controls.Add(this.lvwPayment);
            this.gbxDanhSach.Location = new System.Drawing.Point(13, 189);
            this.gbxDanhSach.Name = "gbxDanhSach";
            this.gbxDanhSach.Size = new System.Drawing.Size(565, 399);
            this.gbxDanhSach.TabIndex = 1;
            this.gbxDanhSach.TabStop = false;
            this.gbxDanhSach.Text = "Danh sách ";
            // 
            // lvwPayment
            // 
            this.lvwPayment.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lvwPayment.FullRowSelect = true;
            this.lvwPayment.GridLines = true;
            this.lvwPayment.Location = new System.Drawing.Point(7, 20);
            this.lvwPayment.Name = "lvwPayment";
            this.lvwPayment.Size = new System.Drawing.Size(552, 373);
            this.lvwPayment.TabIndex = 0;
            this.lvwPayment.UseCompatibleStateImageBehavior = false;
            this.lvwPayment.View = System.Windows.Forms.View.Details;
            this.lvwPayment.SelectedIndexChanged += new System.EventHandler(this.lvwPayment_SelectedIndexChanged);
            this.lvwPayment.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvwPayment_ItemCheck);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Người chi tiền";
            this.columnHeader1.Width = 172;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên loại chi";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Người nhận";
            this.columnHeader3.Width = 220;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Số tiền";
            this.columnHeader4.Width = 127;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Tiền tệ";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Tỷ giá";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Ngày chi";
            this.columnHeader7.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Ghi chú";
            this.columnHeader8.Width = 100;
            // 
            // btnPrintVoucher
            // 
            this.btnPrintVoucher.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintVoucher.Image")));
            this.btnPrintVoucher.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintVoucher.Location = new System.Drawing.Point(451, 594);
            this.btnPrintVoucher.Name = "btnPrintVoucher";
            this.btnPrintVoucher.Size = new System.Drawing.Size(93, 25);
            this.btnPrintVoucher.TabIndex = 22;
            this.btnPrintVoucher.Text = "In phiếu";
            this.btnPrintVoucher.UseVisualStyleBackColor = true;
            this.btnPrintVoucher.Click += new System.EventHandler(this.btnPrintVoucher_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(352, 594);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 25);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(253, 594);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 25);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(154, 594);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 25);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInsert.ImageIndex = 0;
            this.btnInsert.ImageList = this.imgInsert;
            this.btnInsert.Location = new System.Drawing.Point(55, 594);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(93, 25);
            this.btnInsert.TabIndex = 18;
            this.btnInsert.Text = "Thêm mới";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // imgInsert
            // 
            this.imgInsert.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgInsert.ImageStream")));
            this.imgInsert.TransparentColor = System.Drawing.Color.Transparent;
            this.imgInsert.Images.SetKeyName(0, "103.png");
            this.imgInsert.Images.SetKeyName(1, "101.png");
            // 
            // frmCashPaymentVoucher
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(594, 632);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrintVoucher);
            this.Controls.Add(this.gbxDanhSach);
            this.Controls.Add(this.gbxTTChiTien);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCashPaymentVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin chi tiền";
            this.Load += new System.EventHandler(this.frmCashPaymentVoucher_Load);
            this.gbxTTChiTien.ResumeLayout(false);
            this.gbxTTChiTien.PerformLayout();
            this.gbxDanhSach.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxTTChiTien;
        private System.Windows.Forms.ComboBox cboPaymentType;
        private System.Windows.Forms.ComboBox cboPerson;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtPersonReceipt;
        private System.Windows.Forms.TextBox txtPaymentCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbxDanhSach;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboAmountType;
        private System.Windows.Forms.DateTimePicker dtpPaymentTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ListView lvwPayment;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnPrintVoucher;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ImageList imgInsert;
    }
}