namespace SaleMTInterfaces.FrmSaleManagement
{
    partial class dlgChooseGift
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgChooseGift));
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.grbGift2 = new System.Windows.Forms.GroupBox();
            this.lvwGift2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.lvwGift1 = new System.Windows.Forms.ListView();
            this.colProCode = new System.Windows.Forms.ColumnHeader();
            this.colProName = new System.Windows.Forms.ColumnHeader();
            this.colQuantity = new System.Windows.Forms.ColumnHeader();
            this.colTK = new System.Windows.Forms.ColumnHeader();
            this.colProgramPro = new System.Windows.Forms.ColumnHeader();
            this.colProgramCode = new System.Windows.Forms.ColumnHeader();
            this.grbGift1 = new System.Windows.Forms.GroupBox();
            this.colIsBul = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.grbGift2.SuspendLayout();
            this.grbGift1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic);
            this.label1.Location = new System.Drawing.Point(19, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "(Nhấn F2 để thay đổi số lượng) ";
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(538, 296);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(78, 25);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(622, 296);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 25);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grbGift2
            // 
            this.grbGift2.Controls.Add(this.lvwGift2);
            this.grbGift2.Location = new System.Drawing.Point(12, 151);
            this.grbGift2.Name = "grbGift2";
            this.grbGift2.Size = new System.Drawing.Size(703, 137);
            this.grbGift2.TabIndex = 1;
            this.grbGift2.TabStop = false;
            this.grbGift2.Text = "Danh sách quà tặng 2";
            // 
            // lvwGift2
            // 
            this.lvwGift2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvwGift2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwGift2.FullRowSelect = true;
            this.lvwGift2.GridLines = true;
            this.lvwGift2.Location = new System.Drawing.Point(3, 18);
            this.lvwGift2.MultiSelect = false;
            this.lvwGift2.Name = "lvwGift2";
            this.lvwGift2.Size = new System.Drawing.Size(697, 116);
            this.lvwGift2.TabIndex = 0;
            this.lvwGift2.UseCompatibleStateImageBehavior = false;
            this.lvwGift2.View = System.Windows.Forms.View.Details;
            this.lvwGift2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwGift2_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã hàng";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên hàng";
            this.columnHeader2.Width = 180;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "SL";
            this.columnHeader3.Width = 50;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "TK";
            this.columnHeader4.Width = 50;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Mã CTKM";
            this.columnHeader5.Width = 180;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Tên CTKM";
            this.columnHeader6.Width = 151;
            // 
            // lvwGift1
            // 
            this.lvwGift1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProCode,
            this.colProName,
            this.colQuantity,
            this.colTK,
            this.colProgramPro,
            this.colProgramCode,
            this.colIsBul});
            this.lvwGift1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwGift1.FullRowSelect = true;
            this.lvwGift1.GridLines = true;
            this.lvwGift1.Location = new System.Drawing.Point(3, 18);
            this.lvwGift1.MultiSelect = false;
            this.lvwGift1.Name = "lvwGift1";
            this.lvwGift1.Size = new System.Drawing.Size(697, 114);
            this.lvwGift1.TabIndex = 0;
            this.lvwGift1.UseCompatibleStateImageBehavior = false;
            this.lvwGift1.View = System.Windows.Forms.View.Details;
            this.lvwGift1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwGift1_KeyDown);
            // 
            // colProCode
            // 
            this.colProCode.Text = "Mã hàng";
            this.colProCode.Width = 80;
            // 
            // colProName
            // 
            this.colProName.Text = "Tên hàng";
            this.colProName.Width = 180;
            // 
            // colQuantity
            // 
            this.colQuantity.Text = "SL";
            this.colQuantity.Width = 50;
            // 
            // colTK
            // 
            this.colTK.Text = "TK";
            this.colTK.Width = 50;
            // 
            // colProgramPro
            // 
            this.colProgramPro.Text = "Mã CTKM";
            this.colProgramPro.Width = 180;
            // 
            // colProgramCode
            // 
            this.colProgramCode.Text = "Tên CTKM";
            this.colProgramCode.Width = 150;
            // 
            // grbGift1
            // 
            this.grbGift1.Controls.Add(this.lvwGift1);
            this.grbGift1.Location = new System.Drawing.Point(12, 12);
            this.grbGift1.Name = "grbGift1";
            this.grbGift1.Size = new System.Drawing.Size(703, 135);
            this.grbGift1.TabIndex = 0;
            this.grbGift1.TabStop = false;
            this.grbGift1.Text = "Danh sách quà tặng 1";
            // 
            // dlgChooseGift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 326);
            this.Controls.Add(this.grbGift2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grbGift1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "dlgChooseGift";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chọn quà tặng";
            this.Load += new System.EventHandler(this.dlgChooseGift_Load);
            this.grbGift2.ResumeLayout(false);
            this.grbGift1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbGift2;
        private System.Windows.Forms.ListView lvwGift2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ListView lvwGift1;
        private System.Windows.Forms.ColumnHeader colProCode;
        private System.Windows.Forms.ColumnHeader colProName;
        private System.Windows.Forms.ColumnHeader colQuantity;
        private System.Windows.Forms.ColumnHeader colTK;
        private System.Windows.Forms.ColumnHeader colProgramPro;
        private System.Windows.Forms.ColumnHeader colProgramCode;
        private System.Windows.Forms.GroupBox grbGift1;
        private System.Windows.Forms.ColumnHeader colIsBul;
        private System.Windows.Forms.ColumnHeader columnHeader7;
    }
}