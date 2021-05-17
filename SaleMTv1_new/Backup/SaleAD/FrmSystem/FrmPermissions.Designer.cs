namespace SaleAD.FrmSystem
{
    partial class FrmPermissions
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvGroupUser = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGroupPos = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkPrint = new System.Windows.Forms.CheckBox();
            this.chkDelete = new System.Windows.Forms.CheckBox();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.chkInsert = new System.Windows.Forms.CheckBox();
            this.chkView = new System.Windows.Forms.CheckBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabData = new System.Windows.Forms.TabPage();
            this.col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rbtMainProPos = new System.Windows.Forms.RadioButton();
            this.rbtMainSale = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPermissionInventory = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.treeGroupProduct = new System.Windows.Forms.TreeView();
            this.btnSavetabData = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupUser)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabGroupPos.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabData.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvGroupUser);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(289, 452);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhóm người dùng";
            // 
            // dgvGroupUser
            // 
            this.dgvGroupUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGroupUser.Location = new System.Drawing.Point(6, 20);
            this.dgvGroupUser.Name = "dgvGroupUser";
            this.dgvGroupUser.Size = new System.Drawing.Size(277, 426);
            this.dgvGroupUser.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGroupPos);
            this.tabControl1.Controls.Add(this.tabData);
            this.tabControl1.Location = new System.Drawing.Point(310, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(721, 452);
            this.tabControl1.TabIndex = 1;
            // 
            // tabGroupPos
            // 
            this.tabGroupPos.Controls.Add(this.btnSave);
            this.tabGroupPos.Controls.Add(this.groupBox2);
            this.tabGroupPos.Controls.Add(this.chkAll);
            this.tabGroupPos.Controls.Add(this.chkPrint);
            this.tabGroupPos.Controls.Add(this.chkDelete);
            this.tabGroupPos.Controls.Add(this.chkUpdate);
            this.tabGroupPos.Controls.Add(this.chkInsert);
            this.tabGroupPos.Controls.Add(this.chkView);
            this.tabGroupPos.Controls.Add(this.dataGridView2);
            this.tabGroupPos.Location = new System.Drawing.Point(4, 25);
            this.tabGroupPos.Name = "tabGroupPos";
            this.tabGroupPos.Padding = new System.Windows.Forms.Padding(3);
            this.tabGroupPos.Size = new System.Drawing.Size(713, 423);
            this.tabGroupPos.TabIndex = 0;
            this.tabGroupPos.Text = "Nhóm chức năng màn hình ProPos";
            this.tabGroupPos.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtMainSale);
            this.groupBox2.Controls.Add(this.rbtMainProPos);
            this.groupBox2.Location = new System.Drawing.Point(7, 379);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 38);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(318, 8);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(15, 14);
            this.chkAll.TabIndex = 6;
            this.chkAll.UseVisualStyleBackColor = true;
            // 
            // chkPrint
            // 
            this.chkPrint.AutoSize = true;
            this.chkPrint.Location = new System.Drawing.Point(664, 8);
            this.chkPrint.Name = "chkPrint";
            this.chkPrint.Size = new System.Drawing.Size(15, 14);
            this.chkPrint.TabIndex = 5;
            this.chkPrint.UseVisualStyleBackColor = true;
            // 
            // chkDelete
            // 
            this.chkDelete.AutoSize = true;
            this.chkDelete.Location = new System.Drawing.Point(596, 7);
            this.chkDelete.Name = "chkDelete";
            this.chkDelete.Size = new System.Drawing.Size(15, 14);
            this.chkDelete.TabIndex = 4;
            this.chkDelete.UseVisualStyleBackColor = true;
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Location = new System.Drawing.Point(531, 8);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(15, 14);
            this.chkUpdate.TabIndex = 3;
            this.chkUpdate.UseVisualStyleBackColor = true;
            // 
            // chkInsert
            // 
            this.chkInsert.AutoSize = true;
            this.chkInsert.Location = new System.Drawing.Point(459, 7);
            this.chkInsert.Name = "chkInsert";
            this.chkInsert.Size = new System.Drawing.Size(15, 14);
            this.chkInsert.TabIndex = 2;
            this.chkInsert.UseVisualStyleBackColor = true;
            // 
            // chkView
            // 
            this.chkView.AutoSize = true;
            this.chkView.Location = new System.Drawing.Point(390, 8);
            this.chkView.Name = "chkView";
            this.chkView.Size = new System.Drawing.Size(15, 14);
            this.chkView.TabIndex = 1;
            this.chkView.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col,
            this.Column1,
            this.Column3,
            this.Column5,
            this.Column8,
            this.Column9,
            this.Column10});
            this.dataGridView2.Location = new System.Drawing.Point(4, 31);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(703, 342);
            this.dataGridView2.TabIndex = 0;
            // 
            // tabData
            // 
            this.tabData.Controls.Add(this.btnSavetabData);
            this.tabData.Controls.Add(this.groupBox3);
            this.tabData.Location = new System.Drawing.Point(4, 25);
            this.tabData.Name = "tabData";
            this.tabData.Padding = new System.Windows.Forms.Padding(3);
            this.tabData.Size = new System.Drawing.Size(713, 423);
            this.tabData.TabIndex = 1;
            this.tabData.Text = "Dữ liệu";
            this.tabData.UseVisualStyleBackColor = true;
            // 
            // col
            // 
            this.col.HeaderText = "Tên chức năng - Màn hình";
            this.col.Name = "col";
            this.col.Width = 250;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Tất cả";
            this.Column1.Name = "Column1";
            this.Column1.Width = 70;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Xem";
            this.Column3.Name = "Column3";
            this.Column3.Width = 70;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Thêm mới";
            this.Column5.Name = "Column5";
            this.Column5.Width = 70;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Cập nhật";
            this.Column8.Name = "Column8";
            this.Column8.Width = 70;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Xóa";
            this.Column9.Name = "Column9";
            this.Column9.Width = 70;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "In ấn";
            this.Column10.Name = "Column10";
            this.Column10.Width = 70;
            // 
            // rbtMainProPos
            // 
            this.rbtMainProPos.AutoSize = true;
            this.rbtMainProPos.Location = new System.Drawing.Point(7, 13);
            this.rbtMainProPos.Name = "rbtMainProPos";
            this.rbtMainProPos.Size = new System.Drawing.Size(103, 20);
            this.rbtMainProPos.TabIndex = 0;
            this.rbtMainProPos.TabStop = true;
            this.rbtMainProPos.Text = "Main ProPos";
            this.rbtMainProPos.UseVisualStyleBackColor = true;
            // 
            // rbtMainSale
            // 
            this.rbtMainSale.AutoSize = true;
            this.rbtMainSale.Location = new System.Drawing.Point(160, 13);
            this.rbtMainSale.Name = "rbtMainSale";
            this.rbtMainSale.Size = new System.Drawing.Size(86, 20);
            this.rbtMainSale.TabIndex = 1;
            this.rbtMainSale.TabStop = true;
            this.rbtMainSale.Text = "Main Sale";
            this.rbtMainSale.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(596, 384);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 28);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(910, 473);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(102, 28);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnPermissionInventory
            // 
            this.btnPermissionInventory.Location = new System.Drawing.Point(19, 473);
            this.btnPermissionInventory.Name = "btnPermissionInventory";
            this.btnPermissionInventory.Size = new System.Drawing.Size(178, 28);
            this.btnPermissionInventory.TabIndex = 10;
            this.btnPermissionInventory.Text = "Phân quyền KT tồn kho";
            this.btnPermissionInventory.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.treeGroupProduct);
            this.groupBox3.Location = new System.Drawing.Point(7, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(700, 367);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nhóm sản phẩm";
            // 
            // treeGroupProduct
            // 
            this.treeGroupProduct.Location = new System.Drawing.Point(7, 22);
            this.treeGroupProduct.Name = "treeGroupProduct";
            this.treeGroupProduct.Size = new System.Drawing.Size(687, 339);
            this.treeGroupProduct.TabIndex = 0;
            // 
            // btnSavetabData
            // 
            this.btnSavetabData.Location = new System.Drawing.Point(596, 381);
            this.btnSavetabData.Name = "btnSavetabData";
            this.btnSavetabData.Size = new System.Drawing.Size(102, 28);
            this.btnSavetabData.TabIndex = 11;
            this.btnSavetabData.Text = "Lưu";
            this.btnSavetabData.UseVisualStyleBackColor = true;
            // 
            // FrmPermissions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 513);
            this.Controls.Add(this.btnPermissionInventory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmPermissions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phân quyền người dùng";
            this.Load += new System.EventHandler(this.FrmPermissions_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupUser)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabGroupPos.ResumeLayout(false);
            this.tabGroupPos.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabData.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGroupPos;
        private System.Windows.Forms.TabPage tabData;
        private System.Windows.Forms.DataGridView dgvGroupUser;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.CheckBox chkPrint;
        private System.Windows.Forms.CheckBox chkDelete;
        private System.Windows.Forms.CheckBox chkUpdate;
        private System.Windows.Forms.CheckBox chkInsert;
        private System.Windows.Forms.CheckBox chkView;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.RadioButton rbtMainProPos;
        private System.Windows.Forms.RadioButton rbtMainSale;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPermissionInventory;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSavetabData;
        private System.Windows.Forms.TreeView treeGroupProduct;
    }
}