using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class PERMISSIONS {
	#region members
	string iDROLE;
	string iDRESOURCE;
	bool? pER_PRINT;
	bool? pER_INSERT;
	bool? pER_UPDATE;
	bool? pER_DELETE;

	#endregion members
	#region Properties
	[PKSqlColumn("IDROLE", SqlDbType.VarChar, null)]
	public string IDROLE {
		get { return iDROLE; }
		set{ iDROLE = value; }
	}
	[PKSqlColumn("IDRESOURCE", SqlDbType.VarChar, null)]
	public string IDRESOURCE {
		get { return iDRESOURCE; }
		set{ iDRESOURCE = value; }
	}
	[SqlColumn("PER_PRINT", SqlDbType.Bit)]
	public bool? PER_PRINT {
		get { return pER_PRINT; }
		set{ pER_PRINT = value; }
	}
	[SqlColumn("PER_INSERT", SqlDbType.Bit)]
	public bool? PER_INSERT {
		get { return pER_INSERT; }
		set{ pER_INSERT = value; }
	}
	[SqlColumn("PER_UPDATE", SqlDbType.Bit)]
	public bool? PER_UPDATE {
		get { return pER_UPDATE; }
		set{ pER_UPDATE = value; }
	}
	[SqlColumn("PER_DELETE", SqlDbType.Bit)]
	public bool? PER_DELETE {
		get { return pER_DELETE; }
		set{ pER_DELETE = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public PERMISSIONS() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<PERMISSIONS> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<PERMISSIONS>("PERMISSIONS");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "PERMISSIONS");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "PERMISSIONS");
	}
	/// <summary>
	///Read By Foreign Key
	/// </summary>
	/// <param name="inIDROLE"></param>
	public static List<PERMISSIONS> ReadByIDROLE(string inIDROLE) {
		return rdodb_KTSqlDAC.ReadByParams<PERMISSIONS>("PERMISSIONS", rdodb_KTSqlDAC.newInParam("@IDROLE", inIDROLE));
	}
	#endregion DAC Methods 
 }
}
