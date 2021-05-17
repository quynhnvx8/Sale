namespace SaleMTInterfaces.FrmReporter.FrmReportSale
{
    partial class frmReportProductsSale
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportProductsSale));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpDateToInvoice = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFromInvoice = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPO = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCodeInvoice = new System.Windows.Forms.TextBox();
            this.txtCodeProduct = new System.Windows.Forms.TextBox();
            this.cboTypeInput = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnDeleteProduct = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnproductattributes = new System.Windows.Forms.Button();
            this.txtproductattributes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpdateTo = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpdateFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSeach = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.gridPageView1 = new SaleMTCommon.GridPageView(translate);
            this.imgUpDown = new System.Windows.Forms.ImageList(this.components);
            this.btnPrint = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ctlInfoStore1 = new SaleMTCommon.ctlInfoStore();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.dtpDateToInvoice);
            this.groupBox1.Controls.Add(this.dtpDateFromInvoice);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtPO);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtNB);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCodeInvoice);
            this.groupBox1.Controls.Add(this.txtCodeProduct);
            this.groupBox1.Controls.Add(this.cboTypeInput);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnDeleteProduct);
            this.groupBox1.Controls.Add(this.btnProduct);
            this.groupBox1.Controls.Add(this.txtProduct);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnproductattributes);
            this.groupBox1.Controls.Add(this.txtproductattributes);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dtpdateTo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpdateFrom);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(719, 205);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(282, 181);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 16);
            this.label10.TabIndex = 23;
            this.label10.Text = "Đến ngày";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 186);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 16);
            this.label9.TabIndex = 22;
            this.label9.Text = "Ngày hóa đơn";
            // 
            // dtpDateToInvoice
            // 
            this.dtpDateToInvoice.Checked = false;
            this.dtpDateToInvoice.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
            this.dtpDateToInvoice.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateToInvoice.Location = new System.Drawing.Point(367, 179);
            this.dtpDateToInvoice.Name = "dtpDateToInvoice";
            this.dtpDateToInvoice.ShowCheckBox = true;
            this.dtpDateToInvoice.Size = new System.Drawing.Size(125, 22);
            this.dtpDateToInvoice.TabIndex = 21;
            // 
            // dtpDateFromInvoice
            // 
            this.dtpDateFromInvoice.Checked = false;
            this.dtpDateFromInvoice.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
            this.dtpDateFromInvoice.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFromInvoice.Location = new System.Drawing.Point(151, 180);
            this.dtpDateFromInvoice.Name = "dtpDateFromInvoice";
            this.dtpDateFromInvoice.ShowCheckBox = true;
            this.dtpDateFromInvoice.Size = new System.Drawing.Size(125, 22);
            this.dtpDateFromInvoice.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(314, 158);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Số PO";
            // 
            // txtPO
            // 
            this.txtPO.Location = new System.Drawing.Point(431, 154);
            this.txtPO.Name = "txtPO";
            this.txtPO.Size = new System.Drawing.Size(169, 22);
            this.txtPO.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Số nộ bộ";
            // 
            // txtNB
            // 
            this.txtNB.Location = new System.Drawing.Point(151, 154);
            this.txtNB.Name = "txtNB";
            this.txtNB.Size = new System.Drawing.Size(157, 22);
            this.txtNB.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Số hóa đơn";
            // 
            // txtCodeInvoice
            // 
            this.txtCodeInvoice.Location = new System.Drawing.Point(151, 127);
            this.txtCodeInvoice.Name = "txtCodeInvoice";
            this.txtCodeInvoice.Size = new System.Drawing.Size(157, 22);
            this.txtCodeInvoice.TabIndex = 14;
            // 
            // txtCodeProduct
            // 
            this.txtCodeProduct.Location = new System.Drawing.Point(151, 99);
            this.txtCodeProduct.Name = "txtCodeProduct";
            this.txtCodeProduct.Size = new System.Drawing.Size(113, 22);
            this.txtCodeProduct.TabIndex = 13;
            this.txtCodeProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCodeProduct_KeyDown);
            // 
            // cboTypeInput
            // 
            this.cboTypeInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTypeInput.FormattingEnabled = true;
            this.cboTypeInput.Location = new System.Drawing.Point(431, 126);
            this.cboTypeInput.Name = "cboTypeInput";
            this.cboTypeInput.Size = new System.Drawing.Size(169, 24);
            this.cboTypeInput.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(314, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Loại nhập";
            // 
            // btnDeleteProduct
            // 
            this.btnDeleteProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteProduct.Image")));
            this.btnDeleteProduct.Location = new System.Drawing.Point(662, 100);
            this.btnDeleteProduct.Name = "btnDeleteProduct";
            this.btnDeleteProduct.Size = new System.Drawing.Size(21, 21);
            this.btnDeleteProduct.TabIndex = 10;
            this.btnDeleteProduct.Text = "...";
            this.btnDeleteProduct.UseVisualStyleBackColor = false;
            this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProduct.Location = new System.Drawing.Point(638, 100);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(22, 22);
            this.btnProduct.TabIndex = 9;
            this.btnProduct.Text = "...";
            this.btnProduct.UseVisualStyleBackColor = false;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // txtProduct
            // 
            this.txtProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProduct.Enabled = false;
            this.txtProduct.Location = new System.Drawing.Point(270, 99);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.ReadOnly = true;
            this.txtProduct.Size = new System.Drawing.Size(362, 22);
            this.txtProduct.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sản phẩm";
            // 
            // btnproductattributes
            // 
            this.btnproductattributes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnproductattributes.Location = new System.Drawing.Point(655, 42);
            this.btnproductattributes.Name = "btnproductattributes";
            this.btnproductattributes.Size = new System.Drawing.Size(28, 53);
            this.btnproductattributes.TabIndex = 6;
            this.btnproductattributes.Text = "...";
            this.btnproductattributes.UseVisualStyleBackColor = false;
            this.btnproductattributes.Click += new System.EventHandler(this.btnproductattributes_Click);
            // 
            // txtproductattributes
            // 
            this.txtproductattributes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtproductattributes.Location = new System.Drawing.Point(151, 44);
            this.txtproductattributes.Multiline = true;
            this.txtproductattributes.Name = "txtproductattributes";
            this.txtproductattributes.ReadOnly = true;
            this.txtproductattributes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtproductattributes.Size = new System.Drawing.Size(498, 51);
            this.txtproductattributes.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Thuộc tính sản phẩm";
            // 
            // dtpdateTo
            // 
            this.dtpdateTo.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
            this.dtpdateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdateTo.Location = new System.Drawing.Point(367, 15);
            this.dtpdateTo.Name = "dtpdateTo";
            this.dtpdateTo.Size = new System.Drawing.Size(117, 22);
            this.dtpdateTo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Đến ngày";
            // 
            // dtpdateFrom
            // 
            this.dtpdateFrom.CustomFormat = SaleMTDataAccessLayer.SaleMTDAL.AppConfigFileSettings.strOptDate;
            this.dtpdateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpdateFrom.Location = new System.Drawing.Point(151, 15);
            this.dtpdateFrom.Name = "dtpdateFrom";
            this.dtpdateFrom.Size = new System.Drawing.Size(113, 22);
            this.dtpdateFrom.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ ngày";
            // 
            // btnSeach
            // 
            this.btnSeach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSeach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeach.Image = ((System.Drawing.Image)(resources.GetObject("btnSeach.Image")));
            this.btnSeach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeach.Location = new System.Drawing.Point(319, 211);
            this.btnSeach.Name = "btnSeach";
            this.btnSeach.Size = new System.Drawing.Size(93, 27);
            this.btnSeach.TabIndex = 1;
            this.btnSeach.Text = "Tìm";
            this.btnSeach.UseVisualStyleBackColor = true;
            this.btnSeach.Click += new System.EventHandler(this.btnSeach_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(503, 211);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(90, 27);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(595, 211);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(88, 27);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Đóng";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // gridPageView1
            // 
            this.gridPageView1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gridPageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPageView1.Location = new System.Drawing.Point(0, 242);
            this.gridPageView1.Margin = new System.Windows.Forms.Padding(12, 9, 12, 9);
            this.gridPageView1.Name = "gridPageView1";
            this.gridPageView1.Size = new System.Drawing.Size(719, 278);
            this.gridPageView1.TabIndex = 1;
            // 
            // imgUpDown
            // 
            this.imgUpDown.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgUpDown.ImageStream")));
            this.imgUpDown.TransparentColor = System.Drawing.Color.Transparent;
            this.imgUpDown.Images.SetKeyName(0, "1.png");
            this.imgUpDown.Images.SetKeyName(1, "2.png");
            this.imgUpDown.Images.SetKeyName(2, "tree.bmp");
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::SaleMTInterfaces.Properties.Resources._1121;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(414, 211);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(87, 27);
            this.btnPrint.TabIndex = 18;
            this.btnPrint.Text = "In";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ctlInfoStore1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 520);
            this.panel2.TabIndex = 19;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(969, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 520);
            this.panel3.TabIndex = 20;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.gridPageView1);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(250, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(719, 520);
            this.panel4.TabIndex = 21;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.groupBox1);
            this.panel5.Controls.Add(this.btnExit);
            this.panel5.Controls.Add(this.btnSeach);
            this.panel5.Controls.Add(this.btnPrint);
            this.panel5.Controls.Add(this.btnExport);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(719, 242);
            this.panel5.TabIndex = 0;
            // 
            // ctlInfoStore1
            // 
            this.ctlInfoStore1.BackColor = System.Drawing.SystemColors.Control;
            this.ctlInfoStore1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlInfoStore1.Location = new System.Drawing.Point(0, 0);
            this.ctlInfoStore1.Name = "ctlInfoStore1";
            this.ctlInfoStore1.Size = new System.Drawing.Size(250, 520);
            this.ctlInfoStore1.TabIndex = 0;
            // 
            // frmReportProductsSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 520);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmReportProductsSale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cửa hàng nhập hàng";
            this.Load += new System.EventHandler(this.frmReportSale_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReportSale_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpdateTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpdateFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnproductattributes;
        private System.Windows.Forms.TextBox txtproductattributes;
        private System.Windows.Forms.Button btnDeleteProduct;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSeach;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCodeInvoice;
        private System.Windows.Forms.TextBox txtCodeProduct;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpDateToInvoice;
        private System.Windows.Forms.DateTimePicker dtpDateFromInvoice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPO;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNB;
        private System.Windows.Forms.ComboBox cboTypeInput;
        private System.Windows.Forms.Label label5;
        private SaleMTCommon.GridPageView gridPageView1;
        private System.Windows.Forms.ImageList imgUpDown;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private SaleMTCommon.ctlInfoStore ctlInfoStore1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
    }
}