namespace SaleMTInterfaces.FrmSaleManagement
{
    partial class dlgSearchCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgSearchCustomer));
            this.gbListCustomer = new System.Windows.Forms.GroupBox();
            this.dgvCustomer = new System.Windows.Forms.DataGridView();
            this.clnSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnCustomerCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnOldCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPhoneNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnBirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnIDNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnTelephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnAdress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPlace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPurchase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbPage = new System.Windows.Forms.GroupBox();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnGoPage = new System.Windows.Forms.Button();
            this.txtPageGo = new System.Windows.Forms.TextBox();
            this.lblTotalRow = new System.Windows.Forms.Label();
            this.lblPage = new System.Windows.Forms.Label();
            this.cboRowOnPage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkActiveCustomer = new System.Windows.Forms.CheckBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.gbListCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            this.gbPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbListCustomer
            // 
            this.gbListCustomer.Controls.Add(this.dgvCustomer);
            this.gbListCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbListCustomer.Location = new System.Drawing.Point(3, 1);
            this.gbListCustomer.Name = "gbListCustomer";
            this.gbListCustomer.Size = new System.Drawing.Size(706, 401);
            this.gbListCustomer.TabIndex = 0;
            this.gbListCustomer.TabStop = false;
            this.gbListCustomer.Text = "Danh sách khách hàng";
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.AllowUserToAddRows = false;
            this.dgvCustomer.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCustomer.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCustomer.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvCustomer.ColumnHeadersHeight = 26;
            this.dgvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnSTT,
            this.clnCustomerCode,
            this.clnOldCode,
            this.clnFirstName,
            this.clnLastName,
            this.clnPhoneNumber,
            this.clnBirthDate,
            this.clnIDNO,
            this.clnTelephone,
            this.clnEmail,
            this.clnAdress,
            this.clnGroup,
            this.clnPlace,
            this.clnPurchase});
            this.dgvCustomer.Location = new System.Drawing.Point(6, 19);
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.ReadOnly = true;
            this.dgvCustomer.RowHeadersVisible = false;
            this.dgvCustomer.Size = new System.Drawing.Size(694, 376);
            this.dgvCustomer.TabIndex = 0;
            this.dgvCustomer.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomer_CellDoubleClick);
            this.dgvCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCustomer_KeyDown);
            this.dgvCustomer.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCustomer_DataBindingComplete);
            this.dgvCustomer.SelectionChanged += new System.EventHandler(this.dgvCustomer_SelectionChanged);
            // 
            // clnSTT
            // 
            this.clnSTT.DataPropertyName = "STT";
            this.clnSTT.HeaderText = "STT";
            this.clnSTT.Name = "clnSTT";
            this.clnSTT.ReadOnly = true;
            this.clnSTT.Visible = false;
            // 
            // clnCustomerCode
            // 
            this.clnCustomerCode.DataPropertyName = "CUSTOMER_ID";
            this.clnCustomerCode.HeaderText = "Mã KH";
            this.clnCustomerCode.Name = "clnCustomerCode";
            this.clnCustomerCode.ReadOnly = true;
            this.clnCustomerCode.Width = 150;
            // 
            // clnOldCode
            // 
            this.clnOldCode.DataPropertyName = "MACU";
            this.clnOldCode.HeaderText = "Mã cũ";
            this.clnOldCode.Name = "clnOldCode";
            this.clnOldCode.ReadOnly = true;
            // 
            // clnFirstName
            // 
            this.clnFirstName.DataPropertyName = "FIRST_NAME";
            this.clnFirstName.HeaderText = "Tên";
            this.clnFirstName.Name = "clnFirstName";
            this.clnFirstName.ReadOnly = true;
            this.clnFirstName.Width = 170;
            // 
            // clnLastName
            // 
            this.clnLastName.DataPropertyName = "LAST_NAME";
            this.clnLastName.HeaderText = "Họ";
            this.clnLastName.Name = "clnLastName";
            this.clnLastName.ReadOnly = true;
            this.clnLastName.Width = 120;
            // 
            // clnPhoneNumber
            // 
            this.clnPhoneNumber.DataPropertyName = "MOBILE_PHONE";
            this.clnPhoneNumber.HeaderText = "ĐT di động";
            this.clnPhoneNumber.Name = "clnPhoneNumber";
            this.clnPhoneNumber.ReadOnly = true;
            // 
            // clnBirthDate
            // 
            this.clnBirthDate.DataPropertyName = "DATE_OF_BIRTH";
            this.clnBirthDate.HeaderText = "Ngày sinh";
            this.clnBirthDate.Name = "clnBirthDate";
            this.clnBirthDate.ReadOnly = true;
            // 
            // clnIDNO
            // 
            this.clnIDNO.DataPropertyName = "ID_NO";
            this.clnIDNO.HeaderText = "CMND";
            this.clnIDNO.Name = "clnIDNO";
            this.clnIDNO.ReadOnly = true;
            // 
            // clnTelephone
            // 
            this.clnTelephone.DataPropertyName = "TEL";
            this.clnTelephone.HeaderText = "ĐT bàn";
            this.clnTelephone.Name = "clnTelephone";
            this.clnTelephone.ReadOnly = true;
            // 
            // clnEmail
            // 
            this.clnEmail.DataPropertyName = "EMAIL_ADDRESS";
            this.clnEmail.HeaderText = "Email";
            this.clnEmail.Name = "clnEmail";
            this.clnEmail.ReadOnly = true;
            // 
            // clnAdress
            // 
            this.clnAdress.DataPropertyName = "ADDRESS";
            this.clnAdress.HeaderText = "Địa chỉ";
            this.clnAdress.Name = "clnAdress";
            this.clnAdress.ReadOnly = true;
            this.clnAdress.Width = 200;
            // 
            // clnGroup
            // 
            this.clnGroup.DataPropertyName = "CUSTOMER_GROUP_CODE";
            this.clnGroup.HeaderText = "group";
            this.clnGroup.Name = "clnGroup";
            this.clnGroup.ReadOnly = true;
            this.clnGroup.Visible = false;
            // 
            // clnPlace
            // 
            this.clnPlace.DataPropertyName = "DEPT_CODE";
            this.clnPlace.HeaderText = "CH";
            this.clnPlace.Name = "clnPlace";
            this.clnPlace.ReadOnly = true;
            this.clnPlace.Visible = false;
            // 
            // clnPurchase
            // 
            this.clnPurchase.DataPropertyName = "Purchase";
            this.clnPurchase.HeaderText = "Doanh số";
            this.clnPurchase.Name = "clnPurchase";
            this.clnPurchase.ReadOnly = true;
            this.clnPurchase.Visible = false;
            // 
            // gbPage
            // 
            this.gbPage.Controls.Add(this.btnLast);
            this.gbPage.Controls.Add(this.btnNext);
            this.gbPage.Controls.Add(this.btnPrev);
            this.gbPage.Controls.Add(this.btnFirst);
            this.gbPage.Controls.Add(this.btnGoPage);
            this.gbPage.Controls.Add(this.txtPageGo);
            this.gbPage.Controls.Add(this.lblTotalRow);
            this.gbPage.Controls.Add(this.lblPage);
            this.gbPage.Controls.Add(this.cboRowOnPage);
            this.gbPage.Controls.Add(this.label1);
            this.gbPage.Location = new System.Drawing.Point(3, 399);
            this.gbPage.Name = "gbPage";
            this.gbPage.Size = new System.Drawing.Size(706, 39);
            this.gbPage.TabIndex = 1;
            this.gbPage.TabStop = false;
            // 
            // btnLast
            // 
            this.btnLast.Image = global::SaleMTInterfaces.Properties.Resources.p2;
            this.btnLast.Location = new System.Drawing.Point(228, 10);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(32, 23);
            this.btnLast.TabIndex = 9;
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnNext
            // 
            this.btnNext.Image = global::SaleMTInterfaces.Properties.Resources.p3;
            this.btnNext.Location = new System.Drawing.Point(201, 10);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(27, 23);
            this.btnNext.TabIndex = 8;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Image = global::SaleMTInterfaces.Properties.Resources.p1;
            this.btnPrev.Location = new System.Drawing.Point(174, 10);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(28, 23);
            this.btnPrev.TabIndex = 7;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Image = global::SaleMTInterfaces.Properties.Resources.p4;
            this.btnFirst.Location = new System.Drawing.Point(143, 10);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(31, 23);
            this.btnFirst.TabIndex = 6;
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnGoPage
            // 
            this.btnGoPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoPage.Image = global::SaleMTInterfaces.Properties.Resources.next;
            this.btnGoPage.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnGoPage.Location = new System.Drawing.Point(614, 9);
            this.btnGoPage.Name = "btnGoPage";
            this.btnGoPage.Size = new System.Drawing.Size(88, 25);
            this.btnGoPage.TabIndex = 5;
            this.btnGoPage.Text = "Tới trang";
            this.btnGoPage.UseVisualStyleBackColor = true;
            this.btnGoPage.Click += new System.EventHandler(this.btnGoPage_Click);
            // 
            // txtPageGo
            // 
            this.txtPageGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPageGo.Location = new System.Drawing.Point(550, 11);
            this.txtPageGo.Name = "txtPageGo";
            this.txtPageGo.Size = new System.Drawing.Size(60, 21);
            this.txtPageGo.TabIndex = 4;
            this.txtPageGo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // lblTotalRow
            // 
            this.lblTotalRow.AutoSize = true;
            this.lblTotalRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRow.Location = new System.Drawing.Point(408, 13);
            this.lblTotalRow.Name = "lblTotalRow";
            this.lblTotalRow.Size = new System.Drawing.Size(46, 16);
            this.lblTotalRow.TabIndex = 3;
            this.lblTotalRow.Text = "Tổng :";
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPage.Location = new System.Drawing.Point(266, 14);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(46, 17);
            this.lblPage.TabIndex = 2;
            this.lblPage.Text = "Trang";
            // 
            // cboRowOnPage
            // 
            this.cboRowOnPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRowOnPage.FormattingEnabled = true;
            this.cboRowOnPage.Items.AddRange(new object[] {
            "20",
            "40",
            "60",
            "80",
            "100",
            "200",
            "300",
            "500"});
            this.cboRowOnPage.Location = new System.Drawing.Point(96, 10);
            this.cboRowOnPage.Name = "cboRowOnPage";
            this.cboRowOnPage.Size = new System.Drawing.Size(43, 24);
            this.cboRowOnPage.TabIndex = 1;
            this.cboRowOnPage.SelectedIndexChanged += new System.EventHandler(this.cboRowOnPage_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dòng/ trang";
            // 
            // chkActiveCustomer
            // 
            this.chkActiveCustomer.AutoSize = true;
            this.chkActiveCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActiveCustomer.Location = new System.Drawing.Point(7, 447);
            this.chkActiveCustomer.Name = "chkActiveCustomer";
            this.chkActiveCustomer.Size = new System.Drawing.Size(208, 21);
            this.chkActiveCustomer.TabIndex = 2;
            this.chkActiveCustomer.Text = "Khách hàng ngưng kích hoạt";
            this.chkActiveCustomer.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::SaleMTInterfaces.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(347, 444);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 25);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Image = global::SaleMTInterfaces.Properties.Resources.tick;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(270, 444);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dlgSearchCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 472);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkActiveCustomer);
            this.Controls.Add(this.gbPage);
            this.Controls.Add(this.gbListCustomer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dlgSearchCustomer";
            this.ShowInTaskbar = false;
            this.Text = "Kết quả tìm kiếm";
            this.Load += new System.EventHandler(this.frmDialogSearchCustomer_Load);
            this.gbListCustomer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            this.gbPage.ResumeLayout(false);
            this.gbPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbListCustomer;
        private System.Windows.Forms.DataGridView dgvCustomer;
        private System.Windows.Forms.GroupBox gbPage;
        private System.Windows.Forms.CheckBox chkActiveCustomer;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cboRowOnPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.TextBox txtPageGo;
        private System.Windows.Forms.Label lblTotalRow;
        private System.Windows.Forms.Button btnGoPage;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCustomerCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnOldCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnFirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPhoneNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnBirthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnIDNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnTelephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAdress;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPlace;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPurchase;
    }
}