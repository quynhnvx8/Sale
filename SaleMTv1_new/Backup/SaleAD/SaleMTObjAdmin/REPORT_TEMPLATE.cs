using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class REPORT_TEMPLATE {
	#region members
	string tEMPLATE_ID;
	string tEMPLATE_PATH;
	string tEMPLATE_NAME;
	DateTime? tEMPLATE_DATE;
	byte[] tEMPLATE_OBJECT;
	string tEMPLATE_TYPE;

	#endregion members
	#region Properties
	[PKSqlColumn("TEMPLATE_ID", SqlDbType.NVarChar, null)]
	public string TEMPLATE_ID {
		get { return tEMPLATE_ID; }
		set{ tEMPLATE_ID = value; }
	}
	[SqlColumn("TEMPLATE_PATH", SqlDbType.NVarChar)]
	public string TEMPLATE_PATH {
		get { return tEMPLATE_PATH; }
		set{ tEMPLATE_PATH = value; }
	}
	[SqlColumn("TEMPLATE_NAME", SqlDbType.NVarChar)]
	public string TEMPLATE_NAME {
		get { return tEMPLATE_NAME; }
		set{ tEMPLATE_NAME = value; }
	}
	[SqlColumn("TEMPLATE_DATE", SqlDbType.DateTime)]
	public DateTime? TEMPLATE_DATE {
		get { return tEMPLATE_DATE; }
		set{ tEMPLATE_DATE = value; }
	}
	[SqlColumn("TEMPLATE_OBJECT", SqlDbType.VarBinary)]
	public byte[] TEMPLATE_OBJECT {
		get { return tEMPLATE_OBJECT; }
		set{ tEMPLATE_OBJECT = value; }
	}
	[SqlColumn("TEMPLATE_TYPE", SqlDbType.NVarChar)]
	public string TEMPLATE_TYPE {
		get { return tEMPLATE_TYPE; }
		set{ tEMPLATE_TYPE = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public REPORT_TEMPLATE() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<REPORT_TEMPLATE> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<REPORT_TEMPLATE>("REPORT_TEMPLATE");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "REPORT_TEMPLATE");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "REPORT_TEMPLATE");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inTEMPLATE_ID"></param>
	public static List<REPORT_TEMPLATE> ReadByTEMPLATE_ID(string inTEMPLATE_ID) {
		return rdodb_KTSqlDAC.ReadByParams<REPORT_TEMPLATE>("REPORT_TEMPLATE", rdodb_KTSqlDAC.newInParam("@TEMPLATE_ID", inTEMPLATE_ID));
	}
	#endregion DAC Methods 
 }
}
