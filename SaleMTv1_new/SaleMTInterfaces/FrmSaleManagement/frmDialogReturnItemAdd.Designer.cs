namespace SaleMTInterfaces.FrmSaleManagement
{
    partial class frmDialogReturnItemAdd
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDialogReturnItemAdd));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTotalCashReturn = new System.Windows.Forms.TextBox();
            this.dgvDetailsBill = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.rtfReasons = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboReasons = new System.Windows.Forms.ComboBox();
            this.txtBillCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.clnProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPriceSale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCashReturn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnREASON = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnMASTER_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailsBill)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTotalCashReturn);
            this.groupBox1.Controls.Add(this.dgvDetailsBill);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.rtfReasons);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dtpTime);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.cboReasons);
            this.groupBox1.Controls.Add(this.txtBillCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(701, 449);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin trả hàng";
            // 
            // txtTotalCashReturn
            // 
            this.txtTotalCashReturn.Enabled = false;
            this.txtTotalCashReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalCashReturn.Location = new System.Drawing.Point(148, 418);
            this.txtTotalCashReturn.Name = "txtTotalCashReturn";
            this.txtTotalCashReturn.Size = new System.Drawing.Size(276, 23);
            this.txtTotalCashReturn.TabIndex = 12;
            this.txtTotalCashReturn.Text = "0";
            this.txtTotalCashReturn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgvDetailsBill
            // 
            this.dgvDetailsBill.AllowUserToAddRows = false;
            this.dgvDetailsBill.AllowUserToDeleteRows = false;
            this.dgvDetailsBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailsBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnProductCode,
            this.clnProductName,
            this.clnQuantity,
            this.clnPriceSale,
            this.clnCashReturn,
            this.clnCode,
            this.clnREASON,
            this.clnMASTER_CODE});
            this.dgvDetailsBill.Location = new System.Drawing.Point(6, 171);
            this.dgvDetailsBill.Name = "dgvDetailsBill";
            this.dgvDetailsBill.ReadOnly = true;
            this.dgvDetailsBill.Size = new System.Drawing.Size(689, 238);
            this.dgvDetailsBill.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 421);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tổng tiền trả lại";
            // 
            // rtfReasons
            // 
            this.rtfReasons.Location = new System.Drawing.Point(148, 100);
            this.rtfReasons.Name = "rtfReasons";
            this.rtfReasons.Size = new System.Drawing.Size(547, 62);
            this.rtfReasons.TabIndex = 10;
            this.rtfReasons.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Thông tin phản hồi (*)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Lý do trả (*)";
            // 
            // dtpTime
            // 
            this.dtpTime.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptHour;
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTime.Location = new System.Drawing.Point(319, 46);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(105, 23);
            this.dtpTime.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(268, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Giờ(*)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ngày(*)";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(148, 46);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(105, 23);
            this.dtpDate.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::SaleMTInterfaces.Properties.Resources.search_zoom;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(430, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(88, 25);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboReasons
            // 
            this.cboReasons.FormattingEnabled = true;
            this.cboReasons.Location = new System.Drawing.Point(148, 72);
            this.cboReasons.Name = "cboReasons";
            this.cboReasons.Size = new System.Drawing.Size(174, 24);
            this.cboReasons.TabIndex = 2;
            // 
            // txtBillCode
            // 
            this.txtBillCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillCode.Location = new System.Drawing.Point(148, 20);
            this.txtBillCode.Name = "txtBillCode";
            this.txtBillCode.Size = new System.Drawing.Size(276, 23);
            this.txtBillCode.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã hóa đơn(*)";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSave.Image = global::SaleMTInterfaces.Properties.Resources.save1;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSave.Location = new System.Drawing.Point(257, 467);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 25);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnClose.Image = global::SaleMTInterfaces.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(347, 467);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 25);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // clnProductCode
            // 
            this.clnProductCode.DataPropertyName = "PRODUCT_ID";
            this.clnProductCode.HeaderText = "Mã hàng";
            this.clnProductCode.Name = "clnProductCode";
            this.clnProductCode.ReadOnly = true;
            // 
            // clnProductName
            // 
            this.clnProductName.DataPropertyName = "PRODUCT_NAME";
            this.clnProductName.HeaderText = "Tên hàng";
            this.clnProductName.Name = "clnProductName";
            this.clnProductName.ReadOnly = true;
            this.clnProductName.Width = 160;
            // 
            // clnQuantity
            // 
            this.clnQuantity.DataPropertyName = "QUANTITY";
            this.clnQuantity.HeaderText = "Số lượng";
            this.clnQuantity.Name = "clnQuantity";
            this.clnQuantity.ReadOnly = true;
            this.clnQuantity.Width = 90;
            // 
            // clnPriceSale
            // 
            this.clnPriceSale.DataPropertyName = "PRICE_SALES";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = "0";
            this.clnPriceSale.DefaultCellStyle = dataGridViewCellStyle1;
            this.clnPriceSale.HeaderText = "Giá bán";
            this.clnPriceSale.Name = "clnPriceSale";
            this.clnPriceSale.ReadOnly = true;
            // 
            // clnCashReturn
            // 
            this.clnCashReturn.DataPropertyName = "TOTAL_AMOUNT";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = "0";
            this.clnCashReturn.DefaultCellStyle = dataGridViewCellStyle2;
            this.clnCashReturn.HeaderText = "Tiền trả lại";
            this.clnCashReturn.Name = "clnCashReturn";
            this.clnCashReturn.ReadOnly = true;
            // 
            // clnCode
            // 
            this.clnCode.DataPropertyName = "ITEM_RETURN_DETAIL_CODE";
            this.clnCode.HeaderText = "code";
            this.clnCode.Name = "clnCode";
            this.clnCode.ReadOnly = true;
            this.clnCode.Visible = false;
            // 
            // clnREASON
            // 
            this.clnREASON.HeaderText = "REASON";
            this.clnREASON.Name = "clnREASON";
            this.clnREASON.ReadOnly = true;
            this.clnREASON.Visible = false;
            // 
            // clnMASTER_CODE
            // 
            this.clnMASTER_CODE.HeaderText = "MASTER_CODE";
            this.clnMASTER_CODE.Name = "clnMASTER_CODE";
            this.clnMASTER_CODE.ReadOnly = true;
            this.clnMASTER_CODE.Visible = false;
            // 
            // frmDialogReturnItemAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 498);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDialogReturnItemAdd";
            this.Text = "Thông tin trả hàng";
            this.Load += new System.EventHandler(this.frmDialogReturnItemAdd_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDialogReturnItemAdd_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailsBill)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboReasons;
        private System.Windows.Forms.TextBox txtBillCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtfReasons;
        private System.Windows.Forms.DataGridView dgvDetailsBill;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotalCashReturn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPriceSale;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCashReturn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnREASON;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnMASTER_CODE;
    }
}