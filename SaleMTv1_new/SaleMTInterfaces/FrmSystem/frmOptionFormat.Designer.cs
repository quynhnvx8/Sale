namespace SaleMTInterfaces.FrmSystem
{
    partial class frmOptionFormat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptionFormat));
            this.tabFormFomat = new System.Windows.Forms.TabControl();
            this.tabFormat = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboSTP = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboMoney = new System.Windows.Forms.ComboBox();
            this.cboNum = new System.Windows.Forms.ComboBox();
            this.cboTime = new System.Windows.Forms.ComboBox();
            this.cboDate = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPoleDisplay = new System.Windows.Forms.TabPage();
            this.btnCheckDisplay = new System.Windows.Forms.Button();
            this.cboBRate = new System.Windows.Forms.ComboBox();
            this.cboComPort = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.chkChoose = new System.Windows.Forms.CheckBox();
            this.tabPrintInvoi = new System.Windows.Forms.TabPage();
            this.txtCusPurchase = new System.Windows.Forms.TextBox();
            this.txtCusGroup = new System.Windows.Forms.TextBox();
            this.txtCusAdress = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnCustimerSearch = new System.Windows.Forms.Button();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nudNumInvoi = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabFormFomat.SuspendLayout();
            this.tabFormat.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPoleDisplay.SuspendLayout();
            this.tabPrintInvoi.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumInvoi)).BeginInit();
            this.SuspendLayout();
            // 
            // tabFormFomat
            // 
            this.tabFormFomat.Controls.Add(this.tabFormat);
            this.tabFormFomat.Controls.Add(this.tabPoleDisplay);
            this.tabFormFomat.Controls.Add(this.tabPrintInvoi);
            this.tabFormFomat.Location = new System.Drawing.Point(13, 16);
            this.tabFormFomat.Margin = new System.Windows.Forms.Padding(4);
            this.tabFormFomat.Name = "tabFormFomat";
            this.tabFormFomat.SelectedIndex = 0;
            this.tabFormFomat.Size = new System.Drawing.Size(392, 327);
            this.tabFormFomat.TabIndex = 0;
            // 
            // tabFormat
            // 
            this.tabFormat.Controls.Add(this.groupBox2);
            this.tabFormat.Controls.Add(this.groupBox1);
            this.tabFormat.Location = new System.Drawing.Point(4, 25);
            this.tabFormat.Margin = new System.Windows.Forms.Padding(4);
            this.tabFormat.Name = "tabFormat";
            this.tabFormat.Padding = new System.Windows.Forms.Padding(4);
            this.tabFormat.Size = new System.Drawing.Size(384, 298);
            this.tabFormat.TabIndex = 0;
            this.tabFormat.Text = "Định dạng";
            this.tabFormat.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMoney);
            this.groupBox2.Controls.Add(this.txtNum);
            this.groupBox2.Controls.Add(this.txtTime);
            this.groupBox2.Controls.Add(this.txtDate);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(8, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(369, 136);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mẫu";
            // 
            // txtMoney
            // 
            this.txtMoney.Enabled = false;
            this.txtMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtMoney.Location = new System.Drawing.Point(98, 102);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.ReadOnly = true;
            this.txtMoney.Size = new System.Drawing.Size(255, 22);
            this.txtMoney.TabIndex = 17;
            // 
            // txtNum
            // 
            this.txtNum.Enabled = false;
            this.txtNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtNum.Location = new System.Drawing.Point(98, 75);
            this.txtNum.Name = "txtNum";
            this.txtNum.ReadOnly = true;
            this.txtNum.Size = new System.Drawing.Size(255, 22);
            this.txtNum.TabIndex = 16;
            // 
            // txtTime
            // 
            this.txtTime.Enabled = false;
            this.txtTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTime.Location = new System.Drawing.Point(98, 49);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(255, 22);
            this.txtTime.TabIndex = 15;
            // 
            // txtDate
            // 
            this.txtDate.Enabled = false;
            this.txtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtDate.Location = new System.Drawing.Point(98, 23);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(255, 22);
            this.txtDate.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Tiền tệ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 16);
            this.label9.TabIndex = 10;
            this.label9.Text = "Ngày tháng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Số";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "Giờ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboSTP);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cboMoney);
            this.groupBox1.Controls.Add(this.cboNum);
            this.groupBox1.Controls.Add(this.cboTime);
            this.groupBox1.Controls.Add(this.cboDate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kiểu dữ liệu";
            // 
            // cboSTP
            // 
            this.cboSTP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSTP.FormattingEnabled = true;
            this.cboSTP.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cboSTP.Location = new System.Drawing.Point(311, 72);
            this.cboSTP.Name = "cboSTP";
            this.cboSTP.Size = new System.Drawing.Size(42, 24);
            this.cboSTP.TabIndex = 9;
            this.cboSTP.SelectedIndexChanged += new System.EventHandler(this.cboSTP_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(218, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Số thập phân";
            // 
            // cboMoney
            // 
            this.cboMoney.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMoney.FormattingEnabled = true;
            this.cboMoney.Items.AddRange(new object[] {
            "##0",
            "#,##0"});
            this.cboMoney.Location = new System.Drawing.Point(98, 102);
            this.cboMoney.Name = "cboMoney";
            this.cboMoney.Size = new System.Drawing.Size(117, 24);
            this.cboMoney.TabIndex = 7;
            this.cboMoney.SelectedIndexChanged += new System.EventHandler(this.cboMoney_SelectedIndexChanged);
            // 
            // cboNum
            // 
            this.cboNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNum.FormattingEnabled = true;
            this.cboNum.Items.AddRange(new object[] {
            "##0",
            "#,##0"});
            this.cboNum.Location = new System.Drawing.Point(98, 73);
            this.cboNum.Name = "cboNum";
            this.cboNum.Size = new System.Drawing.Size(117, 24);
            this.cboNum.TabIndex = 6;
            this.cboNum.SelectedIndexChanged += new System.EventHandler(this.cboNum_SelectedIndexChanged);
            // 
            // cboTime
            // 
            this.cboTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTime.FormattingEnabled = true;
            this.cboTime.Items.AddRange(new object[] {
            "HH:mm:ss",
            "H:mm:ss",
            "hh:mm:ss tt",
            "h:mm:ss tt"});
            this.cboTime.Location = new System.Drawing.Point(98, 44);
            this.cboTime.Name = "cboTime";
            this.cboTime.Size = new System.Drawing.Size(255, 24);
            this.cboTime.TabIndex = 5;
            this.cboTime.SelectedIndexChanged += new System.EventHandler(this.cboTime_SelectedIndexChanged);
            // 
            // cboDate
            // 
            this.cboDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDate.FormattingEnabled = true;
            this.cboDate.Items.AddRange(new object[] {
            "dd/MM/yyyy",
            "MM/dd/yyyy"});
            this.cboDate.Location = new System.Drawing.Point(98, 16);
            this.cboDate.Name = "cboDate";
            this.cboDate.Size = new System.Drawing.Size(255, 24);
            this.cboDate.TabIndex = 4;
            this.cboDate.SelectedIndexChanged += new System.EventHandler(this.cboDate_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tiền tệ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Giờ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ngày tháng";
            // 
            // tabPoleDisplay
            // 
            this.tabPoleDisplay.Controls.Add(this.btnCheckDisplay);
            this.tabPoleDisplay.Controls.Add(this.cboBRate);
            this.tabPoleDisplay.Controls.Add(this.cboComPort);
            this.tabPoleDisplay.Controls.Add(this.label11);
            this.tabPoleDisplay.Controls.Add(this.label10);
            this.tabPoleDisplay.Controls.Add(this.chkChoose);
            this.tabPoleDisplay.Location = new System.Drawing.Point(4, 25);
            this.tabPoleDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.tabPoleDisplay.Name = "tabPoleDisplay";
            this.tabPoleDisplay.Padding = new System.Windows.Forms.Padding(4);
            this.tabPoleDisplay.Size = new System.Drawing.Size(384, 298);
            this.tabPoleDisplay.TabIndex = 1;
            this.tabPoleDisplay.Text = "Pole Display";
            this.tabPoleDisplay.UseVisualStyleBackColor = true;
            // 
            // btnCheckDisplay
            // 
            this.btnCheckDisplay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckDisplay.Location = new System.Drawing.Point(88, 107);
            this.btnCheckDisplay.Name = "btnCheckDisplay";
            this.btnCheckDisplay.Size = new System.Drawing.Size(126, 25);
            this.btnCheckDisplay.TabIndex = 6;
            this.btnCheckDisplay.Text = "Kiểm tra hiển thị";
            this.btnCheckDisplay.UseVisualStyleBackColor = true;
            this.btnCheckDisplay.Click += new System.EventHandler(this.btnCheckDisplay_Click);
            // 
            // cboBRate
            // 
            this.cboBRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBRate.FormattingEnabled = true;
            this.cboBRate.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cboBRate.Location = new System.Drawing.Point(88, 77);
            this.cboBRate.Name = "cboBRate";
            this.cboBRate.Size = new System.Drawing.Size(126, 24);
            this.cboBRate.TabIndex = 4;
            // 
            // cboComPort
            // 
            this.cboComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboComPort.FormattingEnabled = true;
            this.cboComPort.Location = new System.Drawing.Point(88, 47);
            this.cboComPort.Name = "cboComPort";
            this.cboComPort.Size = new System.Drawing.Size(126, 24);
            this.cboComPort.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 16);
            this.label11.TabIndex = 2;
            this.label11.Text = "Baud Rate ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "Com Port";
            // 
            // chkChoose
            // 
            this.chkChoose.AutoSize = true;
            this.chkChoose.Location = new System.Drawing.Point(11, 23);
            this.chkChoose.Name = "chkChoose";
            this.chkChoose.Size = new System.Drawing.Size(94, 20);
            this.chkChoose.TabIndex = 0;
            this.chkChoose.Text = "Có sử dụng";
            this.chkChoose.UseVisualStyleBackColor = true;
            this.chkChoose.CheckedChanged += new System.EventHandler(this.chkChoose_CheckedChanged);
            // 
            // tabPrintInvoi
            // 
            this.tabPrintInvoi.Controls.Add(this.txtCusPurchase);
            this.tabPrintInvoi.Controls.Add(this.txtCusGroup);
            this.tabPrintInvoi.Controls.Add(this.txtCusAdress);
            this.tabPrintInvoi.Controls.Add(this.groupBox5);
            this.tabPrintInvoi.Controls.Add(this.groupBox4);
            this.tabPrintInvoi.Controls.Add(this.groupBox3);
            this.tabPrintInvoi.Location = new System.Drawing.Point(4, 25);
            this.tabPrintInvoi.Margin = new System.Windows.Forms.Padding(4);
            this.tabPrintInvoi.Name = "tabPrintInvoi";
            this.tabPrintInvoi.Padding = new System.Windows.Forms.Padding(4);
            this.tabPrintInvoi.Size = new System.Drawing.Size(384, 298);
            this.tabPrintInvoi.TabIndex = 2;
            this.tabPrintInvoi.Text = "In hóa đơn";
            this.tabPrintInvoi.UseVisualStyleBackColor = true;
            // 
            // txtCusPurchase
            // 
            this.txtCusPurchase.Location = new System.Drawing.Point(347, 260);
            this.txtCusPurchase.Name = "txtCusPurchase";
            this.txtCusPurchase.Size = new System.Drawing.Size(27, 22);
            this.txtCusPurchase.TabIndex = 4;
            this.txtCusPurchase.Visible = false;
            // 
            // txtCusGroup
            // 
            this.txtCusGroup.Location = new System.Drawing.Point(347, 232);
            this.txtCusGroup.Name = "txtCusGroup";
            this.txtCusGroup.Size = new System.Drawing.Size(27, 22);
            this.txtCusGroup.TabIndex = 3;
            this.txtCusGroup.Visible = false;
            // 
            // txtCusAdress
            // 
            this.txtCusAdress.Location = new System.Drawing.Point(347, 204);
            this.txtCusAdress.Name = "txtCusAdress";
            this.txtCusAdress.Size = new System.Drawing.Size(27, 22);
            this.txtCusAdress.TabIndex = 2;
            this.txtCusAdress.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnCustimerSearch);
            this.groupBox5.Controls.Add(this.txtCustomerName);
            this.groupBox5.Controls.Add(this.txtCustomerCode);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Location = new System.Drawing.Point(7, 122);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(370, 74);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            // 
            // btnCustimerSearch
            // 
            this.btnCustimerSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnCustimerSearch.Image")));
            this.btnCustimerSearch.Location = new System.Drawing.Point(340, 18);
            this.btnCustimerSearch.Name = "btnCustimerSearch";
            this.btnCustimerSearch.Size = new System.Drawing.Size(27, 23);
            this.btnCustimerSearch.TabIndex = 5;
            this.btnCustimerSearch.UseVisualStyleBackColor = true;
            this.btnCustimerSearch.Click += new System.EventHandler(this.btnCustimerSearch_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtCustomerName.Location = new System.Drawing.Point(137, 42);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(227, 22);
            this.txtCustomerName.TabIndex = 4;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtCustomerCode.Location = new System.Drawing.Point(137, 19);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(201, 22);
            this.txtCustomerCode.TabIndex = 3;
            this.txtCustomerCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerCode_KeyDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 44);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 16);
            this.label15.TabIndex = 3;
            this.label15.Text = "Tên KH";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 16);
            this.label14.TabIndex = 2;
            this.label14.Text = "Mã KH mặc định";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtName);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Location = new System.Drawing.Point(7, 65);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(370, 51);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(137, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(227, 22);
            this.txtName.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(122, 16);
            this.label13.TabIndex = 1;
            this.label13.Text = "Tên người in HĐ đỏ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nudNumInvoi);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(7, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(370, 51);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // nudNumInvoi
            // 
            this.nudNumInvoi.Location = new System.Drawing.Point(311, 17);
            this.nudNumInvoi.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudNumInvoi.Name = "nudNumInvoi";
            this.nudNumInvoi.Size = new System.Drawing.Size(52, 22);
            this.nudNumInvoi.TabIndex = 1;
            this.nudNumInvoi.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(212, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Số lượng HĐ bán hàng in mặc định";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(236, 347);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 25);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(324, 348);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(79, 25);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmOptionFormat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 379);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabFormFomat);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmOptionFormat";
            this.Text = "Tùy chỉnh";
            this.Load += new System.EventHandler(this.frmOptionFormat_Load);
            this.tabFormFomat.ResumeLayout(false);
            this.tabFormat.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPoleDisplay.ResumeLayout(false);
            this.tabPoleDisplay.PerformLayout();
            this.tabPrintInvoi.ResumeLayout(false);
            this.tabPrintInvoi.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumInvoi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabFormFomat;
        private System.Windows.Forms.TabPage tabFormat;
        private System.Windows.Forms.TabPage tabPoleDisplay;
        private System.Windows.Forms.TabPage tabPrintInvoi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboSTP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboMoney;
        private System.Windows.Forms.ComboBox cboNum;
        private System.Windows.Forms.ComboBox cboTime;
        private System.Windows.Forms.ComboBox cboDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCheckDisplay;
        private System.Windows.Forms.ComboBox cboBRate;
        private System.Windows.Forms.ComboBox cboComPort;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkChoose;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.NumericUpDown nudNumInvoi;
        private System.Windows.Forms.Button btnCustimerSearch;
        private System.Windows.Forms.TextBox txtCusPurchase;
        private System.Windows.Forms.TextBox txtCusGroup;
        private System.Windows.Forms.TextBox txtCusAdress;

    }
}