namespace SaleMTInterfaces.FrmInventoryManagement
{
    partial class frmDialogReportF1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDialogReportF1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnPO = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.PRODUCT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DAUKY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NHAP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XUAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TON = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LKTTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KHTTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DMKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TKMIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TKNEXT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TKLEAD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YCTON = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POCONFIRM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PODVKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.THANHTIEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.AllowUserToResizeColumns = false;
            this.dgvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReport.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PRODUCT_ID,
            this.PRODUCT_NAME,
            this.DAUKY,
            this.NHAP,
            this.XUAT,
            this.TON,
            this.LKTTT,
            this.KHTTT,
            this.DMKH,
            this.DTKH,
            this.DTTT,
            this.TKMIN,
            this.TKNEXT,
            this.TKLEAD,
            this.YCTON,
            this.POCONFIRM,
            this.PODVKH,
            this.QC,
            this.SLT,
            this.THANHTIEN,
            this.CB});
            this.dgvReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.dgvReport.Location = new System.Drawing.Point(1, 1);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.Size = new System.Drawing.Size(870, 433);
            this.dgvReport.TabIndex = 0;
            this.dgvReport.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvReport_DataBindingComplete);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(458, 440);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "In";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.Image")));
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(539, 440);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(93, 25);
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Text = "Xuất Excel";
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnPO
            // 
            this.btnPO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnPO.Image = ((System.Drawing.Image)(resources.GetObject("btnPO.Image")));
            this.btnPO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPO.Location = new System.Drawing.Point(636, 440);
            this.btnPO.Name = "btnPO";
            this.btnPO.Size = new System.Drawing.Size(141, 25);
            this.btnPO.TabIndex = 3;
            this.btnPO.Text = "Chuyển thành PO";
            this.btnPO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPO.UseVisualStyleBackColor = true;
            this.btnPO.Click += new System.EventHandler(this.btnPO_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(783, 440);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(77, 25);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            // 
            // PRODUCT_ID
            // 
            this.PRODUCT_ID.DataPropertyName = "PRODUCT_ID";
            this.PRODUCT_ID.HeaderText = "Mã hàng";
            this.PRODUCT_ID.Name = "PRODUCT_ID";
            this.PRODUCT_ID.ReadOnly = true;
            this.PRODUCT_ID.Width = 80;
            // 
            // PRODUCT_NAME
            // 
            this.PRODUCT_NAME.DataPropertyName = "PRODUCT_NAME";
            this.PRODUCT_NAME.HeaderText = "Tên hàng";
            this.PRODUCT_NAME.Name = "PRODUCT_NAME";
            this.PRODUCT_NAME.ReadOnly = true;
            this.PRODUCT_NAME.Width = 180;
            // 
            // DAUKY
            // 
            this.DAUKY.DataPropertyName = "DAUKY";
            dataGridViewCellStyle1.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber + SaleMTCommon.Conversion.NumFormat((int.Parse(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDec)));
            this.DAUKY.DefaultCellStyle = dataGridViewCellStyle1;
            this.DAUKY.HeaderText = "Đầu kỳ";
            this.DAUKY.Name = "DAUKY";
            this.DAUKY.ReadOnly = true;
            this.DAUKY.Width = 80;
            // 
            // NHAP
            // 
            this.NHAP.DataPropertyName = "NHAP";
            dataGridViewCellStyle2.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber + SaleMTCommon.Conversion.NumFormat((int.Parse(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDec)));
            this.NHAP.DefaultCellStyle = dataGridViewCellStyle2;
            this.NHAP.HeaderText = "Nhập";
            this.NHAP.Name = "NHAP";
            this.NHAP.ReadOnly = true;
            this.NHAP.Width = 80;
            // 
            // XUAT
            // 
            this.XUAT.DataPropertyName = "XUAT";
            dataGridViewCellStyle3.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber + SaleMTCommon.Conversion.NumFormat((int.Parse(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDec)));
            this.XUAT.DefaultCellStyle = dataGridViewCellStyle3;
            this.XUAT.HeaderText = "Xuất";
            this.XUAT.Name = "XUAT";
            this.XUAT.ReadOnly = true;
            this.XUAT.Width = 80;
            // 
            // TON
            // 
            this.TON.DataPropertyName = "TON";
            dataGridViewCellStyle4.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber + SaleMTCommon.Conversion.NumFormat((int.Parse(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDec)));
            this.TON.DefaultCellStyle = dataGridViewCellStyle4;
            this.TON.HeaderText = "Tồn";
            this.TON.Name = "TON";
            this.TON.ReadOnly = true;
            this.TON.Width = 80;
            // 
            // LKTTT
            // 
            this.LKTTT.DataPropertyName = "LKTTT";
            dataGridViewCellStyle5.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber + SaleMTCommon.Conversion.NumFormat((int.Parse(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDec)));
            this.LKTTT.DefaultCellStyle = dataGridViewCellStyle5;
            this.LKTTT.HeaderText = "LKTTT";
            this.LKTTT.Name = "LKTTT";
            this.LKTTT.ReadOnly = true;
            this.LKTTT.Width = 80;
            // 
            // KHTTT
            // 
            this.KHTTT.DataPropertyName = "KHTTT";
            dataGridViewCellStyle6.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber + SaleMTCommon.Conversion.NumFormat((int.Parse(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDec)));
            this.KHTTT.DefaultCellStyle = dataGridViewCellStyle6;
            this.KHTTT.HeaderText = "KHTTT";
            this.KHTTT.Name = "KHTTT";
            this.KHTTT.ReadOnly = true;
            this.KHTTT.Width = 80;
            // 
            // DMKH
            // 
            this.DMKH.DataPropertyName = "DMKH";
            dataGridViewCellStyle7.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber + SaleMTCommon.Conversion.NumFormat((int.Parse(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDec)));
            this.DMKH.DefaultCellStyle = dataGridViewCellStyle7;
            this.DMKH.HeaderText = "DMKH";
            this.DMKH.Name = "DMKH";
            this.DMKH.ReadOnly = true;
            this.DMKH.Width = 80;
            // 
            // DTKH
            // 
            this.DTKH.DataPropertyName = "DTKH";
            dataGridViewCellStyle8.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber + SaleMTCommon.Conversion.NumFormat((int.Parse(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDec)));
            this.DTKH.DefaultCellStyle = dataGridViewCellStyle8;
            this.DTKH.HeaderText = "DTKH";
            this.DTKH.Name = "DTKH";
            this.DTKH.ReadOnly = true;
            this.DTKH.Width = 80;
            // 
            // DTTT
            // 
            this.DTTT.DataPropertyName = "DTTT";
            dataGridViewCellStyle9.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber + SaleMTCommon.Conversion.NumFormat((int.Parse(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDec)));
            this.DTTT.DefaultCellStyle = dataGridViewCellStyle9;
            this.DTTT.HeaderText = "DTTT";
            this.DTTT.Name = "DTTT";
            this.DTTT.ReadOnly = true;
            this.DTTT.Width = 80;
            // 
            // TKMIN
            // 
            this.TKMIN.DataPropertyName = "TKMIN";
            dataGridViewCellStyle10.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber + SaleMTCommon.Conversion.NumFormat((int.Parse(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDec)));
            this.TKMIN.DefaultCellStyle = dataGridViewCellStyle10;
            this.TKMIN.HeaderText = "Min";
            this.TKMIN.Name = "TKMIN";
            this.TKMIN.ReadOnly = true;
            this.TKMIN.Width = 80;
            // 
            // TKNEXT
            // 
            this.TKNEXT.DataPropertyName = "TKNEXT";
            dataGridViewCellStyle11.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber + SaleMTCommon.Conversion.NumFormat((int.Parse(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDec)));
            this.TKNEXT.DefaultCellStyle = dataGridViewCellStyle11;
            this.TKNEXT.HeaderText = "Next";
            this.TKNEXT.Name = "TKNEXT";
            this.TKNEXT.ReadOnly = true;
            this.TKNEXT.Width = 80;
            // 
            // TKLEAD
            // 
            this.TKLEAD.DataPropertyName = "TKLEAD";
            dataGridViewCellStyle12.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber + SaleMTCommon.Conversion.NumFormat((int.Parse(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDec)));
            this.TKLEAD.DefaultCellStyle = dataGridViewCellStyle12;
            this.TKLEAD.HeaderText = "Lead";
            this.TKLEAD.Name = "TKLEAD";
            this.TKLEAD.ReadOnly = true;
            this.TKLEAD.Width = 80;
            // 
            // YCTON
            // 
            this.YCTON.DataPropertyName = "YCTON";
            dataGridViewCellStyle13.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber + SaleMTCommon.Conversion.NumFormat((int.Parse(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDec)));
            dataGridViewCellStyle13.NullValue = null;
            this.YCTON.DefaultCellStyle = dataGridViewCellStyle13;
            this.YCTON.HeaderText = "Y/c tồn";
            this.YCTON.Name = "YCTON";
            this.YCTON.ReadOnly = true;
            this.YCTON.Width = 80;
            // 
            // POCONFIRM
            // 
            this.POCONFIRM.DataPropertyName = "POCONFIRM";
            dataGridViewCellStyle14.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber + SaleMTCommon.Conversion.NumFormat((int.Parse(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDec)));
            this.POCONFIRM.DefaultCellStyle = dataGridViewCellStyle14;
            this.POCONFIRM.HeaderText = "POConfirm";
            this.POCONFIRM.Name = "POCONFIRM";
            this.POCONFIRM.ReadOnly = true;
            // 
            // PODVKH
            // 
            this.PODVKH.DataPropertyName = "PODVKH";
            dataGridViewCellStyle15.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber + SaleMTCommon.Conversion.NumFormat((int.Parse(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDec)));
            this.PODVKH.DefaultCellStyle = dataGridViewCellStyle15;
            this.PODVKH.HeaderText = "PODVKH";
            this.PODVKH.Name = "PODVKH";
            this.PODVKH.ReadOnly = true;
            // 
            // QC
            // 
            this.QC.DataPropertyName = "QC";
            dataGridViewCellStyle16.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber + SaleMTCommon.Conversion.NumFormat((int.Parse(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDec)));
            this.QC.DefaultCellStyle = dataGridViewCellStyle16;
            this.QC.HeaderText = "QC";
            this.QC.Name = "QC";
            this.QC.ReadOnly = true;
            this.QC.Width = 80;
            // 
            // SLT
            // 
            this.SLT.DataPropertyName = "SLT";
            dataGridViewCellStyle17.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber + SaleMTCommon.Conversion.NumFormat((int.Parse(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDec)));
            this.SLT.DefaultCellStyle = dataGridViewCellStyle17;
            this.SLT.HeaderText = "SLT";
            this.SLT.Name = "SLT";
            this.SLT.ReadOnly = true;
            this.SLT.Width = 80;
            // 
            // THANHTIEN
            // 
            this.THANHTIEN.DataPropertyName = "THANHTIEN";
            dataGridViewCellStyle18.Format = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptNumber + SaleMTCommon.Conversion.NumFormat((int.Parse(SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDec)));
            this.THANHTIEN.DefaultCellStyle = dataGridViewCellStyle18;
            this.THANHTIEN.HeaderText = "T.Tiền";
            this.THANHTIEN.Name = "THANHTIEN";
            this.THANHTIEN.ReadOnly = true;
            this.THANHTIEN.Width = 80;
            // 
            // CB
            // 
            this.CB.DataPropertyName = "CB";
            this.CB.HeaderText = "CB";
            this.CB.Name = "CB";
            this.CB.ReadOnly = true;
            this.CB.Width = 80;
            // 
            // frmDialogReportF1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 475);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPO);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgvReport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDialogReportF1";
            this.Text = "Báo cáo xuất nhập tồn F1";
            this.Load += new System.EventHandler(this.frmDialogReportF1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnPO;
        private System.Windows.Forms.Button btnClose;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn DAUKY;
        private System.Windows.Forms.DataGridViewTextBoxColumn NHAP;
        private System.Windows.Forms.DataGridViewTextBoxColumn XUAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TON;
        private System.Windows.Forms.DataGridViewTextBoxColumn LKTTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn KHTTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DMKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TKMIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn TKNEXT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TKLEAD;
        private System.Windows.Forms.DataGridViewTextBoxColumn YCTON;
        private System.Windows.Forms.DataGridViewTextBoxColumn POCONFIRM;
        private System.Windows.Forms.DataGridViewTextBoxColumn PODVKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn QC;
        private System.Windows.Forms.DataGridViewTextBoxColumn SLT;
        private System.Windows.Forms.DataGridViewTextBoxColumn THANHTIEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn CB;
    }
}