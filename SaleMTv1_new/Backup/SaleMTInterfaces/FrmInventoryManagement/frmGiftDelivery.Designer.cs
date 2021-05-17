namespace SaleMTInterfaces.FrmInventoryManagement
{
    partial class frmGiftDelivery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGiftDelivery));
            this.panel2 = new System.Windows.Forms.Panel();
            this.gbxPTangQua = new System.Windows.Forms.GroupBox();
            this.btnChooseGift = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lvwGift = new System.Windows.Forms.ListView();
            this.gbxDanhSach = new System.Windows.Forms.GroupBox();
            this.lvwGiftSearch = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGiftSearch = new System.Windows.Forms.Button();
            this.gpxXuatPT = new System.Windows.Forms.GroupBox();
            this.btnBrowe = new System.Windows.Forms.Button();
            this.rbnExportStore = new System.Windows.Forms.RadioButton();
            this.rbnExportWasehouse = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtExportDelivery = new System.Windows.Forms.TextBox();
            this.txtReceipt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpExportTime = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpExportDate = new System.Windows.Forms.DateTimePicker();
            this.txtExportCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gbxNhap = new System.Windows.Forms.GroupBox();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.txtExportCodeSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.gbxPTangQua.SuspendLayout();
            this.gbxDanhSach.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gpxXuatPT.SuspendLayout();
            this.gbxNhap.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.gbxPTangQua);
            this.panel2.Controls.Add(this.gbxDanhSach);
            this.panel2.Location = new System.Drawing.Point(0, 151);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1204, 428);
            this.panel2.TabIndex = 6;
            // 
            // gbxPTangQua
            // 
            this.gbxPTangQua.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxPTangQua.Controls.Add(this.btnChooseGift);
            this.gbxPTangQua.Controls.Add(this.label12);
            this.gbxPTangQua.Controls.Add(this.label11);
            this.gbxPTangQua.Controls.Add(this.label10);
            this.gbxPTangQua.Controls.Add(this.lvwGift);
            this.gbxPTangQua.Location = new System.Drawing.Point(333, 2);
            this.gbxPTangQua.Name = "gbxPTangQua";
            this.gbxPTangQua.Size = new System.Drawing.Size(860, 421);
            this.gbxPTangQua.TabIndex = 6;
            this.gbxPTangQua.TabStop = false;
            this.gbxPTangQua.Text = "Phiếu tặng quà";
            // 
            // btnChooseGift
            // 
            this.btnChooseGift.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChooseGift.Location = new System.Drawing.Point(735, 16);
            this.btnChooseGift.Name = "btnChooseGift";
            this.btnChooseGift.Size = new System.Drawing.Size(118, 25);
            this.btnChooseGift.TabIndex = 4;
            this.btnChooseGift.Text = "Chọn phiếu tặng";
            this.btnChooseGift.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(334, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 16);
            this.label12.TabIndex = 3;
            this.label12.Text = "Tổng giá trị thật:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(175, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 16);
            this.label11.TabIndex = 2;
            this.label11.Text = "Tổng số tiền:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "Tổng số phiếu:";
            // 
            // lvwGift
            // 
            this.lvwGift.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwGift.Location = new System.Drawing.Point(2, 49);
            this.lvwGift.Name = "lvwGift";
            this.lvwGift.Size = new System.Drawing.Size(852, 367);
            this.lvwGift.TabIndex = 0;
            this.lvwGift.UseCompatibleStateImageBehavior = false;
            // 
            // gbxDanhSach
            // 
            this.gbxDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbxDanhSach.Controls.Add(this.lvwGiftSearch);
            this.gbxDanhSach.Location = new System.Drawing.Point(10, 2);
            this.gbxDanhSach.Name = "gbxDanhSach";
            this.gbxDanhSach.Size = new System.Drawing.Size(317, 422);
            this.gbxDanhSach.TabIndex = 5;
            this.gbxDanhSach.TabStop = false;
            this.gbxDanhSach.Text = "Danh sách";
            // 
            // lvwGiftSearch
            // 
            this.lvwGiftSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lvwGiftSearch.Location = new System.Drawing.Point(6, 17);
            this.lvwGiftSearch.Name = "lvwGiftSearch";
            this.lvwGiftSearch.Size = new System.Drawing.Size(309, 399);
            this.lvwGiftSearch.TabIndex = 0;
            this.lvwGiftSearch.UseCompatibleStateImageBehavior = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGiftSearch);
            this.panel1.Controls.Add(this.gpxXuatPT);
            this.panel1.Controls.Add(this.gbxNhap);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1204, 151);
            this.panel1.TabIndex = 5;
            // 
            // btnGiftSearch
            // 
            this.btnGiftSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnGiftSearch.Image")));
            this.btnGiftSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGiftSearch.Location = new System.Drawing.Point(252, 124);
            this.btnGiftSearch.Name = "btnGiftSearch";
            this.btnGiftSearch.Size = new System.Drawing.Size(75, 23);
            this.btnGiftSearch.TabIndex = 5;
            this.btnGiftSearch.Text = "Tìm";
            this.btnGiftSearch.UseVisualStyleBackColor = true;
            // 
            // gpxXuatPT
            // 
            this.gpxXuatPT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpxXuatPT.Controls.Add(this.btnBrowe);
            this.gpxXuatPT.Controls.Add(this.rbnExportStore);
            this.gpxXuatPT.Controls.Add(this.rbnExportWasehouse);
            this.gpxXuatPT.Controls.Add(this.textBox1);
            this.gpxXuatPT.Controls.Add(this.txtExportDelivery);
            this.gpxXuatPT.Controls.Add(this.txtReceipt);
            this.gpxXuatPT.Controls.Add(this.label9);
            this.gpxXuatPT.Controls.Add(this.label8);
            this.gpxXuatPT.Controls.Add(this.dtpExportTime);
            this.gpxXuatPT.Controls.Add(this.label7);
            this.gpxXuatPT.Controls.Add(this.dtpExportDate);
            this.gpxXuatPT.Controls.Add(this.txtExportCode);
            this.gpxXuatPT.Controls.Add(this.label6);
            this.gpxXuatPT.Controls.Add(this.label5);
            this.gpxXuatPT.Controls.Add(this.label4);
            this.gpxXuatPT.Location = new System.Drawing.Point(333, 12);
            this.gpxXuatPT.Name = "gpxXuatPT";
            this.gpxXuatPT.Size = new System.Drawing.Size(859, 137);
            this.gpxXuatPT.TabIndex = 4;
            this.gpxXuatPT.TabStop = false;
            this.gpxXuatPT.Text = "Thông tin xuất phiếu tặng";
            // 
            // btnBrowe
            // 
            this.btnBrowe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowe.Location = new System.Drawing.Point(826, 49);
            this.btnBrowe.Name = "btnBrowe";
            this.btnBrowe.Size = new System.Drawing.Size(27, 25);
            this.btnBrowe.TabIndex = 17;
            this.btnBrowe.Text = "...";
            this.btnBrowe.UseVisualStyleBackColor = true;
            // 
            // rbnExportStore
            // 
            this.rbnExportStore.AutoSize = true;
            this.rbnExportStore.Location = new System.Drawing.Point(489, 23);
            this.rbnExportStore.Name = "rbnExportStore";
            this.rbnExportStore.Size = new System.Drawing.Size(134, 17);
            this.rbnExportStore.TabIndex = 16;
            this.rbnExportStore.TabStop = true;
            this.rbnExportStore.Text = "Xuất ra cửa hàng khác";
            this.rbnExportStore.UseVisualStyleBackColor = true;
            // 
            // rbnExportWasehouse
            // 
            this.rbnExportWasehouse.AutoSize = true;
            this.rbnExportWasehouse.Location = new System.Drawing.Point(389, 23);
            this.rbnExportWasehouse.Name = "rbnExportWasehouse";
            this.rbnExportWasehouse.Size = new System.Drawing.Size(83, 17);
            this.rbnExportWasehouse.TabIndex = 15;
            this.rbnExportWasehouse.TabStop = true;
            this.rbnExportWasehouse.Text = "Xuất về kho";
            this.rbnExportWasehouse.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(103, 75);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(275, 56);
            this.textBox1.TabIndex = 14;
            // 
            // txtExportDelivery
            // 
            this.txtExportDelivery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExportDelivery.Location = new System.Drawing.Point(489, 75);
            this.txtExportDelivery.Name = "txtExportDelivery";
            this.txtExportDelivery.ReadOnly = true;
            this.txtExportDelivery.Size = new System.Drawing.Size(331, 22);
            this.txtExportDelivery.TabIndex = 13;
            // 
            // txtReceipt
            // 
            this.txtReceipt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReceipt.Location = new System.Drawing.Point(489, 50);
            this.txtReceipt.Name = "txtReceipt";
            this.txtReceipt.ReadOnly = true;
            this.txtReceipt.Size = new System.Drawing.Size(331, 22);
            this.txtReceipt.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(386, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 16);
            this.label9.TabIndex = 11;
            this.label9.Text = "Nơi xuất phiếu";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(386, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Nơi nhận phiếu";
            // 
            // dtpExportTime
            // 
            this.dtpExportTime.Checked = false;
            this.dtpExportTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpExportTime.Location = new System.Drawing.Point(264, 50);
            this.dtpExportTime.Name = "dtpExportTime";
            this.dtpExportTime.ShowCheckBox = true;
            this.dtpExportTime.Size = new System.Drawing.Size(114, 22);
            this.dtpExportTime.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(208, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Giờ xuất";
            // 
            // dtpExportDate
            // 
            this.dtpExportDate.Checked = false;
            this.dtpExportDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExportDate.Location = new System.Drawing.Point(103, 50);
            this.dtpExportDate.Name = "dtpExportDate";
            this.dtpExportDate.ShowCheckBox = true;
            this.dtpExportDate.Size = new System.Drawing.Size(102, 22);
            this.dtpExportDate.TabIndex = 4;
            // 
            // txtExportCode
            // 
            this.txtExportCode.Location = new System.Drawing.Point(103, 22);
            this.txtExportCode.Name = "txtExportCode";
            this.txtExportCode.ReadOnly = true;
            this.txtExportCode.Size = new System.Drawing.Size(275, 22);
            this.txtExportCode.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Ghi chú";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Ngày xuất";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mã xuất phiếu";
            // 
            // gbxNhap
            // 
            this.gbxNhap.Controls.Add(this.dtpDateTo);
            this.gbxNhap.Controls.Add(this.dtpDateFrom);
            this.gbxNhap.Controls.Add(this.txtExportCodeSearch);
            this.gbxNhap.Controls.Add(this.label3);
            this.gbxNhap.Controls.Add(this.label2);
            this.gbxNhap.Controls.Add(this.label1);
            this.gbxNhap.Location = new System.Drawing.Point(10, 12);
            this.gbxNhap.Name = "gbxNhap";
            this.gbxNhap.Size = new System.Drawing.Size(317, 107);
            this.gbxNhap.TabIndex = 3;
            this.gbxNhap.TabStop = false;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateTo.Location = new System.Drawing.Point(103, 70);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.ShowCheckBox = true;
            this.dtpDateTo.Size = new System.Drawing.Size(208, 22);
            this.dtpDateTo.TabIndex = 5;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateFrom.Location = new System.Drawing.Point(103, 46);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.ShowCheckBox = true;
            this.dtpDateFrom.Size = new System.Drawing.Size(208, 22);
            this.dtpDateFrom.TabIndex = 4;
            // 
            // txtExportCodeSearch
            // 
            this.txtExportCodeSearch.Location = new System.Drawing.Point(103, 22);
            this.txtExportCodeSearch.Name = "txtExportCodeSearch";
            this.txtExportCodeSearch.Size = new System.Drawing.Size(208, 22);
            this.txtExportCodeSearch.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đến ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Từ ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã xuất phiếu";
            // 
            // frmGiftDelivery
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1204, 580);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmGiftDelivery";
            this.Text = "Xuất phiếu tặng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel2.ResumeLayout(false);
            this.gbxPTangQua.ResumeLayout(false);
            this.gbxPTangQua.PerformLayout();
            this.gbxDanhSach.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.gpxXuatPT.ResumeLayout(false);
            this.gpxXuatPT.PerformLayout();
            this.gbxNhap.ResumeLayout(false);
            this.gbxNhap.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGiftSearch;
        private System.Windows.Forms.GroupBox gpxXuatPT;
        private System.Windows.Forms.TextBox txtExportDelivery;
        private System.Windows.Forms.TextBox txtReceipt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpExportTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpExportDate;
        private System.Windows.Forms.TextBox txtExportCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox gbxNhap;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.TextBox txtExportCodeSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox gbxPTangQua;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListView lvwGift;
        private System.Windows.Forms.GroupBox gbxDanhSach;
        private System.Windows.Forms.ListView lvwGiftSearch;
        private System.Windows.Forms.Button btnChooseGift;
        private System.Windows.Forms.Button btnBrowe;
        private System.Windows.Forms.RadioButton rbnExportStore;
        private System.Windows.Forms.RadioButton rbnExportWasehouse;
        private System.Windows.Forms.TextBox textBox1;

    }
}