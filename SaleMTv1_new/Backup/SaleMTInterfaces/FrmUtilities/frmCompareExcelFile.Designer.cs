namespace SaleMTInterfaces.FrmUtilities
{
    partial class frmCompareExcelFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCompareExcelFile));
            this.gbxFileA = new System.Windows.Forms.GroupBox();
            this.dgvFileA = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnImportA = new System.Windows.Forms.Button();
            this.gbxFileB = new System.Windows.Forms.GroupBox();
            this.dgvFileB = new System.Windows.Forms.DataGridView();
            this.STTB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnProductCodeB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnQuantityB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnImportB = new System.Windows.Forms.Button();
            this.gbxDuLieu = new System.Windows.Forms.GroupBox();
            this.dgvCompare = new System.Windows.Forms.DataGridView();
            this.STTK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaSPK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.gbxFileA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileA)).BeginInit();
            this.gbxFileB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileB)).BeginInit();
            this.gbxDuLieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompare)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxFileA
            // 
            this.gbxFileA.Controls.Add(this.dgvFileA);
            this.gbxFileA.Controls.Add(this.btnImportA);
            this.gbxFileA.Location = new System.Drawing.Point(13, 2);
            this.gbxFileA.Name = "gbxFileA";
            this.gbxFileA.Size = new System.Drawing.Size(447, 302);
            this.gbxFileA.TabIndex = 0;
            this.gbxFileA.TabStop = false;
            this.gbxFileA.Text = "File A";
            // 
            // dgvFileA
            // 
            this.dgvFileA.AllowUserToAddRows = false;
            this.dgvFileA.AllowUserToDeleteRows = false;
            this.dgvFileA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFileA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.clnProductCode,
            this.clnQuantity});
            this.dgvFileA.Location = new System.Drawing.Point(7, 41);
            this.dgvFileA.Name = "dgvFileA";
            this.dgvFileA.ReadOnly = true;
            this.dgvFileA.Size = new System.Drawing.Size(434, 253);
            this.dgvFileA.TabIndex = 1;
            this.dgvFileA.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvFileA_DataBindingComplete);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.ReadOnly = true;
            // 
            // clnProductCode
            // 
            this.clnProductCode.DataPropertyName = "ProductCode";
            this.clnProductCode.HeaderText = "Mã sản phẩm";
            this.clnProductCode.Name = "clnProductCode";
            this.clnProductCode.ReadOnly = true;
            this.clnProductCode.Width = 120;
            // 
            // clnQuantity
            // 
            this.clnQuantity.DataPropertyName = "Quantity";
            this.clnQuantity.HeaderText = "Số lượng";
            this.clnQuantity.Name = "clnQuantity";
            this.clnQuantity.ReadOnly = true;
            // 
            // btnImportA
            // 
            this.btnImportA.Image = ((System.Drawing.Image)(resources.GetObject("btnImportA.Image")));
            this.btnImportA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportA.Location = new System.Drawing.Point(344, 11);
            this.btnImportA.Name = "btnImportA";
            this.btnImportA.Size = new System.Drawing.Size(98, 25);
            this.btnImportA.TabIndex = 0;
            this.btnImportA.Text = "Import";
            this.btnImportA.UseVisualStyleBackColor = true;
            this.btnImportA.Click += new System.EventHandler(this.btnImportA_Click);
            // 
            // gbxFileB
            // 
            this.gbxFileB.Controls.Add(this.dgvFileB);
            this.gbxFileB.Controls.Add(this.btnImportB);
            this.gbxFileB.Location = new System.Drawing.Point(466, 2);
            this.gbxFileB.Name = "gbxFileB";
            this.gbxFileB.Size = new System.Drawing.Size(444, 302);
            this.gbxFileB.TabIndex = 1;
            this.gbxFileB.TabStop = false;
            this.gbxFileB.Text = "File B";
            // 
            // dgvFileB
            // 
            this.dgvFileB.AllowUserToAddRows = false;
            this.dgvFileB.AllowUserToDeleteRows = false;
            this.dgvFileB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFileB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STTB,
            this.clnProductCodeB,
            this.clnQuantityB});
            this.dgvFileB.Location = new System.Drawing.Point(6, 41);
            this.dgvFileB.Name = "dgvFileB";
            this.dgvFileB.ReadOnly = true;
            this.dgvFileB.Size = new System.Drawing.Size(432, 253);
            this.dgvFileB.TabIndex = 2;
            this.dgvFileB.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvFileB_DataBindingComplete);
            // 
            // STTB
            // 
            this.STTB.HeaderText = "STT";
            this.STTB.Name = "STTB";
            this.STTB.ReadOnly = true;
            // 
            // clnProductCodeB
            // 
            this.clnProductCodeB.DataPropertyName = "ProductCode";
            this.clnProductCodeB.HeaderText = "Mã sản phẩm";
            this.clnProductCodeB.Name = "clnProductCodeB";
            this.clnProductCodeB.ReadOnly = true;
            this.clnProductCodeB.Width = 120;
            // 
            // clnQuantityB
            // 
            this.clnQuantityB.DataPropertyName = "Quantity";
            this.clnQuantityB.HeaderText = "Số lượng";
            this.clnQuantityB.Name = "clnQuantityB";
            this.clnQuantityB.ReadOnly = true;
            // 
            // btnImportB
            // 
            this.btnImportB.Image = ((System.Drawing.Image)(resources.GetObject("btnImportB.Image")));
            this.btnImportB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportB.Location = new System.Drawing.Point(337, 10);
            this.btnImportB.Name = "btnImportB";
            this.btnImportB.Size = new System.Drawing.Size(101, 25);
            this.btnImportB.TabIndex = 1;
            this.btnImportB.Text = "Import";
            this.btnImportB.UseVisualStyleBackColor = true;
            this.btnImportB.Click += new System.EventHandler(this.btnImportB_Click);
            // 
            // gbxDuLieu
            // 
            this.gbxDuLieu.Controls.Add(this.dgvCompare);
            this.gbxDuLieu.Location = new System.Drawing.Point(13, 305);
            this.gbxDuLieu.Name = "gbxDuLieu";
            this.gbxDuLieu.Size = new System.Drawing.Size(897, 293);
            this.gbxDuLieu.TabIndex = 2;
            this.gbxDuLieu.TabStop = false;
            this.gbxDuLieu.Text = "Số liệu khác nhau";
            // 
            // dgvCompare
            // 
            this.dgvCompare.AllowUserToAddRows = false;
            this.dgvCompare.AllowUserToDeleteRows = false;
            this.dgvCompare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompare.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STTK,
            this.MaSPK,
            this.SoLuongK,
            this.GhiChu});
            this.dgvCompare.Location = new System.Drawing.Point(7, 20);
            this.dgvCompare.Name = "dgvCompare";
            this.dgvCompare.ReadOnly = true;
            this.dgvCompare.Size = new System.Drawing.Size(884, 263);
            this.dgvCompare.TabIndex = 0;
            this.dgvCompare.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCompare_DataBindingComplete);
            // 
            // STTK
            // 
            this.STTK.HeaderText = "STT";
            this.STTK.Name = "STTK";
            this.STTK.ReadOnly = true;
            // 
            // MaSPK
            // 
            this.MaSPK.DataPropertyName = "ProductCode";
            this.MaSPK.HeaderText = "Mã sản phẩm";
            this.MaSPK.Name = "MaSPK";
            this.MaSPK.ReadOnly = true;
            this.MaSPK.Width = 120;
            // 
            // SoLuongK
            // 
            this.SoLuongK.DataPropertyName = "Quantity";
            this.SoLuongK.HeaderText = "Số lượng";
            this.SoLuongK.Name = "SoLuongK";
            this.SoLuongK.ReadOnly = true;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "Remarks";
            this.GhiChu.HeaderText = "Ghi chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.ReadOnly = true;
            this.GhiChu.Width = 200;
            // 
            // btnCompare
            // 
            this.btnCompare.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompare.Image = global::SaleMTInterfaces.Properties.Resources.search_zoom;
            this.btnCompare.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompare.Location = new System.Drawing.Point(291, 604);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(102, 25);
            this.btnCompare.TabIndex = 9;
            this.btnCompare.Text = "So sánh";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(496, 604);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(82, 25);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::SaleMTInterfaces.Properties.Resources.excel;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(397, 604);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(95, 25);
            this.btnExcel.TabIndex = 11;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(17, 608);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(80, 17);
            this.lblTotal.TabIndex = 12;
            this.lblTotal.Text = "Tổng cộng:";
            // 
            // frmCompareExcelFile
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(922, 635);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbxDuLieu);
            this.Controls.Add(this.gbxFileB);
            this.Controls.Add(this.gbxFileA);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCompareExcelFile";
            this.Text = "So sánh số lượng";
            this.Load += new System.EventHandler(this.frmCompareExcelFile_Load);
            this.gbxFileA.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileA)).EndInit();
            this.gbxFileB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileB)).EndInit();
            this.gbxDuLieu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompare)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxFileA;
        private System.Windows.Forms.DataGridView dgvFileA;
        private System.Windows.Forms.Button btnImportA;
        private System.Windows.Forms.GroupBox gbxFileB;
        private System.Windows.Forms.DataGridView dgvFileB;
        private System.Windows.Forms.Button btnImportB;
        private System.Windows.Forms.GroupBox gbxDuLieu;
        private System.Windows.Forms.DataGridView dgvCompare;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnQuantity;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn STTB;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnProductCodeB;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnQuantityB;
        private System.Windows.Forms.DataGridViewTextBoxColumn STTK;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSPK;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongK;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.Label lblTotal;
    }
}