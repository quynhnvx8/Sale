namespace SaleMTInterfaces.FrmSaleManagement
{
    partial class frmDialogRedInvoiceMng
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDialogRedInvoiceMng));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.txtCusName = new System.Windows.Forms.TextBox();
            this.txtCusID = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvRedInvoiceList = new System.Windows.Forms.DataGridView();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.INVOICE_NO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OFFICE_WORKING = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OFFICE_ADDRESS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TAX_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL_QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL_MONEY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRINT_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.REMARKS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AUTO_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICE_INFO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREATE_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USER_CREATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PAYMENT_TYPE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LIST_INVOICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRedInvoiceList)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.txtCusName);
            this.groupBox1.Controls.Add(this.txtCusID);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox1.Location = new System.Drawing.Point(8, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(828, 77);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // btnReset
            // 
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.Location = new System.Drawing.Point(341, 22);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(30, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(305, 22);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(30, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(393, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Đến ngày";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "In từ ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(405, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tên KH";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã khách hàng";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(464, 48);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(119, 22);
            this.dtpToDate.TabIndex = 6;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(119, 48);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(110, 22);
            this.dtpFromDate.TabIndex = 5;
            // 
            // txtCusName
            // 
            this.txtCusName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtCusName.Location = new System.Drawing.Point(464, 22);
            this.txtCusName.Name = "txtCusName";
            this.txtCusName.ReadOnly = true;
            this.txtCusName.Size = new System.Drawing.Size(228, 22);
            this.txtCusName.TabIndex = 4;
            // 
            // txtCusID
            // 
            this.txtCusID.Location = new System.Drawing.Point(119, 22);
            this.txtCusID.Name = "txtCusID";
            this.txtCusID.Size = new System.Drawing.Size(180, 22);
            this.txtCusID.TabIndex = 1;
            this.txtCusID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCusID_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvRedInvoiceList);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.groupBox2.Location = new System.Drawing.Point(14, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(822, 385);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách";
            // 
            // dgvRedInvoiceList
            // 
            this.dgvRedInvoiceList.AllowUserToAddRows = false;
            this.dgvRedInvoiceList.AllowUserToDeleteRows = false;
            this.dgvRedInvoiceList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRedInvoiceList.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvRedInvoiceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.INVOICE_NO,
            this.OFFICE_WORKING,
            this.OFFICE_ADDRESS,
            this.TAX_CODE,
            this.TOTAL_QUANTITY,
            this.TOTAL_MONEY,
            this.VAT,
            this.TOTAL,
            this.PRINT_DATE,
            this.REMARKS,
            this.AUTO_ID,
            this.INVOICE_INFO,
            this.CREATE_DATE,
            this.USER_CREATE,
            this.PAYMENT_TYPE,
            this.CUSTOMER_ID,
            this.LIST_INVOICE});
            this.dgvRedInvoiceList.Location = new System.Drawing.Point(6, 20);
            this.dgvRedInvoiceList.MultiSelect = false;
            this.dgvRedInvoiceList.Name = "dgvRedInvoiceList";
            this.dgvRedInvoiceList.ReadOnly = true;
            this.dgvRedInvoiceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRedInvoiceList.Size = new System.Drawing.Size(810, 365);
            this.dgvRedInvoiceList.TabIndex = 8;
            this.dgvRedInvoiceList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvRedInvoiceList_DataBindingComplete);
            // 
            // btnLoad
            // 
            this.btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("btnLoad.Image")));
            this.btnLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoad.Location = new System.Drawing.Point(746, 95);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(90, 25);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Tìm";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(462, 517);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(88, 25);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "In";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnView
            // 
            this.btnView.Image = ((System.Drawing.Image)(resources.GetObject("btnView.Image")));
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(556, 517);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(80, 25);
            this.btnView.TabIndex = 12;
            this.btnView.Text = "Xem lại";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(642, 517);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 25);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(736, 517);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 25);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // INVOICE_NO
            // 
            this.INVOICE_NO.DataPropertyName = "INVOICE_NO";
            this.INVOICE_NO.HeaderText = "Số hóa đơn đỏ";
            this.INVOICE_NO.Name = "INVOICE_NO";
            this.INVOICE_NO.ReadOnly = true;
            this.INVOICE_NO.Width = 120;
            // 
            // OFFICE_WORKING
            // 
            this.OFFICE_WORKING.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.OFFICE_WORKING.DataPropertyName = "OFFICE_WORKING";
            this.OFFICE_WORKING.HeaderText = "Tên đơn vị";
            this.OFFICE_WORKING.Name = "OFFICE_WORKING";
            this.OFFICE_WORKING.ReadOnly = true;
            this.OFFICE_WORKING.Width = 96;
            // 
            // OFFICE_ADDRESS
            // 
            this.OFFICE_ADDRESS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.OFFICE_ADDRESS.DataPropertyName = "OFFICE_ADDRESS";
            this.OFFICE_ADDRESS.HeaderText = "Địa chỉ";
            this.OFFICE_ADDRESS.Name = "OFFICE_ADDRESS";
            this.OFFICE_ADDRESS.ReadOnly = true;
            this.OFFICE_ADDRESS.Width = 73;
            // 
            // TAX_CODE
            // 
            this.TAX_CODE.DataPropertyName = "TAX_CODE";
            this.TAX_CODE.HeaderText = "Mã số thuế";
            this.TAX_CODE.Name = "TAX_CODE";
            this.TAX_CODE.ReadOnly = true;
            this.TAX_CODE.Width = 120;
            // 
            // TOTAL_QUANTITY
            // 
            this.TOTAL_QUANTITY.DataPropertyName = "TOTAL_QUANTITY";
            this.TOTAL_QUANTITY.HeaderText = "Số lượng";
            this.TOTAL_QUANTITY.Name = "TOTAL_QUANTITY";
            this.TOTAL_QUANTITY.ReadOnly = true;
            this.TOTAL_QUANTITY.Width = 80;
            // 
            // TOTAL_MONEY
            // 
            this.TOTAL_MONEY.DataPropertyName = "TOTAL_MONEY";
            dataGridViewCellStyle1.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency;
            this.TOTAL_MONEY.DefaultCellStyle = dataGridViewCellStyle1;
            this.TOTAL_MONEY.HeaderText = "Tiền hàng";
            this.TOTAL_MONEY.Name = "TOTAL_MONEY";
            this.TOTAL_MONEY.ReadOnly = true;
            this.TOTAL_MONEY.Width = 120;
            // 
            // VAT
            // 
            this.VAT.DataPropertyName = "VAT";
            dataGridViewCellStyle2.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency;
            this.VAT.DefaultCellStyle = dataGridViewCellStyle2;
            this.VAT.HeaderText = "Tiền thuế GTGT";
            this.VAT.Name = "VAT";
            this.VAT.ReadOnly = true;
            this.VAT.Width = 120;
            // 
            // TOTAL
            // 
            this.TOTAL.DataPropertyName = "TOTAL";
            dataGridViewCellStyle3.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptCurency;
            this.TOTAL.DefaultCellStyle = dataGridViewCellStyle3;
            this.TOTAL.HeaderText = "Tổng cộng tiền thanh toán";
            this.TOTAL.Name = "TOTAL";
            this.TOTAL.ReadOnly = true;
            this.TOTAL.Width = 120;
            // 
            // PRINT_DATE
            // 
            this.PRINT_DATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.PRINT_DATE.DataPropertyName = "PRINT_DATE";
            this.PRINT_DATE.HeaderText = "Ngày in";
            this.PRINT_DATE.Name = "PRINT_DATE";
            this.PRINT_DATE.ReadOnly = true;
            this.PRINT_DATE.Width = 79;
            // 
            // REMARKS
            // 
            this.REMARKS.DataPropertyName = "REMARKS";
            this.REMARKS.HeaderText = "Ghi chú HĐ đỏ";
            this.REMARKS.Name = "REMARKS";
            this.REMARKS.ReadOnly = true;
            this.REMARKS.Width = 120;
            // 
            // AUTO_ID
            // 
            this.AUTO_ID.DataPropertyName = "AUTO_ID";
            this.AUTO_ID.HeaderText = "AUTO_ID";
            this.AUTO_ID.Name = "AUTO_ID";
            this.AUTO_ID.ReadOnly = true;
            this.AUTO_ID.Visible = false;
            // 
            // INVOICE_INFO
            // 
            this.INVOICE_INFO.DataPropertyName = "INVOICE_INFO";
            this.INVOICE_INFO.HeaderText = "INVOICE_INFO";
            this.INVOICE_INFO.Name = "INVOICE_INFO";
            this.INVOICE_INFO.ReadOnly = true;
            this.INVOICE_INFO.Visible = false;
            // 
            // CREATE_DATE
            // 
            this.CREATE_DATE.DataPropertyName = "CREATE_DATE";
            this.CREATE_DATE.HeaderText = "CREATE_DATE";
            this.CREATE_DATE.Name = "CREATE_DATE";
            this.CREATE_DATE.ReadOnly = true;
            this.CREATE_DATE.Visible = false;
            // 
            // USER_CREATE
            // 
            this.USER_CREATE.DataPropertyName = "USER_CREATE";
            this.USER_CREATE.HeaderText = "USER_CREATE";
            this.USER_CREATE.Name = "USER_CREATE";
            this.USER_CREATE.ReadOnly = true;
            this.USER_CREATE.Visible = false;
            // 
            // PAYMENT_TYPE
            // 
            this.PAYMENT_TYPE.DataPropertyName = "USER_CREATE";
            this.PAYMENT_TYPE.HeaderText = "PAYMENT_TYPE";
            this.PAYMENT_TYPE.Name = "PAYMENT_TYPE";
            this.PAYMENT_TYPE.ReadOnly = true;
            this.PAYMENT_TYPE.Visible = false;
            // 
            // CUSTOMER_ID
            // 
            this.CUSTOMER_ID.DataPropertyName = "CUSTOMER_ID";
            this.CUSTOMER_ID.HeaderText = "CUSTOMER_ID";
            this.CUSTOMER_ID.Name = "CUSTOMER_ID";
            this.CUSTOMER_ID.ReadOnly = true;
            this.CUSTOMER_ID.Visible = false;
            // 
            // LIST_INVOICE
            // 
            this.LIST_INVOICE.DataPropertyName = "LIST_INVOICE";
            this.LIST_INVOICE.HeaderText = "LIST_INVOICE";
            this.LIST_INVOICE.Name = "LIST_INVOICE";
            this.LIST_INVOICE.ReadOnly = true;
            this.LIST_INVOICE.Visible = false;
            // 
            // frmDialogRedInvoiceMng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 558);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDialogRedInvoiceMng";
            this.Text = "Quản lý hóa đơn đỏ";
            this.Load += new System.EventHandler(this.DialogRedInvoiceMng_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRedInvoiceList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.TextBox txtCusName;
        private System.Windows.Forms.TextBox txtCusID;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvRedInvoiceList;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_NO;
        private System.Windows.Forms.DataGridViewTextBoxColumn OFFICE_WORKING;
        private System.Windows.Forms.DataGridViewTextBoxColumn OFFICE_ADDRESS;
        private System.Windows.Forms.DataGridViewTextBoxColumn TAX_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL_QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL_MONEY;
        private System.Windows.Forms.DataGridViewTextBoxColumn VAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRINT_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn REMARKS;
        private System.Windows.Forms.DataGridViewTextBoxColumn AUTO_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_INFO;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREATE_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn USER_CREATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PAYMENT_TYPE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LIST_INVOICE;
    }
}