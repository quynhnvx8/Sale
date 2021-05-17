using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class CUSTOMER_CARD {
	#region members
	string cARD_NO;
	DateTime? iSSUE_DATE;
	DateTime? eXPIRATION_DATE;
	bool? iS_USED;
	string cUSTOMER_ID;
	string rEMARK;
	string cREATE_BY;
	DateTime? cREATE_DATE;
	int? dEPT_CODE;
	string rEASON_NOT_USED;
	string sTORE_CODE;

	#endregion members
	#region Properties
	[PKSqlColumn("CARD_NO", SqlDbType.VarChar, null)]
	public string CARD_NO {
		get { return cARD_NO; }
		set{ cARD_NO = value; }
	}
	[SqlColumn("ISSUE_DATE", SqlDbType.DateTime)]
	public DateTime? ISSUE_DATE {
		get { return iSSUE_DATE; }
		set{ iSSUE_DATE = value; }
	}
	[SqlColumn("EXPIRATION_DATE", SqlDbType.DateTime)]
	public DateTime? EXPIRATION_DATE {
		get { return eXPIRATION_DATE; }
		set{ eXPIRATION_DATE = value; }
	}
	[SqlColumn("IS_USED", SqlDbType.Bit)]
	public bool? IS_USED {
		get { return iS_USED; }
		set{ iS_USED = value; }
	}
	[StringSqlColumn("CUSTOMER_ID")]
	public string CUSTOMER_ID {
		get { return cUSTOMER_ID; }
		set{ cUSTOMER_ID = value; }
	}
	[SqlColumn("REMARK", SqlDbType.NVarChar)]
	public string REMARK {
		get { return rEMARK; }
		set{ rEMARK = value; }
	}
	[SqlColumn("CREATE_BY", SqlDbType.NVarChar)]
	public string CREATE_BY {
		get { return cREATE_BY; }
		set{ cREATE_BY = value; }
	}
	[SqlColumn("CREATE_DATE", SqlDbType.DateTime)]
	public DateTime? CREATE_DATE {
		get { return cREATE_DATE; }
		set{ cREATE_DATE = value; }
	}
	[SqlColumn("DEPT_CODE", SqlDbType.Int)]
	public int? DEPT_CODE {
		get { return dEPT_CODE; }
		set{ dEPT_CODE = value; }
	}
	[SqlColumn("REASON_NOT_USED", SqlDbType.NVarChar)]
	public string REASON_NOT_USED {
		get { return rEASON_NOT_USED; }
		set{ rEASON_NOT_USED = value; }
	}
	[StringSqlColumn("STORE_CODE")]
	public string STORE_CODE {
		get { return sTORE_CODE; }
		set{ sTORE_CODE = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public CUSTOMER_CARD() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<CUSTOMER_CARD> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<CUSTOMER_CARD>("CUSTOMER_CARD");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "CUSTOMER_CARD");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "CUSTOMER_CARD");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inCARD_NO"></param>
	public static List<CUSTOMER_CARD> ReadByCARD_NO(string inCARD_NO) {
		return rdodb_KTSqlDAC.ReadByParams<CUSTOMER_CARD>("CUSTOMER_CARD", rdodb_KTSqlDAC.newInParam("@CARD_NO", inCARD_NO));
	}
	/// <summary>
	///Read By Foreign Key
	/// </summary>
	/// <param name="inCUSTOMER_ID"></param>
	public static List<CUSTOMER_CARD> ReadByCUSTOMER_ID(string inCUSTOMER_ID) {
		object parameter = inCUSTOMER_ID ?? string.Empty;
		return rdodb_KTSqlDAC.ReadByParams<CUSTOMER_CARD>("CUSTOMER_CARD", rdodb_KTSqlDAC.newInParam("@CUSTOMER_ID", parameter));
	}
	#endregion DAC Methods 
 }
}
