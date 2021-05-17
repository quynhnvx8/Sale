namespace SaleMTInterfaces.FrmReporter.FrmReportSale
{
    partial class frmProductReportSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductReportSearch));
            this.label1 = new System.Windows.Forms.Label();
            this.cboReasion = new System.Windows.Forms.ComboBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabReasion = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treProductGroups = new System.Windows.Forms.TreeView();
            this.imgUpDown = new System.Windows.Forms.ImageList(this.components);
            this.tabCol = new System.Windows.Forms.TabPage();
            this.chkChooseAll = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabReasion.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabCol.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Điều kiện";
            // 
            // cboReasion
            // 
            this.cboReasion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReasion.FormattingEnabled = true;
            this.cboReasion.Location = new System.Drawing.Point(82, 13);
            this.cboReasion.Name = "cboReasion";
            this.cboReasion.Size = new System.Drawing.Size(707, 24);
            this.cboReasion.TabIndex = 1;
            this.cboReasion.SelectedIndexChanged += new System.EventHandler(this.cboReasion_SelectedIndexChanged);
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(795, 12);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(44, 25);
            this.btnChoose.TabIndex = 2;
            this.btnChoose.Text = "...";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabReasion);
            this.tabControl1.Controls.Add(this.tabCol);
            this.tabControl1.Location = new System.Drawing.Point(10, 45);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(829, 445);
            this.tabControl1.TabIndex = 3;
            // 
            // tabReasion
            // 
            this.tabReasion.Controls.Add(this.groupBox2);
            this.tabReasion.Controls.Add(this.groupBox1);
            this.tabReasion.Location = new System.Drawing.Point(4, 25);
            this.tabReasion.Name = "tabReasion";
            this.tabReasion.Padding = new System.Windows.Forms.Padding(3);
            this.tabReasion.Size = new System.Drawing.Size(821, 416);
            this.tabReasion.TabIndex = 0;
            this.tabReasion.Text = "Điều kiện";
            this.tabReasion.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(403, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(412, 405);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thuộc tính";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treProductGroups);
            this.groupBox1.Location = new System.Drawing.Point(7, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 406);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhóm sản phẩm";
            // 
            // treProductGroups
            // 
            this.treProductGroups.CheckBoxes = true;
            this.treProductGroups.ImageIndex = 0;
            this.treProductGroups.ImageList = this.imgUpDown;
            this.treProductGroups.Location = new System.Drawing.Point(7, 22);
            this.treProductGroups.Name = "treProductGroups";
            this.treProductGroups.SelectedImageIndex = 0;
            this.treProductGroups.Size = new System.Drawing.Size(377, 378);
            this.treProductGroups.TabIndex = 0;
            this.treProductGroups.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treProductGroups_AfterCheck);
            // 
            // imgUpDown
            // 
            this.imgUpDown.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgUpDown.ImageStream")));
            this.imgUpDown.TransparentColor = System.Drawing.Color.Transparent;
            this.imgUpDown.Images.SetKeyName(0, "tree.bmp");
            // 
            // tabCol
            // 
            this.tabCol.Controls.Add(this.chkChooseAll);
            this.tabCol.Controls.Add(this.groupBox3);
            this.tabCol.Location = new System.Drawing.Point(4, 25);
            this.tabCol.Name = "tabCol";
            this.tabCol.Padding = new System.Windows.Forms.Padding(3);
            this.tabCol.Size = new System.Drawing.Size(821, 416);
            this.tabCol.TabIndex = 1;
            this.tabCol.Text = "Cột";
            this.tabCol.UseVisualStyleBackColor = true;
            // 
            // chkChooseAll
            // 
            this.chkChooseAll.AutoSize = true;
            this.chkChooseAll.Location = new System.Drawing.Point(13, 386);
            this.chkChooseAll.Name = "chkChooseAll";
            this.chkChooseAll.Size = new System.Drawing.Size(93, 20);
            this.chkChooseAll.TabIndex = 8;
            this.chkChooseAll.Text = "Chọn tất cả";
            this.chkChooseAll.UseVisualStyleBackColor = true;
            this.chkChooseAll.CheckedChanged += new System.EventHandler(this.chkChooseAll_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(7, 7);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(808, 368);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Danh sách cột";
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(749, 496);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 25);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(654, 496);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 25);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Lưu ĐK";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Image = ((System.Drawing.Image)(resources.GetObject("btnInsert.Image")));
            this.btnInsert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInsert.Location = new System.Drawing.Point(561, 496);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(87, 25);
            this.btnInsert.TabIndex = 6;
            this.btnInsert.Text = "Thêm ĐK";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(454, 496);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(101, 25);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "Chấp nhận";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmProductReportSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 541);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.cboReasion);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmProductReportSearch";
            this.Text = "Điều kiện tìm kiếm";
            this.Load += new System.EventHandler(this.frmProductReportSearch_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabReasion.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabCol.ResumeLayout(false);
            this.tabCol.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboReasion;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabReasion;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage tabCol;
        public System.Windows.Forms.TreeView treProductGroups;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ImageList imgUpDown;
        private System.Windows.Forms.CheckBox chkChooseAll;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}