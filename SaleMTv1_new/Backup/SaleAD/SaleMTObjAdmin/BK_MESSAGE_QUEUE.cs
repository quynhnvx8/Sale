using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class BK_MESSAGE_QUEUE {
	#region members
	string eMAIL_FROM;
	string eMAIL_TO;
	string eMAIL_CC;
	string eMAIL_BCC;
	string sUBJECT;
	string eMAIL_CONTENT;
	string aTTACH_PATH;
	DateTime? dATE_SEND;
	int? iMPORTANCE;
	int pRIORITY;
	int? sTATUS;
	Guid mESSAGE_ID;
	string eRROR_MESSAGE;
	string dISPLAY_NAME;

	#endregion members
	#region Properties
	[StringSqlColumn("EMAIL_FROM")]
	public string EMAIL_FROM {
		get { return eMAIL_FROM; }
		set{ eMAIL_FROM = value; }
	}
	[SqlColumn("EMAIL_TO", SqlDbType.NText)]
	public string EMAIL_TO {
		get { return eMAIL_TO; }
		set{ eMAIL_TO = value; }
	}
	[SqlColumn("EMAIL_CC", SqlDbType.NText)]
	public string EMAIL_CC {
		get { return eMAIL_CC; }
		set{ eMAIL_CC = value; }
	}
	[SqlColumn("EMAIL_BCC", SqlDbType.NText)]
	public string EMAIL_BCC {
		get { return eMAIL_BCC; }
		set{ eMAIL_BCC = value; }
	}
	[SqlColumn("SUBJECT", SqlDbType.NText)]
	public string SUBJECT {
		get { return sUBJECT; }
		set{ sUBJECT = value; }
	}
	[SqlColumn("EMAIL_CONTENT", SqlDbType.NText)]
	public string EMAIL_CONTENT {
		get { return eMAIL_CONTENT; }
		set{ eMAIL_CONTENT = value; }
	}
	[SqlColumn("ATTACH_PATH", SqlDbType.NText)]
	public string ATTACH_PATH {
		get { return aTTACH_PATH; }
		set{ aTTACH_PATH = value; }
	}
	[SqlColumn("DATE_SEND", SqlDbType.DateTime)]
	public DateTime? DATE_SEND {
		get { return dATE_SEND; }
		set{ dATE_SEND = value; }
	}
	[SqlColumn("IMPORTANCE", SqlDbType.Int)]
	public int? IMPORTANCE {
		get { return iMPORTANCE; }
		set{ iMPORTANCE = value; }
	}
	[SqlColumn("PRIORITY", SqlDbType.Int)]
	public int PRIORITY {
		get { return pRIORITY; }
		set{ pRIORITY = value; }
	}
	[SqlColumn("STATUS", SqlDbType.Int)]
	public int? STATUS {
		get { return sTATUS; }
		set{ sTATUS = value; }
	}
	[PKSqlColumn("MESSAGE_ID", SqlDbType.UniqueIdentifier, null)]
	public Guid MESSAGE_ID {
		get { return mESSAGE_ID; }
		set{ mESSAGE_ID = value; }
	}
	[SqlColumn("ERROR_MESSAGE", SqlDbType.Text)]
	public string ERROR_MESSAGE {
		get { return eRROR_MESSAGE; }
		set{ eRROR_MESSAGE = value; }
	}
	[SqlColumn("DISPLAY_NAME", SqlDbType.NVarChar)]
	public string DISPLAY_NAME {
		get { return dISPLAY_NAME; }
		set{ dISPLAY_NAME = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public BK_MESSAGE_QUEUE() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<BK_MESSAGE_QUEUE> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<BK_MESSAGE_QUEUE>("BK_MESSAGE_QUEUE");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "BK_MESSAGE_QUEUE");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "BK_MESSAGE_QUEUE");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inMESSAGE_ID"></param>
	public static List<BK_MESSAGE_QUEUE> ReadByMESSAGE_ID(Guid inMESSAGE_ID) {
		return rdodb_KTSqlDAC.ReadByParams<BK_MESSAGE_QUEUE>("BK_MESSAGE_QUEUE", rdodb_KTSqlDAC.newInParam("@MESSAGE_ID", inMESSAGE_ID));
	}
	#endregion DAC Methods 
 }
}
