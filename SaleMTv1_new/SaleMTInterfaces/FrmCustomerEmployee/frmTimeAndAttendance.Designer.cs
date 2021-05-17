namespace SaleMTInterfaces.FrmCustomerEmployee
{
    partial class frmTimeAndAttendance
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
            this.dtpGetDate = new System.Windows.Forms.DateTimePicker();
            this.label42 = new System.Windows.Forms.Label();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.gbxThongTinNV = new System.Windows.Forms.GroupBox();
            this.lsvHinhAnh = new System.Windows.Forms.ListView();
            this.txtWorkPlaces = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDateBarcode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmployeeCode = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbxThongTinNV.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpGetDate
            // 
            this.dtpGetDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpGetDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpGetDate.Location = new System.Drawing.Point(73, 16);
            this.dtpGetDate.Name = "dtpGetDate";
            this.dtpGetDate.Size = new System.Drawing.Size(112, 20);
            this.dtpGetDate.TabIndex = 129;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.Location = new System.Drawing.Point(23, 19);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(40, 13);
            this.label42.TabIndex = 128;
            this.label42.Text = "Ngày:";
            // 
            // dtpTime
            // 
            this.dtpTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime.Location = new System.Drawing.Point(192, 17);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(99, 20);
            this.dtpTime.TabIndex = 130;
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(132, 49);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(164, 20);
            this.txtBarCode.TabIndex = 132;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(23, 51);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(78, 13);
            this.label20.TabIndex = 131;
            this.label20.Text = "Mã vạch(F5)";
            // 
            // gbxThongTinNV
            // 
            this.gbxThongTinNV.Controls.Add(this.lsvHinhAnh);
            this.gbxThongTinNV.Controls.Add(this.txtWorkPlaces);
            this.gbxThongTinNV.Controls.Add(this.label4);
            this.gbxThongTinNV.Controls.Add(this.txtDateBarcode);
            this.gbxThongTinNV.Controls.Add(this.label3);
            this.gbxThongTinNV.Controls.Add(this.txtFullName);
            this.gbxThongTinNV.Controls.Add(this.label1);
            this.gbxThongTinNV.Controls.Add(this.txtEmployeeCode);
            this.gbxThongTinNV.Controls.Add(this.label31);
            this.gbxThongTinNV.Controls.Add(this.label28);
            this.gbxThongTinNV.Controls.Add(this.label2);
            this.gbxThongTinNV.Location = new System.Drawing.Point(12, 85);
            this.gbxThongTinNV.Name = "gbxThongTinNV";
            this.gbxThongTinNV.Size = new System.Drawing.Size(463, 170);
            this.gbxThongTinNV.TabIndex = 133;
            this.gbxThongTinNV.TabStop = false;
            this.gbxThongTinNV.Text = "Thông tin nhân viên";
            // 
            // lsvHinhAnh
            // 
            this.lsvHinhAnh.Location = new System.Drawing.Point(345, 39);
            this.lsvHinhAnh.Name = "lsvHinhAnh";
            this.lsvHinhAnh.Size = new System.Drawing.Size(111, 114);
            this.lsvHinhAnh.TabIndex = 148;
            this.lsvHinhAnh.UseCompatibleStateImageBehavior = false;
            // 
            // txtWorkPlaces
            // 
            this.txtWorkPlaces.Location = new System.Drawing.Point(121, 122);
            this.txtWorkPlaces.Name = "txtWorkPlaces";
            this.txtWorkPlaces.Size = new System.Drawing.Size(215, 20);
            this.txtWorkPlaces.TabIndex = 147;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 146;
            this.label4.Text = "Nơi làm việc";
            // 
            // txtDateBarcode
            // 
            this.txtDateBarcode.Location = new System.Drawing.Point(121, 96);
            this.txtDateBarcode.Name = "txtDateBarcode";
            this.txtDateBarcode.Size = new System.Drawing.Size(215, 20);
            this.txtDateBarcode.TabIndex = 145;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 144;
            this.label3.Text = "Ngày giờ quét thẻ";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(121, 70);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(215, 20);
            this.txtFullName.TabIndex = 143;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 142;
            this.label1.Text = "Họ tên";
            // 
            // txtEmployeeCode
            // 
            this.txtEmployeeCode.Location = new System.Drawing.Point(121, 44);
            this.txtEmployeeCode.Name = "txtEmployeeCode";
            this.txtEmployeeCode.Size = new System.Drawing.Size(215, 20);
            this.txtEmployeeCode.TabIndex = 141;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(11, 48);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(72, 13);
            this.label31.TabIndex = 140;
            this.label31.Text = "Mã nhân viên";
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.DarkGray;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.label28.Location = new System.Drawing.Point(342, 16);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(114, 20);
            this.label28.TabIndex = 139;
            this.label28.Text = "Hình ảnh";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DarkGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.label2.Location = new System.Drawing.Point(11, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(325, 20);
            this.label2.TabIndex = 134;
            this.label2.Text = "Thông tin chính";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmTimeAndAttendance
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(487, 274);
            this.Controls.Add(this.gbxThongTinNV);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.dtpGetDate);
            this.Controls.Add(this.label42);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmTimeAndAttendance";
            this.Text = "Quét thẻ nhân viên";
            this.gbxThongTinNV.ResumeLayout(false);
            this.gbxThongTinNV.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpGetDate;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox gbxThongTinNV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ListView lsvHinhAnh;
        private System.Windows.Forms.TextBox txtWorkPlaces;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDateBarcode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmployeeCode;
        private System.Windows.Forms.Label label31;
    }
}