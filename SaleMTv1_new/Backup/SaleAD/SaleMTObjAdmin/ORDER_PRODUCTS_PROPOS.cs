using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class ORDER_PRODUCTS_PROPOS {
	#region members
	string oRDER_PRODUCTS_PRO_ID;
	DateTime oRDER_DATE;
	DateTime iNPUT_DATE;
	DateTime eXPECTED_DATE;
	string sUPPLIER_ID;
	string rEMARKS;
	string rEMARKS_STATUS;
	string rEMARKS_STATUS_REALLY;
	DateTime? eXPECTED_DATE_REALLY;
	string oRDER_ID;
	string eVALUATION;
	string rEMARKS_EVALUATION;
	DateTime? eVALUATION_DATE;
	string eMPLOYEE_ID;

	#endregion members
	#region Properties
	[PKSqlColumn("ORDER_PRODUCTS_PRO_ID", SqlDbType.NVarChar, null)]
	public string ORDER_PRODUCTS_PRO_ID {
		get { return oRDER_PRODUCTS_PRO_ID; }
		set{ oRDER_PRODUCTS_PRO_ID = value; }
	}
	[SqlColumn("ORDER_DATE", SqlDbType.DateTime)]
	public DateTime ORDER_DATE {
		get { return oRDER_DATE; }
		set{ oRDER_DATE = value; }
	}
	[SqlColumn("INPUT_DATE", SqlDbType.DateTime)]
	public DateTime INPUT_DATE {
		get { return iNPUT_DATE; }
		set{ iNPUT_DATE = value; }
	}
	[SqlColumn("EXPECTED_DATE", SqlDbType.DateTime)]
	public DateTime EXPECTED_DATE {
		get { return eXPECTED_DATE; }
		set{ eXPECTED_DATE = value; }
	}
	[SqlColumn("SUPPLIER_ID", SqlDbType.NVarChar)]
	public string SUPPLIER_ID {
		get { return sUPPLIER_ID; }
		set{ sUPPLIER_ID = value; }
	}
	[SqlColumn("REMARKS", SqlDbType.NVarChar)]
	public string REMARKS {
		get { return rEMARKS; }
		set{ rEMARKS = value; }
	}
	[SqlColumn("REMARKS_STATUS", SqlDbType.NVarChar)]
	public string REMARKS_STATUS {
		get { return rEMARKS_STATUS; }
		set{ rEMARKS_STATUS = value; }
	}
	[SqlColumn("REMARKS_STATUS_REALLY", SqlDbType.NVarChar)]
	public string REMARKS_STATUS_REALLY {
		get { return rEMARKS_STATUS_REALLY; }
		set{ rEMARKS_STATUS_REALLY = value; }
	}
	[SqlColumn("EXPECTED_DATE_REALLY", SqlDbType.DateTime)]
	public DateTime? EXPECTED_DATE_REALLY {
		get { return eXPECTED_DATE_REALLY; }
		set{ eXPECTED_DATE_REALLY = value; }
	}
	[SqlColumn("ORDER_ID", SqlDbType.NVarChar)]
	public string ORDER_ID {
		get { return oRDER_ID; }
		set{ oRDER_ID = value; }
	}
	[SqlColumn("EVALUATION", SqlDbType.NVarChar)]
	public string EVALUATION {
		get { return eVALUATION; }
		set{ eVALUATION = value; }
	}
	[SqlColumn("REMARKS_EVALUATION", SqlDbType.NVarChar)]
	public string REMARKS_EVALUATION {
		get { return rEMARKS_EVALUATION; }
		set{ rEMARKS_EVALUATION = value; }
	}
	[SqlColumn("EVALUATION_DATE", SqlDbType.DateTime)]
	public DateTime? EVALUATION_DATE {
		get { return eVALUATION_DATE; }
		set{ eVALUATION_DATE = value; }
	}
	[SqlColumn("EMPLOYEE_ID", SqlDbType.NVarChar)]
	public string EMPLOYEE_ID {
		get { return eMPLOYEE_ID; }
		set{ eMPLOYEE_ID = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public ORDER_PRODUCTS_PROPOS() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<ORDER_PRODUCTS_PROPOS> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<ORDER_PRODUCTS_PROPOS>("ORDER_PRODUCTS_PROPOS");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "ORDER_PRODUCTS_PROPOS");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "ORDER_PRODUCTS_PROPOS");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inORDER_PRODUCTS_PRO_ID"></param>
	public static List<ORDER_PRODUCTS_PROPOS> ReadByORDER_PRODUCTS_PRO_ID(string inORDER_PRODUCTS_PRO_ID) {
		return rdodb_KTSqlDAC.ReadByParams<ORDER_PRODUCTS_PROPOS>("ORDER_PRODUCTS_PROPOS", rdodb_KTSqlDAC.newInParam("@ORDER_PRODUCTS_PRO_ID", inORDER_PRODUCTS_PRO_ID));
	}
	#endregion DAC Methods 
 }
}
