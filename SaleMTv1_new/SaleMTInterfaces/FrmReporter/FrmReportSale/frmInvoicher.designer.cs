namespace SaleMTInterfaces.FrmReporter.FrmReportSale
{
    partial class frmInvoicher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInvoicher));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctlInfoStore1 = new SaleMTCommon.ctlInfoStore();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblSpace = new System.Windows.Forms.Label();
            this.lblScount = new System.Windows.Forms.Label();
            this.lblCurrentPage = new System.Windows.Forms.Label();
            this.lblTotalPage = new System.Windows.Forms.Label();
            this.btnChoosePage = new System.Windows.Forms.Button();
            this.txtGoPage = new System.Windows.Forms.TextBox();
            this.lblPage = new System.Windows.Forms.Label();
            this.btnEndPage = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnTopPage = new System.Windows.Forms.Button();
            this.cboRows = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvCusTotalInvoi = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkToinvoi = new System.Windows.Forms.CheckBox();
            this.chkFromInvoi = new System.Windows.Forms.CheckBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.dtpdateTo = new System.Windows.Forms.DateTimePicker();
            this.btnExport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSeach = new System.Windows.Forms.Button();
            this.dtpdateFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.imgUpDown = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCusTotalInvoi)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.ctlInfoStore1);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1123, 563);
            this.panel1.TabIndex = 0;
            // 
            // ctlInfoStore1
            // 
            this.ctlInfoStore1.BackColor = System.Drawing.SystemColors.Control;
            this.ctlInfoStore1.Location = new System.Drawing.Point(3, 0);
            this.ctlInfoStore1.Name = "ctlInfoStore1";
            this.ctlInfoStore1.Size = new System.Drawing.Size(282, 560);
            this.ctlInfoStore1.TabIndex = 23;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblSpace);
            this.groupBox3.Controls.Add(this.lblScount);
            this.groupBox3.Controls.Add(this.lblCurrentPage);
            this.groupBox3.Controls.Add(this.lblTotalPage);
            this.groupBox3.Controls.Add(this.btnChoosePage);
            this.groupBox3.Controls.Add(this.txtGoPage);
            this.groupBox3.Controls.Add(this.lblPage);
            this.groupBox3.Controls.Add(this.btnEndPage);
            this.groupBox3.Controls.Add(this.btnNext);
            this.groupBox3.Controls.Add(this.btnPrev);
            this.groupBox3.Controls.Add(this.btnTopPage);
            this.groupBox3.Controls.Add(this.cboRows);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(291, 504);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(825, 45);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            // 
            // lblSpace
            // 
            this.lblSpace.AutoSize = true;
            this.lblSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblSpace.Location = new System.Drawing.Point(370, 19);
            this.lblSpace.Name = "lblSpace";
            this.lblSpace.Size = new System.Drawing.Size(12, 16);
            this.lblSpace.TabIndex = 32;
            this.lblSpace.Text = "/";
            // 
            // lblScount
            // 
            this.lblScount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScount.AutoSize = true;
            this.lblScount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblScount.Location = new System.Drawing.Point(514, 18);
            this.lblScount.Name = "lblScount";
            this.lblScount.Size = new System.Drawing.Size(43, 16);
            this.lblScount.TabIndex = 21;
            this.lblScount.Text = "Tổng:";
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.AutoSize = true;
            this.lblCurrentPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblCurrentPage.Location = new System.Drawing.Point(355, 19);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(15, 16);
            this.lblCurrentPage.TabIndex = 31;
            this.lblCurrentPage.Text = "1";
            // 
            // lblTotalPage
            // 
            this.lblTotalPage.AutoSize = true;
            this.lblTotalPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblTotalPage.Location = new System.Drawing.Point(380, 19);
            this.lblTotalPage.Name = "lblTotalPage";
            this.lblTotalPage.Size = new System.Drawing.Size(15, 16);
            this.lblTotalPage.TabIndex = 30;
            this.lblTotalPage.Text = "1";
            // 
            // btnChoosePage
            // 
            this.btnChoosePage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChoosePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnChoosePage.Image = ((System.Drawing.Image)(resources.GetObject("btnChoosePage.Image")));
            this.btnChoosePage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChoosePage.Location = new System.Drawing.Point(731, 13);
            this.btnChoosePage.Name = "btnChoosePage";
            this.btnChoosePage.Size = new System.Drawing.Size(89, 25);
            this.btnChoosePage.TabIndex = 20;
            this.btnChoosePage.Text = "Tới trang";
            this.btnChoosePage.UseVisualStyleBackColor = true;
            this.btnChoosePage.Click += new System.EventHandler(this.btnChoosePage_Click);
            // 
            // txtGoPage
            // 
            this.txtGoPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGoPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtGoPage.Location = new System.Drawing.Point(644, 15);
            this.txtGoPage.Name = "txtGoPage";
            this.txtGoPage.Size = new System.Drawing.Size(81, 22);
            this.txtGoPage.TabIndex = 19;
            // 
            // lblPage
            // 
            this.lblPage.AutoSize = true;
            this.lblPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblPage.Location = new System.Drawing.Point(295, 19);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(44, 16);
            this.lblPage.TabIndex = 18;
            this.lblPage.Text = "Trang";
            // 
            // btnEndPage
            // 
            this.btnEndPage.Image = ((System.Drawing.Image)(resources.GetObject("btnEndPage.Image")));
            this.btnEndPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEndPage.Location = new System.Drawing.Point(259, 15);
            this.btnEndPage.Name = "btnEndPage";
            this.btnEndPage.Size = new System.Drawing.Size(29, 23);
            this.btnEndPage.TabIndex = 17;
            this.btnEndPage.UseVisualStyleBackColor = true;
            this.btnEndPage.Click += new System.EventHandler(this.btnEndPage_Click);
            // 
            // btnNext
            // 
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(224, 15);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(29, 23);
            this.btnNext.TabIndex = 16;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Image")));
            this.btnPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrev.Location = new System.Drawing.Point(189, 14);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(29, 23);
            this.btnPrev.TabIndex = 15;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnTopPage
            // 
            this.btnTopPage.Image = ((System.Drawing.Image)(resources.GetObject("btnTopPage.Image")));
            this.btnTopPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTopPage.Location = new System.Drawing.Point(154, 14);
            this.btnTopPage.Name = "btnTopPage";
            this.btnTopPage.Size = new System.Drawing.Size(29, 23);
            this.btnTopPage.TabIndex = 14;
            this.btnTopPage.UseVisualStyleBackColor = true;
            this.btnTopPage.Click += new System.EventHandler(this.btnTopPage_Click);
            // 
            // cboRows
            // 
            this.cboRows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRows.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.755F);
            this.cboRows.FormattingEnabled = true;
            this.cboRows.Items.AddRange(new object[] {
            "20",
            "40",
            "60",
            "80",
            "100"});
            this.cboRows.Location = new System.Drawing.Point(93, 14);
            this.cboRows.Name = "cboRows";
            this.cboRows.Size = new System.Drawing.Size(55, 24);
            this.cboRows.TabIndex = 13;
            this.cboRows.SelectedIndexChanged += new System.EventHandler(this.cboRows_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label6.Location = new System.Drawing.Point(11, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Dòng / trang";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvCusTotalInvoi);
            this.groupBox2.Location = new System.Drawing.Point(291, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(825, 414);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách";
            // 
            // dgvCusTotalInvoi
            // 
            this.dgvCusTotalInvoi.AllowUserToAddRows = false;
            this.dgvCusTotalInvoi.AllowUserToDeleteRows = false;
            this.dgvCusTotalInvoi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCusTotalInvoi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvCusTotalInvoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCusTotalInvoi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT});
            this.dgvCusTotalInvoi.Location = new System.Drawing.Point(7, 22);
            this.dgvCusTotalInvoi.Name = "dgvCusTotalInvoi";
            this.dgvCusTotalInvoi.Size = new System.Drawing.Size(811, 388);
            this.dgvCusTotalInvoi.TabIndex = 0;
            this.dgvCusTotalInvoi.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCusTotalInvoi_DataBindingComplete);
            // 
            // STT
            // 
            this.STT.DataPropertyName = "STT";
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkToinvoi);
            this.groupBox1.Controls.Add(this.chkFromInvoi);
            this.groupBox1.Controls.Add(this.txtFrom);
            this.groupBox1.Controls.Add(this.txtTo);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.dtpdateTo);
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSeach);
            this.groupBox1.Controls.Add(this.dtpdateFrom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(291, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(825, 80);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tìm kiếm";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // chkToinvoi
            // 
            this.chkToinvoi.AutoSize = true;
            this.chkToinvoi.Location = new System.Drawing.Point(257, 50);
            this.chkToinvoi.Name = "chkToinvoi";
            this.chkToinvoi.Size = new System.Drawing.Size(51, 20);
            this.chkToinvoi.TabIndex = 6;
            this.chkToinvoi.Text = "Đến";
            this.chkToinvoi.UseVisualStyleBackColor = true;
            this.chkToinvoi.CheckedChanged += new System.EventHandler(this.chkToinvoi_CheckedChanged);
            // 
            // chkFromInvoi
            // 
            this.chkFromInvoi.AutoSize = true;
            this.chkFromInvoi.Location = new System.Drawing.Point(10, 52);
            this.chkFromInvoi.Name = "chkFromInvoi";
            this.chkFromInvoi.Size = new System.Drawing.Size(109, 20);
            this.chkFromInvoi.TabIndex = 4;
            this.chkFromInvoi.Text = "Số hóa đơn từ";
            this.chkFromInvoi.UseVisualStyleBackColor = true;
            this.chkFromInvoi.CheckedChanged += new System.EventHandler(this.chkFromInvoi_CheckedChanged);
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(125, 50);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.ReadOnly = true;
            this.txtFrom.Size = new System.Drawing.Size(126, 22);
            this.txtFrom.TabIndex = 5;
            this.txtFrom.TextChanged += new System.EventHandler(this.txtFrom_TextChanged);
            this.txtFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFrom_KeyPress);
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(343, 50);
            this.txtTo.Name = "txtTo";
            this.txtTo.ReadOnly = true;
            this.txtTo.Size = new System.Drawing.Size(133, 22);
            this.txtTo.TabIndex = 7;
            this.txtTo.TextChanged += new System.EventHandler(this.txtMoneyTo_TextChanged);
            this.txtTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTo_KeyPress);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(729, 19);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(89, 28);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Đóng";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // dtpdateTo
            // 
            this.dtpdateTo.CustomFormat = "dd/MM/yyyy";
            this.dtpdateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdateTo.Location = new System.Drawing.Point(343, 21);
            this.dtpdateTo.Margin = new System.Windows.Forms.Padding(4);
            this.dtpdateTo.Name = "dtpdateTo";
            this.dtpdateTo.Size = new System.Drawing.Size(133, 22);
            this.dtpdateTo.TabIndex = 3;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(640, 19);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(85, 28);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến ngày";
            // 
            // btnSeach
            // 
            this.btnSeach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeach.Image = ((System.Drawing.Image)(resources.GetObject("btnSeach.Image")));
            this.btnSeach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeach.Location = new System.Drawing.Point(552, 19);
            this.btnSeach.Margin = new System.Windows.Forms.Padding(4);
            this.btnSeach.Name = "btnSeach";
            this.btnSeach.Size = new System.Drawing.Size(84, 28);
            this.btnSeach.TabIndex = 8;
            this.btnSeach.Text = "Tìm";
            this.btnSeach.UseVisualStyleBackColor = true;
            this.btnSeach.Click += new System.EventHandler(this.btnSeach_Click);
            // 
            // dtpdateFrom
            // 
            this.dtpdateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpdateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdateFrom.Location = new System.Drawing.Point(82, 21);
            this.dtpdateFrom.Margin = new System.Windows.Forms.Padding(4);
            this.dtpdateFrom.Name = "dtpdateFrom";
            this.dtpdateFrom.Size = new System.Drawing.Size(125, 22);
            this.dtpdateFrom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày";
            // 
            // imgUpDown
            // 
            this.imgUpDown.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgUpDown.ImageStream")));
            this.imgUpDown.TransparentColor = System.Drawing.Color.Transparent;
            this.imgUpDown.Images.SetKeyName(0, "1.png");
            this.imgUpDown.Images.SetKeyName(1, "2.png");
            this.imgUpDown.Images.SetKeyName(2, "tree.bmp");
            // 
            // frmInvoicher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 563);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmInvoicher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Báo cáo theo hóa đơn";
            this.Load += new System.EventHandler(this.frmInvoicher_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCusTotalInvoi)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpdateTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpdateFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSeach;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkToinvoi;
        private System.Windows.Forms.CheckBox chkFromInvoi;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.DataGridView dgvCusTotalInvoi;
        private System.Windows.Forms.ImageList imgUpDown;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblScount;
        private System.Windows.Forms.Button btnChoosePage;
        private System.Windows.Forms.TextBox txtGoPage;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Button btnEndPage;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnTopPage;
        private System.Windows.Forms.ComboBox cboRows;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSpace;
        private System.Windows.Forms.Label lblCurrentPage;
        private System.Windows.Forms.Label lblTotalPage;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private SaleMTCommon.ctlInfoStore ctlInfoStore1;
    }
}