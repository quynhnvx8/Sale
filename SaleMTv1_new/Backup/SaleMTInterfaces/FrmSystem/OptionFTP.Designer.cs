namespace SaleMTInterfaces.FrmSystem
{
    partial class OptionFTP
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtImExServer = new System.Windows.Forms.RadioButton();
            this.rbtExImServerOther = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHostIm = new System.Windows.Forms.TextBox();
            this.chkSSL = new System.Windows.Forms.CheckBox();
            this.btnCheckCoIm = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserNameIm = new System.Windows.Forms.TextBox();
            this.txtPassIm = new System.Windows.Forms.TextBox();
            this.txtPortIm = new System.Windows.Forms.TextBox();
            this.txtPortEx = new System.Windows.Forms.TextBox();
            this.txtPassEx = new System.Windows.Forms.TextBox();
            this.txtUserNamEx = new System.Windows.Forms.TextBox();
            this.txtHostEx = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkSSLEx = new System.Windows.Forms.CheckBox();
            this.btnCheckCoEx = new System.Windows.Forms.Button();
            this.lblFTP = new System.Windows.Forms.Label();
            this.txtLocalEx = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLocalIm = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cboFTPIm = new System.Windows.Forms.ComboBox();
            this.cboFTPEx = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFTP);
            this.groupBox1.Controls.Add(this.btnCheckCoEx);
            this.groupBox1.Controls.Add(this.chkSSLEx);
            this.groupBox1.Controls.Add(this.txtPortEx);
            this.groupBox1.Controls.Add(this.txtPassEx);
            this.groupBox1.Controls.Add(this.txtUserNamEx);
            this.groupBox1.Controls.Add(this.txtHostEx);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtPortIm);
            this.groupBox1.Controls.Add(this.txtPassIm);
            this.groupBox1.Controls.Add(this.txtUserNameIm);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnCheckCoIm);
            this.groupBox1.Controls.Add(this.chkSSL);
            this.groupBox1.Controls.Add(this.txtHostIm);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.rbtExImServerOther);
            this.groupBox1.Controls.Add(this.rbtImExServer);
            this.groupBox1.Location = new System.Drawing.Point(13, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(787, 175);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông số kết nối đến server FTP ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboFTPEx);
            this.groupBox2.Controls.Add(this.cboFTPIm);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtLocalEx);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtLocalIm);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(13, 189);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(787, 151);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thư mục thực thi";
            // 
            // rbtImExServer
            // 
            this.rbtImExServer.AutoSize = true;
            this.rbtImExServer.Checked = true;
            this.rbtImExServer.Location = new System.Drawing.Point(9, 24);
            this.rbtImExServer.Name = "rbtImExServer";
            this.rbtImExServer.Size = new System.Drawing.Size(197, 20);
            this.rbtImExServer.TabIndex = 0;
            this.rbtImExServer.TabStop = true;
            this.rbtImExServer.Text = "Export và Import cùng Server";
            this.rbtImExServer.UseVisualStyleBackColor = true;
            // 
            // rbtExImServerOther
            // 
            this.rbtExImServerOther.AutoSize = true;
            this.rbtExImServerOther.Location = new System.Drawing.Point(300, 24);
            this.rbtExImServerOther.Name = "rbtExImServerOther";
            this.rbtExImServerOther.Size = new System.Drawing.Size(200, 20);
            this.rbtExImServerOther.TabIndex = 1;
            this.rbtExImServerOther.Text = "Export và Import khác Server ";
            this.rbtExImServerOther.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Import";
            // 
            // txtHostIm
            // 
            this.txtHostIm.Location = new System.Drawing.Point(90, 75);
            this.txtHostIm.Name = "txtHostIm";
            this.txtHostIm.Size = new System.Drawing.Size(178, 22);
            this.txtHostIm.TabIndex = 3;
            // 
            // chkSSL
            // 
            this.chkSSL.AutoSize = true;
            this.chkSSL.Location = new System.Drawing.Point(600, 79);
            this.chkSSL.Name = "chkSSL";
            this.chkSSL.Size = new System.Drawing.Size(52, 20);
            this.chkSSL.TabIndex = 4;
            this.chkSSL.Text = "SSL";
            this.chkSSL.UseVisualStyleBackColor = true;
            // 
            // btnCheckCoIm
            // 
            this.btnCheckCoIm.Location = new System.Drawing.Point(658, 75);
            this.btnCheckCoIm.Name = "btnCheckCoIm";
            this.btnCheckCoIm.Size = new System.Drawing.Size(116, 25);
            this.btnCheckCoIm.TabIndex = 5;
            this.btnCheckCoIm.Text = "Kiểm tra kết nối";
            this.btnCheckCoIm.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Host";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(283, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "UserName";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(410, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(537, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Port";
            // 
            // txtUserNameIm
            // 
            this.txtUserNameIm.Location = new System.Drawing.Point(286, 76);
            this.txtUserNameIm.Name = "txtUserNameIm";
            this.txtUserNameIm.Size = new System.Drawing.Size(107, 22);
            this.txtUserNameIm.TabIndex = 4;
            // 
            // txtPassIm
            // 
            this.txtPassIm.Location = new System.Drawing.Point(413, 75);
            this.txtPassIm.Name = "txtPassIm";
            this.txtPassIm.Size = new System.Drawing.Size(108, 22);
            this.txtPassIm.TabIndex = 5;
            // 
            // txtPortIm
            // 
            this.txtPortIm.Location = new System.Drawing.Point(540, 76);
            this.txtPortIm.Name = "txtPortIm";
            this.txtPortIm.Size = new System.Drawing.Size(47, 22);
            this.txtPortIm.TabIndex = 12;
            // 
            // txtPortEx
            // 
            this.txtPortEx.Location = new System.Drawing.Point(540, 109);
            this.txtPortEx.Name = "txtPortEx";
            this.txtPortEx.Size = new System.Drawing.Size(47, 22);
            this.txtPortEx.TabIndex = 17;
            // 
            // txtPassEx
            // 
            this.txtPassEx.Location = new System.Drawing.Point(413, 108);
            this.txtPassEx.Name = "txtPassEx";
            this.txtPassEx.Size = new System.Drawing.Size(108, 22);
            this.txtPassEx.TabIndex = 16;
            // 
            // txtUserNamEx
            // 
            this.txtUserNamEx.Location = new System.Drawing.Point(286, 109);
            this.txtUserNamEx.Name = "txtUserNamEx";
            this.txtUserNamEx.Size = new System.Drawing.Size(107, 22);
            this.txtUserNamEx.TabIndex = 15;
            // 
            // txtHostEx
            // 
            this.txtHostEx.Location = new System.Drawing.Point(90, 107);
            this.txtHostEx.Name = "txtHostEx";
            this.txtHostEx.Size = new System.Drawing.Size(178, 22);
            this.txtHostEx.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Export";
            // 
            // chkSSLEx
            // 
            this.chkSSLEx.AutoSize = true;
            this.chkSSLEx.Location = new System.Drawing.Point(600, 109);
            this.chkSSLEx.Name = "chkSSLEx";
            this.chkSSLEx.Size = new System.Drawing.Size(52, 20);
            this.chkSSLEx.TabIndex = 18;
            this.chkSSLEx.Text = "SSL";
            this.chkSSLEx.UseVisualStyleBackColor = true;
            this.chkSSLEx.CheckedChanged += new System.EventHandler(this.chkSSLEx_CheckedChanged);
            // 
            // btnCheckCoEx
            // 
            this.btnCheckCoEx.Location = new System.Drawing.Point(658, 104);
            this.btnCheckCoEx.Name = "btnCheckCoEx";
            this.btnCheckCoEx.Size = new System.Drawing.Size(116, 25);
            this.btnCheckCoEx.TabIndex = 19;
            this.btnCheckCoEx.Text = "Kiểm tra kết nối";
            this.btnCheckCoEx.UseVisualStyleBackColor = true;
            // 
            // lblFTP
            // 
            this.lblFTP.AutoSize = true;
            this.lblFTP.Location = new System.Drawing.Point(90, 137);
            this.lblFTP.Name = "lblFTP";
            this.lblFTP.Size = new System.Drawing.Size(134, 16);
            this.lblFTP.TabIndex = 20;
            this.lblFTP.Text = "(Ex: ftp://192.168.1.89)";
            // 
            // txtLocalEx
            // 
            this.txtLocalEx.Location = new System.Drawing.Point(284, 86);
            this.txtLocalEx.Name = "txtLocalEx";
            this.txtLocalEx.Size = new System.Drawing.Size(352, 22);
            this.txtLocalEx.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 85);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 16);
            this.label8.TabIndex = 26;
            this.label8.Text = "Export";
            // 
            // txtLocalIm
            // 
            this.txtLocalIm.Location = new System.Drawing.Point(284, 51);
            this.txtLocalIm.Name = "txtLocalIm";
            this.txtLocalIm.Size = new System.Drawing.Size(352, 22);
            this.txtLocalIm.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(281, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 16);
            this.label9.TabIndex = 24;
            this.label9.Text = "Local";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(90, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 16);
            this.label10.TabIndex = 23;
            this.label10.Text = "FTP";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 16);
            this.label11.TabIndex = 21;
            this.label11.Text = "Import";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(569, 346);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 25);
            this.button3.TabIndex = 21;
            this.button3.Text = "Load lại thiết lập";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(694, 346);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 25);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(755, 16);
            this.label12.TabIndex = 29;
            this.label12.Text = "Note: Thư mục FTP của Import phải khác thư mục FTP của Export & thư mục Local của" +
                " Import phải khác thư mục Local của Export";
            // 
            // cboFTPIm
            // 
            this.cboFTPIm.FormattingEnabled = true;
            this.cboFTPIm.Location = new System.Drawing.Point(90, 49);
            this.cboFTPIm.Name = "cboFTPIm";
            this.cboFTPIm.Size = new System.Drawing.Size(178, 24);
            this.cboFTPIm.TabIndex = 30;
            // 
            // cboFTPEx
            // 
            this.cboFTPEx.FormattingEnabled = true;
            this.cboFTPEx.Location = new System.Drawing.Point(90, 85);
            this.cboFTPEx.Name = "cboFTPEx";
            this.cboFTPEx.Size = new System.Drawing.Size(178, 24);
            this.cboFTPEx.TabIndex = 31;
            // 
            // OptionFTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 382);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "OptionFTP";
            this.Text = "FTP Monitor";
            this.Load += new System.EventHandler(this.OptionFTP_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCheckCoIm;
        private System.Windows.Forms.CheckBox chkSSL;
        private System.Windows.Forms.TextBox txtHostIm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtExImServerOther;
        private System.Windows.Forms.RadioButton rbtImExServer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblFTP;
        private System.Windows.Forms.Button btnCheckCoEx;
        private System.Windows.Forms.CheckBox chkSSLEx;
        private System.Windows.Forms.TextBox txtPortEx;
        private System.Windows.Forms.TextBox txtPassEx;
        private System.Windows.Forms.TextBox txtUserNamEx;
        private System.Windows.Forms.TextBox txtHostEx;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPortIm;
        private System.Windows.Forms.TextBox txtPassIm;
        private System.Windows.Forms.TextBox txtUserNameIm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLocalEx;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtLocalIm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboFTPEx;
        private System.Windows.Forms.ComboBox cboFTPIm;
    }
}