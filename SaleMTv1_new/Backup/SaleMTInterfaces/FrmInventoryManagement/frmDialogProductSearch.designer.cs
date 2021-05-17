namespace SaleMTInterfaces.FrmInventoryManagement
{
    partial class frmDialogProductSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDialogProductSearch));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.rdbTenHang = new System.Windows.Forms.RadioButton();
            this.rdbMaHang = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grvDanhSach = new System.Windows.Forms.DataGridView();
            this.PRODUCT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkChoose = new System.Windows.Forms.CheckBox();
            this.btnTopPage = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnEndPage = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.rdbTenHang);
            this.groupBox1.Controls.Add(this.rdbMaHang);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(275, 116);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(186, 80);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(78, 25);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(8, 80);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(170, 22);
            this.txtSearch.TabIndex = 4;
            // 
            // rdbTenHang
            // 
            this.rdbTenHang.AutoSize = true;
            this.rdbTenHang.Checked = true;
            this.rdbTenHang.Location = new System.Drawing.Point(8, 47);
            this.rdbTenHang.Margin = new System.Windows.Forms.Padding(4);
            this.rdbTenHang.Name = "rdbTenHang";
            this.rdbTenHang.Size = new System.Drawing.Size(83, 20);
            this.rdbTenHang.TabIndex = 3;
            this.rdbTenHang.TabStop = true;
            this.rdbTenHang.Text = "Tên hàng";
            this.rdbTenHang.UseVisualStyleBackColor = true;
            this.rdbTenHang.Click += new System.EventHandler(this.rdbTenHang_Click);
            this.rdbTenHang.CheckedChanged += new System.EventHandler(this.rdbTenHang_CheckedChanged);
            // 
            // rdbMaHang
            // 
            this.rdbMaHang.AutoSize = true;
            this.rdbMaHang.Location = new System.Drawing.Point(8, 15);
            this.rdbMaHang.Margin = new System.Windows.Forms.Padding(4);
            this.rdbMaHang.Name = "rdbMaHang";
            this.rdbMaHang.Size = new System.Drawing.Size(78, 20);
            this.rdbMaHang.TabIndex = 3;
            this.rdbMaHang.Text = "Mã hàng";
            this.rdbMaHang.UseVisualStyleBackColor = true;
            this.rdbMaHang.Click += new System.EventHandler(this.rdbMaHang_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grvDanhSach);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.groupBox2.Location = new System.Drawing.Point(299, 9);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(575, 409);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách";
            // 
            // grvDanhSach
            // 
            this.grvDanhSach.AllowUserToAddRows = false;
            this.grvDanhSach.AllowUserToDeleteRows = false;
            this.grvDanhSach.AllowUserToResizeColumns = false;
            this.grvDanhSach.AllowUserToResizeRows = false;
            this.grvDanhSach.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PRODUCT_ID,
            this.PRODUCT_NAME});
            this.grvDanhSach.Location = new System.Drawing.Point(5, 23);
            this.grvDanhSach.Margin = new System.Windows.Forms.Padding(4);
            this.grvDanhSach.MultiSelect = false;
            this.grvDanhSach.Name = "grvDanhSach";
            this.grvDanhSach.ReadOnly = true;
            this.grvDanhSach.RowHeadersVisible = false;
            this.grvDanhSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grvDanhSach.Size = new System.Drawing.Size(546, 378);
            this.grvDanhSach.TabIndex = 0;
            this.grvDanhSach.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvDanhSach_CellDoubleClick);
            this.grvDanhSach.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grvDanhSach_CellContentDoubleClick);
            this.grvDanhSach.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grvDanhSach_KeyDown);
            this.grvDanhSach.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grvDanhSach_DataBindingComplete);
            // 
            // PRODUCT_ID
            // 
            this.PRODUCT_ID.DataPropertyName = "PRODUCT_ID";
            this.PRODUCT_ID.HeaderText = "Mã hàng";
            this.PRODUCT_ID.Name = "PRODUCT_ID";
            this.PRODUCT_ID.ReadOnly = true;
            // 
            // PRODUCT_NAME
            // 
            this.PRODUCT_NAME.DataPropertyName = "PRODUCT_NAME";
            this.PRODUCT_NAME.HeaderText = "Tên hàng";
            this.PRODUCT_NAME.Name = "PRODUCT_NAME";
            this.PRODUCT_NAME.ReadOnly = true;
            this.PRODUCT_NAME.Width = 200;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkChoose);
            this.groupBox3.Controls.Add(this.btnTopPage);
            this.groupBox3.Controls.Add(this.btnPrev);
            this.groupBox3.Controls.Add(this.btnNext);
            this.groupBox3.Controls.Add(this.btnEndPage);
            this.groupBox3.Controls.Add(this.listView1);
            this.groupBox3.Location = new System.Drawing.Point(16, 133);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(275, 285);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // chkChoose
            // 
            this.chkChoose.AutoSize = true;
            this.chkChoose.Checked = true;
            this.chkChoose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChoose.Location = new System.Drawing.Point(8, 262);
            this.chkChoose.Name = "chkChoose";
            this.chkChoose.Size = new System.Drawing.Size(15, 14);
            this.chkChoose.TabIndex = 5;
            this.chkChoose.TabStop = false;
            this.chkChoose.UseVisualStyleBackColor = true;
            // 
            // btnTopPage
            // 
            this.btnTopPage.Image = ((System.Drawing.Image)(resources.GetObject("btnTopPage.Image")));
            this.btnTopPage.Location = new System.Drawing.Point(150, 257);
            this.btnTopPage.Name = "btnTopPage";
            this.btnTopPage.Size = new System.Drawing.Size(24, 23);
            this.btnTopPage.TabIndex = 4;
            this.btnTopPage.TabStop = false;
            this.btnTopPage.UseVisualStyleBackColor = true;
            // 
            // btnPrev
            // 
            this.btnPrev.Image = ((System.Drawing.Image)(resources.GetObject("btnPrev.Image")));
            this.btnPrev.Location = new System.Drawing.Point(180, 257);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(24, 23);
            this.btnPrev.TabIndex = 3;
            this.btnPrev.TabStop = false;
            this.btnPrev.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(210, 257);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(24, 23);
            this.btnNext.TabIndex = 2;
            this.btnNext.TabStop = false;
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnEndPage
            // 
            this.btnEndPage.Image = ((System.Drawing.Image)(resources.GetObject("btnEndPage.Image")));
            this.btnEndPage.Location = new System.Drawing.Point(240, 257);
            this.btnEndPage.Name = "btnEndPage";
            this.btnEndPage.Size = new System.Drawing.Size(24, 23);
            this.btnEndPage.TabIndex = 1;
            this.btnEndPage.TabStop = false;
            this.btnEndPage.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(8, 16);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(256, 240);
            this.listView1.TabIndex = 0;
            this.listView1.TabStop = false;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(502, 423);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(81, 25);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnExit
            // 
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(591, 423);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(79, 25);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Đóng";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmDialogProductSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 464);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDialogProductSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tìm kiếm mã hàng";
            this.Load += new System.EventHandler(this.frmDialogProductSearch_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvDanhSach)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.RadioButton rdbTenHang;
        private System.Windows.Forms.RadioButton rdbMaHang;
        private System.Windows.Forms.DataGridView grvDanhSach;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_NAME;
        private System.Windows.Forms.CheckBox chkChoose;
        private System.Windows.Forms.Button btnTopPage;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnEndPage;
        private System.Windows.Forms.ListView listView1;

    }
}