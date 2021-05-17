using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class MASTER_PRODUCT_ATTRIBUTES {
	#region members
	string iD;
	string nAME;
	string tYPE;
	string dM;

	#endregion members
	#region Properties
	[PKSqlColumn("ID", SqlDbType.VarChar, null)]
	public string ID {
		get { return iD; }
		set{ iD = value; }
	}
	[SqlColumn("NAME", SqlDbType.NVarChar)]
	public string NAME {
		get { return nAME; }
		set{ nAME = value; }
	}
	[StringSqlColumn("TYPE")]
	public string TYPE {
		get { return tYPE; }
		set{ tYPE = value; }
	}
	[StringSqlColumn("DM")]
	public string DM {
		get { return dM; }
		set{ dM = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public MASTER_PRODUCT_ATTRIBUTES() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<MASTER_PRODUCT_ATTRIBUTES> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<MASTER_PRODUCT_ATTRIBUTES>("MASTER_PRODUCT_ATTRIBUTES");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "MASTER_PRODUCT_ATTRIBUTES");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "MASTER_PRODUCT_ATTRIBUTES");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inID"></param>
	public static List<MASTER_PRODUCT_ATTRIBUTES> ReadByID(string inID) {
		return rdodb_KTSqlDAC.ReadByParams<MASTER_PRODUCT_ATTRIBUTES>("MASTER_PRODUCT_ATTRIBUTES", rdodb_KTSqlDAC.newInParam("@ID", inID));
	}
	/// <summary>
	///Read By Foreign Key
	/// </summary>
	/// <param name="inTYPE"></param>
	public static List<MASTER_PRODUCT_ATTRIBUTES> ReadByTYPE(string inTYPE) {
		return rdodb_KTSqlDAC.ReadByParams<MASTER_PRODUCT_ATTRIBUTES>("MASTER_PRODUCT_ATTRIBUTES", rdodb_KTSqlDAC.newInParam("@TYPE", inTYPE));
	}
	/// <summary>
	///Read By Foreign Key
	/// </summary>
	/// <param name="inDM"></param>
	public static List<MASTER_PRODUCT_ATTRIBUTES> ReadByDM(string inDM) {
		object parameter = inDM ?? string.Empty;
		return rdodb_KTSqlDAC.ReadByParams<MASTER_PRODUCT_ATTRIBUTES>("MASTER_PRODUCT_ATTRIBUTES", rdodb_KTSqlDAC.newInParam("@DM", parameter));
	}
	#endregion DAC Methods 
 }
}
