namespace SaleMTInterfaces.FrmReporter.FrmReportSale
{
    partial class frmDeleteResion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeleteResion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvwResion = new System.Windows.Forms.ListView();
            this.Resion = new System.Windows.Forms.ColumnHeader();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.lvwResion);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(413, 279);
            this.panel1.TabIndex = 0;
            // 
            // lvwResion
            // 
            this.lvwResion.CheckBoxes = true;
            this.lvwResion.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Resion});
            this.lvwResion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lvwResion.FullRowSelect = true;
            this.lvwResion.GridLines = true;
            this.lvwResion.Location = new System.Drawing.Point(23, 26);
            this.lvwResion.Name = "lvwResion";
            this.lvwResion.Size = new System.Drawing.Size(364, 206);
            this.lvwResion.TabIndex = 0;
            this.lvwResion.UseCompatibleStateImageBehavior = false;
            this.lvwResion.View = System.Windows.Forms.View.Details;
            this.lvwResion.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwResion_ItemChecked);
            this.lvwResion.SelectedIndexChanged += new System.EventHandler(this.lvwResion_SelectedIndexChanged);
            this.lvwResion.DoubleClick += new System.EventHandler(this.lvwResion_DoubleClick);
            this.lvwResion.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvwResion_ItemCheck);
            // 
            // Resion
            // 
            this.Resion.Text = "Điều kiện";
            this.Resion.Width = 300;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(299, 239);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(87, 25);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Đóng";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(214, 238);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(79, 25);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmDeleteResion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 280);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmDeleteResion";
            this.Text = "Điều kiện";
            this.Load += new System.EventHandler(this.frmDeleteResion_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvwResion;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ColumnHeader Resion;
    }
}