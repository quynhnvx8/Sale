namespace SaleMTInterfaces.FrmSystem
{
    partial class frmShifts
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
            this.grbShifts = new System.Windows.Forms.GroupBox();
            this.lvwListShift = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnOkShifts = new System.Windows.Forms.Button();
            this.btnContinute = new System.Windows.Forms.Button();
            this.grbShifts.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbShifts
            // 
            this.grbShifts.Controls.Add(this.lvwListShift);
            this.grbShifts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbShifts.Location = new System.Drawing.Point(8, -2);
            this.grbShifts.Name = "grbShifts";
            this.grbShifts.Size = new System.Drawing.Size(537, 165);
            this.grbShifts.TabIndex = 0;
            this.grbShifts.TabStop = false;
            this.grbShifts.Text = "Danh sách chưa kết ca làm việc";
            // 
            // lvwListShift
            // 
            this.lvwListShift.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwListShift.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwListShift.FullRowSelect = true;
            this.lvwListShift.GridLines = true;
            this.lvwListShift.Location = new System.Drawing.Point(3, 19);
            this.lvwListShift.MultiSelect = false;
            this.lvwListShift.Name = "lvwListShift";
            this.lvwListShift.Size = new System.Drawing.Size(531, 143);
            this.lvwListShift.TabIndex = 0;
            this.lvwListShift.UseCompatibleStateImageBehavior = false;
            this.lvwListShift.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ca";
            this.columnHeader1.Width = 128;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ngày";
            this.columnHeader2.Width = 151;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Người dùng";
            this.columnHeader3.Width = 240;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Image = global::SaleMTInterfaces.Properties.Resources.printer;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(138, 164);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(88, 25);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "In dữ liệu";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnOkShifts
            // 
            this.btnOkShifts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOkShifts.Image = global::SaleMTInterfaces.Properties.Resources.close;
            this.btnOkShifts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOkShifts.Location = new System.Drawing.Point(227, 164);
            this.btnOkShifts.Name = "btnOkShifts";
            this.btnOkShifts.Size = new System.Drawing.Size(75, 25);
            this.btnOkShifts.TabIndex = 2;
            this.btnOkShifts.Text = "Kết ca";
            this.btnOkShifts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOkShifts.UseVisualStyleBackColor = true;
            this.btnOkShifts.Click += new System.EventHandler(this.btnOkShifts_Click);
            // 
            // btnContinute
            // 
            this.btnContinute.Enabled = false;
            this.btnContinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinute.Location = new System.Drawing.Point(303, 164);
            this.btnContinute.Name = "btnContinute";
            this.btnContinute.Size = new System.Drawing.Size(75, 25);
            this.btnContinute.TabIndex = 3;
            this.btnContinute.Text = "Tiếp tục";
            this.btnContinute.UseVisualStyleBackColor = true;
            // 
            // frmShifts
            // 
            this.AcceptButton = this.btnPrint;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 192);
            this.ControlBox = false;
            this.Controls.Add(this.btnContinute);
            this.Controls.Add(this.btnOkShifts);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.grbShifts);
            this.Name = "frmShifts";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = translate["Msg.TitleDialog"];
            this.Load += new System.EventHandler(this.frmShifts_Load);
            this.grbShifts.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbShifts;
        private System.Windows.Forms.ListView lvwListShift;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnOkShifts;
        private System.Windows.Forms.Button btnContinute;
    }
}