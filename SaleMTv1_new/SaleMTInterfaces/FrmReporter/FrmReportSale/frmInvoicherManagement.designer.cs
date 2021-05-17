namespace SaleMTInterfaces.FrmReporter.FrmReportSale
{
    partial class frmInvoicherManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInvoicherManagement));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ctlInfoStore1 = new SaleMTCommon.ctlInfoStore();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblSpace = new System.Windows.Forms.Label();
            this.lblSCount = new System.Windows.Forms.Label();
            this.lblCurrentPage = new System.Windows.Forms.Label();
            this.btnChoosePage = new System.Windows.Forms.Button();
            this.lblTotalPage = new System.Windows.Forms.Label();
            this.txtGoPage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEndPage = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnTopPage = new System.Windows.Forms.Button();
            this.cboRows = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvCusTotal = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkToMoney = new System.Windows.Forms.CheckBox();
            this.chkFromMoney = new System.Windows.Forms.CheckBox();
            this.txtMoneyFrom = new System.Windows.Forms.TextBox();
            this.txtMoneyTo = new System.Windows.Forms.TextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvCusTotal)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1096, 563);
            this.panel1.TabIndex = 0;
            // 
            // ctlInfoStore1
            // 
            this.ctlInfoStore1.BackColor = System.Drawing.SystemColors.Control;
            this.ctlInfoStore1.Location = new System.Drawing.Point(0, 2);
            this.ctlInfoStore1.Name = "ctlInfoStore1";
            this.ctlInfoStore1.Size = new System.Drawing.Size(282, 560);
            this.ctlInfoStore1.TabIndex = 22;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblSpace);
            this.groupBox3.Controls.Add(this.lblSCount);
            this.groupBox3.Controls.Add(this.lblCurrentPage);
            this.groupBox3.Controls.Add(this.btnChoosePage);
            this.groupBox3.Controls.Add(this.lblTotalPage);
            this.groupBox3.Controls.Add(this.txtGoPage);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnEndPage);
            this.groupBox3.Controls.Add(this.btnNext);
            this.groupBox3.Controls.Add(this.btnPrev);
            this.groupBox3.Controls.Add(this.btnTopPage);
            this.groupBox3.Controls.Add(this.cboRows);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(288, 504);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(801, 45);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            // 
            // lblSpace
            // 
            this.lblSpace.AutoSize = true;
            this.lblSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblSpace.Location = new System.Drawing.Point(381, 19);
            this.lblSpace.Name = "lblSpace";
            this.lblSpace.Size = new System.Drawing.Size(12, 16);
            this.lblSpace.TabIndex = 33;
            this.lblSpace.Text = "/";
            // 
            // lblSCount
            // 
            this.lblSCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSCount.AutoSize = true;
            this.lblSCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblSCount.Location = new System.Drawing.Point(490, 18);
            this.lblSCount.Name = "lblSCount";
            this.lblSCount.Size = new System.Drawing.Size(43, 16);
            this.lblSCount.TabIndex = 21;
            this.lblSCount.Text = "Tổng:";
            // 
            // lblCurrentPage
            // 
            this.lblCurrentPage.AutoSize = true;
            this.lblCurrentPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblCurrentPage.Location = new System.Drawing.Point(366, 19);
            this.lblCurrentPage.Name = "lblCurrentPage";
            this.lblCurrentPage.Size = new System.Drawing.Size(15, 16);
            this.lblCurrentPage.TabIndex = 32;
            this.lblCurrentPage.Text = "1";
            // 
            // btnChoosePage
            // 
            this.btnChoosePage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChoosePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnChoosePage.Image = ((System.Drawing.Image)(resources.GetObject("btnChoosePage.Image")));
            this.btnChoosePage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChoosePage.Location = new System.Drawing.Point(707, 13);
            this.btnChoosePage.Name = "btnChoosePage";
            this.btnChoosePage.Size = new System.Drawing.Size(89, 25);
            this.btnChoosePage.TabIndex = 20;
            this.btnChoosePage.Text = "Tới trang";
            this.btnChoosePage.UseVisualStyleBackColor = true;
            this.btnChoosePage.Click += new System.EventHandler(this.btnChoosePage_Click);
            // 
            // lblTotalPage
            // 
            this.lblTotalPage.AutoSize = true;
            this.lblTotalPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblTotalPage.Location = new System.Drawing.Point(391, 19);
            this.lblTotalPage.Name = "lblTotalPage";
            this.lblTotalPage.Size = new System.Drawing.Size(15, 16);
            this.lblTotalPage.TabIndex = 31;
            this.lblTotalPage.Text = "1";
            // 
            // txtGoPage
            // 
            this.txtGoPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGoPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtGoPage.Location = new System.Drawing.Point(620, 15);
            this.txtGoPage.Name = "txtGoPage";
            this.txtGoPage.Size = new System.Drawing.Size(81, 22);
            this.txtGoPage.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.Location = new System.Drawing.Point(307, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "Trang :";
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
            this.groupBox2.Controls.Add(this.dgvCusTotal);
            this.groupBox2.Location = new System.Drawing.Point(288, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(801, 414);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách";
            // 
            // dgvCusTotal
            // 
            this.dgvCusTotal.AllowUserToAddRows = false;
            this.dgvCusTotal.AllowUserToDeleteRows = false;
            this.dgvCusTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCusTotal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvCusTotal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCusTotal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT});
            this.dgvCusTotal.Location = new System.Drawing.Point(6, 22);
            this.dgvCusTotal.Name = "dgvCusTotal";
            this.dgvCusTotal.Size = new System.Drawing.Size(788, 388);
            this.dgvCusTotal.TabIndex = 0;
            this.dgvCusTotal.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvCusTotal_DataBindingComplete);
            this.dgvCusTotal.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCusTotal_CellContentClick);
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
            this.groupBox1.Controls.Add(this.chkToMoney);
            this.groupBox1.Controls.Add(this.chkFromMoney);
            this.groupBox1.Controls.Add(this.txtMoneyFrom);
            this.groupBox1.Controls.Add(this.txtMoneyTo);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.dtpdateTo);
            this.groupBox1.Controls.Add(this.btnExport);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSeach);
            this.groupBox1.Controls.Add(this.dtpdateFrom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox1.Location = new System.Drawing.Point(288, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(801, 80);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tìm kiếm";
            // 
            // chkToMoney
            // 
            this.chkToMoney.AutoSize = true;
            this.chkToMoney.Location = new System.Drawing.Point(252, 50);
            this.chkToMoney.Name = "chkToMoney";
            this.chkToMoney.Size = new System.Drawing.Size(51, 20);
            this.chkToMoney.TabIndex = 6;
            this.chkToMoney.Text = "Đến";
            this.chkToMoney.UseVisualStyleBackColor = true;
            this.chkToMoney.CheckedChanged += new System.EventHandler(this.chkToMoney_CheckedChanged);
            // 
            // chkFromMoney
            // 
            this.chkFromMoney.AutoSize = true;
            this.chkFromMoney.Location = new System.Drawing.Point(10, 52);
            this.chkFromMoney.Name = "chkFromMoney";
            this.chkFromMoney.Size = new System.Drawing.Size(81, 20);
            this.chkFromMoney.TabIndex = 4;
            this.chkFromMoney.Text = "Số tiền từ";
            this.chkFromMoney.UseVisualStyleBackColor = true;
            this.chkFromMoney.CheckedChanged += new System.EventHandler(this.chkFromMoney_CheckedChanged);
            // 
            // txtMoneyFrom
            // 
            this.txtMoneyFrom.Location = new System.Drawing.Point(97, 50);
            this.txtMoneyFrom.Name = "txtMoneyFrom";
            this.txtMoneyFrom.ReadOnly = true;
            this.txtMoneyFrom.Size = new System.Drawing.Size(143, 22);
            this.txtMoneyFrom.TabIndex = 5;
            this.txtMoneyFrom.TextChanged += new System.EventHandler(this.txtMoneyFrom_TextChanged);
            this.txtMoneyFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMoneyFrom_KeyPress);
            // 
            // txtMoneyTo
            // 
            this.txtMoneyTo.Location = new System.Drawing.Point(343, 50);
            this.txtMoneyTo.Name = "txtMoneyTo";
            this.txtMoneyTo.ReadOnly = true;
            this.txtMoneyTo.Size = new System.Drawing.Size(133, 22);
            this.txtMoneyTo.TabIndex = 7;
            this.txtMoneyTo.TextChanged += new System.EventHandler(this.txtMoneyTo_TextChanged);
            this.txtMoneyTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMoneyTo_KeyPress);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(705, 19);
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
            this.dtpdateTo.ValueChanged += new System.EventHandler(this.dtpdateTo_ValueChanged);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(616, 19);
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
            this.btnSeach.Location = new System.Drawing.Point(528, 19);
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
            // frmInvoicherManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1096, 563);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmInvoicherManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Báo cáo doanh số theo hóa đơn";
            this.Load += new System.EventHandler(this.frmInvoicherManagement_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCusTotal)).EndInit();
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
        private System.Windows.Forms.CheckBox chkToMoney;
        private System.Windows.Forms.CheckBox chkFromMoney;
        private System.Windows.Forms.TextBox txtMoneyFrom;
        private System.Windows.Forms.TextBox txtMoneyTo;
        private System.Windows.Forms.DataGridView dgvCusTotal;
        private System.Windows.Forms.ImageList imgUpDown;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblSCount;
        private System.Windows.Forms.Button btnChoosePage;
        private System.Windows.Forms.TextBox txtGoPage;
        private System.Windows.Forms.Button btnEndPage;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnTopPage;
        private System.Windows.Forms.ComboBox cboRows;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSpace;
        private System.Windows.Forms.Label lblCurrentPage;
        private System.Windows.Forms.Label lblTotalPage;
        private System.Windows.Forms.Label label3;
        private SaleMTCommon.ctlInfoStore ctlInfoStore1;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
    }
}