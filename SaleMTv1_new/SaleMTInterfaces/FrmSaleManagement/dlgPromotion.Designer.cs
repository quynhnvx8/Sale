namespace SaleMTInterfaces.FrmSaleManagement
{
    partial class dlgPromotion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgPromotion));
            this.tabPromotion = new System.Windows.Forms.TabControl();
            this.tabNum = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvwProgram = new System.Windows.Forms.ListView();
            this.colProCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDateFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDateTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNumMin = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabPromotion.SuspendLayout();
            this.tabNum.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPromotion
            // 
            this.tabPromotion.Controls.Add(this.tabNum);
            this.tabPromotion.Location = new System.Drawing.Point(6, 11);
            this.tabPromotion.Name = "tabPromotion";
            this.tabPromotion.SelectedIndex = 0;
            this.tabPromotion.Size = new System.Drawing.Size(839, 413);
            this.tabPromotion.TabIndex = 0;
            // 
            // tabNum
            // 
            this.tabNum.Controls.Add(this.groupBox1);
            this.tabNum.Location = new System.Drawing.Point(4, 29);
            this.tabNum.Name = "tabNum";
            this.tabNum.Padding = new System.Windows.Forms.Padding(3);
            this.tabNum.Size = new System.Drawing.Size(831, 380);
            this.tabNum.TabIndex = 0;
            this.tabNum.Text = "Số lượng";
            this.tabNum.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvwProgram);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(825, 374);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chương trình";
            // 
            // lvwProgram
            // 
            this.lvwProgram.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProCode,
            this.colProName,
            this.colDateFrom,
            this.colDateTo,
            this.colNumMin,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.lvwProgram.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwProgram.FullRowSelect = true;
            this.lvwProgram.GridLines = true;
            this.lvwProgram.Location = new System.Drawing.Point(3, 22);
            this.lvwProgram.MultiSelect = false;
            this.lvwProgram.Name = "lvwProgram";
            this.lvwProgram.Size = new System.Drawing.Size(819, 349);
            this.lvwProgram.TabIndex = 0;
            this.lvwProgram.UseCompatibleStateImageBehavior = false;
            this.lvwProgram.View = System.Windows.Forms.View.Details;
            // 
            // colProCode
            // 
            this.colProCode.Text = "Mã CT";
            this.colProCode.Width = 120;
            // 
            // colProName
            // 
            this.colProName.Text = "Tên CT";
            this.colProName.Width = 200;
            // 
            // colDateFrom
            // 
            this.colDateFrom.Text = "Từ ngày";
            this.colDateFrom.Width = 80;
            // 
            // colDateTo
            // 
            this.colDateTo.Text = "Đến ngày";
            this.colDateTo.Width = 80;
            // 
            // colNumMin
            // 
            this.colNumMin.Text = "SL tối thiểu";
            this.colNumMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colNumMin.Width = 78;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Giảm theo";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader7.Width = 90;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Giá trị giảm";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader8.Width = 80;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Tổng SL mua";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader9.Width = 100;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Tổng tiền mua";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader10.Width = 100;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Thành tiền giảm";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader11.Width = 120;
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(662, 430);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(86, 25);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(754, 430);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 25);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dlgPromotion
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(849, 467);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabPromotion);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgPromotion";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chương trình khuyến mại";
            this.Load += new System.EventHandler(this.dlgPromotion_Load);
            this.tabPromotion.ResumeLayout(false);
            this.tabNum.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabPromotion;
        private System.Windows.Forms.TabPage tabNum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvwProgram;
        private System.Windows.Forms.ColumnHeader colProCode;
        private System.Windows.Forms.ColumnHeader colProName;
        private System.Windows.Forms.ColumnHeader colDateFrom;
        private System.Windows.Forms.ColumnHeader colDateTo;
        private System.Windows.Forms.ColumnHeader colNumMin;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
    }
}