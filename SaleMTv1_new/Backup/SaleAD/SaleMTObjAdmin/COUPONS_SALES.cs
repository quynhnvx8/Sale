using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class COUPONS_SALES {
	#region members
	string cOUPONS_SALES_CODE;
	DateTime cOUPONS_SALES_DATE;
	DateTime iNPUT_DATE;
	string sTORE_CODE;
	string iNVOICE_CODE;
	string cUSTOMER_ID;
	string eMPLOYEE_ID;
	string rEMARK;
	string tRANSFER_SHIFT_CODE;
	string eVENT_ID;

	#endregion members
	#region Properties
	[PKSqlColumn("COUPONS_SALES_CODE", SqlDbType.NVarChar, null)]
	public string COUPONS_SALES_CODE {
		get { return cOUPONS_SALES_CODE; }
		set{ cOUPONS_SALES_CODE = value; }
	}
	[SqlColumn("COUPONS_SALES_DATE", SqlDbType.DateTime)]
	public DateTime COUPONS_SALES_DATE {
		get { return cOUPONS_SALES_DATE; }
		set{ cOUPONS_SALES_DATE = value; }
	}
	[SqlColumn("INPUT_DATE", SqlDbType.DateTime)]
	public DateTime INPUT_DATE {
		get { return iNPUT_DATE; }
		set{ iNPUT_DATE = value; }
	}
	[SqlColumn("STORE_CODE", SqlDbType.NVarChar)]
	public string STORE_CODE {
		get { return sTORE_CODE; }
		set{ sTORE_CODE = value; }
	}
	[SqlColumn("INVOICE_CODE", SqlDbType.NVarChar)]
	public string INVOICE_CODE {
		get { return iNVOICE_CODE; }
		set{ iNVOICE_CODE = value; }
	}
	[SqlColumn("CUSTOMER_ID", SqlDbType.NVarChar)]
	public string CUSTOMER_ID {
		get { return cUSTOMER_ID; }
		set{ cUSTOMER_ID = value; }
	}
	[SqlColumn("EMPLOYEE_ID", SqlDbType.NVarChar)]
	public string EMPLOYEE_ID {
		get { return eMPLOYEE_ID; }
		set{ eMPLOYEE_ID = value; }
	}
	[SqlColumn("REMARK", SqlDbType.NVarChar)]
	public string REMARK {
		get { return rEMARK; }
		set{ rEMARK = value; }
	}
	[SqlColumn("TRANSFER_SHIFT_CODE", SqlDbType.NVarChar)]
	public string TRANSFER_SHIFT_CODE {
		get { return tRANSFER_SHIFT_CODE; }
		set{ tRANSFER_SHIFT_CODE = value; }
	}
	[SqlColumn("EVENT_ID", SqlDbType.NVarChar)]
	public string EVENT_ID {
		get { return eVENT_ID; }
		set{ eVENT_ID = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public COUPONS_SALES() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<COUPONS_SALES> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<COUPONS_SALES>("COUPONS_SALES");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "COUPONS_SALES");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "COUPONS_SALES");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inCOUPONS_SALES_CODE"></param>
	public static List<COUPONS_SALES> ReadByCOUPONS_SALES_CODE(string inCOUPONS_SALES_CODE) {
		return rdodb_KTSqlDAC.ReadByParams<COUPONS_SALES>("COUPONS_SALES", rdodb_KTSqlDAC.newInParam("@COUPONS_SALES_CODE", inCOUPONS_SALES_CODE));
	}
	#endregion DAC Methods 
 }
}
