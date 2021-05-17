namespace SaleMTInterfaces.FrmInventoryManagement
{
    partial class dlgChooseProduct
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgChooseProduct));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCountProduct = new System.Windows.Forms.Label();
            this.pnlAutoName = new System.Windows.Forms.Panel();
            this.lvwAutoName = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.pnlAutoCode = new System.Windows.Forms.Panel();
            this.lvwAutoCode = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.clnProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblTotalProduct = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.cboCatagory = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCountChoosed = new System.Windows.Forms.Label();
            this.lblTotalChoosed = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.dgvChoosedProduct = new System.Windows.Forms.DataGridView();
            this.clnProduct_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnProduct_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnChose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlAutoName.SuspendLayout();
            this.pnlAutoCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoosedProduct)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(422, 501);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCountProduct);
            this.groupBox1.Controls.Add(this.pnlAutoName);
            this.groupBox1.Controls.Add(this.txtProductName);
            this.groupBox1.Controls.Add(this.txtProductCode);
            this.groupBox1.Controls.Add(this.pnlAutoCode);
            this.groupBox1.Controls.Add(this.dgvProducts);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.lblTotalProduct);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnExcel);
            this.groupBox1.Controls.Add(this.cboCatagory);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 495);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn sản phẩm";
            // 
            // lblCountProduct
            // 
            this.lblCountProduct.AutoSize = true;
            this.lblCountProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountProduct.Location = new System.Drawing.Point(78, 42);
            this.lblCountProduct.Name = "lblCountProduct";
            this.lblCountProduct.Size = new System.Drawing.Size(15, 15);
            this.lblCountProduct.TabIndex = 12;
            this.lblCountProduct.Text = "0";
            // 
            // pnlAutoName
            // 
            this.pnlAutoName.Controls.Add(this.lvwAutoName);
            this.pnlAutoName.Location = new System.Drawing.Point(155, 83);
            this.pnlAutoName.Name = "pnlAutoName";
            this.pnlAutoName.Size = new System.Drawing.Size(214, 154);
            this.pnlAutoName.TabIndex = 12;
            // 
            // lvwAutoName
            // 
            this.lvwAutoName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvwAutoName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwAutoName.FullRowSelect = true;
            this.lvwAutoName.Location = new System.Drawing.Point(0, 0);
            this.lvwAutoName.Name = "lvwAutoName";
            this.lvwAutoName.Size = new System.Drawing.Size(214, 151);
            this.lvwAutoName.TabIndex = 0;
            this.lvwAutoName.UseCompatibleStateImageBehavior = false;
            this.lvwAutoName.View = System.Windows.Forms.View.Details;
            this.lvwAutoName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwAutoName_MouseDoubleClick);
            this.lvwAutoName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwAutoName_KeyDown);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Sản phẩm";
            this.columnHeader2.Width = 210;
            // 
            // txtProductName
            // 
            this.txtProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(155, 60);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(214, 23);
            this.txtProductName.TabIndex = 11;
            this.txtProductName.TextChanged += new System.EventHandler(this.txtProductName_TextChanged);
            this.txtProductName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductName_KeyDown);
            // 
            // txtProductCode
            // 
            this.txtProductCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductCode.Location = new System.Drawing.Point(7, 60);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(141, 23);
            this.txtProductCode.TabIndex = 10;
            this.txtProductCode.TextChanged += new System.EventHandler(this.txtProductCode_TextChanged);
            this.txtProductCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductCode_KeyDown);
            // 
            // pnlAutoCode
            // 
            this.pnlAutoCode.Controls.Add(this.lvwAutoCode);
            this.pnlAutoCode.Location = new System.Drawing.Point(6, 83);
            this.pnlAutoCode.Name = "pnlAutoCode";
            this.pnlAutoCode.Size = new System.Drawing.Size(142, 154);
            this.pnlAutoCode.TabIndex = 9;
            // 
            // lvwAutoCode
            // 
            this.lvwAutoCode.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvwAutoCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwAutoCode.FullRowSelect = true;
            this.lvwAutoCode.Location = new System.Drawing.Point(0, 0);
            this.lvwAutoCode.MultiSelect = false;
            this.lvwAutoCode.Name = "lvwAutoCode";
            this.lvwAutoCode.Size = new System.Drawing.Size(142, 151);
            this.lvwAutoCode.TabIndex = 0;
            this.lvwAutoCode.UseCompatibleStateImageBehavior = false;
            this.lvwAutoCode.View = System.Windows.Forms.View.Details;
            this.lvwAutoCode.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwAutoCode_MouseDoubleClick);
            this.lvwAutoCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwAutoCode_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã sản phẩm";
            this.columnHeader1.Width = 138;
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProducts.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnProductCode,
            this.clnProductName});
            this.dgvProducts.Location = new System.Drawing.Point(6, 87);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(402, 402);
            this.dgvProducts.TabIndex = 8;
            // 
            // clnProductCode
            // 
            this.clnProductCode.DataPropertyName = "PRODUCT_ID";
            this.clnProductCode.HeaderText = "Mã SP";
            this.clnProductCode.Name = "clnProductCode";
            this.clnProductCode.ReadOnly = true;
            this.clnProductCode.Width = 120;
            // 
            // clnProductName
            // 
            this.clnProductName.DataPropertyName = "PRODUCT_NAME";
            this.clnProductName.HeaderText = "Tên SP";
            this.clnProductName.Name = "clnProductName";
            this.clnProductName.ReadOnly = true;
            this.clnProductName.Width = 220;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::SaleMTInterfaces.Properties.Resources.search_zoom;
            this.btnSearch.Location = new System.Drawing.Point(375, 58);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(32, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblTotalProduct
            // 
            this.lblTotalProduct.AutoSize = true;
            this.lblTotalProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProduct.Location = new System.Drawing.Point(2, 40);
            this.lblTotalProduct.Name = "lblTotalProduct";
            this.lblTotalProduct.Size = new System.Drawing.Size(80, 17);
            this.lblTotalProduct.TabIndex = 4;
            this.lblTotalProduct.Text = "Tổng cộng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Lọc theo";
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Image = global::SaleMTInterfaces.Properties.Resources.excel;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.Location = new System.Drawing.Point(327, 19);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(81, 26);
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Text = "Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // cboCatagory
            // 
            this.cboCatagory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCatagory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCatagory.FormattingEnabled = true;
            this.cboCatagory.Location = new System.Drawing.Point(113, 20);
            this.cboCatagory.Name = "cboCatagory";
            this.cboCatagory.Size = new System.Drawing.Size(207, 23);
            this.cboCatagory.TabIndex = 1;
            this.cboCatagory.SelectedIndexChanged += new System.EventHandler(this.cboCatagory_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Location = new System.Drawing.Point(497, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(399, 501);
            this.panel2.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblCountChoosed);
            this.groupBox2.Controls.Add(this.lblTotalChoosed);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnImport);
            this.groupBox2.Controls.Add(this.dgvChoosedProduct);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(393, 495);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Đã chọn";
            // 
            // lblCountChoosed
            // 
            this.lblCountChoosed.AutoSize = true;
            this.lblCountChoosed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountChoosed.Location = new System.Drawing.Point(299, 26);
            this.lblCountChoosed.Name = "lblCountChoosed";
            this.lblCountChoosed.Size = new System.Drawing.Size(15, 15);
            this.lblCountChoosed.TabIndex = 11;
            this.lblCountChoosed.Text = "0";
            // 
            // lblTotalChoosed
            // 
            this.lblTotalChoosed.AutoSize = true;
            this.lblTotalChoosed.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalChoosed.Location = new System.Drawing.Point(221, 24);
            this.lblTotalChoosed.Name = "lblTotalChoosed";
            this.lblTotalChoosed.Size = new System.Drawing.Size(80, 17);
            this.lblTotalChoosed.TabIndex = 9;
            this.lblTotalChoosed.Text = "Tổng cộng:";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(114, 21);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(91, 26);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Image = global::SaleMTInterfaces.Properties.Resources.excel;
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.Location = new System.Drawing.Point(6, 21);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(91, 26);
            this.btnImport.TabIndex = 9;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // dgvChoosedProduct
            // 
            this.dgvChoosedProduct.AllowUserToAddRows = false;
            this.dgvChoosedProduct.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvChoosedProduct.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChoosedProduct.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvChoosedProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChoosedProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnProduct_Id,
            this.clnProduct_name});
            this.dgvChoosedProduct.Location = new System.Drawing.Point(6, 61);
            this.dgvChoosedProduct.Name = "dgvChoosedProduct";
            this.dgvChoosedProduct.ReadOnly = true;
            this.dgvChoosedProduct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChoosedProduct.Size = new System.Drawing.Size(381, 428);
            this.dgvChoosedProduct.TabIndex = 9;
            // 
            // clnProduct_Id
            // 
            this.clnProduct_Id.DataPropertyName = "PRODUCT_ID";
            this.clnProduct_Id.HeaderText = "Mã SP";
            this.clnProduct_Id.Name = "clnProduct_Id";
            this.clnProduct_Id.ReadOnly = true;
            // 
            // clnProduct_name
            // 
            this.clnProduct_name.DataPropertyName = "PRODUCT_NAME";
            this.clnProduct_name.HeaderText = "Tên SP";
            this.clnProduct_name.Name = "clnProduct_name";
            this.clnProduct_name.ReadOnly = true;
            this.clnProduct_name.Width = 220;
            // 
            // btnChose
            // 
            this.btnChose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChose.Location = new System.Drawing.Point(432, 236);
            this.btnChose.Name = "btnChose";
            this.btnChose.Size = new System.Drawing.Size(61, 26);
            this.btnChose.TabIndex = 11;
            this.btnChose.Text = "(F5)>>";
            this.btnChose.UseVisualStyleBackColor = true;
            this.btnChose.Click += new System.EventHandler(this.btnChose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Image = global::SaleMTInterfaces.Properties.Resources._5;
            this.btnDelete.Location = new System.Drawing.Point(432, 268);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(61, 26);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::SaleMTInterfaces.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(473, 512);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(81, 26);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::SaleMTInterfaces.Properties.Resources.save1;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(386, 512);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 26);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(912, 568);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.btnClose);
            this.tabPage2.Controls.Add(this.btnDelete);
            this.tabPage2.Controls.Add(this.btnSave);
            this.tabPage2.Controls.Add(this.btnChose);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(904, 542);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sản phẩm";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dlgChooseProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(927, 574);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dlgChooseProduct";
            this.Text = "Chọn sản phẩm";
            this.Load += new System.EventHandler(this.dlgChooseProduct_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.dlgChooseProduct_FormClosed);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlAutoName.ResumeLayout(false);
            this.pnlAutoCode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChoosedProduct)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.ComboBox cboCatagory;
        private System.Windows.Forms.Label lblTotalProduct;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvChoosedProduct;
        private System.Windows.Forms.Label lblTotalChoosed;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnChose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnProduct_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnProduct_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnProductName;
        private System.Windows.Forms.Panel pnlAutoCode;
        private System.Windows.Forms.ListView lvwAutoCode;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox txtProductCode;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Panel pnlAutoName;
        private System.Windows.Forms.ListView lvwAutoName;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label lblCountChoosed;
        private System.Windows.Forms.Label lblCountProduct;
    }
}