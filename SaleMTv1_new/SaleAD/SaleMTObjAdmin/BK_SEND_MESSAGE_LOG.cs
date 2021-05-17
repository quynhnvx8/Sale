using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class BK_SEND_MESSAGE_LOG {
	#region members
	Guid iD;
	string cUSTOMER_ID;
	int? tYPE_CONTACT;
	string cONTACT;
	string uSER_CONTACT;
	string eMAIL_FROM;
	DateTime? dATE;
	string sUBJECT;
	string cONTENT;
	string sTORE_CODE;
	string fILE_ATTACH;

	#endregion members
	#region Properties
	[PKSqlColumn("ID", SqlDbType.UniqueIdentifier, null)]
	public Guid ID {
		get { return iD; }
		set{ iD = value; }
	}
	[SqlColumn("CUSTOMER_ID", SqlDbType.NVarChar)]
	public string CUSTOMER_ID {
		get { return cUSTOMER_ID; }
		set{ cUSTOMER_ID = value; }
	}
	[SqlColumn("TYPE_CONTACT", SqlDbType.Int)]
	public int? TYPE_CONTACT {
		get { return tYPE_CONTACT; }
		set{ tYPE_CONTACT = value; }
	}
	[SqlColumn("CONTACT", SqlDbType.NVarChar)]
	public string CONTACT {
		get { return cONTACT; }
		set{ cONTACT = value; }
	}
	[SqlColumn("USER_CONTACT", SqlDbType.NVarChar)]
	public string USER_CONTACT {
		get { return uSER_CONTACT; }
		set{ uSER_CONTACT = value; }
	}
	[SqlColumn("EMAIL_FROM", SqlDbType.NVarChar)]
	public string EMAIL_FROM {
		get { return eMAIL_FROM; }
		set{ eMAIL_FROM = value; }
	}
	[SqlColumn("DATE", SqlDbType.DateTime)]
	public DateTime? DATE {
		get { return dATE; }
		set{ dATE = value; }
	}
	[SqlColumn("SUBJECT", SqlDbType.NText)]
	public string SUBJECT {
		get { return sUBJECT; }
		set{ sUBJECT = value; }
	}
	[SqlColumn("CONTENT", SqlDbType.NText)]
	public string CONTENT {
		get { return cONTENT; }
		set{ cONTENT = value; }
	}
	[SqlColumn("STORE_CODE", SqlDbType.NVarChar)]
	public string STORE_CODE {
		get { return sTORE_CODE; }
		set{ sTORE_CODE = value; }
	}
	[SqlColumn("FILE_ATTACH", SqlDbType.NVarChar)]
	public string FILE_ATTACH {
		get { return fILE_ATTACH; }
		set{ fILE_ATTACH = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public BK_SEND_MESSAGE_LOG() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<BK_SEND_MESSAGE_LOG> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<BK_SEND_MESSAGE_LOG>("BK_SEND_MESSAGE_LOG");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "BK_SEND_MESSAGE_LOG");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "BK_SEND_MESSAGE_LOG");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inID"></param>
	public static List<BK_SEND_MESSAGE_LOG> ReadByID(Guid inID) {
		return rdodb_KTSqlDAC.ReadByParams<BK_SEND_MESSAGE_LOG>("BK_SEND_MESSAGE_LOG", rdodb_KTSqlDAC.newInParam("@ID", inID));
	}
	#endregion DAC Methods 
 }
}
