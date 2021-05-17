using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class PRODUCTS {
	#region members
	string pRODUCT_ID;
	string pRODUCT_NAME;
	string sHORT_NAME;
	string bARCODE;
	string uNIT;
	string tRADEMARK;
	string mANUFACTURE;
	string sIZE;
	string cOLOR;
	string cATEGORY;
	float? pRICE;
	string iMAGE_FOLDER;
	string iMAGE_DEFAULT;
	string pRODUCT_NAME_PRINT;
	string mA_CU;
	float? cONV_FACT;
	string uNIT1;
	string cAT;
	string uNIT_NAME;
	string uNIT_NAME1;
	string cOL_SEARCH;
	float? pRICE1;
	float? pRICE2;
	float? pRICE3;
	bool? aCTIVE;
	string rED_INVOICE_CAT;

	#endregion members
	#region Properties
	[PKSqlColumn("PRODUCT_ID", SqlDbType.VarChar, null)]
	public string PRODUCT_ID {
		get { return pRODUCT_ID; }
		set{ pRODUCT_ID = value; }
	}
	[SqlColumn("PRODUCT_NAME", SqlDbType.NVarChar)]
	public string PRODUCT_NAME {
		get { return pRODUCT_NAME; }
		set{ pRODUCT_NAME = value; }
	}
	[SqlColumn("SHORT_NAME", SqlDbType.NVarChar)]
	public string SHORT_NAME {
		get { return sHORT_NAME; }
		set{ sHORT_NAME = value; }
	}
	[StringSqlColumn("BARCODE")]
	public string BARCODE {
		get { return bARCODE; }
		set{ bARCODE = value; }
	}
	[StringSqlColumn("UNIT")]
	public string UNIT {
		get { return uNIT; }
		set{ uNIT = value; }
	}
	[StringSqlColumn("TRADEMARK")]
	public string TRADEMARK {
		get { return tRADEMARK; }
		set{ tRADEMARK = value; }
	}
	[StringSqlColumn("MANUFACTURE")]
	public string MANUFACTURE {
		get { return mANUFACTURE; }
		set{ mANUFACTURE = value; }
	}
	[StringSqlColumn("SIZE")]
	public string SIZE {
		get { return sIZE; }
		set{ sIZE = value; }
	}
	[StringSqlColumn("COLOR")]
	public string COLOR {
		get { return cOLOR; }
		set{ cOLOR = value; }
	}
	[StringSqlColumn("CATEGORY")]
	public string CATEGORY {
		get { return cATEGORY; }
		set{ cATEGORY = value; }
	}
	[SqlColumn("PRICE", SqlDbType.Float)]
	public float? PRICE {
		get { return pRICE; }
		set{ pRICE = value; }
	}
	[SqlColumn("IMAGE_FOLDER", SqlDbType.NVarChar)]
	public string IMAGE_FOLDER {
		get { return iMAGE_FOLDER; }
		set{ iMAGE_FOLDER = value; }
	}
	[SqlColumn("IMAGE_DEFAULT", SqlDbType.NVarChar)]
	public string IMAGE_DEFAULT {
		get { return iMAGE_DEFAULT; }
		set{ iMAGE_DEFAULT = value; }
	}
	[SqlColumn("PRODUCT_NAME_PRINT", SqlDbType.NVarChar)]
	public string PRODUCT_NAME_PRINT {
		get { return pRODUCT_NAME_PRINT; }
		set{ pRODUCT_NAME_PRINT = value; }
	}
	[SqlColumn("MA_CU", SqlDbType.NVarChar)]
	public string MA_CU {
		get { return mA_CU; }
		set{ mA_CU = value; }
	}
	[SqlColumn("CONV_FACT", SqlDbType.Float)]
	public float? CONV_FACT {
		get { return cONV_FACT; }
		set{ cONV_FACT = value; }
	}
	[StringSqlColumn("UNIT1")]
	public string UNIT1 {
		get { return uNIT1; }
		set{ uNIT1 = value; }
	}
	[SqlColumn("CAT", SqlDbType.NVarChar)]
	public string CAT {
		get { return cAT; }
		set{ cAT = value; }
	}
	[SqlColumn("UNIT_NAME", SqlDbType.NVarChar)]
	public string UNIT_NAME {
		get { return uNIT_NAME; }
		set{ uNIT_NAME = value; }
	}
	[SqlColumn("UNIT_NAME1", SqlDbType.NVarChar)]
	public string UNIT_NAME1 {
		get { return uNIT_NAME1; }
		set{ uNIT_NAME1 = value; }
	}
	[StringSqlColumn("COL_SEARCH")]
	public string COL_SEARCH {
		get { return cOL_SEARCH; }
		set{ cOL_SEARCH = value; }
	}
	[SqlColumn("PRICE1", SqlDbType.Float)]
	public float? PRICE1 {
		get { return pRICE1; }
		set{ pRICE1 = value; }
	}
	[SqlColumn("PRICE2", SqlDbType.Float)]
	public float? PRICE2 {
		get { return pRICE2; }
		set{ pRICE2 = value; }
	}
	[SqlColumn("PRICE3", SqlDbType.Float)]
	public float? PRICE3 {
		get { return pRICE3; }
		set{ pRICE3 = value; }
	}
	[SqlColumn("ACTIVE", SqlDbType.Bit)]
	public bool? ACTIVE {
		get { return aCTIVE; }
		set{ aCTIVE = value; }
	}
	[StringSqlColumn("RED_INVOICE_CAT")]
	public string RED_INVOICE_CAT {
		get { return rED_INVOICE_CAT; }
		set{ rED_INVOICE_CAT = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public PRODUCTS() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<PRODUCTS> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<PRODUCTS>("PRODUCTS");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "PRODUCTS");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "PRODUCTS");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inPRODUCT_ID"></param>
	public static List<PRODUCTS> ReadByPRODUCT_ID(string inPRODUCT_ID) {
		return rdodb_KTSqlDAC.ReadByParams<PRODUCTS>("PRODUCTS", rdodb_KTSqlDAC.newInParam("@PRODUCT_ID", inPRODUCT_ID));
	}
	#endregion DAC Methods 
 }
}
