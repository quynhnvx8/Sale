namespace SaleMTInterfaces.FrmSystem
{
    partial class frmRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegister));
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.lblNVHienthi = new System.Windows.Forms.Label();
            this.cmdGiupdo = new System.Windows.Forms.Button();
            this.cmdThoat = new System.Windows.Forms.Button();
            this.cmdChapnhan = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.lblgiaima = new System.Windows.Forms.Label();
            this.txtMamay = new System.Windows.Forms.TextBox();
            this.lblmadangky = new System.Windows.Forms.Label();
            this.txtReg = new System.Windows.Forms.TextBox();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox2
            // 
            this.GroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox2.Controls.Add(this.lblNVHienthi);
            this.GroupBox2.Controls.Add(this.cmdGiupdo);
            this.GroupBox2.Controls.Add(this.cmdThoat);
            this.GroupBox2.Controls.Add(this.cmdChapnhan);
            this.GroupBox2.Controls.Add(this.GroupBox1);
            this.GroupBox2.Location = new System.Drawing.Point(1, 1);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(352, 168);
            this.GroupBox2.TabIndex = 31;
            this.GroupBox2.TabStop = false;
            // 
            // lblNVHienthi
            // 
            this.lblNVHienthi.BackColor = System.Drawing.Color.White;
            this.lblNVHienthi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNVHienthi.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNVHienthi.ForeColor = System.Drawing.Color.Black;
            this.lblNVHienthi.Image = ((System.Drawing.Image)(resources.GetObject("lblNVHienthi.Image")));
            this.lblNVHienthi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNVHienthi.Location = new System.Drawing.Point(-1, 0);
            this.lblNVHienthi.Name = "lblNVHienthi";
            this.lblNVHienthi.Size = new System.Drawing.Size(354, 24);
            this.lblNVHienthi.TabIndex = 32;
            this.lblNVHienthi.Text = "ÐĂNG KÝ SỬ DỤNG";
            this.lblNVHienthi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmdGiupdo
            // 
            this.cmdGiupdo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdGiupdo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdGiupdo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGiupdo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdGiupdo.Location = new System.Drawing.Point(129, 129);
            this.cmdGiupdo.Name = "cmdGiupdo";
            this.cmdGiupdo.Size = new System.Drawing.Size(86, 26);
            this.cmdGiupdo.TabIndex = 31;
            this.cmdGiupdo.Text = "      &Giúp đỡ";
            // 
            // cmdThoat
            // 
            this.cmdThoat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdThoat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdThoat.Image = ((System.Drawing.Image)(resources.GetObject("cmdThoat.Image")));
            this.cmdThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cmdThoat.Location = new System.Drawing.Point(258, 129);
            this.cmdThoat.Name = "cmdThoat";
            this.cmdThoat.Size = new System.Drawing.Size(86, 27);
            this.cmdThoat.TabIndex = 30;
            this.cmdThoat.Text = " Th&oát";
            this.cmdThoat.Click += new System.EventHandler(this.cmdThoat_Click);
            // 
            // cmdChapnhan
            // 
            this.cmdChapnhan.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdChapnhan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmdChapnhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdChapnhan.Image = ((System.Drawing.Image)(resources.GetObject("cmdChapnhan.Image")));
            this.cmdChapnhan.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.cmdChapnhan.Location = new System.Drawing.Point(9, 129);
            this.cmdChapnhan.Name = "cmdChapnhan";
            this.cmdChapnhan.Size = new System.Drawing.Size(86, 27);
            this.cmdChapnhan.TabIndex = 29;
            this.cmdChapnhan.Text = "&Chấp nhận";
            this.cmdChapnhan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdChapnhan.Click += new System.EventHandler(this.cmdChapnhan_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtReg);
            this.GroupBox1.Controls.Add(this.lblgiaima);
            this.GroupBox1.Controls.Add(this.txtMamay);
            this.GroupBox1.Controls.Add(this.lblmadangky);
            this.GroupBox1.Location = new System.Drawing.Point(3, 24);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(345, 90);
            this.GroupBox1.TabIndex = 28;
            this.GroupBox1.TabStop = false;
            // 
            // lblgiaima
            // 
            this.lblgiaima.Location = new System.Drawing.Point(6, 50);
            this.lblgiaima.Name = "lblgiaima";
            this.lblgiaima.Size = new System.Drawing.Size(63, 30);
            this.lblgiaima.TabIndex = 3;
            this.lblgiaima.Text = "Mã ĐK";
            this.lblgiaima.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMamay
            // 
            this.txtMamay.BackColor = System.Drawing.Color.White;
            this.txtMamay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMamay.ForeColor = System.Drawing.Color.Red;
            this.txtMamay.Location = new System.Drawing.Point(72, 21);
            this.txtMamay.Name = "txtMamay";
            this.txtMamay.ReadOnly = true;
            this.txtMamay.Size = new System.Drawing.Size(265, 20);
            this.txtMamay.TabIndex = 1;
            // 
            // lblmadangky
            // 
            this.lblmadangky.Location = new System.Drawing.Point(5, 24);
            this.lblmadangky.Name = "lblmadangky";
            this.lblmadangky.Size = new System.Drawing.Size(66, 16);
            this.lblmadangky.TabIndex = 0;
            this.lblmadangky.Text = "Mã của bạn";
            // 
            // txtReg
            // 
            this.txtReg.BackColor = System.Drawing.Color.White;
            this.txtReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReg.ForeColor = System.Drawing.Color.Red;
            this.txtReg.Location = new System.Drawing.Point(72, 47);
            this.txtReg.Multiline = true;
            this.txtReg.Name = "txtReg";
            this.txtReg.Size = new System.Drawing.Size(265, 37);
            this.txtReg.TabIndex = 4;
            // 
            // frmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 167);
            this.Controls.Add(this.GroupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRegister";
            this.Load += new System.EventHandler(this.frmRegister_Load);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.Label lblNVHienthi;
        internal System.Windows.Forms.Button cmdGiupdo;
        internal System.Windows.Forms.Button cmdThoat;
        internal System.Windows.Forms.Button cmdChapnhan;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label lblgiaima;
        internal System.Windows.Forms.TextBox txtMamay;
        internal System.Windows.Forms.Label lblmadangky;
        internal System.Windows.Forms.TextBox txtReg;
    }
}