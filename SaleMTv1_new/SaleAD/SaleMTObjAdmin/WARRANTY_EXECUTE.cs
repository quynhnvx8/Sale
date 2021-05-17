using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class WARRANTY_EXECUTE {
	#region members
	string iD_NO_RECEIPT;
	string wARRANTY_STATUS_CODE;
	DateTime? wARRANTY_EXECUTE_DATE;
	string wARRANTY_EXECUTE_REMARK;
	string eVENT_ID;

	#endregion members
	#region Properties
	[PKSqlColumn("ID_NO_RECEIPT", SqlDbType.VarChar, null)]
	public string ID_NO_RECEIPT {
		get { return iD_NO_RECEIPT; }
		set{ iD_NO_RECEIPT = value; }
	}
	[PKSqlColumn("WARRANTY_STATUS_CODE", SqlDbType.VarChar, null)]
	public string WARRANTY_STATUS_CODE {
		get { return wARRANTY_STATUS_CODE; }
		set{ wARRANTY_STATUS_CODE = value; }
	}
	[SqlColumn("WARRANTY_EXECUTE_DATE", SqlDbType.DateTime)]
	public DateTime? WARRANTY_EXECUTE_DATE {
		get { return wARRANTY_EXECUTE_DATE; }
		set{ wARRANTY_EXECUTE_DATE = value; }
	}
	[SqlColumn("WARRANTY_EXECUTE_REMARK", SqlDbType.NVarChar)]
	public string WARRANTY_EXECUTE_REMARK {
		get { return wARRANTY_EXECUTE_REMARK; }
		set{ wARRANTY_EXECUTE_REMARK = value; }
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
	public WARRANTY_EXECUTE() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<WARRANTY_EXECUTE> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<WARRANTY_EXECUTE>("WARRANTY_EXECUTE");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "WARRANTY_EXECUTE");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "WARRANTY_EXECUTE");
	}
	/// <summary>
	///Read By Foreign Key
	/// </summary>
	/// <param name="inID_NO_RECEIPT"></param>
	public static List<WARRANTY_EXECUTE> ReadByID_NO_RECEIPT(string inID_NO_RECEIPT) {
		return rdodb_KTSqlDAC.ReadByParams<WARRANTY_EXECUTE>("WARRANTY_EXECUTE", rdodb_KTSqlDAC.newInParam("@ID_NO_RECEIPT", inID_NO_RECEIPT));
	}
	/// <summary>
	///Read By Foreign Key
	/// </summary>
	/// <param name="inWARRANTY_STATUS_CODE"></param>
	public static List<WARRANTY_EXECUTE> ReadByWARRANTY_STATUS_CODE(string inWARRANTY_STATUS_CODE) {
		return rdodb_KTSqlDAC.ReadByParams<WARRANTY_EXECUTE>("WARRANTY_EXECUTE", rdodb_KTSqlDAC.newInParam("@WARRANTY_STATUS_CODE", inWARRANTY_STATUS_CODE));
	}
	#endregion DAC Methods 
 }
}
