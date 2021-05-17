namespace SaleMTInterfaces.FrmLiablityManagement
{
    partial class frmLiablityView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLiablityView));
            this.gbxBCCongNo = new System.Windows.Forms.GroupBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnImportPay = new System.Windows.Forms.Button();
            this.btnViewPay = new System.Windows.Forms.Button();
            this.dtpDateToPay = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDateFromPay = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnImportLiablity = new System.Windows.Forms.Button();
            this.btnViewLiablity = new System.Windows.Forms.Button();
            this.dtpDateToLiablity = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDateFromLiablity = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnImportInvoices = new System.Windows.Forms.Button();
            this.btnViewInvoices = new System.Windows.Forms.Button();
            this.dtpDateToInvoices = new System.Windows.Forms.DateTimePicker();
            this.label27 = new System.Windows.Forms.Label();
            this.dtpDateFromInvoices = new System.Windows.Forms.DateTimePicker();
            this.label42 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbxBCCongNo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxBCCongNo
            // 
            this.gbxBCCongNo.Controls.Add(this.btnImport);
            this.gbxBCCongNo.Controls.Add(this.btnView);
            this.gbxBCCongNo.Controls.Add(this.dtpDateFrom);
            this.gbxBCCongNo.Controls.Add(this.label8);
            this.gbxBCCongNo.Controls.Add(this.label9);
            this.gbxBCCongNo.Controls.Add(this.btnImportPay);
            this.gbxBCCongNo.Controls.Add(this.btnViewPay);
            this.gbxBCCongNo.Controls.Add(this.dtpDateToPay);
            this.gbxBCCongNo.Controls.Add(this.label4);
            this.gbxBCCongNo.Controls.Add(this.dtpDateFromPay);
            this.gbxBCCongNo.Controls.Add(this.label5);
            this.gbxBCCongNo.Controls.Add(this.label6);
            this.gbxBCCongNo.Controls.Add(this.btnImportLiablity);
            this.gbxBCCongNo.Controls.Add(this.btnViewLiablity);
            this.gbxBCCongNo.Controls.Add(this.dtpDateToLiablity);
            this.gbxBCCongNo.Controls.Add(this.label1);
            this.gbxBCCongNo.Controls.Add(this.dtpDateFromLiablity);
            this.gbxBCCongNo.Controls.Add(this.label2);
            this.gbxBCCongNo.Controls.Add(this.label3);
            this.gbxBCCongNo.Controls.Add(this.btnImportInvoices);
            this.gbxBCCongNo.Controls.Add(this.btnViewInvoices);
            this.gbxBCCongNo.Controls.Add(this.dtpDateToInvoices);
            this.gbxBCCongNo.Controls.Add(this.label27);
            this.gbxBCCongNo.Controls.Add(this.dtpDateFromInvoices);
            this.gbxBCCongNo.Controls.Add(this.label42);
            this.gbxBCCongNo.Controls.Add(this.label31);
            this.gbxBCCongNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxBCCongNo.Location = new System.Drawing.Point(13, 13);
            this.gbxBCCongNo.Name = "gbxBCCongNo";
            this.gbxBCCongNo.Size = new System.Drawing.Size(916, 188);
            this.gbxBCCongNo.TabIndex = 0;
            this.gbxBCCongNo.TabStop = false;
            // 
            // btnImport
            // 
            this.btnImport.Image = ((System.Drawing.Image)(resources.GetObject("btnImport.Image")));
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.Location = new System.Drawing.Point(804, 153);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(95, 23);
            this.btnImport.TabIndex = 162;
            this.btnImport.Text = "Excel";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnView
            // 
            this.btnView.Image = ((System.Drawing.Image)(resources.GetObject("btnView.Image")));
            this.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnView.Location = new System.Drawing.Point(704, 153);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(92, 23);
            this.btnView.TabIndex = 161;
            this.btnView.Text = "Xem ";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(377, 154);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(141, 22);
            this.dtpDateFrom.TabIndex = 158;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(321, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 16);
            this.label8.TabIndex = 157;
            this.label8.Text = "Ngày";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 157);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(308, 16);
            this.label9.TabIndex = 156;
            this.label9.Text = "Bảng kê chi tiết các loại hóa đơn thanh toán";
            // 
            // btnImportPay
            // 
            this.btnImportPay.Image = ((System.Drawing.Image)(resources.GetObject("btnImportPay.Image")));
            this.btnImportPay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportPay.Location = new System.Drawing.Point(804, 107);
            this.btnImportPay.Name = "btnImportPay";
            this.btnImportPay.Size = new System.Drawing.Size(95, 23);
            this.btnImportPay.TabIndex = 155;
            this.btnImportPay.Text = "Excel";
            this.btnImportPay.UseVisualStyleBackColor = true;
            this.btnImportPay.Click += new System.EventHandler(this.btnImportPay_Click);
            // 
            // btnViewPay
            // 
            this.btnViewPay.Image = ((System.Drawing.Image)(resources.GetObject("btnViewPay.Image")));
            this.btnViewPay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewPay.Location = new System.Drawing.Point(704, 107);
            this.btnViewPay.Name = "btnViewPay";
            this.btnViewPay.Size = new System.Drawing.Size(92, 23);
            this.btnViewPay.TabIndex = 154;
            this.btnViewPay.Text = "Xem ";
            this.btnViewPay.UseVisualStyleBackColor = true;
            this.btnViewPay.Click += new System.EventHandler(this.btnViewPay_Click);
            // 
            // dtpDateToPay
            // 
            this.dtpDateToPay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateToPay.Location = new System.Drawing.Point(564, 109);
            this.dtpDateToPay.Name = "dtpDateToPay";
            this.dtpDateToPay.Size = new System.Drawing.Size(128, 22);
            this.dtpDateToPay.TabIndex = 153;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(526, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 16);
            this.label4.TabIndex = 152;
            this.label4.Text = "đến";
            // 
            // dtpDateFromPay
            // 
            this.dtpDateFromPay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFromPay.Location = new System.Drawing.Point(377, 108);
            this.dtpDateFromPay.Name = "dtpDateFromPay";
            this.dtpDateFromPay.Size = new System.Drawing.Size(141, 22);
            this.dtpDateFromPay.TabIndex = 151;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(321, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 16);
            this.label5.TabIndex = 150;
            this.label5.Text = "Từ ngày";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(253, 16);
            this.label6.TabIndex = 149;
            this.label6.Text = "Bảng kê nộp tiền thanh toán công ty";
            // 
            // btnImportLiablity
            // 
            this.btnImportLiablity.Image = ((System.Drawing.Image)(resources.GetObject("btnImportLiablity.Image")));
            this.btnImportLiablity.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportLiablity.Location = new System.Drawing.Point(804, 63);
            this.btnImportLiablity.Name = "btnImportLiablity";
            this.btnImportLiablity.Size = new System.Drawing.Size(95, 23);
            this.btnImportLiablity.TabIndex = 148;
            this.btnImportLiablity.Text = "Excel";
            this.btnImportLiablity.UseVisualStyleBackColor = true;
            this.btnImportLiablity.Click += new System.EventHandler(this.btnImportLiablity_Click);
            // 
            // btnViewLiablity
            // 
            this.btnViewLiablity.Image = global::SaleMTInterfaces.Properties.Resources.search_zoom;
            this.btnViewLiablity.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewLiablity.Location = new System.Drawing.Point(704, 63);
            this.btnViewLiablity.Name = "btnViewLiablity";
            this.btnViewLiablity.Size = new System.Drawing.Size(92, 23);
            this.btnViewLiablity.TabIndex = 147;
            this.btnViewLiablity.Text = "Xem ";
            this.btnViewLiablity.UseVisualStyleBackColor = true;
            this.btnViewLiablity.Click += new System.EventHandler(this.btnViewLiablity_Click);
            // 
            // dtpDateToLiablity
            // 
            this.dtpDateToLiablity.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateToLiablity.Location = new System.Drawing.Point(564, 65);
            this.dtpDateToLiablity.Name = "dtpDateToLiablity";
            this.dtpDateToLiablity.Size = new System.Drawing.Size(128, 22);
            this.dtpDateToLiablity.TabIndex = 146;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(526, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 16);
            this.label1.TabIndex = 145;
            this.label1.Text = "đến";
            // 
            // dtpDateFromLiablity
            // 
            this.dtpDateFromLiablity.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFromLiablity.Location = new System.Drawing.Point(377, 64);
            this.dtpDateFromLiablity.Name = "dtpDateFromLiablity";
            this.dtpDateFromLiablity.Size = new System.Drawing.Size(141, 22);
            this.dtpDateFromLiablity.TabIndex = 144;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 143;
            this.label2.Text = "Từ ngày";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 16);
            this.label3.TabIndex = 142;
            this.label3.Text = "Đối chiếu công nợ công ty";
            // 
            // btnImportInvoices
            // 
            this.btnImportInvoices.Image = ((System.Drawing.Image)(resources.GetObject("btnImportInvoices.Image")));
            this.btnImportInvoices.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportInvoices.Location = new System.Drawing.Point(804, 23);
            this.btnImportInvoices.Name = "btnImportInvoices";
            this.btnImportInvoices.Size = new System.Drawing.Size(95, 23);
            this.btnImportInvoices.TabIndex = 141;
            this.btnImportInvoices.Text = "Excel";
            this.btnImportInvoices.UseVisualStyleBackColor = true;
            this.btnImportInvoices.Click += new System.EventHandler(this.btnImportInvoices_Click);
            // 
            // btnViewInvoices
            // 
            this.btnViewInvoices.Image = global::SaleMTInterfaces.Properties.Resources.search_zoom;
            this.btnViewInvoices.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewInvoices.Location = new System.Drawing.Point(704, 23);
            this.btnViewInvoices.Name = "btnViewInvoices";
            this.btnViewInvoices.Size = new System.Drawing.Size(92, 23);
            this.btnViewInvoices.TabIndex = 140;
            this.btnViewInvoices.Text = "Xem ";
            this.btnViewInvoices.UseVisualStyleBackColor = true;
            this.btnViewInvoices.Click += new System.EventHandler(this.btnViewInvoices_Click);
            // 
            // dtpDateToInvoices
            // 
            this.dtpDateToInvoices.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateToInvoices.Location = new System.Drawing.Point(564, 25);
            this.dtpDateToInvoices.Name = "dtpDateToInvoices";
            this.dtpDateToInvoices.Size = new System.Drawing.Size(128, 22);
            this.dtpDateToInvoices.TabIndex = 139;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(526, 28);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(31, 16);
            this.label27.TabIndex = 138;
            this.label27.Text = "đến";
            // 
            // dtpDateFromInvoices
            // 
            this.dtpDateFromInvoices.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFromInvoices.Location = new System.Drawing.Point(377, 24);
            this.dtpDateFromInvoices.Name = "dtpDateFromInvoices";
            this.dtpDateFromInvoices.Size = new System.Drawing.Size(141, 22);
            this.dtpDateFromInvoices.TabIndex = 137;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(321, 27);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(57, 16);
            this.label42.TabIndex = 136;
            this.label42.Text = "Từ ngày";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(6, 27);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(250, 16);
            this.label31.TabIndex = 64;
            this.label31.Text = "Bảng kê chi tiết hóa đơn nhập hàng";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::SaleMTInterfaces.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(819, 212);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 24);
            this.btnClose.TabIndex = 163;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmLiablityReport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(941, 242);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbxBCCongNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmLiablityReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo công nợ";
            this.Load += new System.EventHandler(this.frmLiablityReport_Load);
            this.gbxBCCongNo.ResumeLayout(false);
            this.gbxBCCongNo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxBCCongNo;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.DateTimePicker dtpDateToInvoices;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.DateTimePicker dtpDateFromInvoices;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnImportPay;
        private System.Windows.Forms.Button btnViewPay;
        private System.Windows.Forms.DateTimePicker dtpDateToPay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDateFromPay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnImportLiablity;
        private System.Windows.Forms.Button btnViewLiablity;
        private System.Windows.Forms.DateTimePicker dtpDateToLiablity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateFromLiablity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnImportInvoices;
        private System.Windows.Forms.Button btnViewInvoices;
        private System.Windows.Forms.Button btnClose;
    }
}