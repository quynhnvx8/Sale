namespace SaleMTInterfaces.FrmSaleManagement
{
    partial class frmDialogDiscountProduct
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
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.clnChose = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clnProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPriceSales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnIntoMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkChose = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvProduct);
            this.groupBox1.Controls.Add(this.chkChose);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(668, 259);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách hàng";
            // 
            // dgvProduct
            // 
            this.dgvProduct.AllowUserToAddRows = false;
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnChose,
            this.clnProductCode,
            this.clnProductName,
            this.clnQuantity,
            this.clnPrice,
            this.clnPriceSales,
            this.clnIntoMoney});
            this.dgvProduct.Location = new System.Drawing.Point(6, 43);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.Size = new System.Drawing.Size(655, 210);
            this.dgvProduct.TabIndex = 1;
            this.dgvProduct.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // clnChose
            // 
            this.clnChose.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clnChose.HeaderText = "Chọn";
            this.clnChose.MinimumWidth = 20;
            this.clnChose.Name = "clnChose";
            this.clnChose.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // clnProductCode
            // 
            this.clnProductCode.DataPropertyName = "PRODUCT_ID";
            this.clnProductCode.HeaderText = "Mã hàng";
            this.clnProductCode.Name = "clnProductCode";
            this.clnProductCode.Width = 90;
            // 
            // clnProductName
            // 
            this.clnProductName.DataPropertyName = "PRODUCT_NAME";
            this.clnProductName.HeaderText = "Tên hàng";
            this.clnProductName.Name = "clnProductName";
            this.clnProductName.Width = 120;
            // 
            // clnQuantity
            // 
            this.clnQuantity.DataPropertyName = "QUANTITY";
            this.clnQuantity.HeaderText = "Số lượng";
            this.clnQuantity.Name = "clnQuantity";
            this.clnQuantity.Width = 50;
            // 
            // clnPrice
            // 
            this.clnPrice.DataPropertyName = "PRICE";
            this.clnPrice.HeaderText = "Giá gốc";
            this.clnPrice.Name = "clnPrice";
            // 
            // clnPriceSales
            // 
            this.clnPriceSales.DataPropertyName = "PRICE";
            this.clnPriceSales.HeaderText = "Giá bán";
            this.clnPriceSales.Name = "clnPriceSales";
            // 
            // clnIntoMoney
            // 
            this.clnIntoMoney.DataPropertyName = "INTOMONEY";
            this.clnIntoMoney.HeaderText = "Thành tiền";
            this.clnIntoMoney.Name = "clnIntoMoney";
            // 
            // chkChose
            // 
            this.chkChose.AutoSize = true;
            this.chkChose.Location = new System.Drawing.Point(7, 21);
            this.chkChose.Name = "chkChose";
            this.chkChose.Size = new System.Drawing.Size(184, 21);
            this.chkChose.TabIndex = 0;
            this.chkChose.Text = "Bỏ chọn tất cả sản phẩm";
            this.chkChose.UseVisualStyleBackColor = true;
            this.chkChose.CheckedChanged += new System.EventHandler(this.chkChose_CheckedChanged);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Image = global::SaleMTInterfaces.Properties.Resources.tick;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(254, 265);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 25);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::SaleMTInterfaces.Properties.Resources._216;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(340, 265);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 25);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Hủy bỏ";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmDialogDiscountProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 295);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDialogDiscountProduct";
            this.Text = "Chọn sản phẩm chiết khấu";
            this.Load += new System.EventHandler(this.frmDialogDiscountProduct_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDialogDiscountProduct_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkChose;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clnChose;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPriceSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnIntoMoney;
    }
}