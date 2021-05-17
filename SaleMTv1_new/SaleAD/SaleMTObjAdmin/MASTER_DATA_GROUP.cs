using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class MASTER_DATA_GROUP {
	#region members
	string mASTER_GROUP;
	string pREFIX;
	string pARENT_GROUP;
	bool? isSystem;
	string mASTER_GROUP_NAME;
	string dESCRIPTION;

	#endregion members
	#region Properties
	[PKSqlColumn("MASTER_GROUP", SqlDbType.VarChar, null)]
	public string MASTER_GROUP {
		get { return mASTER_GROUP; }
		set{ mASTER_GROUP = value; }
	}
	[StringSqlColumn("PREFIX")]
	public string PREFIX {
		get { return pREFIX; }
		set{ pREFIX = value; }
	}
	[StringSqlColumn("PARENT_GROUP")]
	public string PARENT_GROUP {
		get { return pARENT_GROUP; }
		set{ pARENT_GROUP = value; }
	}
	[SqlColumn("IsSystem", SqlDbType.Bit)]
	public bool? IsSystem {
		get { return isSystem; }
		set{ isSystem = value; }
	}
	[SqlColumn("MASTER_GROUP_NAME", SqlDbType.NVarChar)]
	public string MASTER_GROUP_NAME {
		get { return mASTER_GROUP_NAME; }
		set{ mASTER_GROUP_NAME = value; }
	}
	[SqlColumn("DESCRIPTION", SqlDbType.NVarChar)]
	public string DESCRIPTION {
		get { return dESCRIPTION; }
		set{ dESCRIPTION = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public MASTER_DATA_GROUP() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<MASTER_DATA_GROUP> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<MASTER_DATA_GROUP>("MASTER_DATA_GROUP");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "MASTER_DATA_GROUP");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "MASTER_DATA_GROUP");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inMASTER_GROUP"></param>
	public static List<MASTER_DATA_GROUP> ReadByMASTER_GROUP(string inMASTER_GROUP) {
		return rdodb_KTSqlDAC.ReadByParams<MASTER_DATA_GROUP>("MASTER_DATA_GROUP", rdodb_KTSqlDAC.newInParam("@MASTER_GROUP", inMASTER_GROUP));
	}
	#endregion DAC Methods 
 }
}
