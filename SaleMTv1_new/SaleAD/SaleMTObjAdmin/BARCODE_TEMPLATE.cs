using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


      public class BARCODE_TEMPLATE
      {
          #region members
          Guid iD;
          string tEMPLATE_ID;
          string tEMPLATE_NAME;
          string sEGMENT_VALUE;
          int? sEGMENT_LENGTH;
          bool? aUTO_GEN;
          string mAX_VALUE;
          string dESCRIPTION;
          int? pRIORITY;

          #endregion members
          #region Properties
          [PKSqlColumn("ID", SqlDbType.UniqueIdentifier, null)]
          public Guid ID
          {
              get { return iD; }
              set { iD = value; }
          }
          [StringSqlColumn("TEMPLATE_ID")]
          public string TEMPLATE_ID
          {
              get { return tEMPLATE_ID; }
              set { tEMPLATE_ID = value; }
          }
          [SqlColumn("TEMPLATE_NAME", SqlDbType.NVarChar)]
          public string TEMPLATE_NAME
          {
              get { return tEMPLATE_NAME; }
              set { tEMPLATE_NAME = value; }
          }
          [StringSqlColumn("SEGMENT_VALUE")]
          public string SEGMENT_VALUE
          {
              get { return sEGMENT_VALUE; }
              set { sEGMENT_VALUE = value; }
          }
          [SqlColumn("SEGMENT_LENGTH", SqlDbType.Int)]
          public int? SEGMENT_LENGTH
          {
              get { return sEGMENT_LENGTH; }
              set { sEGMENT_LENGTH = value; }
          }
          [SqlColumn("AUTO_GEN", SqlDbType.Bit)]
          public bool? AUTO_GEN
          {
              get { return aUTO_GEN; }
              set { aUTO_GEN = value; }
          }
          [StringSqlColumn("MAX_VALUE")]
          public string MAX_VALUE
          {
              get { return mAX_VALUE; }
              set { mAX_VALUE = value; }
          }
          [SqlColumn("DESCRIPTION", SqlDbType.NVarChar)]
          public string DESCRIPTION
          {
              get { return dESCRIPTION; }
              set { dESCRIPTION = value; }
          }
          [SqlColumn("PRIORITY", SqlDbType.Int)]
          public int? PRIORITY
          {
              get { return pRIORITY; }
              set { pRIORITY = value; }
          }

          #endregion Properties
          #region Constructors
          /// <summary>
          ///Default Constructor. Required by DAL Helper
          /// </summary>
          public BARCODE_TEMPLATE() { }

          #endregion Constructors
          #region DAC Methods
          /// <summary>
          ///Reads all items in database.
          /// </summary>
          public static List<BARCODE_TEMPLATE> ReadAll()
          {
              return rdodb_KTSqlDAC.ReadAll<BARCODE_TEMPLATE>("BARCODE_TEMPLATE");
          }
          /// <summary>
          ///Saves item to database.
          /// </summary>
          public void Save()
          {
              rdodb_KTSqlDAC.Save(this, "BARCODE_TEMPLATE");
          }
          /// <summary>
          ///Deletes item from database.
          /// </summary>
          public void Delete()
          {
              rdodb_KTSqlDAC.Delete(this, "BARCODE_TEMPLATE");
          }
          /// <summary>
          ///Read by Unique Constraint
          /// </summary>
          /// <param name="inID"></param>
          public static List<BARCODE_TEMPLATE> ReadByID(Guid inID)
          {
              return rdodb_KTSqlDAC.ReadByParams<BARCODE_TEMPLATE>("BARCODE_TEMPLATE", rdodb_KTSqlDAC.newInParam("@ID", inID));
          }
          #endregion DAC Methods
      }
}
