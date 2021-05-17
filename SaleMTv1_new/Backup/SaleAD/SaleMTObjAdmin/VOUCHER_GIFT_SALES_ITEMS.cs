using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class VOUCHER_GIFT_SALES_ITEMS {
	#region members
	Guid iD;
	string iNVOICE_ID;
	string vOUCHER_GIFT_ITEM_NO;
	string eVENT_ID;

	#endregion members
	#region Properties
	[PKSqlColumn("ID", SqlDbType.UniqueIdentifier, null)]
	public Guid ID {
		get { return iD; }
		set{ iD = value; }
	}
	[StringSqlColumn("INVOICE_ID")]
	public string INVOICE_ID {
		get { return iNVOICE_ID; }
		set{ iNVOICE_ID = value; }
	}
	[StringSqlColumn("VOUCHER_GIFT_ITEM_NO")]
	public string VOUCHER_GIFT_ITEM_NO {
		get { return vOUCHER_GIFT_ITEM_NO; }
		set{ vOUCHER_GIFT_ITEM_NO = value; }
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
	public VOUCHER_GIFT_SALES_ITEMS() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<VOUCHER_GIFT_SALES_ITEMS> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<VOUCHER_GIFT_SALES_ITEMS>("VOUCHER_GIFT_SALES_ITEMS");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "VOUCHER_GIFT_SALES_ITEMS");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "VOUCHER_GIFT_SALES_ITEMS");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inID"></param>
	public static List<VOUCHER_GIFT_SALES_ITEMS> ReadByID(Guid inID) {
		return rdodb_KTSqlDAC.ReadByParams<VOUCHER_GIFT_SALES_ITEMS>("VOUCHER_GIFT_SALES_ITEMS", rdodb_KTSqlDAC.newInParam("@ID", inID));
	}
	#endregion DAC Methods 
 }
}
