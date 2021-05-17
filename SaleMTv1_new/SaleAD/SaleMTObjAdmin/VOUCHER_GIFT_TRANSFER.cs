using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class VOUCHER_GIFT_TRANSFER {
	#region members
	string eXPORT_CODE;
	DateTime? eXPORT_DATE;
	string fROM_STORE;
	string tO_STORE;
	string uSER_EXPORT;
	string eXPORT_REMARK;
	string iMPORT_CODE;
	DateTime? iMPORT_DATE;
	string uSER_IMPORT;
	string iMPORT_REMARK;
	string eVENT_ID;

	#endregion members
	#region Properties
	[PKSqlColumn("EXPORT_CODE", SqlDbType.VarChar, null)]
	public string EXPORT_CODE {
		get { return eXPORT_CODE; }
		set{ eXPORT_CODE = value; }
	}
	[SqlColumn("EXPORT_DATE", SqlDbType.DateTime)]
	public DateTime? EXPORT_DATE {
		get { return eXPORT_DATE; }
		set{ eXPORT_DATE = value; }
	}
	[StringSqlColumn("FROM_STORE")]
	public string FROM_STORE {
		get { return fROM_STORE; }
		set{ fROM_STORE = value; }
	}
	[StringSqlColumn("TO_STORE")]
	public string TO_STORE {
		get { return tO_STORE; }
		set{ tO_STORE = value; }
	}
	[SqlColumn("USER_EXPORT", SqlDbType.NVarChar)]
	public string USER_EXPORT {
		get { return uSER_EXPORT; }
		set{ uSER_EXPORT = value; }
	}
	[SqlColumn("EXPORT_REMARK", SqlDbType.NText)]
	public string EXPORT_REMARK {
		get { return eXPORT_REMARK; }
		set{ eXPORT_REMARK = value; }
	}
	[StringSqlColumn("IMPORT_CODE")]
	public string IMPORT_CODE {
		get { return iMPORT_CODE; }
		set{ iMPORT_CODE = value; }
	}
	[SqlColumn("IMPORT_DATE", SqlDbType.DateTime)]
	public DateTime? IMPORT_DATE {
		get { return iMPORT_DATE; }
		set{ iMPORT_DATE = value; }
	}
	[SqlColumn("USER_IMPORT", SqlDbType.NVarChar)]
	public string USER_IMPORT {
		get { return uSER_IMPORT; }
		set{ uSER_IMPORT = value; }
	}
	[SqlColumn("IMPORT_REMARK", SqlDbType.NText)]
	public string IMPORT_REMARK {
		get { return iMPORT_REMARK; }
		set{ iMPORT_REMARK = value; }
	}
	[StringSqlColumn("EVENT_ID")]
	public string EVENT_ID {
		get { return eVENT_ID; }
		set{ eVENT_ID = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public VOUCHER_GIFT_TRANSFER() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<VOUCHER_GIFT_TRANSFER> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<VOUCHER_GIFT_TRANSFER>("VOUCHER_GIFT_TRANSFER");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "VOUCHER_GIFT_TRANSFER");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "VOUCHER_GIFT_TRANSFER");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inEXPORT_CODE"></param>
	public static List<VOUCHER_GIFT_TRANSFER> ReadByEXPORT_CODE(string inEXPORT_CODE) {
		return rdodb_KTSqlDAC.ReadByParams<VOUCHER_GIFT_TRANSFER>("VOUCHER_GIFT_TRANSFER", rdodb_KTSqlDAC.newInParam("@EXPORT_CODE", inEXPORT_CODE));
	}
	#endregion DAC Methods 
 }
}
