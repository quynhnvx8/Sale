namespace SaleMTInterfaces.FrmSaleManagement
{
    partial class frmDialogPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDialogPayment));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.tabPayment = new System.Windows.Forms.TabControl();
            this.tpPayCard = new System.Windows.Forms.TabPage();
            this.txtMoneyCard = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboTypeCard = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.dgvCurrencys = new System.Windows.Forms.DataGridView();
            this.clnCurrency = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clnExchangeRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnIntoMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpGift = new System.Windows.Forms.TabPage();
            this.dgvVoucherGift = new System.Windows.Forms.DataGridView();
            this.clnCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnMaxPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnRemain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpPromotion = new System.Windows.Forms.TabPage();
            this.rtfPromotion = new System.Windows.Forms.RichTextBox();
            this.tpBill = new System.Windows.Forms.TabPage();
            this.rtfRemarkRed = new System.Windows.Forms.RichTextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtTaxCode = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtAdress = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.chkRedBill = new System.Windows.Forms.CheckBox();
            this.pnlOtherPay = new System.Windows.Forms.Panel();
            this.btnResizeTop = new System.Windows.Forms.Button();
            this.imgUpDown = new System.Windows.Forms.ImageList(this.components);
            this.imglUpDown1 = new System.Windows.Forms.ImageList(this.components);
            this.grbPayment = new System.Windows.Forms.GroupBox();
            this.txtTotalPay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSpacialDiscount = new System.Windows.Forms.TextBox();
            this.txtPromotion = new System.Windows.Forms.TextBox();
            this.txtDiscounts = new System.Windows.Forms.TextBox();
            this.txtCashSales = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCalculator = new System.Windows.Forms.Button();
            this.txtVND = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOrtherMoney = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dudBill = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPayMissing = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRefund = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotalReceived = new System.Windows.Forms.TextBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlRemarks = new System.Windows.Forms.Panel();
            this.btnResize = new System.Windows.Forms.Button();
            this.rtfRemarks = new System.Windows.Forms.RichTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
            this.btnPayAndPrint = new System.Windows.Forms.Button();
            this.btnPrintTemp = new System.Windows.Forms.Button();
            this.bdsCurrency = new System.Windows.Forms.BindingSource(this.components);
            this.pnlTop.SuspendLayout();
            this.tabPayment.SuspendLayout();
            this.tpPayCard.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrencys)).BeginInit();
            this.tpGift.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucherGift)).BeginInit();
            this.tpPromotion.SuspendLayout();
            this.tpBill.SuspendLayout();
            this.pnlOtherPay.SuspendLayout();
            this.grbPayment.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dudBill)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlRemarks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bdsCurrency)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTop.Controls.Add(this.tabPayment);
            this.pnlTop.Controls.Add(this.pnlOtherPay);
            this.pnlTop.Location = new System.Drawing.Point(11, 2);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(512, 28);
            this.pnlTop.TabIndex = 0;
            // 
            // tabPayment
            // 
            this.tabPayment.Controls.Add(this.tpPayCard);
            this.tabPayment.Controls.Add(this.tpGift);
            this.tabPayment.Controls.Add(this.tpPromotion);
            this.tabPayment.Controls.Add(this.tpBill);
            this.tabPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPayment.Location = new System.Drawing.Point(0, 30);
            this.tabPayment.Name = "tabPayment";
            this.tabPayment.SelectedIndex = 0;
            this.tabPayment.Size = new System.Drawing.Size(510, 174);
            this.tabPayment.TabIndex = 9;
            // 
            // tpPayCard
            // 
            this.tpPayCard.Controls.Add(this.txtMoneyCard);
            this.tpPayCard.Controls.Add(this.label14);
            this.tpPayCard.Controls.Add(this.cboTypeCard);
            this.tpPayCard.Controls.Add(this.label15);
            this.tpPayCard.Controls.Add(this.panel1);
            this.tpPayCard.Controls.Add(this.dgvCurrencys);
            this.tpPayCard.Location = new System.Drawing.Point(4, 25);
            this.tpPayCard.Name = "tpPayCard";
            this.tpPayCard.Padding = new System.Windows.Forms.Padding(3);
            this.tpPayCard.Size = new System.Drawing.Size(502, 145);
            this.tpPayCard.TabIndex = 0;
            this.tpPayCard.Text = "Ngoại tệ, thẻ thanh toán";
            this.tpPayCard.UseVisualStyleBackColor = true;
            // 
            // txtMoneyCard
            // 
            this.txtMoneyCard.Location = new System.Drawing.Point(308, 117);
            this.txtMoneyCard.Name = "txtMoneyCard";
            this.txtMoneyCard.Size = new System.Drawing.Size(187, 23);
            this.txtMoneyCard.TabIndex = 6;
            this.txtMoneyCard.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMoneyCard.TextChanged += new System.EventHandler(this.txtMoneyCard_TextChanged);
            this.txtMoneyCard.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMoneyCard_KeyPress);
            this.txtMoneyCard.Enter += new System.EventHandler(this.txtMoneyCard_Enter);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(250, 120);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 17);
            this.label14.TabIndex = 5;
            this.label14.Text = "Số tiền";
            // 
            // cboTypeCard
            // 
            this.cboTypeCard.FormattingEnabled = true;
            this.cboTypeCard.Items.AddRange(new object[] {
            "VISA",
            "MASTER"});
            this.cboTypeCard.Location = new System.Drawing.Point(72, 117);
            this.cboTypeCard.Name = "cboTypeCard";
            this.cboTypeCard.Size = new System.Drawing.Size(172, 24);
            this.cboTypeCard.TabIndex = 4;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 119);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 17);
            this.label15.TabIndex = 3;
            this.label15.Text = "Loại thẻ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.panel1.Controls.Add(this.label16);
            this.panel1.Location = new System.Drawing.Point(6, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(490, 22);
            this.panel1.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(4, 3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 17);
            this.label16.TabIndex = 0;
            this.label16.Text = "Visa";
            // 
            // dgvCurrencys
            // 
            this.dgvCurrencys.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvCurrencys.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvCurrencys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrencys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnCurrency,
            this.clnExchangeRate,
            this.clnAmount,
            this.clnIntoMoney});
            this.dgvCurrencys.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvCurrencys.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvCurrencys.Location = new System.Drawing.Point(7, 4);
            this.dgvCurrencys.Name = "dgvCurrencys";
            this.dgvCurrencys.Size = new System.Drawing.Size(489, 90);
            this.dgvCurrencys.TabIndex = 0;
            this.dgvCurrencys.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCurrencys_CellValueChanged);
            this.dgvCurrencys.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCurrencys_CellLeave);
            this.dgvCurrencys.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCurrencys_RowLeave);
            this.dgvCurrencys.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCurrencys_CellEnter);
            this.dgvCurrencys.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvCurrencys_KeyPress);
            // 
            // clnCurrency
            // 
            this.clnCurrency.HeaderText = "Tiền tệ";
            this.clnCurrency.Name = "clnCurrency";
            this.clnCurrency.Width = 110;
            // 
            // clnExchangeRate
            // 
            this.clnExchangeRate.HeaderText = "Tỷ giá";
            this.clnExchangeRate.Name = "clnExchangeRate";
            this.clnExchangeRate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clnExchangeRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clnExchangeRate.Width = 110;
            // 
            // clnAmount
            // 
            this.clnAmount.HeaderText = "Số tiền";
            this.clnAmount.Name = "clnAmount";
            this.clnAmount.Width = 110;
            // 
            // clnIntoMoney
            // 
            this.clnIntoMoney.HeaderText = "Thành tiền";
            this.clnIntoMoney.Name = "clnIntoMoney";
            this.clnIntoMoney.ReadOnly = true;
            this.clnIntoMoney.Width = 115;
            // 
            // tpGift
            // 
            this.tpGift.Controls.Add(this.dgvVoucherGift);
            this.tpGift.Location = new System.Drawing.Point(4, 25);
            this.tpGift.Name = "tpGift";
            this.tpGift.Padding = new System.Windows.Forms.Padding(3);
            this.tpGift.Size = new System.Drawing.Size(502, 145);
            this.tpGift.TabIndex = 1;
            this.tpGift.Text = "Phiếu quà tặng";
            this.tpGift.UseVisualStyleBackColor = true;
            // 
            // dgvVoucherGift
            // 
            this.dgvVoucherGift.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvVoucherGift.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVoucherGift.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnCode,
            this.clnPar,
            this.clnBalance,
            this.clnMaxPay,
            this.clnPayment,
            this.clnRemain});
            this.dgvVoucherGift.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVoucherGift.Location = new System.Drawing.Point(3, 3);
            this.dgvVoucherGift.Name = "dgvVoucherGift";
            this.dgvVoucherGift.Size = new System.Drawing.Size(496, 139);
            this.dgvVoucherGift.TabIndex = 0;
            this.dgvVoucherGift.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVoucherGift_CellLeave);
            this.dgvVoucherGift.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVoucherGift_CellEndEdit);
            this.dgvVoucherGift.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVoucherGift_CellEnter);
            // 
            // clnCode
            // 
            this.clnCode.HeaderText = "Mã phiếu";
            this.clnCode.Name = "clnCode";
            this.clnCode.Width = 102;
            // 
            // clnPar
            // 
            this.clnPar.HeaderText = "Mệnh giá";
            this.clnPar.Name = "clnPar";
            this.clnPar.ReadOnly = true;
            this.clnPar.Width = 70;
            // 
            // clnBalance
            // 
            this.clnBalance.HeaderText = "Số dư";
            this.clnBalance.Name = "clnBalance";
            this.clnBalance.ReadOnly = true;
            this.clnBalance.Width = 70;
            // 
            // clnMaxPay
            // 
            this.clnMaxPay.HeaderText = "TT Tối đa";
            this.clnMaxPay.Name = "clnMaxPay";
            this.clnMaxPay.ReadOnly = true;
            this.clnMaxPay.Width = 70;
            // 
            // clnPayment
            // 
            this.clnPayment.HeaderText = "Thanh toán";
            this.clnPayment.Name = "clnPayment";
            this.clnPayment.Width = 70;
            // 
            // clnRemain
            // 
            this.clnRemain.HeaderText = "Còn lại";
            this.clnRemain.Name = "clnRemain";
            this.clnRemain.ReadOnly = true;
            this.clnRemain.Width = 70;
            // 
            // tpPromotion
            // 
            this.tpPromotion.Controls.Add(this.rtfPromotion);
            this.tpPromotion.Location = new System.Drawing.Point(4, 25);
            this.tpPromotion.Name = "tpPromotion";
            this.tpPromotion.Size = new System.Drawing.Size(502, 145);
            this.tpPromotion.TabIndex = 2;
            this.tpPromotion.Text = "Khuyến mãi";
            this.tpPromotion.UseVisualStyleBackColor = true;
            // 
            // rtfPromotion
            // 
            this.rtfPromotion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtfPromotion.Location = new System.Drawing.Point(0, 0);
            this.rtfPromotion.Name = "rtfPromotion";
            this.rtfPromotion.Size = new System.Drawing.Size(502, 145);
            this.rtfPromotion.TabIndex = 0;
            this.rtfPromotion.Text = "";
            // 
            // tpBill
            // 
            this.tpBill.Controls.Add(this.rtfRemarkRed);
            this.tpBill.Controls.Add(this.label17);
            this.tpBill.Controls.Add(this.txtTaxCode);
            this.tpBill.Controls.Add(this.label18);
            this.tpBill.Controls.Add(this.txtAdress);
            this.tpBill.Controls.Add(this.label19);
            this.tpBill.Controls.Add(this.txtCompanyName);
            this.tpBill.Controls.Add(this.label20);
            this.tpBill.Controls.Add(this.chkRedBill);
            this.tpBill.Location = new System.Drawing.Point(4, 25);
            this.tpBill.Name = "tpBill";
            this.tpBill.Size = new System.Drawing.Size(502, 145);
            this.tpBill.TabIndex = 3;
            this.tpBill.Text = "Hóa đơn đỏ";
            this.tpBill.UseVisualStyleBackColor = true;
            // 
            // rtfRemarkRed
            // 
            this.rtfRemarkRed.Enabled = false;
            this.rtfRemarkRed.Location = new System.Drawing.Point(98, 98);
            this.rtfRemarkRed.Name = "rtfRemarkRed";
            this.rtfRemarkRed.Size = new System.Drawing.Size(387, 42);
            this.rtfRemarkRed.TabIndex = 9;
            this.rtfRemarkRed.Text = "";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(9, 98);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(57, 17);
            this.label17.TabIndex = 8;
            this.label17.Text = "Ghi chú";
            // 
            // txtTaxCode
            // 
            this.txtTaxCode.Enabled = false;
            this.txtTaxCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaxCode.Location = new System.Drawing.Point(98, 73);
            this.txtTaxCode.Name = "txtTaxCode";
            this.txtTaxCode.Size = new System.Drawing.Size(387, 23);
            this.txtTaxCode.TabIndex = 7;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(9, 76);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(78, 17);
            this.label18.TabIndex = 6;
            this.label18.Text = "Mã số thuế";
            // 
            // txtAdress
            // 
            this.txtAdress.Enabled = false;
            this.txtAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdress.Location = new System.Drawing.Point(98, 48);
            this.txtAdress.Name = "txtAdress";
            this.txtAdress.Size = new System.Drawing.Size(387, 23);
            this.txtAdress.TabIndex = 5;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(9, 51);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(51, 17);
            this.label19.TabIndex = 4;
            this.label19.Text = "Địa chỉ";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Enabled = false;
            this.txtCompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyName.Location = new System.Drawing.Point(98, 23);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(387, 23);
            this.txtCompanyName.TabIndex = 3;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(9, 25);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(83, 17);
            this.label20.TabIndex = 1;
            this.label20.Text = "Tên công ty";
            // 
            // chkRedBill
            // 
            this.chkRedBill.AutoSize = true;
            this.chkRedBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRedBill.ForeColor = System.Drawing.Color.Red;
            this.chkRedBill.Location = new System.Drawing.Point(12, 5);
            this.chkRedBill.Name = "chkRedBill";
            this.chkRedBill.Size = new System.Drawing.Size(114, 21);
            this.chkRedBill.TabIndex = 0;
            this.chkRedBill.Text = "In hóa đơn đỏ";
            this.chkRedBill.UseVisualStyleBackColor = true;
            this.chkRedBill.CheckedChanged += new System.EventHandler(this.chkRedBill_CheckedChanged);
            // 
            // pnlOtherPay
            // 
            this.pnlOtherPay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlOtherPay.BackgroundImage")));
            this.pnlOtherPay.Controls.Add(this.btnResizeTop);
            this.pnlOtherPay.Location = new System.Drawing.Point(-1, 0);
            this.pnlOtherPay.Name = "pnlOtherPay";
            this.pnlOtherPay.Size = new System.Drawing.Size(512, 24);
            this.pnlOtherPay.TabIndex = 3;
            this.pnlOtherPay.Click += new System.EventHandler(this.pnlOtherPay_Click);
            // 
            // btnResizeTop
            // 
            this.btnResizeTop.ForeColor = System.Drawing.SystemColors.Control;
            this.btnResizeTop.ImageIndex = 0;
            this.btnResizeTop.ImageList = this.imgUpDown;
            this.btnResizeTop.Location = new System.Drawing.Point(493, 3);
            this.btnResizeTop.Name = "btnResizeTop";
            this.btnResizeTop.Size = new System.Drawing.Size(16, 16);
            this.btnResizeTop.TabIndex = 2;
            this.btnResizeTop.UseVisualStyleBackColor = false;
            this.btnResizeTop.Click += new System.EventHandler(this.btnResizeTop_Click);
            // 
            // imgUpDown
            // 
            this.imgUpDown.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgUpDown.ImageStream")));
            this.imgUpDown.TransparentColor = System.Drawing.Color.Transparent;
            this.imgUpDown.Images.SetKeyName(0, "down.png");
            this.imgUpDown.Images.SetKeyName(1, "up.png");
            // 
            // imglUpDown1
            // 
            this.imglUpDown1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglUpDown1.ImageStream")));
            this.imglUpDown1.TransparentColor = System.Drawing.Color.Transparent;
            this.imglUpDown1.Images.SetKeyName(0, "down.png");
            this.imglUpDown1.Images.SetKeyName(1, "up.png");
            // 
            // grbPayment
            // 
            this.grbPayment.Controls.Add(this.txtTotalPay);
            this.grbPayment.Controls.Add(this.label5);
            this.grbPayment.Controls.Add(this.txtSpacialDiscount);
            this.grbPayment.Controls.Add(this.txtPromotion);
            this.grbPayment.Controls.Add(this.txtDiscounts);
            this.grbPayment.Controls.Add(this.txtCashSales);
            this.grbPayment.Controls.Add(this.label4);
            this.grbPayment.Controls.Add(this.label3);
            this.grbPayment.Controls.Add(this.label2);
            this.grbPayment.Controls.Add(this.label1);
            this.grbPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbPayment.Location = new System.Drawing.Point(10, 29);
            this.grbPayment.Name = "grbPayment";
            this.grbPayment.Size = new System.Drawing.Size(513, 180);
            this.grbPayment.TabIndex = 1;
            this.grbPayment.TabStop = false;
            this.grbPayment.Text = "Thanh toán";
            // 
            // txtTotalPay
            // 
            this.txtTotalPay.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtTotalPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPay.ForeColor = System.Drawing.Color.Lime;
            this.txtTotalPay.Location = new System.Drawing.Point(176, 138);
            this.txtTotalPay.Name = "txtTotalPay";
            this.txtTotalPay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalPay.Size = new System.Drawing.Size(321, 29);
            this.txtTotalPay.TabIndex = 9;
            this.txtTotalPay.Text = "0";
            this.txtTotalPay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTotalPay_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Phải thanh toán";
            // 
            // txtSpacialDiscount
            // 
            this.txtSpacialDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSpacialDiscount.Location = new System.Drawing.Point(176, 51);
            this.txtSpacialDiscount.Name = "txtSpacialDiscount";
            this.txtSpacialDiscount.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSpacialDiscount.Size = new System.Drawing.Size(321, 22);
            this.txtSpacialDiscount.TabIndex = 7;
            this.txtSpacialDiscount.Text = "0";
            this.txtSpacialDiscount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSpacialDiscount_KeyPress);
            // 
            // txtPromotion
            // 
            this.txtPromotion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPromotion.Location = new System.Drawing.Point(176, 82);
            this.txtPromotion.Name = "txtPromotion";
            this.txtPromotion.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPromotion.Size = new System.Drawing.Size(321, 22);
            this.txtPromotion.TabIndex = 6;
            this.txtPromotion.Text = "0";
            this.txtPromotion.TextChanged += new System.EventHandler(this.txtPromotion_TextChanged);
            this.txtPromotion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPromotion_KeyPress);
            // 
            // txtDiscounts
            // 
            this.txtDiscounts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscounts.Location = new System.Drawing.Point(176, 111);
            this.txtDiscounts.Name = "txtDiscounts";
            this.txtDiscounts.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDiscounts.Size = new System.Drawing.Size(321, 22);
            this.txtDiscounts.TabIndex = 5;
            this.txtDiscounts.Text = "0";
            this.txtDiscounts.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiscounts_KeyPress);
            // 
            // txtCashSales
            // 
            this.txtCashSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashSales.Location = new System.Drawing.Point(176, 21);
            this.txtCashSales.Name = "txtCashSales";
            this.txtCashSales.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCashSales.Size = new System.Drawing.Size(321, 22);
            this.txtCashSales.TabIndex = 4;
            this.txtCashSales.Text = "0";
            this.txtCashSales.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCashSales_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tiền chiết khấu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tiền khuyến mãi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Giảm giá";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tiền hàng";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCalculator);
            this.groupBox2.Controls.Add(this.txtVND);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtOrtherMoney);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(10, 215);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(513, 85);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tiền khách hàng đưa";
            // 
            // btnCalculator
            // 
            this.btnCalculator.Image = global::SaleMTInterfaces.Properties.Resources.cal;
            this.btnCalculator.Location = new System.Drawing.Point(210, 47);
            this.btnCalculator.Name = "btnCalculator";
            this.btnCalculator.Size = new System.Drawing.Size(28, 29);
            this.btnCalculator.TabIndex = 4;
            this.btnCalculator.UseVisualStyleBackColor = true;
            this.btnCalculator.Click += new System.EventHandler(this.btnCalculator_Click);
            // 
            // txtVND
            // 
            this.txtVND.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVND.Location = new System.Drawing.Point(244, 50);
            this.txtVND.Name = "txtVND";
            this.txtVND.Size = new System.Drawing.Size(253, 23);
            this.txtVND.TabIndex = 3;
            this.txtVND.Text = "0";
            this.txtVND.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVND.TextChanged += new System.EventHandler(this.txtVND_TextChanged);
            this.txtVND.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVND_KeyDown);
            this.txtVND.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVND_KeyPress);
            this.txtVND.Enter += new System.EventHandler(this.txtVND_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "VNĐ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(225, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "Tiền khác (Visa,Master,ngoại tệ...)";
            // 
            // txtOrtherMoney
            // 
            this.txtOrtherMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrtherMoney.Location = new System.Drawing.Point(244, 19);
            this.txtOrtherMoney.Name = "txtOrtherMoney";
            this.txtOrtherMoney.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtOrtherMoney.Size = new System.Drawing.Size(253, 23);
            this.txtOrtherMoney.TabIndex = 0;
            this.txtOrtherMoney.Text = "0";
            this.txtOrtherMoney.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOrtherMoney_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dudBill);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtPayMissing);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtRefund);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtTotalReceived);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(10, 305);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(513, 142);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tổng";
            // 
            // dudBill
            // 
            this.dudBill.Location = new System.Drawing.Point(452, 118);
            this.dudBill.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.dudBill.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dudBill.Name = "dudBill";
            this.dudBill.Size = new System.Drawing.Size(45, 23);
            this.dudBill.TabIndex = 8;
            this.dudBill.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(402, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 17);
            this.label11.TabIndex = 7;
            this.label11.Text = "SL bill";
            // 
            // txtPayMissing
            // 
            this.txtPayMissing.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtPayMissing.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayMissing.ForeColor = System.Drawing.Color.Lime;
            this.txtPayMissing.Location = new System.Drawing.Point(176, 86);
            this.txtPayMissing.Name = "txtPayMissing";
            this.txtPayMissing.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPayMissing.Size = new System.Drawing.Size(321, 29);
            this.txtPayMissing.TabIndex = 5;
            this.txtPayMissing.Text = "0";
            this.txtPayMissing.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPayMissing_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(10, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 17);
            this.label10.TabIndex = 4;
            this.label10.Text = "Còn thiếu";
            // 
            // txtRefund
            // 
            this.txtRefund.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtRefund.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefund.ForeColor = System.Drawing.Color.Lime;
            this.txtRefund.Location = new System.Drawing.Point(176, 51);
            this.txtRefund.Name = "txtRefund";
            this.txtRefund.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtRefund.Size = new System.Drawing.Size(321, 29);
            this.txtRefund.TabIndex = 3;
            this.txtRefund.Text = "0";
            this.txtRefund.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRefund_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 60);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "Tiền trả lại";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(10, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Tổng tiền nhận";
            // 
            // txtTotalReceived
            // 
            this.txtTotalReceived.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtTotalReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalReceived.ForeColor = System.Drawing.Color.Lime;
            this.txtTotalReceived.Location = new System.Drawing.Point(176, 19);
            this.txtTotalReceived.Name = "txtTotalReceived";
            this.txtTotalReceived.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotalReceived.Size = new System.Drawing.Size(321, 29);
            this.txtTotalReceived.TabIndex = 0;
            this.txtTotalReceived.Text = "0";
            this.txtTotalReceived.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTotalReceived_KeyPress);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBottom.Controls.Add(this.pnlRemarks);
            this.pnlBottom.Controls.Add(this.rtfRemarks);
            this.pnlBottom.Location = new System.Drawing.Point(10, 479);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(513, 24);
            this.pnlBottom.TabIndex = 8;
            // 
            // pnlRemarks
            // 
            this.pnlRemarks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(201)))), ((int)(((byte)(201)))));
            this.pnlRemarks.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlRemarks.BackgroundImage")));
            this.pnlRemarks.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlRemarks.Controls.Add(this.btnResize);
            this.pnlRemarks.Location = new System.Drawing.Point(0, 0);
            this.pnlRemarks.Name = "pnlRemarks";
            this.pnlRemarks.Size = new System.Drawing.Size(512, 24);
            this.pnlRemarks.TabIndex = 2;
            this.pnlRemarks.Click += new System.EventHandler(this.pnlRemarks_Click);
            // 
            // btnResize
            // 
            this.btnResize.ImageIndex = 1;
            this.btnResize.ImageList = this.imgUpDown;
            this.btnResize.Location = new System.Drawing.Point(490, 2);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(16, 16);
            this.btnResize.TabIndex = 0;
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // rtfRemarks
            // 
            this.rtfRemarks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtfRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtfRemarks.Location = new System.Drawing.Point(3, 33);
            this.rtfRemarks.Name = "rtfRemarks";
            this.rtfRemarks.Size = new System.Drawing.Size(461, 47);
            this.rtfRemarks.TabIndex = 1;
            this.rtfRemarks.Text = "";
            this.rtfRemarks.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::SaleMTInterfaces.Properties.Resources.huy;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(411, 451);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 24);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "ESC: &Hủy bỏ";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayment.Image = global::SaleMTInterfaces.Properties.Resources.save1;
            this.btnPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPayment.Location = new System.Drawing.Point(285, 451);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(126, 25);
            this.btnPayment.TabIndex = 6;
            this.btnPayment.Text = "F9: &Thanh toán";
            this.btnPayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnPayAndPrint
            // 
            this.btnPayAndPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPayAndPrint.Image = global::SaleMTInterfaces.Properties.Resources.printer;
            this.btnPayAndPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPayAndPrint.Location = new System.Drawing.Point(125, 451);
            this.btnPayAndPrint.Name = "btnPayAndPrint";
            this.btnPayAndPrint.Size = new System.Drawing.Size(160, 25);
            this.btnPayAndPrint.TabIndex = 5;
            this.btnPayAndPrint.Text = "F8: Thanh toán và &In";
            this.btnPayAndPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPayAndPrint.UseVisualStyleBackColor = true;
            this.btnPayAndPrint.Click += new System.EventHandler(this.btnPayAndPrint_Click);
            // 
            // btnPrintTemp
            // 
            this.btnPrintTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintTemp.Image = global::SaleMTInterfaces.Properties.Resources.printer;
            this.btnPrintTemp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintTemp.Location = new System.Drawing.Point(8, 451);
            this.btnPrintTemp.Name = "btnPrintTemp";
            this.btnPrintTemp.Size = new System.Drawing.Size(117, 25);
            this.btnPrintTemp.TabIndex = 4;
            this.btnPrintTemp.Text = "F7: I&n HĐ tạm";
            this.btnPrintTemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrintTemp.UseVisualStyleBackColor = true;
            this.btnPrintTemp.Click += new System.EventHandler(this.btnPrintTemp_Click);
            // 
            // frmDialogPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 514);
            this.ControlBox = false;
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.btnPayAndPrint);
            this.Controls.Add(this.btnPrintTemp);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grbPayment);
            this.Controls.Add(this.pnlTop);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDialogPayment";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Thanh toán";
            this.Load += new System.EventHandler(this.frmDialogPayment_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDialogPayment_FormClosed);
            this.pnlTop.ResumeLayout(false);
            this.tabPayment.ResumeLayout(false);
            this.tpPayCard.ResumeLayout(false);
            this.tpPayCard.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrencys)).EndInit();
            this.tpGift.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVoucherGift)).EndInit();
            this.tpPromotion.ResumeLayout(false);
            this.tpBill.ResumeLayout(false);
            this.tpBill.PerformLayout();
            this.pnlOtherPay.ResumeLayout(false);
            this.grbPayment.ResumeLayout(false);
            this.grbPayment.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dudBill)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlRemarks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bdsCurrency)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.GroupBox grbPayment;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtSpacialDiscount;
        private System.Windows.Forms.TextBox txtPromotion;
        private System.Windows.Forms.TextBox txtDiscounts;
        private System.Windows.Forms.TextBox txtCashSales;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalPay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOrtherMoney;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtVND;
        private System.Windows.Forms.Button btnCalculator;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRefund;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTotalReceived;
        private System.Windows.Forms.TextBox txtPayMissing;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnPrintTemp;
        private System.Windows.Forms.Button btnPayAndPrint;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnResize;
        private System.Windows.Forms.RichTextBox rtfRemarks;
        private System.Windows.Forms.Panel pnlRemarks;
        private System.Windows.Forms.Panel pnlOtherPay;
        private System.Windows.Forms.Button btnResizeTop;
        private System.Windows.Forms.TabControl tabPayment;
        private System.Windows.Forms.TabPage tpPayCard;
        private System.Windows.Forms.TextBox txtMoneyCard;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboTypeCard;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView dgvCurrencys;
        private System.Windows.Forms.TabPage tpGift;
        private System.Windows.Forms.DataGridView dgvVoucherGift;
        private System.Windows.Forms.TabPage tpPromotion;
        private System.Windows.Forms.RichTextBox rtfPromotion;
        private System.Windows.Forms.TabPage tpBill;
        private System.Windows.Forms.RichTextBox rtfRemarkRed;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtTaxCode;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtAdress;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox chkRedBill;
        private System.Windows.Forms.BindingSource bdsCurrency;
        private System.Windows.Forms.ImageList imglUpDown1;
        private System.Windows.Forms.DataGridViewComboBoxColumn clnCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnExchangeRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnIntoMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPar;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnMaxPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnRemain;
        private System.Windows.Forms.NumericUpDown dudBill;
        private System.Windows.Forms.ImageList imgUpDown;
    }
}