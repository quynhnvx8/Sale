using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class SUPPLIER_ORDERS_DETAIL {
	#region members
	Guid dETAIL_ID;
	string oRDER_ID;
	string sUPPLIER_ID;
	string pERFORMANCE;
	DateTime? cONTACT_DATE;
	string cONTACT_PERSON;
	string rEMARK;

	#endregion members
	#region Properties
	[PKSqlColumn("DETAIL_ID", SqlDbType.UniqueIdentifier, null)]
	public Guid DETAIL_ID {
		get { return dETAIL_ID; }
		set{ dETAIL_ID = value; }
	}
	[StringSqlColumn("ORDER_ID")]
	public string ORDER_ID {
		get { return oRDER_ID; }
		set{ oRDER_ID = value; }
	}
	[StringSqlColumn("SUPPLIER_ID")]
	public string SUPPLIER_ID {
		get { return sUPPLIER_ID; }
		set{ sUPPLIER_ID = value; }
	}
	[StringSqlColumn("PERFORMANCE")]
	public string PERFORMANCE {
		get { return pERFORMANCE; }
		set{ pERFORMANCE = value; }
	}
	[SqlColumn("CONTACT_DATE", SqlDbType.DateTime)]
	public DateTime? CONTACT_DATE {
		get { return cONTACT_DATE; }
		set{ cONTACT_DATE = value; }
	}
	[SqlColumn("CONTACT_PERSON", SqlDbType.NVarChar)]
	public string CONTACT_PERSON {
		get { return cONTACT_PERSON; }
		set{ cONTACT_PERSON = value; }
	}
	[SqlColumn("REMARK", SqlDbType.NVarChar)]
	public string REMARK {
		get { return rEMARK; }
		set{ rEMARK = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public SUPPLIER_ORDERS_DETAIL() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<SUPPLIER_ORDERS_DETAIL> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<SUPPLIER_ORDERS_DETAIL>("SUPPLIER_ORDERS_DETAIL");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "SUPPLIER_ORDERS_DETAIL");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "SUPPLIER_ORDERS_DETAIL");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inDETAIL_ID"></param>
	public static List<SUPPLIER_ORDERS_DETAIL> ReadByDETAIL_ID(Guid inDETAIL_ID) {
		return rdodb_KTSqlDAC.ReadByParams<SUPPLIER_ORDERS_DETAIL>("SUPPLIER_ORDERS_DETAIL", rdodb_KTSqlDAC.newInParam("@DETAIL_ID", inDETAIL_ID));
	}
	#endregion DAC Methods 
 }
}
