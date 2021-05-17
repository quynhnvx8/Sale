using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class PROMOTIONS {
	#region members
	string pROMOTION_NO;
	string pROMOTION_NAME;
	DateTime? pROMOTION_DATE;
	DateTime? fROM_DATE;
	DateTime? tO_DATE;
	string rEMARK;
	DateTime? iNPUT_DATE;
	bool? iS_ADD_MORE;

	#endregion members
	#region Properties
	[PKSqlColumn("PROMOTION_NO", SqlDbType.VarChar, null)]
	public string PROMOTION_NO {
		get { return pROMOTION_NO; }
		set{ pROMOTION_NO = value; }
	}
	[SqlColumn("PROMOTION_NAME", SqlDbType.NVarChar)]
	public string PROMOTION_NAME {
		get { return pROMOTION_NAME; }
		set{ pROMOTION_NAME = value; }
	}
	[SqlColumn("PROMOTION_DATE", SqlDbType.DateTime)]
	public DateTime? PROMOTION_DATE {
		get { return pROMOTION_DATE; }
		set{ pROMOTION_DATE = value; }
	}
	[SqlColumn("FROM_DATE", SqlDbType.DateTime)]
	public DateTime? FROM_DATE {
		get { return fROM_DATE; }
		set{ fROM_DATE = value; }
	}
	[SqlColumn("TO_DATE", SqlDbType.DateTime)]
	public DateTime? TO_DATE {
		get { return tO_DATE; }
		set{ tO_DATE = value; }
	}
	[SqlColumn("REMARK", SqlDbType.NVarChar)]
	public string REMARK {
		get { return rEMARK; }
		set{ rEMARK = value; }
	}
	[SqlColumn("INPUT_DATE", SqlDbType.DateTime)]
	public DateTime? INPUT_DATE {
		get { return iNPUT_DATE; }
		set{ iNPUT_DATE = value; }
	}
	[SqlColumn("IS_ADD_MORE", SqlDbType.Bit)]
	public bool? IS_ADD_MORE {
		get { return iS_ADD_MORE; }
		set{ iS_ADD_MORE = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public PROMOTIONS() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<PROMOTIONS> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<PROMOTIONS>("PROMOTIONS");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "PROMOTIONS");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "PROMOTIONS");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inPROMOTION_NO"></param>
	public static List<PROMOTIONS> ReadByPROMOTION_NO(string inPROMOTION_NO) {
		return rdodb_KTSqlDAC.ReadByParams<PROMOTIONS>("PROMOTIONS", rdodb_KTSqlDAC.newInParam("@PROMOTION_NO", inPROMOTION_NO));
	}
	#endregion DAC Methods 
 }
}
