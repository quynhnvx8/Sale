namespace SaleMTInterfaces.FrmInventoryManagement
{
    partial class frmCheckInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckInventory));
            this.gbxSanPham = new System.Windows.Forms.GroupBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtProductPrice = new System.Windows.Forms.TextBox();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gpxTonKho = new System.Windows.Forms.GroupBox();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.StoreName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StoreFax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExit = new System.Windows.Forms.Button();
            this.gbxSanPham.SuspendLayout();
            this.gpxTonKho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxSanPham
            // 
            this.gbxSanPham.Controls.Add(this.btnCheck);
            this.gbxSanPham.Controls.Add(this.txtProductPrice);
            this.gbxSanPham.Controls.Add(this.txtShortName);
            this.gbxSanPham.Controls.Add(this.txtProductName);
            this.gbxSanPham.Controls.Add(this.txtProductCode);
            this.gbxSanPham.Controls.Add(this.label4);
            this.gbxSanPham.Controls.Add(this.label3);
            this.gbxSanPham.Controls.Add(this.label2);
            this.gbxSanPham.Controls.Add(this.label1);
            this.gbxSanPham.Location = new System.Drawing.Point(26, 13);
            this.gbxSanPham.Name = "gbxSanPham";
            this.gbxSanPham.Size = new System.Drawing.Size(721, 133);
            this.gbxSanPham.TabIndex = 0;
            this.gbxSanPham.TabStop = false;
            this.gbxSanPham.Text = "Thông tin sản phẩm";
            // 
            // btnCheck
            // 
            this.btnCheck.Image = ((System.Drawing.Image)(resources.GetObject("btnCheck.Image")));
            this.btnCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheck.Location = new System.Drawing.Point(376, 22);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(92, 23);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "Kiểm tra";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtProductPrice
            // 
            this.txtProductPrice.Location = new System.Drawing.Point(139, 101);
            this.txtProductPrice.Name = "txtProductPrice";
            this.txtProductPrice.ReadOnly = true;
            this.txtProductPrice.Size = new System.Drawing.Size(569, 22);
            this.txtProductPrice.TabIndex = 5;
            // 
            // txtShortName
            // 
            this.txtShortName.Location = new System.Drawing.Point(139, 74);
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.ReadOnly = true;
            this.txtShortName.Size = new System.Drawing.Size(569, 22);
            this.txtShortName.TabIndex = 4;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(139, 47);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(569, 22);
            this.txtProductName.TabIndex = 3;
            // 
            // txtProductCode
            // 
            this.txtProductCode.Location = new System.Drawing.Point(139, 22);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(222, 22);
            this.txtProductCode.TabIndex = 1;
            this.txtProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductCode_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Giá";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên viết tắt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên sản phẩm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã sản phẩm";
            // 
            // gpxTonKho
            // 
            this.gpxTonKho.Controls.Add(this.dgvInventory);
            this.gpxTonKho.Location = new System.Drawing.Point(26, 152);
            this.gpxTonKho.Name = "gpxTonKho";
            this.gpxTonKho.Size = new System.Drawing.Size(721, 301);
            this.gpxTonKho.TabIndex = 1;
            this.gpxTonKho.TabStop = false;
            this.gpxTonKho.Text = "Tồn kho";
            // 
            // dgvInventory
            // 
            this.dgvInventory.AllowUserToAddRows = false;
            this.dgvInventory.AllowUserToDeleteRows = false;
            this.dgvInventory.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StoreName,
            this.StoreCode,
            this.StoreLocation,
            this.Quantity,
            this.StoreAddress,
            this.StoreTel,
            this.StoreFax});
            this.dgvInventory.Location = new System.Drawing.Point(10, 21);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.Size = new System.Drawing.Size(698, 274);
            this.dgvInventory.TabIndex = 0;
            // 
            // StoreName
            // 
            this.StoreName.DataPropertyName = "StoreName";
            this.StoreName.HeaderText = "Cửa hàng";
            this.StoreName.Name = "StoreName";
            this.StoreName.ReadOnly = true;
            this.StoreName.Width = 160;
            // 
            // StoreCode
            // 
            this.StoreCode.DataPropertyName = "StoreCode";
            this.StoreCode.HeaderText = "Chuỗi";
            this.StoreCode.Name = "StoreCode";
            this.StoreCode.ReadOnly = true;
            this.StoreCode.Width = 80;
            // 
            // StoreLocation
            // 
            this.StoreLocation.DataPropertyName = "StoreLocation";
            this.StoreLocation.HeaderText = "Vị trí";
            this.StoreLocation.Name = "StoreLocation";
            this.StoreLocation.ReadOnly = true;
            this.StoreLocation.Width = 80;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Tồn kho";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 80;
            // 
            // StoreAddress
            // 
            this.StoreAddress.DataPropertyName = "StoreAddress";
            this.StoreAddress.HeaderText = "Địa chỉ cửa hàng";
            this.StoreAddress.Name = "StoreAddress";
            this.StoreAddress.ReadOnly = true;
            this.StoreAddress.Width = 160;
            // 
            // StoreTel
            // 
            this.StoreTel.DataPropertyName = "StoreTel";
            this.StoreTel.HeaderText = "Điện thoại";
            this.StoreTel.Name = "StoreTel";
            this.StoreTel.ReadOnly = true;
            this.StoreTel.Width = 150;
            // 
            // StoreFax
            // 
            this.StoreFax.DataPropertyName = "StoreFax";
            this.StoreFax.HeaderText = "Fax";
            this.StoreFax.Name = "StoreFax";
            this.StoreFax.ReadOnly = true;
            this.StoreFax.Width = 150;
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(657, 460);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(90, 23);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Đóng";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmCheckInventory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(773, 495);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.gpxTonKho);
            this.Controls.Add(this.gbxSanPham);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCheckInventory";
            this.Text = "Kiểm tra tồn kho";
            this.gbxSanPham.ResumeLayout(false);
            this.gbxSanPham.PerformLayout();
            this.gpxTonKho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxSanPham;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TextBox txtProductPrice;
        private System.Windows.Forms.TextBox txtShortName;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gpxTonKho;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn StoreFax;
    }
}