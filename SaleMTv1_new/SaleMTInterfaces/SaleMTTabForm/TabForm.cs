using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SaleMTInterfaces.SaleMTTabForm
{
    // Created By Thanvn - 26/09/2013
    // Form xy ly MDI dang Tab ke thua tu form chuan .net
    //Su dung ToolStrip va ToolStripButton de dieu khien menu tab
    public class TabForm : Form
    {
        //Tab page tuong ung voi 1 form
        public ToolStripButton DSSMenuTab
        {
            get { return tsbMenuTab; }
            set { tsbMenuTab = value; }
        }
        //Tab control chua cac mdi form
        public ToolStrip DSSMenuBar
        {
            get { return tsMenuBar; }
            set { tsMenuBar = value; }
        }

        private ToolStripItemCollection lstButton;
        public ToolStripItemCollection ListButton
        {
            get { return lstButton; }
            set { lstButton = value; }
        }
        private bool[] blButtonStatus;
        private void SaveButtonStatus()
        {
            if (lstButton != null)
            {
                blButtonStatus = new bool[lstButton.Count];
                for (int i = 0; i < lstButton.Count - 1; i++)
                {
                    blButtonStatus[i] = lstButton[i].Enabled;
                }
            }

        }
        public void SetButtonStatus()
        {
            if (lstButton != null && blButtonStatus != null)
            {
                for (int i = 0; i < lstButton.Count - 1; i++)
                {
                    lstButton[i].Enabled = blButtonStatus[i];
                }
            }
        }

        private ToolStripButton tsbMenuTab;
        private ToolStrip tsMenuBar;
        public TabForm()
        {
            this.Activated += new System.EventHandler(this.DssTabForm_ativated);
            this.Deactivate += new System.EventHandler(this.DssTabForm_DeAtivated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DssTabForm_FormClosed);
            tsbMenuTab = new ToolStripButton(this.Text);
            tsbMenuTab.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbMenuTab.ImageTransparentColor = Color.Transparent;
            tsbMenuTab.Margin = new Padding(1);
            tsbMenuTab.Click += new System.EventHandler(this.tsbMenuTab_Click);
        }

        #region Menu event
        public event EventHandler evAddNew;
        public event EventHandler evSave;
        public event EventHandler evEdit;
        public event EventHandler evCancel;
        public event EventHandler evDelete;
        public event EventHandler evSearch;
        public event EventHandler evPrint;
        public event EventHandler evExportExcel;
        public void OnAddNew(EventArgs e)
        {
            EventHandler handler = evAddNew;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public void OnSave(EventArgs e)
        {
            EventHandler handler = evSave;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public void OnEdit(EventArgs e)
        {
            EventHandler handler = evEdit;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public void OnCancel(EventArgs e)
        {
            EventHandler handler = evCancel;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public void OnDelete(EventArgs e)
        {
            EventHandler handler = evDelete;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public void OnSearch(EventArgs e)
        {
            EventHandler handler = evSearch;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public void OnPrint(EventArgs e)
        {
            EventHandler handler = evPrint;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public void OnExportExcel(EventArgs e)
        {
            EventHandler handler = evExportExcel;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        private void DssTabForm_ativated(object sender, EventArgs e)
        {
            tsbMenuTab.AutoSize = true;
            tsbMenuTab.BackColor = Color.White;
            tsMenuBar.Visible = true;
            SetButtonStatus();
        }
        private void tsbMenuTab_Click(object sender, EventArgs e)
        {
            this.Activate();
        }
        private void DssTabForm_DeAtivated(object sender, EventArgs e)
        {
            tsbMenuTab.AutoSize = false;
            tsbMenuTab.Size = new Size(tsbMenuTab.Size.Width, tsbMenuTab.Size.Height - 2);
            tsbMenuTab.BackColor = SystemColors.Control;
            SaveButtonStatus();
        }

        private void DssTabForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            tsMenuBar.Items.Remove(tsbMenuTab);
            tsMenuBar.Visible = tsMenuBar.Items.Count > 0;
        }

    }

}


