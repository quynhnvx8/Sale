using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SaleMTDataAccessLayer.SaleMTDAL;
using SaleMTCommon;
using System.Net;
using System.IO;
namespace SaleMTInterfaces.FrmSystem
{
    /// <summary>
    /// Người tạo Thanvn – 28/11/2013 : Form cấu hình ftp server
    /// </summary>
    public partial class frmFTPMonitor : Form
    {
        
        public frmFTPMonitor(Dictionary<string, string> language)
        {
            translate = language;
            InitializeComponent();
            initLanguage();
        }
        static private Dictionary<string, string> translate = new Dictionary<string, string>();
        private void initLanguage()
        {
            this.statusStrip1.Text = translate["frmFTPMonitor.statusStrip1.Text"];
            this.grbParameter.Text = translate["frmFTPMonitor.grbParameter.Text"];
            this.label6.Text = translate["frmFTPMonitor.label6.Text"];
            this.label5.Text = translate["frmFTPMonitor.label5.Text"];
            this.label4.Text = translate["frmFTPMonitor.label4.Text"];
            this.label3.Text = translate["frmFTPMonitor.label3.Text"];
            this.btnExCheckConn.Text = translate["frmFTPMonitor.btnExCheckConn.Text"];
            this.ckbExSSL.Text = translate["frmFTPMonitor.ckbExSSL.Text"];
            this.btnImpCheckConn.Text = translate["frmFTPMonitor.btnImpCheckConn.Text"];
            this.ckbImpSSL.Text = translate["frmFTPMonitor.ckbImpSSL.Text"];
            this.label2.Text = translate["frmFTPMonitor.label2.Text"];
            this.label1.Text = translate["frmFTPMonitor.label1.Text"];
            this.rdDif.Text = translate["frmFTPMonitor.rdDif.Text"];
            this.rdSame.Text = translate["frmFTPMonitor.rdSame.Text"];
            this.grbDir.Text = translate["frmFTPMonitor.grbDir.Text"];
            this.label12.Text = translate["frmFTPMonitor.label12.Text"];
            this.label10.Text = translate["frmFTPMonitor.label10.Text"];
            this.label11.Text = translate["frmFTPMonitor.label11.Text"];
            this.label9.Text = translate["frmFTPMonitor.label9.Text"];
            this.label8.Text = translate["frmFTPMonitor.label8.Text"];
            this.btnLoad.Text = translate["frmFTPMonitor.btnLoad.Text"];
            this.btnSave.Text = translate["frmFTPMonitor.btnSave.Text"];
            this.Text = translate["frmFTPMonitor.Text"];
        }	

        #region Declaration
        private posdb_vnmSqlDAC sqlDac = new posdb_vnmSqlDAC();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private const string CONN_SUCCESS = "Kết nối thành công!";
        private const string CONN_FAIL = "Không thể kết nối!";
        private const string CONN_CHK = "Đang kiểm tra kết nối...";
        private const string CONN_CHKFOLDER = "Thư mục import phải khác thư mục export";        
        #endregion

        #region Event
        /// <summary>
        /// Người tạo Thanvn – 28/11/2013: Load cấu hình đã lưu.
        /// </summary>
        private void frmFTPMonitor_Load(object sender, EventArgs e)
        {
            try
            {
                string imSer, imUser, imPw, exSer, exUser, exPw, ftpImp, ftpEx, clientImp, clientEx;
                int imPort, exPort;
                imSer = UserImformation.FtpServer;
                imUser = UserImformation.FtpUser;
                imPw = UserImformation.FtpPassword;
                exSer = UserImformation.FtpExServer;
                exUser = UserImformation.FtpExUser;
                exPw = UserImformation.FtpExPassword;
                ftpImp = UserImformation.FtpImportPath.Replace("/", "");
                ftpEx = UserImformation.FtpExportPath.Replace("/", "");
                clientImp = UserImformation.ClientImportPath;
                clientEx = UserImformation.ClientExportPath;

                imPort = UserImformation.FtpImportPort;
                exPort = UserImformation.FtpExportPort;

                txtImpHost.Text = imSer;
                txtImpUser.Text = imUser;
                txtImpPw.Text = imPw;
                txtExHost.Text = exSer;
                txtExUser.Text = exUser;
                txtExPw.Text = exPw;

                cbImpFTP.Items.Clear();
                cbImpFTP.Items.Add(ftpImp);
                cbImpFTP.Items.Add("Load lại");

                cbExFTP.Items.Clear();
                cbExFTP.Items.Add(ftpEx);
                cbExFTP.Items.Add("Load lại");

                cbImpFTP.SelectedIndex = 0;
                cbExFTP.SelectedIndex = 0;
                txtImpLocal.Text = clientImp;
                txtExLocal.Text = clientEx;

                ckbImpSSL.Checked = UserImformation.FtpImportSSL;
                ckbExSSL.Checked = UserImformation.FtpExportSSL;
                txtExPort.Text = UserImformation.FtpExportPort.ToString();
                txtImpPort.Text = UserImformation.FtpImportPort.ToString();

            }
            catch (Exception ex)
            {
                log.Error(" Error 'frmFTPMonitor_Load': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanvn – 28/11/2013: Kiểm tra kết nối server ftp Import.
        /// </summary>
        private void btnImpCheckConn_Click(object sender, EventArgs e)
        {
            try
            {
                if (isValidConnection(txtImpHost.Text + ":" + txtExPort.Text, txtImpUser.Text, txtImpPw.Text, ckbImpSSL.Checked))
                {
                    MessageBox.Show(CONN_SUCCESS, Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show(CONN_FAIL, Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                        MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'ImpCheckConn': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanvn – 28/11/2013: Kiểm tra kết nối server ftp Export.
        /// </summary>
        private void btnExCheckConn_Click(object sender, EventArgs e)
        {
            if (isValidConnection(txtExHost.Text + ":" + txtExPort.Text, txtExUser.Text, txtExPw.Text, ckbExSSL.Checked))
            {
                MessageBox.Show(CONN_SUCCESS);
            }
            else
            {
                MessageBox.Show(CONN_FAIL);
            }
        }
        /// <summary>
        /// Người tạo Thanvn – 28/11/2013: Import khác server Export.
        /// </summary>
        private void rdDif_CheckedChanged(object sender, EventArgs e)
        {
            sameDifCheck();
        }
        /// <summary>
        /// Người tạo Thanvn – 28/11/2013: Import cùng server Export.
        /// </summary>
        private void rdSame_CheckedChanged(object sender, EventArgs e)
        {
            sameDifCheck();
        }
        /// <summary>
        /// Người tạo Thanvn – 28/11/2013: Load cấu hình đã lưu.
        /// </summary>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                frmFTPMonitor_Load(sender, e);
            }
            catch (Exception ex)
            {
                log.Error(" Error 'btnLoad_Click': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanvn – 28/11/2013: Lưu cấu hình hiện tại.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool ckFolder = true;
                if (cbImpFTP.Text.ToLower() == cbExFTP.Text.ToLower())
                {
                    ckFolder = false;
                }
                if (txtImpLocal.Text.ToLower() == txtExLocal.Text.ToLower())
                {
                    ckFolder = false;
                }
                if (!ckFolder)
                {
                    MessageBox.Show(CONN_CHKFOLDER, Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    SortedList<string, string> appSetting = new SortedList<string, string>();
                    appSetting.Add("FtpServer", txtImpHost.Text);
                    appSetting.Add("FtpUser", txtImpUser.Text);
                    appSetting.Add("FtpPassword", txtImpPw.Text);
                    appSetting.Add("FtpImportPort", txtImpPort.Text);
                    appSetting.Add("FtpImportSSL", ckbImpSSL.Checked.ToString());

                    appSetting.Add("FtpExServer", txtExHost.Text);
                    appSetting.Add("FtpExUser", txtExUser.Text);
                    appSetting.Add("FtpExPassword", txtExPw.Text);
                    appSetting.Add("FtpExportPort", txtExPort.Text);
                    appSetting.Add("FtpExportSSL", ckbExSSL.Checked.ToString());

                    appSetting.Add("ClientImportPath", txtImpLocal.Text);
                    appSetting.Add("ClientExportPath", txtExLocal.Text);
                    appSetting.Add("FtpImportPath", cbImpFTP.Text);
                    appSetting.Add("FtpExportPath", cbExFTP.Text);

                    UserImformation.FtpServer = txtImpHost.Text;
                    UserImformation.FtpUser = txtImpUser.Text;
                    UserImformation.FtpPassword = txtImpPw.Text;
                    UserImformation.FtpImportPort = int.Parse(txtImpPort.Text);
                    UserImformation.FtpImportSSL = ckbImpSSL.Checked;

                    UserImformation.FtpExServer = txtExHost.Text;
                    UserImformation.FtpExUser = txtExUser.Text;
                    UserImformation.FtpExPassword = txtExPw.Text;
                    UserImformation.FtpExportPort = int.Parse(txtExPort.Text);
                    UserImformation.FtpExportSSL = ckbExSSL.Checked;

                    UserImformation.ClientImportPath = txtImpLocal.Text;
                    UserImformation.ClientExportPath = txtExLocal.Text;
                    UserImformation.FtpImportPath = cbImpFTP.Text;
                    UserImformation.FtpExportPath = cbExFTP.Text;

                    AppConfigFileSettings.UpdateAppSettings(appSetting);
                    MessageBox.Show(Properties.Resources.SystemSetupPrinter, Properties.rsfSales.Notice.ToString(), MessageBoxButtons.OK,
                                                            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'btnSave_Click': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanvn – 28/11/2013: List thư mục trên ftp server import.
        /// </summary>
        private void cbImpFTP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbImpFTP.Items.Count > 1)
                {
                    if (cbImpFTP.SelectedIndex == cbImpFTP.Items.Count - 1)
                    {
                        cbImpFTP.Items.Clear();
                        cbImpFTP.Items.Add("");
                        string[] its = loadFTPFolder(txtImpHost.Text + ":" + txtImpPort.Text, txtImpUser.Text, txtImpPw.Text);
                        cbImpFTP.Items.AddRange(its);
                        cbImpFTP.Items.Add("Load lại");
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'cbImpFTP_SelectedIndexChanged': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanvn – 28/11/2013: List thư mục trên ftp server export.
        /// </summary>
        private void cbExFTP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbExFTP.Items.Count > 1)
                {
                    if (cbExFTP.SelectedIndex == cbExFTP.Items.Count - 1)
                    {
                        cbExFTP.Items.Clear();
                        cbExFTP.Items.Add("");
                        string[] its = loadFTPFolder(txtExHost.Text + ":" + txtExPort.Text, txtExUser.Text, txtExPw.Text);
                        cbExFTP.Items.AddRange(its);
                        cbExFTP.Items.Add("Load lại");
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'cbExFTP_SelectedIndexChanged': " + ex.Message);
            }
        }

        private void txtImpHost_TextChanged(object sender, EventArgs e)
        {
            if (rdSame.Checked)
            {
                txtExHost.Text = txtImpHost.Text;
            }
        }

        private void txtImpUser_TextChanged(object sender, EventArgs e)
        {
            if (rdSame.Checked)
            {
                txtExUser.Text = txtImpUser.Text;
            }
        }

        private void txtImpPw_TextChanged(object sender, EventArgs e)
        {
            if (rdSame.Checked)
            {
                txtExPw.Text = txtImpPw.Text;
            }
        }

        private void txtImpPort_TextChanged(object sender, EventArgs e)
        {
            if (rdSame.Checked)
            {
                txtExPort.Text = txtImpPort.Text;
            }
        }

        private void txtImpLocal_MouseClick(object sender, MouseEventArgs e)
        {
            txtImpLocal_Enter(sender, e);
        }

        private void txtExLocal_MouseClick(object sender, MouseEventArgs e)
        {
            txtExLocal_Enter(sender, e);
        }
        /// <summary>
        /// Người tạo Thanvn – 28/11/2013: List thư mục trên local import.
        /// </summary>
        private void txtImpLocal_Enter(object sender, EventArgs e)
        {
            try
            {
                if (fbdImp.ShowDialog() == DialogResult.OK)
                {
                    txtImpLocal.Text = fbdImp.SelectedPath + @"\";
                }
                else
                {
                    txtImpLocal.Text = "";
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'Import local select': " + ex.Message);
            }
        }
        /// <summary>
        /// Người tạo Thanvn – 28/11/2013: List thư mục trên local export.
        /// </summary>
        private void txtExLocal_Enter(object sender, EventArgs e)
        {
            try
            {
                if (fdbEx.ShowDialog() == DialogResult.OK)
                {
                    txtExLocal.Text = fdbEx.SelectedPath + @"\";
                }
                else
                {
                    txtExLocal.Text = "";
                }
            }
            catch (Exception ex)
            {
                log.Error(" Error 'Export local select': " + ex.Message);
            }
        }
        #endregion

        #region Method/Function
        /// <summary>
        /// Người tạo Thanvn – 28/11/2013: Xử lý kiểm tra kết nối FTP.
        /// </summary>
        private bool isValidConnection(string url, string user, string password, bool ssl)
        {
            FtpWebRequest request;
            bool re;
            try
            {
                tslStatus.Text = CONN_CHK;
                request = (FtpWebRequest)WebRequest.Create(url);
                request.Timeout = 10000;
                request.EnableSsl = ssl;
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(user, password);
                using (FtpWebResponse res = (FtpWebResponse)request.GetResponse())
                {
                    StreamReader reader = new StreamReader(res.GetResponseStream());
                }
                re = true;
            }
            catch
            {
                re = false;
            }
            request = null;
            tslStatus.Text = "";
            return re;
        }
        /// <summary>
        /// Người tạo Thanvn – 28/11/2013: Xử lý import cùng hoặc khác server export.
        /// </summary>
        private void sameDifCheck()
        {
            txtExHost.ReadOnly = !rdDif.Checked;
            txtExUser.ReadOnly = !rdDif.Checked;
            txtExPw.ReadOnly = !rdDif.Checked;
            txtExPort.ReadOnly = !rdDif.Checked;
            ckbExSSL.Enabled = rdDif.Checked;
            btnExCheckConn.Enabled = rdDif.Checked;
            if (rdSame.Checked)
            {
                txtExHost.Text = txtImpHost.Text;
                txtExUser.Text = txtImpUser.Text;
                txtExPw.Text = txtImpPw.Text;
                txtExPort.Text = txtImpPort.Text;
                ckbExSSL.Checked = ckbImpSSL.Checked;
            }
        }
        /// <summary>
        /// Người tạo Thanvn – 28/11/2013: Kiểm tra kết nối FTP.
        /// </summary>
        private string[] loadFTPFolder(string hostIP, string userName, string password)
        {
            Ftp ftpClient = new Ftp(hostIP, userName, password);
            string[] listDetail = ftpClient.directoryListDetailed("");
            string[] list = ftpClient.directoryListSimple("");
            List<string> re = new List<string>();
            foreach (string dir in listDetail)
            {
                if (dir.ToLower().Contains("drwxr")||dir.ToLower().Contains(@"<dir>"))
                {
                    re.AddRange(list.Where<string>(c => dir.Contains(c) && c != ""));
                }
            }
            return re.ToArray();
        }

        #endregion
        
        
    }
}
