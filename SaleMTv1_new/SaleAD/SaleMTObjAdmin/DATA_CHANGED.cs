using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class DATA_CHANGED 
{
	#region members
	long id;
	string xMLContent;
	string storeCode;
	DateTime? cREATE_DATE;
	string iPAddress;
	string computerName;
	string priority;

	#endregion members
	#region Properties
	[PKSqlColumn("AutoId", SqlDbType.BigInt, 0)]
	public long Id {
		get { return id; }
		set{ id = value; }
	}
	[SqlColumn("XMLContent", SqlDbType.NText)]
	public string XMLContent {
		get { return xMLContent; }
		set{ xMLContent = value; }
	}
	[StringSqlColumn("StoreCode")]
	public string StoreCode {
		get { return storeCode; }
		set{ storeCode = value; }
	}
	[SqlColumn("CREATE_DATE", SqlDbType.DateTime)]
	public DateTime? CREATE_DATE {
		get { return cREATE_DATE; }
		set{ cREATE_DATE = value; }
	}
	[StringSqlColumn("IPAddress")]
	public string IPAddress {
		get { return iPAddress; }
		set{ iPAddress = value; }
	}
	[StringSqlColumn("ComputerName")]
	public string ComputerName {
		get { return computerName; }
		set{ computerName = value; }
	}
	[StringSqlColumn("Priority")]
	public string Priority {
		get { return priority; }
		set{ priority = value; }
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
	public DATA_CHANGED() { }
	/// <summary>
	///Gets item by Id.
	/// </summary>
	/// <param name="inId"></param>
	public DATA_CHANGED(int inId) {
		this.id = inId;
		populate();
	}

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<DATA_CHANGED> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<DATA_CHANGED>("DATA_CHANGED");
	}
	/// <summary>
	///Populates item from database by its id.
	/// </summary>
	private void populate() {
		rdodb_KTSqlDAC.ReadById<DATA_CHANGED>(this, "DATA_CHANGED");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "DATA_CHANGED");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "DATA_CHANGED");
	}
	#endregion DAC Methods 
 }
}
