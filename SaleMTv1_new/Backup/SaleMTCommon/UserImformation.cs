using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaleMTCommon
{
    /// <summary>
    /// Created by Luannv – 08/10/2013: Thông tin user đăng nhập.
    /// </summary>
    public static class UserImformation
    {


        #region member
        private static string companyName;
        private static string companyAdress;
        private static string companyTelePhone;
        private static string companyFax;
        private static string businessTypeCode;
        private static string userName;
        private static string deptName;
        private static string deptCode;
        private static int deptNumber;
        private static string storeCode;
        private static string storeAdress;
        private static string storeTelePhone;
        private static string storeFax;
        private static string logo;
        private static string shiftCode;
        private static string ftpServer;
        private static string ftpUser;
        private static string ftpPw;
        private static string ftpExServer;
        private static string ftpExUser;
        private static string ftpExPw;
        private static string ftpExportPath;
        private static string ftpImportPath;
        private static string clientExportPath;
        private static string clientImportPath;
        private static bool ftpImportSSL;
        private static bool ftpExortSSL;
        private static int ftpImportPort;
        private static int ftpExportPort;
        private static string webserviceAddress;
        private static string webserviceUsername;
        private static string webservicePassword;
        private static bool openSynData;
        private static string sysDataAfter;
        private static string checkConectTime;
        private static bool checkSyn;
        private static string sbtnExitSynText;
        private static string portName;
        private static int baudRate;
        private static int dataBits;
        private static bool chekPole;
        
        #endregion

        #region properties

        public static string PortName
        {
            get { return UserImformation.portName; }
            set { UserImformation.portName = value; }
        }
        public static int BaudRate
        {
            get { return UserImformation.baudRate; }
            set { UserImformation.baudRate = value; }
        }
        public static int DataBits
        {
            get { return UserImformation.dataBits; }
            set { UserImformation.dataBits = value; }
        }
        public static bool ChekPole
        {
            get { return UserImformation.chekPole; }
            set { UserImformation.chekPole = value; }
        }

        public static string SbtnExitSynText
        {
            get { return UserImformation.sbtnExitSynText; }
            set { UserImformation.sbtnExitSynText = value; }
        }
        public static bool CheckSyn
        {
            get { return UserImformation.checkSyn; }
            set { UserImformation.checkSyn = value; }
        }
        public static bool OpenSynData
        {
            get { return UserImformation.openSynData; }
            set { UserImformation.openSynData = value; }
        }
        public static string SysDataAfter
        {
            get { return UserImformation.sysDataAfter; }
            set { UserImformation.sysDataAfter = value; }
        }
        public static string CheckConectTime
        {
            get { return UserImformation.checkConectTime; }
            set { UserImformation.checkConectTime = value; }
        }
        public static string WebServiceUsername
        {
            get { return UserImformation.webserviceUsername; }
            set { UserImformation.webserviceUsername = value; }
        }
        public static string WebServicePassword
        {
            get { return UserImformation.webservicePassword; }
            set { UserImformation.webservicePassword = value; }
        }
        public static string WebServiceAddress
        {
            get { return UserImformation.webserviceAddress; }
            set { UserImformation.webserviceAddress = value; }
        }
        public static string CompanyFax
        {
            get { return UserImformation.companyFax; }
            set { UserImformation.companyFax = value; }
        }
        public static string CompanyTelePhone
        {
            get { return UserImformation.companyTelePhone; }
            set { UserImformation.companyTelePhone = value; }
        }
        public static string CompanyAdress
        {
            get { return UserImformation.companyAdress; }
            set { UserImformation.companyAdress = value; }
        }
        public static string BusinessTypeCode
        {
            get { return businessTypeCode; }
            set { businessTypeCode = value; }
        }
        public static string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public static string DeptName
        {
            get { return deptName; }
            set { deptName = value; }
        }
        public static string DeptCode
        {
            get { return deptCode; }
            set { deptCode = value; }
        }
        public static int DeptNumber
        {
            get { return deptNumber; }
            set { deptNumber = value; }
        }
        public static string StoreCode
        {
            get { return storeCode; }
            set { storeCode = value; }
        }
        public static string StoreAdress
        {
            get { return UserImformation.storeAdress; }
            set { UserImformation.storeAdress = value; }
        }
        public static string StoreTelePhone
        {
            get { return UserImformation.storeTelePhone; }
            set { UserImformation.storeTelePhone = value; }
        }
        public static string StoreFax
        {
            get { return UserImformation.storeFax; }
            set { UserImformation.storeFax = value; }
        }
        public static string Logo
        {
            get { return UserImformation.logo; }
            set { UserImformation.logo = value; }
        }
        public static string CompanyName
        {
            get { return UserImformation.companyName; }
            set { UserImformation.companyName = value; }
        }
        public static string ShiftCode
        {
            get { return UserImformation.shiftCode; }
            set { UserImformation.shiftCode = value; }
        }
        public static string FtpServer
        {
            get { return ftpServer; }
            set { ftpServer = value; }
        }
        public static string FtpUser
        {
            get { return ftpUser; }
            set { ftpUser = value; }
        }
        public static string FtpPassword
        {
            get { return ftpPw; }
            set
            {
                ftpPw = value;
            }
        }
        public static string FtpExServer
        {
            get { return ftpExServer; }
            set { ftpExServer = value; }
        }
        public static string FtpExUser
        {
            get { return ftpExUser; }
            set { ftpExUser = value; }
        }
        public static string FtpExPassword
        {
            get { return ftpExPw; }
            set
            {
                ftpExPw = value;
            }
        }
        public static string FtpExportPath
        {
            get { return ftpExportPath; }
            set { ftpExportPath = value; }
        }
        public static string FtpImportPath
        {
            get { return ftpImportPath; }
            set { ftpImportPath = value; }
        }

        public static string ClientExportPath
        {
            get { return clientExportPath; }
            set { clientExportPath = value; }
        }
        public static string ClientImportPath
        {
            get { return clientImportPath; }
            set { clientImportPath = value; }
        }
        public static bool FtpImportSSL
        {
            get { return ftpImportSSL; }
            set { ftpImportSSL = value; }
        }
        public static bool FtpExportSSL
        {
            get { return ftpExortSSL; }
            set { ftpExortSSL = value; }
        }
        public static int FtpExportPort
        {
            get { return ftpExportPort; }
            set { ftpExportPort = value; }
        }
        public static int FtpImportPort
        {
            get { return ftpImportPort; }
            set { ftpImportPort = value; }
        }
        
        #endregion
    }
}
