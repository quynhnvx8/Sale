using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;

namespace SaleMTDataAccessLayer.SaleMTObj
{
    public class CN_ThanhToan : IDataModel
    {
        #region members
        int id;
        string maTT;
        string maCH;
        DateTime ngay;
        string soHD;
        float soTien;
        string ghiChu;
        string loaiTT;
        float? conLai;

        #endregion members
        #region Properties
        [PKSqlColumn("ID", 0)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        [StringSqlColumn("MaTT")]
        public string MaTT
        {
            get { return maTT; }
            set { maTT = value; }
        }
        [StringSqlColumn("MaCH")]
        public string MaCH
        {
            get { return maCH; }
            set { maCH = value; }
        }
        [SqlColumn("Ngay", SqlDbType.DateTime)]
        public DateTime Ngay
        {
            get { return ngay; }
            set { ngay = value; }
        }
        [StringSqlColumn("SoHD")]
        public string SoHD
        {
            get { return soHD; }
            set { soHD = value; }
        }
        [SqlColumn("SoTien", SqlDbType.Float)]
        public float SoTien
        {
            get { return soTien; }
            set { soTien = value; }
        }
        [SqlColumn("GhiChu", SqlDbType.NVarChar)]
        public string GhiChu
        {
            get { return ghiChu; }
            set { ghiChu = value; }
        }
        [StringSqlColumn("LoaiTT")]
        public string LoaiTT
        {
            get { return loaiTT; }
            set { loaiTT = value; }
        }
        [SqlColumn("ConLai", SqlDbType.Float)]
        public float? ConLai
        {
            get { return conLai; }
            set { conLai = value; }
        }

        #endregion Properties
        #region IsNew()
        public bool IsNew()
        {
            return id == 0;
        }

        #endregion IsNew()
        #region Constructors
        /// <summary>
        ///Default Constructor. Required by DAL Helper
        /// </summary>
        public CN_ThanhToan() { }
        /// <summary>
        ///Gets item by Id.
        /// </summary>
        /// <param name="inId"></param>
        public CN_ThanhToan(int inId)
        {
            this.id = inId;
            populate();
        }

        #endregion Constructors
        #region DAC Methods
        /// <summary>
        ///Reads all items in database.
        /// </summary>
        public static List<CN_ThanhToan> ReadAll()
        {
            return posdb_vnmSqlDAC.ReadAll<CN_ThanhToan>("CN_ThanhToan");
        }
        /// <summary>
        ///Populates item from database by its id.
        /// </summary>
        private void populate()
        {
            posdb_vnmSqlDAC.ReadById<CN_ThanhToan>(this, "CN_ThanhToan");
        }
        /// <summary>
        ///Saves item to database.
        /// </summary>
        public void Save(bool isNew)
        {
            posdb_vnmSqlDAC.Save(this, "CN_ThanhToan",isNew);
        }
        /// <summary>
        ///Deletes item from database.
        /// </summary>
        public void Delete()
        {
            posdb_vnmSqlDAC.Delete(this, "CN_ThanhToan");
        }
        #endregion DAC Methods
    }
}
