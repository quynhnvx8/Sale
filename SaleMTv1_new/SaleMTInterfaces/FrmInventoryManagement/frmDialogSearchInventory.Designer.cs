namespace SaleMTInterfaces.FrmInventoryManagement
{
    partial class frmDialogSearchInventory
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rdbProductName = new System.Windows.Forms.RadioButton();
            this.rdbProductCode = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.chkProduct = new System.Windows.Forms.CheckBox();
            this.picProduct = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvListProduct = new System.Windows.Forms.DataGridView();
            this.clnProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtProductCode);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.rdbProductName);
            this.groupBox1.Controls.Add(this.rdbProductCode);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 114);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductCode.Location = new System.Drawing.Point(12, 81);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(175, 23);
            this.txtProductCode.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::SaleMTInterfaces.Properties.Resources.tick;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(193, 81);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rdbProductName
            // 
            this.rdbProductName.AutoSize = true;
            this.rdbProductName.Location = new System.Drawing.Point(12, 47);
            this.rdbProductName.Name = "rdbProductName";
            this.rdbProductName.Size = new System.Drawing.Size(87, 21);
            this.rdbProductName.TabIndex = 4;
            this.rdbProductName.Text = "Tên hàng";
            this.rdbProductName.UseVisualStyleBackColor = true;
            this.rdbProductName.Click += new System.EventHandler(this.rdbProductName_Click);
            // 
            // rdbProductCode
            // 
            this.rdbProductCode.AutoSize = true;
            this.rdbProductCode.Checked = true;
            this.rdbProductCode.Location = new System.Drawing.Point(12, 19);
            this.rdbProductCode.Name = "rdbProductCode";
            this.rdbProductCode.Size = new System.Drawing.Size(81, 21);
            this.rdbProductCode.TabIndex = 3;
            this.rdbProductCode.TabStop = true;
            this.rdbProductCode.Text = "Mã hàng";
            this.rdbProductCode.UseVisualStyleBackColor = true;
            this.rdbProductCode.Click += new System.EventHandler(this.rdbProductCode_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLast);
            this.groupBox2.Controls.Add(this.btnNext);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.chkProduct);
            this.groupBox2.Controls.Add(this.picProduct);
            this.groupBox2.Location = new System.Drawing.Point(13, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 294);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnLast
            // 
            this.btnLast.Enabled = false;
            this.btnLast.Image = global::SaleMTInterfaces.Properties.Resources.last;
            this.btnLast.Location = new System.Drawing.Point(236, 266);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(32, 23);
            this.btnLast.TabIndex = 13;
            this.btnLast.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Enabled = false;
            this.btnNext.Image = global::SaleMTInterfaces.Properties.Resources.next;
            this.btnNext.Location = new System.Drawing.Point(210, 266);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(27, 23);
            this.btnNext.TabIndex = 12;
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Image = global::SaleMTInterfaces.Properties.Resources.prev;
            this.button2.Location = new System.Drawing.Point(183, 266);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(28, 23);
            this.button2.TabIndex = 11;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Image = global::SaleMTInterfaces.Properties.Resources.first;
            this.button1.Location = new System.Drawing.Point(153, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 23);
            this.button1.TabIndex = 10;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // chkProduct
            // 
            this.chkProduct.AutoSize = true;
            this.chkProduct.Checked = true;
            this.chkProduct.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProduct.Location = new System.Drawing.Point(7, 271);
            this.chkProduct.Name = "chkProduct";
            this.chkProduct.Size = new System.Drawing.Size(15, 14);
            this.chkProduct.TabIndex = 5;
            this.chkProduct.UseVisualStyleBackColor = true;
            // 
            // picProduct
            // 
            this.picProduct.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.picProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picProduct.Location = new System.Drawing.Point(7, 12);
            this.picProduct.Name = "picProduct";
            this.picProduct.Size = new System.Drawing.Size(262, 242);
            this.picProduct.TabIndex = 0;
            this.picProduct.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvListProduct);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(295, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(418, 414);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách";
            // 
            // dgvListProduct
            // 
            this.dgvListProduct.AllowUserToAddRows = false;
            this.dgvListProduct.AllowUserToDeleteRows = false;
            this.dgvListProduct.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvListProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnProductCode,
            this.clnProductName,
            this.clnPrice,
            this.clnShortName});
            this.dgvListProduct.Location = new System.Drawing.Point(7, 17);
            this.dgvListProduct.Name = "dgvListProduct";
            this.dgvListProduct.ReadOnly = true;
            this.dgvListProduct.Size = new System.Drawing.Size(405, 388);
            this.dgvListProduct.TabIndex = 0;
            this.dgvListProduct.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListProduct_CellDoubleClick);
            this.dgvListProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListProduct_KeyDown);
            this.dgvListProduct.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvListProduct_DataBindingComplete);
            // 
            // clnProductCode
            // 
            this.clnProductCode.DataPropertyName = "PRODUCT_ID";
            this.clnProductCode.HeaderText = "Mã hàng";
            this.clnProductCode.Name = "clnProductCode";
            this.clnProductCode.ReadOnly = true;
            this.clnProductCode.Width = 120;
            // 
            // clnProductName
            // 
            this.clnProductName.DataPropertyName = "PRODUCT_NAME";
            this.clnProductName.HeaderText = "Tên hàng";
            this.clnProductName.Name = "clnProductName";
            this.clnProductName.ReadOnly = true;
            this.clnProductName.Width = 230;
            // 
            // clnPrice
            // 
            this.clnPrice.DataPropertyName = "Price";
            this.clnPrice.HeaderText = "Price";
            this.clnPrice.Name = "clnPrice";
            this.clnPrice.ReadOnly = true;
            this.clnPrice.Visible = false;
            // 
            // clnShortName
            // 
            this.clnShortName.DataPropertyName = "SHORT_NAME";
            this.clnShortName.HeaderText = "short";
            this.clnShortName.Name = "clnShortName";
            this.clnShortName.ReadOnly = true;
            this.clnShortName.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Image = global::SaleMTInterfaces.Properties.Resources.tick;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(275, 433);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 26);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::SaleMTInterfaces.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(361, 433);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 26);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmDialogSearchInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 464);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDialogSearchInventory";
            this.Text = "Tìm kiếm mã hàng";
            this.Load += new System.EventHandler(this.frmDialogSearchInventory_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDialogSearchInventory_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProduct)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvListProduct;
        private System.Windows.Forms.RadioButton rdbProductName;
        private System.Windows.Forms.RadioButton rdbProductCode;
        private System.Windows.Forms.CheckBox chkProduct;
        private System.Windows.Forms.PictureBox picProduct;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnShortName;
    }
}