using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class CUSTOMERS_TEMP {
	#region members
	string cUSTOMER_ID;
	int? dEPT_CODE;
	string fIRST_NAME;
	string lAST_NAME;
	string oCCUPATION_CODE;
	string oCCUPATION_OTHER;
	string cOUNTRY_CODE;
	string mARITAL_STATUS;
	DateTime? dATE_OF_BIRTH;
	string pLACE_OF_BIRTH;
	string sEX_CODE;
	string bLOOD_CODE;
	string rACE_CODE;
	string rELIGION_CODE;
	string tEL;
	string fAX;
	string mOBILE_PHONE;
	string eMAIL_ADDRESS;
	string iD_NO;
	DateTime? iD_NO_ISSUED_DATE;
	string iD_NO_ISSUED_PLACE;
	string pASSPORT_NO;
	DateTime? pASSPORT_NO_ISSUED_DATE;
	DateTime? pASSPORT_NO_EXPIRY_DATE;
	string pASSPORT_NO_ISSUED_PLACE;
	string pROVINCE_CITY_CODE;
	string pROVINCE_CITY_OTHER;
	string dISTRICT_CODE;
	string dISTRICT_OTHER;
	string cOMMUNES_WARDS;
	string hOUSE_STREET;
	string aDDRESS;
	string cUSTOMER_GROUP_CODE;
	string rEMARK;
	DateTime? cREATE_DATE;
	string cREATE_BY;
	DateTime? uPDATE_DATE;
	string lAST_UPDATE_BY;
	string pICTURE_PATH;
	int? nUMBER_MARK;

	#endregion members
	#region Properties
	[PKSqlColumn("CUSTOMER_ID", SqlDbType.VarChar, null)]
	public string CUSTOMER_ID {
		get { return cUSTOMER_ID; }
		set{ cUSTOMER_ID = value; }
	}
	[SqlColumn("DEPT_CODE", SqlDbType.Int)]
	public int? DEPT_CODE {
		get { return dEPT_CODE; }
		set{ dEPT_CODE = value; }
	}
	[SqlColumn("FIRST_NAME", SqlDbType.NVarChar)]
	public string FIRST_NAME {
		get { return fIRST_NAME; }
		set{ fIRST_NAME = value; }
	}
	[SqlColumn("LAST_NAME", SqlDbType.NVarChar)]
	public string LAST_NAME {
		get { return lAST_NAME; }
		set{ lAST_NAME = value; }
	}
	[StringSqlColumn("OCCUPATION_CODE")]
	public string OCCUPATION_CODE {
		get { return oCCUPATION_CODE; }
		set{ oCCUPATION_CODE = value; }
	}
	[SqlColumn("OCCUPATION_OTHER", SqlDbType.NVarChar)]
	public string OCCUPATION_OTHER {
		get { return oCCUPATION_OTHER; }
		set{ oCCUPATION_OTHER = value; }
	}
	[StringSqlColumn("COUNTRY_CODE")]
	public string COUNTRY_CODE {
		get { return cOUNTRY_CODE; }
		set{ cOUNTRY_CODE = value; }
	}
	[StringSqlColumn("MARITAL_STATUS")]
	public string MARITAL_STATUS {
		get { return mARITAL_STATUS; }
		set{ mARITAL_STATUS = value; }
	}
	[SqlColumn("DATE_OF_BIRTH", SqlDbType.DateTime)]
	public DateTime? DATE_OF_BIRTH {
		get { return dATE_OF_BIRTH; }
		set{ dATE_OF_BIRTH = value; }
	}
	[SqlColumn("PLACE_OF_BIRTH", SqlDbType.NVarChar)]
	public string PLACE_OF_BIRTH {
		get { return pLACE_OF_BIRTH; }
		set{ pLACE_OF_BIRTH = value; }
	}
	[StringSqlColumn("SEX_CODE")]
	public string SEX_CODE {
		get { return sEX_CODE; }
		set{ sEX_CODE = value; }
	}
	[StringSqlColumn("BLOOD_CODE")]
	public string BLOOD_CODE {
		get { return bLOOD_CODE; }
		set{ bLOOD_CODE = value; }
	}
	[StringSqlColumn("RACE_CODE")]
	public string RACE_CODE {
		get { return rACE_CODE; }
		set{ rACE_CODE = value; }
	}
	[StringSqlColumn("RELIGION_CODE")]
	public string RELIGION_CODE {
		get { return rELIGION_CODE; }
		set{ rELIGION_CODE = value; }
	}
	[StringSqlColumn("TEL")]
	public string TEL {
		get { return tEL; }
		set{ tEL = value; }
	}
	[StringSqlColumn("FAX")]
	public string FAX {
		get { return fAX; }
		set{ fAX = value; }
	}
	[StringSqlColumn("MOBILE_PHONE")]
	public string MOBILE_PHONE {
		get { return mOBILE_PHONE; }
		set{ mOBILE_PHONE = value; }
	}
	[StringSqlColumn("EMAIL_ADDRESS")]
	public string EMAIL_ADDRESS {
		get { return eMAIL_ADDRESS; }
		set{ eMAIL_ADDRESS = value; }
	}
	[StringSqlColumn("ID_NO")]
	public string ID_NO {
		get { return iD_NO; }
		set{ iD_NO = value; }
	}
	[SqlColumn("ID_NO_ISSUED_DATE", SqlDbType.DateTime)]
	public DateTime? ID_NO_ISSUED_DATE {
		get { return iD_NO_ISSUED_DATE; }
		set{ iD_NO_ISSUED_DATE = value; }
	}
	[SqlColumn("ID_NO_ISSUED_PLACE", SqlDbType.NVarChar)]
	public string ID_NO_ISSUED_PLACE {
		get { return iD_NO_ISSUED_PLACE; }
		set{ iD_NO_ISSUED_PLACE = value; }
	}
	[StringSqlColumn("PASSPORT_NO")]
	public string PASSPORT_NO {
		get { return pASSPORT_NO; }
		set{ pASSPORT_NO = value; }
	}
	[SqlColumn("PASSPORT_NO_ISSUED_DATE", SqlDbType.DateTime)]
	public DateTime? PASSPORT_NO_ISSUED_DATE {
		get { return pASSPORT_NO_ISSUED_DATE; }
		set{ pASSPORT_NO_ISSUED_DATE = value; }
	}
	[SqlColumn("PASSPORT_NO_EXPIRY_DATE", SqlDbType.DateTime)]
	public DateTime? PASSPORT_NO_EXPIRY_DATE {
		get { return pASSPORT_NO_EXPIRY_DATE; }
		set{ pASSPORT_NO_EXPIRY_DATE = value; }
	}
	[SqlColumn("PASSPORT_NO_ISSUED_PLACE", SqlDbType.NVarChar)]
	public string PASSPORT_NO_ISSUED_PLACE {
		get { return pASSPORT_NO_ISSUED_PLACE; }
		set{ pASSPORT_NO_ISSUED_PLACE = value; }
	}
	[StringSqlColumn("PROVINCE_CITY_CODE")]
	public string PROVINCE_CITY_CODE {
		get { return pROVINCE_CITY_CODE; }
		set{ pROVINCE_CITY_CODE = value; }
	}
	[SqlColumn("PROVINCE_CITY_OTHER", SqlDbType.NVarChar)]
	public string PROVINCE_CITY_OTHER {
		get { return pROVINCE_CITY_OTHER; }
		set{ pROVINCE_CITY_OTHER = value; }
	}
	[StringSqlColumn("DISTRICT_CODE")]
	public string DISTRICT_CODE {
		get { return dISTRICT_CODE; }
		set{ dISTRICT_CODE = value; }
	}
	[SqlColumn("DISTRICT_OTHER", SqlDbType.NVarChar)]
	public string DISTRICT_OTHER {
		get { return dISTRICT_OTHER; }
		set{ dISTRICT_OTHER = value; }
	}
	[SqlColumn("COMMUNES_WARDS", SqlDbType.NVarChar)]
	public string COMMUNES_WARDS {
		get { return cOMMUNES_WARDS; }
		set{ cOMMUNES_WARDS = value; }
	}
	[SqlColumn("HOUSE_STREET", SqlDbType.NVarChar)]
	public string HOUSE_STREET {
		get { return hOUSE_STREET; }
		set{ hOUSE_STREET = value; }
	}
	[SqlColumn("ADDRESS", SqlDbType.NVarChar)]
	public string ADDRESS {
		get { return aDDRESS; }
		set{ aDDRESS = value; }
	}
	[StringSqlColumn("CUSTOMER_GROUP_CODE")]
	public string CUSTOMER_GROUP_CODE {
		get { return cUSTOMER_GROUP_CODE; }
		set{ cUSTOMER_GROUP_CODE = value; }
	}
	[SqlColumn("REMARK", SqlDbType.NVarChar)]
	public string REMARK {
		get { return rEMARK; }
		set{ rEMARK = value; }
	}
	[SqlColumn("CREATE_DATE", SqlDbType.DateTime)]
	public DateTime? CREATE_DATE {
		get { return cREATE_DATE; }
		set{ cREATE_DATE = value; }
	}
	[SqlColumn("CREATE_BY", SqlDbType.NVarChar)]
	public string CREATE_BY {
		get { return cREATE_BY; }
		set{ cREATE_BY = value; }
	}
	[SqlColumn("UPDATE_DATE", SqlDbType.DateTime)]
	public DateTime? UPDATE_DATE {
		get { return uPDATE_DATE; }
		set{ uPDATE_DATE = value; }
	}
	[SqlColumn("LAST_UPDATE_BY", SqlDbType.NVarChar)]
	public string LAST_UPDATE_BY {
		get { return lAST_UPDATE_BY; }
		set{ lAST_UPDATE_BY = value; }
	}
	[StringSqlColumn("PICTURE_PATH")]
	public string PICTURE_PATH {
		get { return pICTURE_PATH; }
		set{ pICTURE_PATH = value; }
	}
	[SqlColumn("NUMBER_MARK", SqlDbType.Int)]
	public int? NUMBER_MARK {
		get { return nUMBER_MARK; }
		set{ nUMBER_MARK = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public CUSTOMERS_TEMP() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<CUSTOMERS_TEMP> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<CUSTOMERS_TEMP>("CUSTOMERS_TEMP");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "CUSTOMERS_TEMP");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "CUSTOMERS_TEMP");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inCUSTOMER_ID"></param>
	public static List<CUSTOMERS_TEMP> ReadByCUSTOMER_ID(string inCUSTOMER_ID) {
		return rdodb_KTSqlDAC.ReadByParams<CUSTOMERS_TEMP>("CUSTOMERS_TEMP", rdodb_KTSqlDAC.newInParam("@CUSTOMER_ID", inCUSTOMER_ID));
	}
	#endregion DAC Methods 
 }
}
