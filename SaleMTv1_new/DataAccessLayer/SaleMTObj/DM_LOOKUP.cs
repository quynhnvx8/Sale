using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class DM_LOOKUP
    {
        #region members
        string maLook;
        string tenLook;
        string maDoiTuong;
        string tenDoiTuong;
        string ghiChu;
        string active;

        #endregion members
        #region Properties
        [PKSqlColumn("MaLook", SqlDbType.VarChar, null)]
        public string MaLook
        {
            get { return maLook; }
            set { maLook = value; }
        }
        [SqlColumn("TenLook", SqlDbType.NVarChar)]
        public string TenLook
        {
            get { return tenLook; }
            set { tenLook = value; }
        }
        [PKSqlColumn("MaDoiTuong", SqlDbType.VarChar, null)]
        public string MaDoiTuong
        {
            get { return maDoiTuong; }
            set { maDoiTuong = value; }
        }
        [SqlColumn("TenDoiTuong", SqlDbType.NVarChar)]
        public string TenDoiTuong
        {
            get { return tenDoiTuong; }
            set { tenDoiTuong = value; }
        }
        [SqlColumn("GhiChu", SqlDbType.NVarChar)]
        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
        [SqlColumn("Active", SqlDbType.Char)]
        public string Active
        {
            get { return active; }
            set { active = value; }
        }

        #endregion Properties
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public DM_LOOKUP() { }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<DM_LOOKUP> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<DM_LOOKUP>("DM_LOOKUP");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "DM_LOOKUP",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "DM_LOOKUP");
        }
        #endregion DAC Methods
    }
}
