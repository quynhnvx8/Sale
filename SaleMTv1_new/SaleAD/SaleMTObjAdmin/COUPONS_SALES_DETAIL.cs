using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class COUPONS_SALES_DETAIL {
	#region members
	Guid cOUPONS_SALES_DETAIL_CODE;
	string cOUPONS_SALES_CODE;
	string cOUPONS_NO;
	DateTime iNPUT_DATE;
	string eVENT_ID;

	#endregion members
	#region Properties
	[PKSqlColumn("COUPONS_SALES_DETAIL_CODE", SqlDbType.UniqueIdentifier, null)]
	public Guid COUPONS_SALES_DETAIL_CODE {
		get { return cOUPONS_SALES_DETAIL_CODE; }
		set{ cOUPONS_SALES_DETAIL_CODE = value; }
	}
	[SqlColumn("COUPONS_SALES_CODE", SqlDbType.NVarChar)]
	public string COUPONS_SALES_CODE {
		get { return cOUPONS_SALES_CODE; }
		set{ cOUPONS_SALES_CODE = value; }
	}
	[SqlColumn("COUPONS_NO", SqlDbType.NVarChar)]
	public string COUPONS_NO {
		get { return cOUPONS_NO; }
		set{ cOUPONS_NO = value; }
	}
	[SqlColumn("INPUT_DATE", SqlDbType.DateTime)]
	public DateTime INPUT_DATE {
		get { return iNPUT_DATE; }
		set{ iNPUT_DATE = value; }
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
	public COUPONS_SALES_DETAIL() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<COUPONS_SALES_DETAIL> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<COUPONS_SALES_DETAIL>("COUPONS_SALES_DETAIL");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "COUPONS_SALES_DETAIL");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "COUPONS_SALES_DETAIL");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inCOUPONS_SALES_DETAIL_CODE"></param>
	public static List<COUPONS_SALES_DETAIL> ReadByCOUPONS_SALES_DETAIL_CODE(Guid inCOUPONS_SALES_DETAIL_CODE) {
		return rdodb_KTSqlDAC.ReadByParams<COUPONS_SALES_DETAIL>("COUPONS_SALES_DETAIL", rdodb_KTSqlDAC.newInParam("@COUPONS_SALES_DETAIL_CODE", inCOUPONS_SALES_DETAIL_CODE));
	}
	#endregion DAC Methods 
 }
}
