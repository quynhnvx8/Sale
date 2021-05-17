using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
namespace SaleMTDataAccessLayer.SaleMTDAL
{
    public static class SaleMTEncrypt
    {
        //8 ky tu
        private const string STR_ENCRYPT_SALEMT = "Sale@123";
        private const char CHR_EMPTYE = ' ';

        public static string Encrypt(string strText)
        {
            string strReValue = null;
            try
            {
                string strTextToEncrypt = strText;
                if (strText.Length < 8)
                {
                    strTextToEncrypt = strText.PadRight(8 - strText.Length, CHR_EMPTYE);
                }

                byte[] byKey = { };
                byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
                byKey = Encoding.UTF8.GetBytes(STR_ENCRYPT_SALEMT);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(strTextToEncrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                strReValue = Convert.ToBase64String(ms.ToArray());
                ms.Close();
            }
            catch (Exception)
            {
                strReValue = null;
            }
            return strReValue;
        }

        public static string EncryptX2(string strText)
        {
            string strReValue = null;
            try
            {
                string strTextToEncrypt = strText;
                if (strText.Length < 8)
                {
                    strTextToEncrypt = strText.PadRight(8 - strText.Length, CHR_EMPTYE);
                }

                byte[] byKey = { };
                byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
                byKey = Encoding.UTF8.GetBytes(STR_ENCRYPT_SALEMT);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(strTextToEncrypt);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                StringBuilder sBuilder = new StringBuilder();

                byte[] data = ms.ToArray();
                ms.Close();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                strReValue = sBuilder.ToString();
            }
            catch (Exception)
            {
                strReValue = null;
            }
            return strReValue;
        }

        public static string DecryptX2(string strText)
        {
            string strReValue = null;
            try
            {
                byte[] byKey = { };
                byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
                byKey = Encoding.UTF8.GetBytes(STR_ENCRYPT_SALEMT);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Convert.FromBase64String(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                
                StringBuilder sBuilder = new StringBuilder();

                byte[] data = ms.ToArray();
                ms.Close();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                strReValue = sBuilder.ToString();
            }
            catch (Exception)
            {
                strReValue = null;
            }
            return strReValue;
        }


        public static string Decrypt(string strText)
        {
            string strReValue = null;
            try
            {
                byte[] byKey = { };
                byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
                byKey = Encoding.UTF8.GetBytes(STR_ENCRYPT_SALEMT);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Convert.FromBase64String(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                strReValue = Encoding.UTF8.GetString(ms.ToArray());
                strReValue = strReValue.Trim();
                ms.Close();
            }
            catch (Exception)
            {
                strReValue = null;
            }
            return strReValue;
        }

        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }
    }
}
