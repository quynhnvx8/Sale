namespace SaleMTInterfaces.FrmSaleManagement
{
    partial class frmDialogSales
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
            this.dgvProductSales = new System.Windows.Forms.DataGridView();
            this.clnProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductSales)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProductSales
            // 
            this.dgvProductSales.AllowUserToAddRows = false;
            this.dgvProductSales.AllowUserToDeleteRows = false;
            this.dgvProductSales.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvProductSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnProductCode,
            this.clnBarCode,
            this.clnProductName});
            this.dgvProductSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductSales.Location = new System.Drawing.Point(0, 0);
            this.dgvProductSales.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProductSales.Name = "dgvProductSales";
            this.dgvProductSales.ReadOnly = true;
            this.dgvProductSales.Size = new System.Drawing.Size(734, 412);
            this.dgvProductSales.TabIndex = 0;
            this.dgvProductSales.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductSales_CellDoubleClick);
            this.dgvProductSales.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvProductSales_KeyDown);
            // 
            // clnProductCode
            // 
            this.clnProductCode.DataPropertyName = "PRODUCT_ID";
            this.clnProductCode.HeaderText = "Mã SP";
            this.clnProductCode.Name = "clnProductCode";
            this.clnProductCode.ReadOnly = true;
            // 
            // clnBarCode
            // 
            this.clnBarCode.DataPropertyName = "BARCODE";
            this.clnBarCode.HeaderText = "Mã vạch";
            this.clnBarCode.Name = "clnBarCode";
            this.clnBarCode.ReadOnly = true;
            this.clnBarCode.Width = 148;
            // 
            // clnProductName
            // 
            this.clnProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clnProductName.DataPropertyName = "PRODUCT_NAME";
            this.clnProductName.HeaderText = "Tên SP";
            this.clnProductName.Name = "clnProductName";
            this.clnProductName.ReadOnly = true;
            // 
            // frmDialogSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 412);
            this.Controls.Add(this.dgvProductSales);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDialogSales";
            this.Text = "Danh sách sản phẩm";
            this.Load += new System.EventHandler(this.frmDialogSales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductSales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProductSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnBarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnProductName;
    }
}