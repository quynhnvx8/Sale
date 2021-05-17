using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SaleMTCommon
{
    public partial class frmProcessFTP : Form
    {
        public frmProcessFTP()
        {
            InitializeComponent();
        }
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private List<string> listFiles;
        private bool isUpload;

        public bool IsUpload
        {
            set { isUpload = value; }
            get { return isUpload; }
        }
        public List<string> ListFiles
        {
            set
            {
                listFiles = value;
            }
            get
            {
                return listFiles;
            }
        }
        private void btnOK_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void frmProcessFTP_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsUpload == true)
                {
                    this.Text = "Export files to server";
                }
                bgwDownload.RunWorkerAsync();            
            }
            catch (Exception ex)
            {
                log.Error("Error 'frmProcessFTP_Load': " + ex.Message);
            }
        }

        private void bgwDownload_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (IsUpload == true)
                {
                    Ftp ftpClient = new Ftp(UserImformation.FtpServer,
                                               UserImformation.FtpUser, UserImformation.FtpPassword);
                    foreach (string file in listFiles)
                    {
                        if (bgwDownload.CancellationPending) break;
                        File.SetAttributes(UserImformation.ClientExportPath + file, FileAttributes.Normal);
                        ftpClient.upload(UserImformation.FtpExportPath +"/"+ file,
                                UserImformation.ClientExportPath + file, this, file);                        
                        File.Delete(UserImformation.ClientExportPath + file);
                    }
                }
                else
                {
                    Ftp ftpClient = new Ftp(UserImformation.FtpExServer,
                                               UserImformation.FtpExUser, UserImformation.FtpExPassword);
                    foreach (string file in listFiles)
                    {
                        if (bgwDownload.CancellationPending) break;
                        ftpClient.download(UserImformation.FtpImportPath + "/" + Path.GetFileName(file),
                                UserImformation.ClientImportPath + Path.GetFileName(file), this, Path.GetFileName(file));
                        ftpClient.delete(UserImformation.FtpImportPath+"/" + Path.GetFileName(file));
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'Download': " + ex.Message);
            }
        }        
        public void accessProgress(int v,string fileName) {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new MethodInvoker(delegate
                    {
                        accessProgress(v, fileName);
                    }));
                    return;
                }
                else
                {
                    v = v > progressBar1.Maximum ? progressBar1.Maximum : v;
                    progressBar1.Value = v;
                    lbMsg.Text = fileName;
                }
            }
            catch (Exception ex)
            {
                log.Error("Error 'accessProgress': " + ex.Message);
            }            
        }

        private void bgwDownload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                string lb = "";
                if (listFiles.Count == 0)
                {
                    if (IsUpload == true)
                    {
                        lb = "Không tìm thấy file để export";
                    }
                    else
                    {
                        lb = "Không tìm thấy file để import";
                    }
                }
                else
                {
                    if (IsUpload == true)
                    {
                        lb = "Export thành công " + listFiles.Count + " file!";
                    }
                    else
                    {
                        lb = "Import thành công " + listFiles.Count + " file!";
                    }
                }
                lbMsg.Text = lb;
                btnCancel.Visible = false;
            }
            catch (Exception ex)
            {
                log.Error("Error 'bgwDownload Completed': " + ex.Message);
            }            
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                bgwDownload.CancelAsync();
                this.Close();
            }
            catch (Exception ex)
            {
                log.Error("Error 'CancelAsync': " + ex.Message);
            }  
        }
    }
}
