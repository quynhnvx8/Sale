namespace SaleAD
{
    partial class SaleAD
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
            this.mnuPos = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOptionDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGroupUser = new System.Windows.Forms.ToolStripMenuItem();
            this.dữLiệuHeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dữLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLýSảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đơnGiáToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPos.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuPos
            // 
            this.mnuPos.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.mnuPos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.dữLiệuHeToolStripMenuItem,
            this.quảnLýSảnPhẩmToolStripMenuItem});
            this.mnuPos.Location = new System.Drawing.Point(0, 0);
            this.mnuPos.Name = "mnuPos";
            this.mnuPos.Size = new System.Drawing.Size(1039, 25);
            this.mnuPos.TabIndex = 0;
            this.mnuPos.Text = "menuStrip1";
            this.mnuPos.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOptionDatabase,
            this.mnuGroupUser});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(74, 21);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // mnuOptionDatabase
            // 
            this.mnuOptionDatabase.Name = "mnuOptionDatabase";
            this.mnuOptionDatabase.Size = new System.Drawing.Size(236, 22);
            this.mnuOptionDatabase.Text = "Cấu hình cơ sở dữ liệu";
            this.mnuOptionDatabase.Click += new System.EventHandler(this.cấuHìnhCơSởDữLiệuToolStripMenuItem_Click);
            // 
            // mnuGroupUser
            // 
            this.mnuGroupUser.Name = "mnuGroupUser";
            this.mnuGroupUser.Size = new System.Drawing.Size(236, 22);
            this.mnuGroupUser.Text = "Quản trị nhóm & người dùng";
            // 
            // dữLiệuHeToolStripMenuItem
            // 
            this.dữLiệuHeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dữLiệuToolStripMenuItem});
            this.dữLiệuHeToolStripMenuItem.Name = "dữLiệuHeToolStripMenuItem";
            this.dữLiệuHeToolStripMenuItem.Size = new System.Drawing.Size(117, 21);
            this.dữLiệuHeToolStripMenuItem.Text = "Dữ liệu hệ thống";
            this.dữLiệuHeToolStripMenuItem.Click += new System.EventHandler(this.dữLiệuHeToolStripMenuItem_Click);
            // 
            // dữLiệuToolStripMenuItem
            // 
            this.dữLiệuToolStripMenuItem.Name = "dữLiệuToolStripMenuItem";
            this.dữLiệuToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.dữLiệuToolStripMenuItem.Text = "Dữ liệu";
            this.dữLiệuToolStripMenuItem.Click += new System.EventHandler(this.dữLiệuToolStripMenuItem_Click);
            // 
            // quảnLýSảnPhẩmToolStripMenuItem
            // 
            this.quảnLýSảnPhẩmToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sảnPhẩmToolStripMenuItem,
            this.đơnGiáToolStripMenuItem});
            this.quảnLýSảnPhẩmToolStripMenuItem.Name = "quảnLýSảnPhẩmToolStripMenuItem";
            this.quảnLýSảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(125, 21);
            this.quảnLýSảnPhẩmToolStripMenuItem.Text = "Quản lý sản phẩm";
            // 
            // sảnPhẩmToolStripMenuItem
            // 
            this.sảnPhẩmToolStripMenuItem.Name = "sảnPhẩmToolStripMenuItem";
            this.sảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sảnPhẩmToolStripMenuItem.Text = "Sản phẩm";
            this.sảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.sảnPhẩmToolStripMenuItem_Click);
            // 
            // đơnGiáToolStripMenuItem
            // 
            this.đơnGiáToolStripMenuItem.Name = "đơnGiáToolStripMenuItem";
            this.đơnGiáToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.đơnGiáToolStripMenuItem.Text = "Đơn giá";
            this.đơnGiáToolStripMenuItem.Click += new System.EventHandler(this.đơnGiáToolStripMenuItem_Click);
            // 
            // SaleAD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 322);
            this.Controls.Add(this.mnuPos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.MainMenuStrip = this.mnuPos;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SaleAD";
            this.Text = "Chương trình quản lý ProPos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mnuPos.ResumeLayout(false);
            this.mnuPos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuPos;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuOptionDatabase;
        private System.Windows.Forms.ToolStripMenuItem mnuGroupUser;
        private System.Windows.Forms.ToolStripMenuItem dữLiệuHeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dữLiệuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLýSảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đơnGiáToolStripMenuItem;
    }
}

