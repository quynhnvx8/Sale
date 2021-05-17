namespace SaleMTInterfaces.FrmSaleManagement
{
    partial class frmCashReceiptVoucher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCashReceiptVoucher));
            this.gbxTTThuTien = new System.Windows.Forms.GroupBox();
            this.dtpTimeReceipt = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDateReceipt = new System.Windows.Forms.Label();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboAmountType = new System.Windows.Forms.ComboBox();
            this.cboReceiptType = new System.Windows.Forms.ComboBox();
            this.cboPersonReceipt = new System.Windows.Forms.ComboBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtPlaces = new System.Windows.Forms.TextBox();
            this.txtReceiptCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxDanhSach = new System.Windows.Forms.GroupBox();
            this.lvwReceipt = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.btnInsert = new System.Windows.Forms.Button();
            this.imgInsert = new System.Windows.Forms.ImageList(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.gbxTTThuTien.SuspendLayout();
            this.gbxDanhSach.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxTTThuTien
            // 
            this.gbxTTThuTien.Controls.Add(this.dtpTimeReceipt);
            this.gbxTTThuTien.Controls.Add(this.label9);
            this.gbxTTThuTien.Controls.Add(this.lblDateReceipt);
            this.gbxTTThuTien.Controls.Add(this.txtRate);
            this.gbxTTThuTien.Controls.Add(this.label7);
            this.gbxTTThuTien.Controls.Add(this.cboAmountType);
            this.gbxTTThuTien.Controls.Add(this.cboReceiptType);
            this.gbxTTThuTien.Controls.Add(this.cboPersonReceipt);
            this.gbxTTThuTien.Controls.Add(this.txtNote);
            this.gbxTTThuTien.Controls.Add(this.txtAmount);
            this.gbxTTThuTien.Controls.Add(this.txtPlaces);
            this.gbxTTThuTien.Controls.Add(this.txtReceiptCode);
            this.gbxTTThuTien.Controls.Add(this.label6);
            this.gbxTTThuTien.Controls.Add(this.label5);
            this.gbxTTThuTien.Controls.Add(this.label4);
            this.gbxTTThuTien.Controls.Add(this.label3);
            this.gbxTTThuTien.Controls.Add(this.label2);
            this.gbxTTThuTien.Controls.Add(this.label1);
            this.gbxTTThuTien.Location = new System.Drawing.Point(13, 10);
            this.gbxTTThuTien.Name = "gbxTTThuTien";
            this.gbxTTThuTien.Size = new System.Drawing.Size(590, 173);
            this.gbxTTThuTien.TabIndex = 0;
            this.gbxTTThuTien.TabStop = false;
            this.gbxTTThuTien.Text = "Thông tin thu tiền";
            // 
            // dtpTimeReceipt
            // 
            this.dtpTimeReceipt.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptHour;
            this.dtpTimeReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTimeReceipt.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeReceipt.Location = new System.Drawing.Point(489, 22);
            this.dtpTimeReceipt.Name = "dtpTimeReceipt";
            this.dtpTimeReceipt.ShowUpDown = true;
            this.dtpTimeReceipt.Size = new System.Drawing.Size(83, 23);
            this.dtpTimeReceipt.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(445, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 17);
            this.label9.TabIndex = 3;
            this.label9.Text = "Giờ:";
            // 
            // lblDateReceipt
            // 
            this.lblDateReceipt.AutoSize = true;
            this.lblDateReceipt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateReceipt.Location = new System.Drawing.Point(291, 25);
            this.lblDateReceipt.Name = "lblDateReceipt";
            this.lblDateReceipt.Size = new System.Drawing.Size(50, 17);
            this.lblDateReceipt.TabIndex = 2;
            this.lblDateReceipt.Text = "Ngày:";
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(502, 124);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(69, 22);
            this.txtRate.TabIndex = 15;
            this.txtRate.Text = "1";
            this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRate.TextChanged += new System.EventHandler(this.txtRate_TextChanged);
            this.txtRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRate_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(448, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Tỷ giá";
            // 
            // cboAmountType
            // 
            this.cboAmountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAmountType.FormattingEnabled = true;
            this.cboAmountType.Items.AddRange(new object[] {
            "VNĐ",
            "USD"});
            this.cboAmountType.Location = new System.Drawing.Point(358, 123);
            this.cboAmountType.Name = "cboAmountType";
            this.cboAmountType.Size = new System.Drawing.Size(89, 24);
            this.cboAmountType.TabIndex = 13;
            this.cboAmountType.SelectedIndexChanged += new System.EventHandler(this.cboAmountType_SelectedIndexChanged);
            // 
            // cboReceiptType
            // 
            this.cboReceiptType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReceiptType.FormattingEnabled = true;
            this.cboReceiptType.Location = new System.Drawing.Point(98, 74);
            this.cboReceiptType.Name = "cboReceiptType";
            this.cboReceiptType.Size = new System.Drawing.Size(473, 24);
            this.cboReceiptType.TabIndex = 8;
            // 
            // cboPersonReceipt
            // 
            this.cboPersonReceipt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPersonReceipt.FormattingEnabled = true;
            this.cboPersonReceipt.Location = new System.Drawing.Point(98, 47);
            this.cboPersonReceipt.Name = "cboPersonReceipt";
            this.cboPersonReceipt.Size = new System.Drawing.Size(473, 24);
            this.cboPersonReceipt.TabIndex = 6;
            this.cboPersonReceipt.SelectedIndexChanged += new System.EventHandler(this.cbxNguoiNhan_SelectedIndexChanged);
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(98, 148);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(473, 22);
            this.txtNote.TabIndex = 17;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(98, 124);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(254, 22);
            this.txtAmount.TabIndex = 12;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // txtPlaces
            // 
            this.txtPlaces.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtPlaces.Location = new System.Drawing.Point(98, 100);
            this.txtPlaces.Name = "txtPlaces";
            this.txtPlaces.Size = new System.Drawing.Size(473, 22);
            this.txtPlaces.TabIndex = 10;
            // 
            // txtReceiptCode
            // 
            this.txtReceiptCode.BackColor = System.Drawing.Color.White;
            this.txtReceiptCode.Enabled = false;
            this.txtReceiptCode.Location = new System.Drawing.Point(98, 23);
            this.txtReceiptCode.Name = "txtReceiptCode";
            this.txtReceiptCode.Size = new System.Drawing.Size(187, 22);
            this.txtReceiptCode.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Ghi chú";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Số tiền";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Nhận từ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Loại thu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Người nhận";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã thu";
            // 
            // gbxDanhSach
            // 
            this.gbxDanhSach.Controls.Add(this.lvwReceipt);
            this.gbxDanhSach.Location = new System.Drawing.Point(13, 188);
            this.gbxDanhSach.Name = "gbxDanhSach";
            this.gbxDanhSach.Size = new System.Drawing.Size(590, 396);
            this.gbxDanhSach.TabIndex = 1;
            this.gbxDanhSach.TabStop = false;
            this.gbxDanhSach.Text = "Danh sách";
            // 
            // lvwReceipt
            // 
            this.lvwReceipt.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lvwReceipt.FullRowSelect = true;
            this.lvwReceipt.GridLines = true;
            this.lvwReceipt.Location = new System.Drawing.Point(10, 29);
            this.lvwReceipt.MultiSelect = false;
            this.lvwReceipt.Name = "lvwReceipt";
            this.lvwReceipt.Size = new System.Drawing.Size(574, 361);
            this.lvwReceipt.TabIndex = 0;
            this.lvwReceipt.UseCompatibleStateImageBehavior = false;
            this.lvwReceipt.View = System.Windows.Forms.View.Details;
            this.lvwReceipt.SelectedIndexChanged += new System.EventHandler(this.lvwReceipt_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Người thu tiền";
            this.columnHeader1.Width = 190;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên loại thu";
            this.columnHeader2.Width = 110;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Nhận từ";
            this.columnHeader3.Width = 190;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Số tiền";
            this.columnHeader4.Width = 103;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Tiền tệ";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Tỷ giá";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Ngày thu";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Ghi chú";
            // 
            // btnInsert
            // 
            this.btnInsert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInsert.ImageIndex = 0;
            this.btnInsert.ImageList = this.imgInsert;
            this.btnInsert.Location = new System.Drawing.Point(70, 590);
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
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(169, 590);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 25);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(268, 590);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 25);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(367, 590);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 25);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(466, 590);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(93, 25);
            this.btnPrint.TabIndex = 22;
            this.btnPrint.Text = "In phiếu";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmCashReceiptVoucher
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(615, 626);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbxDanhSach);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.gbxTTThuTien);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCashReceiptVoucher";
            this.Text = "Thông tin thu tiền";
            this.Load += new System.EventHandler(this.frmCashReceiptVoucher_Load);
            this.gbxTTThuTien.ResumeLayout(false);
            this.gbxTTThuTien.PerformLayout();
            this.gbxDanhSach.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxTTThuTien;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboAmountType;
        private System.Windows.Forms.ComboBox cboReceiptType;
        private System.Windows.Forms.ComboBox cboPersonReceipt;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtPlaces;
        private System.Windows.Forms.TextBox txtReceiptCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbxDanhSach;
        private System.Windows.Forms.ListView lvwReceipt;
        private System.Windows.Forms.DateTimePicker dtpTimeReceipt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblDateReceipt;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ImageList imgInsert;
    }
}