using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class SUPPLIER {
	#region members
	string sUPPLIER_ID;
	string cOMPANY_NAME;
	string cONTACT_NAME;
	string aDDRESS;
	string pHONE;
	string fAX;
	string rEMARK;
	string pHONE_1;
	string cONTACT_NAME_2;
	string pHONE_2;
	string tAX_CODE;
	string cAPACITY;
	string wEBSITE;
	string e_MAIL_1;
	string e_MAIL_2;
	string tYPE_BUSINESS;
	string tYPES;
	string pRICE_TABLES;
	float? nORMS_DEBT_ALLOW;
	float? nORMS_DEBT_FOR;
	bool? aCTIVE;

	#endregion members
	#region Properties
	[PKSqlColumn("SUPPLIER_ID", SqlDbType.VarChar, null)]
	public string SUPPLIER_ID {
		get { return sUPPLIER_ID; }
		set{ sUPPLIER_ID = value; }
	}
	[SqlColumn("COMPANY_NAME", SqlDbType.NVarChar)]
	public string COMPANY_NAME {
		get { return cOMPANY_NAME; }
		set{ cOMPANY_NAME = value; }
	}
	[SqlColumn("CONTACT_NAME", SqlDbType.NVarChar)]
	public string CONTACT_NAME {
		get { return cONTACT_NAME; }
		set{ cONTACT_NAME = value; }
	}
	[SqlColumn("ADDRESS", SqlDbType.NVarChar)]
	public string ADDRESS {
		get { return aDDRESS; }
		set{ aDDRESS = value; }
	}
	[StringSqlColumn("PHONE")]
	public string PHONE {
		get { return pHONE; }
		set{ pHONE = value; }
	}
	[StringSqlColumn("FAX")]
	public string FAX {
		get { return fAX; }
		set{ fAX = value; }
	}
	[SqlColumn("REMARK", SqlDbType.NVarChar)]
	public string REMARK {
		get { return rEMARK; }
		set{ rEMARK = value; }
	}
	[SqlColumn("PHONE_1", SqlDbType.NVarChar)]
	public string PHONE_1 {
		get { return pHONE_1; }
		set{ pHONE_1 = value; }
	}
	[SqlColumn("CONTACT_NAME_2", SqlDbType.NVarChar)]
	public string CONTACT_NAME_2 {
		get { return cONTACT_NAME_2; }
		set{ cONTACT_NAME_2 = value; }
	}
	[SqlColumn("PHONE_2", SqlDbType.NVarChar)]
	public string PHONE_2 {
		get { return pHONE_2; }
		set{ pHONE_2 = value; }
	}
	[SqlColumn("TAX_CODE", SqlDbType.NVarChar)]
	public string TAX_CODE {
		get { return tAX_CODE; }
		set{ tAX_CODE = value; }
	}
	[SqlColumn("CAPACITY", SqlDbType.NVarChar)]
	public string CAPACITY {
		get { return cAPACITY; }
		set{ cAPACITY = value; }
	}
	[SqlColumn("WEBSITE", SqlDbType.NVarChar)]
	public string WEBSITE {
		get { return wEBSITE; }
		set{ wEBSITE = value; }
	}
	[SqlColumn("E_MAIL_1", SqlDbType.NVarChar)]
	public string E_MAIL_1 {
		get { return e_MAIL_1; }
		set{ e_MAIL_1 = value; }
	}
	[SqlColumn("E_MAIL_2", SqlDbType.NVarChar)]
	public string E_MAIL_2 {
		get { return e_MAIL_2; }
		set{ e_MAIL_2 = value; }
	}
	[SqlColumn("TYPE_BUSINESS", SqlDbType.NVarChar)]
	public string TYPE_BUSINESS {
		get { return tYPE_BUSINESS; }
		set{ tYPE_BUSINESS = value; }
	}
	[SqlColumn("TYPES", SqlDbType.NVarChar)]
	public string TYPES {
		get { return tYPES; }
		set{ tYPES = value; }
	}
	[SqlColumn("PRICE_TABLES", SqlDbType.NVarChar)]
	public string PRICE_TABLES {
		get { return pRICE_TABLES; }
		set{ pRICE_TABLES = value; }
	}
	[SqlColumn("NORMS_DEBT_ALLOW", SqlDbType.Float)]
	public float? NORMS_DEBT_ALLOW {
		get { return nORMS_DEBT_ALLOW; }
		set{ nORMS_DEBT_ALLOW = value; }
	}
	[SqlColumn("NORMS_DEBT_FOR", SqlDbType.Float)]
	public float? NORMS_DEBT_FOR {
		get { return nORMS_DEBT_FOR; }
		set{ nORMS_DEBT_FOR = value; }
	}
	[SqlColumn("ACTIVE", SqlDbType.Bit)]
	public bool? ACTIVE {
		get { return aCTIVE; }
		set{ aCTIVE = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public SUPPLIER() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<SUPPLIER> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<SUPPLIER>("SUPPLIER");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "SUPPLIER");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "SUPPLIER");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inSUPPLIER_ID"></param>
	public static List<SUPPLIER> ReadBySUPPLIER_ID(string inSUPPLIER_ID) {
		return rdodb_KTSqlDAC.ReadByParams<SUPPLIER>("SUPPLIER", rdodb_KTSqlDAC.newInParam("@SUPPLIER_ID", inSUPPLIER_ID));
	}
	#endregion DAC Methods 
 }
}
