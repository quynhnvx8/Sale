using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaleMTCommon
{
    public partial class frmProgressBar : Form
    {
        public event EventHandler<EventArgs> Canceled;

        public frmProgressBar()
        {
            InitializeComponent();
        }

        public string Message
        {
            set { lblMessage.Text = value; }
        }
        public int Progress
        {
            set { progressBar1.Value = value; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            EventHandler<EventArgs> ea = Canceled;
            if (ea != null)
                ea(this, e);
        }

        private void frmProgress_Load(object sender, EventArgs e)
        {
           
        }
    }
}
