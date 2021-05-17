using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class TRANSFER_SHIFT {
	#region members
	string tRANSFER_SHIFT_CODE;
	DateTime? dATE_SHIFT;
	string sTORECODE;
	string tRANSFER_BY;
	DateTime? dATE_TIME_TRANSFER;
	bool? iSFINISH;
	string aCCOUNT;
	string cOMPUTER_NAME;
	string eVENT_ID;

	#endregion members
	#region Properties
	[PKSqlColumn("TRANSFER_SHIFT_CODE", SqlDbType.VarChar, null)]
	public string TRANSFER_SHIFT_CODE {
		get { return tRANSFER_SHIFT_CODE; }
		set{ tRANSFER_SHIFT_CODE = value; }
	}
	[SqlColumn("DATE_SHIFT", SqlDbType.DateTime)]
	public DateTime? DATE_SHIFT {
		get { return dATE_SHIFT; }
		set{ dATE_SHIFT = value; }
	}
	[StringSqlColumn("STORECODE")]
	public string STORECODE {
		get { return sTORECODE; }
		set{ sTORECODE = value; }
	}
	[SqlColumn("TRANSFER_BY", SqlDbType.NVarChar)]
	public string TRANSFER_BY {
		get { return tRANSFER_BY; }
		set{ tRANSFER_BY = value; }
	}
	[SqlColumn("DATE_TIME_TRANSFER", SqlDbType.DateTime)]
	public DateTime? DATE_TIME_TRANSFER {
		get { return dATE_TIME_TRANSFER; }
		set{ dATE_TIME_TRANSFER = value; }
	}
	[SqlColumn("ISFINISH", SqlDbType.Bit)]
	public bool? ISFINISH {
		get { return iSFINISH; }
		set{ iSFINISH = value; }
	}
	[SqlColumn("ACCOUNT", SqlDbType.NVarChar)]
	public string ACCOUNT {
		get { return aCCOUNT; }
		set{ aCCOUNT = value; }
	}
	[SqlColumn("COMPUTER_NAME", SqlDbType.NVarChar)]
	public string COMPUTER_NAME {
		get { return cOMPUTER_NAME; }
		set{ cOMPUTER_NAME = value; }
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
	public TRANSFER_SHIFT() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<TRANSFER_SHIFT> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<TRANSFER_SHIFT>("TRANSFER_SHIFT");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "TRANSFER_SHIFT");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "TRANSFER_SHIFT");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inTRANSFER_SHIFT_CODE"></param>
	public static List<TRANSFER_SHIFT> ReadByTRANSFER_SHIFT_CODE(string inTRANSFER_SHIFT_CODE) {
		return rdodb_KTSqlDAC.ReadByParams<TRANSFER_SHIFT>("TRANSFER_SHIFT", rdodb_KTSqlDAC.newInParam("@TRANSFER_SHIFT_CODE", inTRANSFER_SHIFT_CODE));
	}
	/// <summary>
	///Read By Foreign Key
	/// </summary>
	/// <param name="inTRANSFER_BY"></param>
	public static List<TRANSFER_SHIFT> ReadByTRANSFER_BY(string inTRANSFER_BY) {
		return rdodb_KTSqlDAC.ReadByParams<TRANSFER_SHIFT>("TRANSFER_SHIFT", rdodb_KTSqlDAC.newInParam("@TRANSFER_BY", inTRANSFER_BY));
	}
	#endregion DAC Methods 
 }
}
