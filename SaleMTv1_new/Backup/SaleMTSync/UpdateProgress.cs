using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaleMTSync
{
    public partial class UpdateProgress : Form
    {
        public UpdateProgress()
        {
            InitializeComponent();
        }
        public int Progress
        {
            set { progressBar1.Value = value; }
        }

        private void UpdateProgress_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
