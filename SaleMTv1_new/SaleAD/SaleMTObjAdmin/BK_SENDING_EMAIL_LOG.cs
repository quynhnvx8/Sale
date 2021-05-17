using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class BK_SENDING_EMAIL_LOG  
{
	#region members
	decimal id;
	string sUBJECT;
	string eMAIL_CONTENT;
	string fROM_ADDRESS;
	DateTime? sENDING_DATE;
	bool? sENDING_TYPE;
	string fILE_ATTACH;

	#endregion members
	#region Properties
	[PKSqlColumn("SENDING_ID", SqlDbType.Decimal, null)]
	public decimal Id {
		get { return id; }
		set{ id = value; }
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
	[SqlColumn("FROM_ADDRESS", SqlDbType.NVarChar)]
	public string FROM_ADDRESS {
		get { return fROM_ADDRESS; }
		set{ fROM_ADDRESS = value; }
	}
	[SqlColumn("SENDING_DATE", SqlDbType.DateTime)]
	public DateTime? SENDING_DATE {
		get { return sENDING_DATE; }
		set{ sENDING_DATE = value; }
	}
	[SqlColumn("SENDING_TYPE", SqlDbType.Bit)]
	public bool? SENDING_TYPE {
		get { return sENDING_TYPE; }
		set{ sENDING_TYPE = value; }
	}
	[SqlColumn("FILE_ATTACH", SqlDbType.NVarChar)]
	public string FILE_ATTACH {
		get { return fILE_ATTACH; }
		set{ fILE_ATTACH = value; }
	}

	#endregion Properties
	#region IsNew()
	public bool IsNew() {
		return id == 0; 
	}

	#endregion IsNew()
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public BK_SENDING_EMAIL_LOG() { }
	/// <summary>
	///Gets item by Id.
	/// </summary>
	/// <param name="inId"></param>
	public BK_SENDING_EMAIL_LOG(int inId) {
		this.id = inId;
		populate();
	}

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<BK_SENDING_EMAIL_LOG> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<BK_SENDING_EMAIL_LOG>("BK_SENDING_EMAIL_LOG");
	}
	/// <summary>
	///Populates item from database by its id.
	/// </summary>
	private void populate() {
		rdodb_KTSqlDAC.ReadById<BK_SENDING_EMAIL_LOG>(this, "BK_SENDING_EMAIL_LOG");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "BK_SENDING_EMAIL_LOG");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "BK_SENDING_EMAIL_LOG");
	}
	#endregion DAC Methods 
 }
}
