namespace SaleMTInterfaces.FrmSystem
{
    partial class frmChangePass
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
            this.lblMKcu = new System.Windows.Forms.Label();
            this.lblMKmoi = new System.Windows.Forms.Label();
            this.lblXacNhanMK = new System.Windows.Forms.Label();
            this.txtMKcu = new System.Windows.Forms.TextBox();
            this.txtMKmoi = new System.Windows.Forms.TextBox();
            this.txtXNMK = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblMKcu
            // 
            this.lblMKcu.AutoSize = true;
            this.lblMKcu.Location = new System.Drawing.Point(13, 23);
            this.lblMKcu.Name = "lblMKcu";
            this.lblMKcu.Size = new System.Drawing.Size(67, 13);
            this.lblMKcu.TabIndex = 0;
            this.lblMKcu.Text = "Mật khẩu cũ";
            // 
            // lblMKmoi
            // 
            this.lblMKmoi.AutoSize = true;
            this.lblMKmoi.Location = new System.Drawing.Point(13, 52);
            this.lblMKmoi.Name = "lblMKmoi";
            this.lblMKmoi.Size = new System.Drawing.Size(71, 13);
            this.lblMKmoi.TabIndex = 1;
            this.lblMKmoi.Text = "Mật khẩu mới";
            // 
            // lblXacNhanMK
            // 
            this.lblXacNhanMK.AutoSize = true;
            this.lblXacNhanMK.Location = new System.Drawing.Point(13, 80);
            this.lblXacNhanMK.Name = "lblXacNhanMK";
            this.lblXacNhanMK.Size = new System.Drawing.Size(100, 13);
            this.lblXacNhanMK.TabIndex = 2;
            this.lblXacNhanMK.Text = "Xác nhận mật khẩu";
            // 
            // txtMKcu
            // 
            this.txtMKcu.Location = new System.Drawing.Point(158, 19);
            this.txtMKcu.Name = "txtMKcu";
            this.txtMKcu.Size = new System.Drawing.Size(204, 20);
            this.txtMKcu.TabIndex = 3;
            // 
            // txtMKmoi
            // 
            this.txtMKmoi.Location = new System.Drawing.Point(158, 49);
            this.txtMKmoi.Name = "txtMKmoi";
            this.txtMKmoi.Size = new System.Drawing.Size(204, 20);
            this.txtMKmoi.TabIndex = 4;
            // 
            // txtXNMK
            // 
            this.txtXNMK.Location = new System.Drawing.Point(158, 77);
            this.txtXNMK.Name = "txtXNMK";
            this.txtXNMK.Size = new System.Drawing.Size(204, 20);
            this.txtXNMK.TabIndex = 5;
            // 
            // frmThayDoiMK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 155);
            this.Controls.Add(this.txtXNMK);
            this.Controls.Add(this.txtMKmoi);
            this.Controls.Add(this.txtMKcu);
            this.Controls.Add(this.lblXacNhanMK);
            this.Controls.Add(this.lblMKmoi);
            this.Controls.Add(this.lblMKcu);
            this.Name = "frmThayDoiMK";
            this.Text = "Thay đổi mật khẩu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMKcu;
        private System.Windows.Forms.Label lblMKmoi;
        private System.Windows.Forms.Label lblXacNhanMK;
        private System.Windows.Forms.TextBox txtMKcu;
        private System.Windows.Forms.TextBox txtMKmoi;
        private System.Windows.Forms.TextBox txtXNMK;
    }
}