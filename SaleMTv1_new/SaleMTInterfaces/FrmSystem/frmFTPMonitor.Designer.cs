namespace SaleMTInterfaces.FrmSystem
{
    partial class frmFTPMonitor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFTPMonitor));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.grbParameter = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnExCheckConn = new System.Windows.Forms.Button();
            this.ckbExSSL = new System.Windows.Forms.CheckBox();
            this.txtExPort = new System.Windows.Forms.TextBox();
            this.txtExPw = new System.Windows.Forms.TextBox();
            this.txtExUser = new System.Windows.Forms.TextBox();
            this.txtExHost = new System.Windows.Forms.TextBox();
            this.btnImpCheckConn = new System.Windows.Forms.Button();
            this.ckbImpSSL = new System.Windows.Forms.CheckBox();
            this.txtImpPort = new System.Windows.Forms.TextBox();
            this.txtImpPw = new System.Windows.Forms.TextBox();
            this.txtImpUser = new System.Windows.Forms.TextBox();
            this.txtImpHost = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdDif = new System.Windows.Forms.RadioButton();
            this.rdSame = new System.Windows.Forms.RadioButton();
            this.grbDir = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtExLocal = new System.Windows.Forms.TextBox();
            this.cbExFTP = new System.Windows.Forms.ComboBox();
            this.txtImpLocal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbImpFTP = new System.Windows.Forms.ComboBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.fbdImp = new System.Windows.Forms.FolderBrowserDialog();
            this.fdbEx = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1.SuspendLayout();
            this.grbParameter.SuspendLayout();
            this.grbDir.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 378);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(819, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // grbParameter
            // 
            this.grbParameter.Controls.Add(this.label7);
            this.grbParameter.Controls.Add(this.label6);
            this.grbParameter.Controls.Add(this.label5);
            this.grbParameter.Controls.Add(this.label4);
            this.grbParameter.Controls.Add(this.label3);
            this.grbParameter.Controls.Add(this.btnExCheckConn);
            this.grbParameter.Controls.Add(this.ckbExSSL);
            this.grbParameter.Controls.Add(this.txtExPort);
            this.grbParameter.Controls.Add(this.txtExPw);
            this.grbParameter.Controls.Add(this.txtExUser);
            this.grbParameter.Controls.Add(this.txtExHost);
            this.grbParameter.Controls.Add(this.btnImpCheckConn);
            this.grbParameter.Controls.Add(this.ckbImpSSL);
            this.grbParameter.Controls.Add(this.txtImpPort);
            this.grbParameter.Controls.Add(this.txtImpPw);
            this.grbParameter.Controls.Add(this.txtImpUser);
            this.grbParameter.Controls.Add(this.txtImpHost);
            this.grbParameter.Controls.Add(this.label2);
            this.grbParameter.Controls.Add(this.label1);
            this.grbParameter.Controls.Add(this.rdDif);
            this.grbParameter.Controls.Add(this.rdSame);
            this.grbParameter.Location = new System.Drawing.Point(12, 12);
            this.grbParameter.Name = "grbParameter";
            this.grbParameter.Size = new System.Drawing.Size(795, 170);
            this.grbParameter.TabIndex = 1;
            this.grbParameter.TabStop = false;
            this.grbParameter.Text = "Thông số kết nối đến server FTP";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(82, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(173, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "(Ex: ftp://yourcompany.com)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(537, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Port";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(402, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(272, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "User name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Host";
            // 
            // btnExCheckConn
            // 
            this.btnExCheckConn.Enabled = false;
            this.btnExCheckConn.Location = new System.Drawing.Point(680, 107);
            this.btnExCheckConn.Name = "btnExCheckConn";
            this.btnExCheckConn.Size = new System.Drawing.Size(110, 26);
            this.btnExCheckConn.TabIndex = 15;
            this.btnExCheckConn.Text = "Kiểm tra kết nối";
            this.btnExCheckConn.UseVisualStyleBackColor = true;
            this.btnExCheckConn.Click += new System.EventHandler(this.btnExCheckConn_Click);
            // 
            // ckbExSSL
            // 
            this.ckbExSSL.AutoSize = true;
            this.ckbExSSL.Enabled = false;
            this.ckbExSSL.Location = new System.Drawing.Point(600, 111);
            this.ckbExSSL.Name = "ckbExSSL";
            this.ckbExSSL.Size = new System.Drawing.Size(52, 20);
            this.ckbExSSL.TabIndex = 14;
            this.ckbExSSL.Text = "SSL";
            this.ckbExSSL.UseVisualStyleBackColor = true;
            // 
            // txtExPort
            // 
            this.txtExPort.Location = new System.Drawing.Point(540, 111);
            this.txtExPort.Name = "txtExPort";
            this.txtExPort.ReadOnly = true;
            this.txtExPort.Size = new System.Drawing.Size(45, 22);
            this.txtExPort.TabIndex = 13;
            // 
            // txtExPw
            // 
            this.txtExPw.Location = new System.Drawing.Point(405, 111);
            this.txtExPw.Name = "txtExPw";
            this.txtExPw.ReadOnly = true;
            this.txtExPw.Size = new System.Drawing.Size(115, 22);
            this.txtExPw.TabIndex = 12;
            this.txtExPw.UseSystemPasswordChar = true;
            // 
            // txtExUser
            // 
            this.txtExUser.Location = new System.Drawing.Point(275, 111);
            this.txtExUser.Name = "txtExUser";
            this.txtExUser.ReadOnly = true;
            this.txtExUser.Size = new System.Drawing.Size(115, 22);
            this.txtExUser.TabIndex = 11;
            // 
            // txtExHost
            // 
            this.txtExHost.Location = new System.Drawing.Point(85, 111);
            this.txtExHost.Name = "txtExHost";
            this.txtExHost.ReadOnly = true;
            this.txtExHost.Size = new System.Drawing.Size(170, 22);
            this.txtExHost.TabIndex = 10;
            // 
            // btnImpCheckConn
            // 
            this.btnImpCheckConn.Location = new System.Drawing.Point(680, 68);
            this.btnImpCheckConn.Name = "btnImpCheckConn";
            this.btnImpCheckConn.Size = new System.Drawing.Size(110, 26);
            this.btnImpCheckConn.TabIndex = 9;
            this.btnImpCheckConn.Text = "Kiểm tra kết nối";
            this.btnImpCheckConn.UseVisualStyleBackColor = true;
            this.btnImpCheckConn.Click += new System.EventHandler(this.btnImpCheckConn_Click);
            // 
            // ckbImpSSL
            // 
            this.ckbImpSSL.AutoSize = true;
            this.ckbImpSSL.Location = new System.Drawing.Point(600, 72);
            this.ckbImpSSL.Name = "ckbImpSSL";
            this.ckbImpSSL.Size = new System.Drawing.Size(52, 20);
            this.ckbImpSSL.TabIndex = 8;
            this.ckbImpSSL.Text = "SSL";
            this.ckbImpSSL.UseVisualStyleBackColor = true;
            // 
            // txtImpPort
            // 
            this.txtImpPort.Location = new System.Drawing.Point(540, 72);
            this.txtImpPort.Name = "txtImpPort";
            this.txtImpPort.Size = new System.Drawing.Size(45, 22);
            this.txtImpPort.TabIndex = 7;
            this.txtImpPort.TextChanged += new System.EventHandler(this.txtImpPort_TextChanged);
            // 
            // txtImpPw
            // 
            this.txtImpPw.Location = new System.Drawing.Point(405, 72);
            this.txtImpPw.Name = "txtImpPw";
            this.txtImpPw.Size = new System.Drawing.Size(115, 22);
            this.txtImpPw.TabIndex = 6;
            this.txtImpPw.UseSystemPasswordChar = true;
            this.txtImpPw.TextChanged += new System.EventHandler(this.txtImpPw_TextChanged);
            // 
            // txtImpUser
            // 
            this.txtImpUser.Location = new System.Drawing.Point(275, 72);
            this.txtImpUser.Name = "txtImpUser";
            this.txtImpUser.Size = new System.Drawing.Size(115, 22);
            this.txtImpUser.TabIndex = 5;
            this.txtImpUser.TextChanged += new System.EventHandler(this.txtImpUser_TextChanged);
            // 
            // txtImpHost
            // 
            this.txtImpHost.Location = new System.Drawing.Point(85, 72);
            this.txtImpHost.Name = "txtImpHost";
            this.txtImpHost.Size = new System.Drawing.Size(170, 22);
            this.txtImpHost.TabIndex = 4;
            this.txtImpHost.TextChanged += new System.EventHandler(this.txtImpHost_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Export";
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
            // rdDif
            // 
            this.rdDif.AutoSize = true;
            this.rdDif.Location = new System.Drawing.Point(270, 25);
            this.rdDif.Name = "rdDif";
            this.rdDif.Size = new System.Drawing.Size(195, 20);
            this.rdDif.TabIndex = 1;
            this.rdDif.Text = "Export và Import khác server";
            this.rdDif.UseVisualStyleBackColor = true;
            this.rdDif.CheckedChanged += new System.EventHandler(this.rdDif_CheckedChanged);
            // 
            // rdSame
            // 
            this.rdSame.AutoSize = true;
            this.rdSame.Checked = true;
            this.rdSame.Location = new System.Drawing.Point(9, 25);
            this.rdSame.Name = "rdSame";
            this.rdSame.Size = new System.Drawing.Size(195, 20);
            this.rdSame.TabIndex = 0;
            this.rdSame.TabStop = true;
            this.rdSame.Text = "Export và Import cùng server";
            this.rdSame.UseVisualStyleBackColor = true;
            this.rdSame.CheckedChanged += new System.EventHandler(this.rdSame_CheckedChanged);
            // 
            // grbDir
            // 
            this.grbDir.Controls.Add(this.label12);
            this.grbDir.Controls.Add(this.txtExLocal);
            this.grbDir.Controls.Add(this.cbExFTP);
            this.grbDir.Controls.Add(this.txtImpLocal);
            this.grbDir.Controls.Add(this.label10);
            this.grbDir.Controls.Add(this.label11);
            this.grbDir.Controls.Add(this.label9);
            this.grbDir.Controls.Add(this.label8);
            this.grbDir.Controls.Add(this.cbImpFTP);
            this.grbDir.Location = new System.Drawing.Point(12, 187);
            this.grbDir.Name = "grbDir";
            this.grbDir.Size = new System.Drawing.Size(795, 145);
            this.grbDir.TabIndex = 2;
            this.grbDir.TabStop = false;
            this.grbDir.Text = "Thư mục thực thi";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 112);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(782, 16);
            this.label12.TabIndex = 24;
            this.label12.Text = "Note: Thư mục FTP của Import phải khác Thư mục FTP của Export && Thư mục Local củ" +
                "a Import phải khác Thư mục Local của Export";
            // 
            // txtExLocal
            // 
            this.txtExLocal.Location = new System.Drawing.Point(274, 78);
            this.txtExLocal.Name = "txtExLocal";
            this.txtExLocal.Size = new System.Drawing.Size(310, 22);
            this.txtExLocal.TabIndex = 23;
            this.txtExLocal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtExLocal_MouseClick);
            this.txtExLocal.Enter += new System.EventHandler(this.txtExLocal_Enter);
            // 
            // cbExFTP
            // 
            this.cbExFTP.FormattingEnabled = true;
            this.cbExFTP.Location = new System.Drawing.Point(84, 78);
            this.cbExFTP.Name = "cbExFTP";
            this.cbExFTP.Size = new System.Drawing.Size(165, 24);
            this.cbExFTP.TabIndex = 22;
            this.cbExFTP.SelectedIndexChanged += new System.EventHandler(this.cbExFTP_SelectedIndexChanged);
            // 
            // txtImpLocal
            // 
            this.txtImpLocal.Location = new System.Drawing.Point(274, 39);
            this.txtImpLocal.Name = "txtImpLocal";
            this.txtImpLocal.Size = new System.Drawing.Size(310, 22);
            this.txtImpLocal.TabIndex = 21;
            this.txtImpLocal.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtImpLocal_MouseClick);
            this.txtImpLocal.Enter += new System.EventHandler(this.txtImpLocal_Enter);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 16);
            this.label10.TabIndex = 20;
            this.label10.Text = "Export";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 16);
            this.label11.TabIndex = 19;
            this.label11.Text = "Import";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(271, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "Local";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(81, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "FTP";
            // 
            // cbImpFTP
            // 
            this.cbImpFTP.FormattingEnabled = true;
            this.cbImpFTP.Location = new System.Drawing.Point(84, 39);
            this.cbImpFTP.Name = "cbImpFTP";
            this.cbImpFTP.Size = new System.Drawing.Size(165, 24);
            this.cbImpFTP.TabIndex = 0;
            this.cbImpFTP.SelectedIndexChanged += new System.EventHandler(this.cbImpFTP_SelectedIndexChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(560, 345);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(120, 26);
            this.btnLoad.TabIndex = 10;
            this.btnLoad.Text = "Load lại thiết lập";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(690, 345);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 26);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tslStatus
            // 
            this.tslStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tslStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.tslStatus.Name = "tslStatus";
            this.tslStatus.Size = new System.Drawing.Size(41, 19);
            this.tslStatus.Text = "          ";
            // 
            // frmFTPMonitor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(819, 402);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.grbDir);
            this.Controls.Add(this.grbParameter);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmFTPMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FTP Monitor";
            this.Load += new System.EventHandler(this.frmFTPMonitor_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grbParameter.ResumeLayout(false);
            this.grbParameter.PerformLayout();
            this.grbDir.ResumeLayout(false);
            this.grbDir.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox grbParameter;
        private System.Windows.Forms.RadioButton rdDif;
        private System.Windows.Forms.RadioButton rdSame;
        private System.Windows.Forms.GroupBox grbDir;
        private System.Windows.Forms.TextBox txtImpPw;
        private System.Windows.Forms.TextBox txtImpUser;
        private System.Windows.Forms.TextBox txtImpHost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExCheckConn;
        private System.Windows.Forms.CheckBox ckbExSSL;
        private System.Windows.Forms.TextBox txtExPort;
        private System.Windows.Forms.TextBox txtExPw;
        private System.Windows.Forms.TextBox txtExUser;
        private System.Windows.Forms.TextBox txtExHost;
        private System.Windows.Forms.Button btnImpCheckConn;
        private System.Windows.Forms.CheckBox ckbImpSSL;
        private System.Windows.Forms.TextBox txtImpPort;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtExLocal;
        private System.Windows.Forms.ComboBox cbExFTP;
        private System.Windows.Forms.TextBox txtImpLocal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbImpFTP;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ToolStripStatusLabel tslStatus;
        private System.Windows.Forms.FolderBrowserDialog fbdImp;
        private System.Windows.Forms.FolderBrowserDialog fdbEx;
    }
}