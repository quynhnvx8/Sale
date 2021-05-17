using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class PARAMETER {
	#region members
	string pARAMETER_ID;
	string pARAMETER_VALUE;
	string dESCRIPTION;
	string gROUPS;
	DateTime? dATE_VALUE;
	bool? iS_LIST;

	#endregion members
	#region Properties
	[PKSqlColumn("PARAMETER_ID", SqlDbType.VarChar, null)]
	public string PARAMETER_ID {
		get { return pARAMETER_ID; }
		set{ pARAMETER_ID = value; }
	}
	[SqlColumn("PARAMETER_VALUE", SqlDbType.NVarChar)]
	public string PARAMETER_VALUE {
		get { return pARAMETER_VALUE; }
		set{ pARAMETER_VALUE = value; }
	}
	[SqlColumn("DESCRIPTION", SqlDbType.NVarChar)]
	public string DESCRIPTION {
		get { return dESCRIPTION; }
		set{ dESCRIPTION = value; }
	}
	[StringSqlColumn("GROUPS")]
	public string GROUPS {
		get { return gROUPS; }
		set{ gROUPS = value; }
	}
	[SqlColumn("DATE_VALUE", SqlDbType.DateTime)]
	public DateTime? DATE_VALUE {
		get { return dATE_VALUE; }
		set{ dATE_VALUE = value; }
	}
	[SqlColumn("IS_LIST", SqlDbType.Bit)]
	public bool? IS_LIST {
		get { return iS_LIST; }
		set{ iS_LIST = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public PARAMETER() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<PARAMETER> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<PARAMETER>("PARAMETER");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "PARAMETER");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "PARAMETER");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inPARAMETER_ID"></param>
	public static List<PARAMETER> ReadByPARAMETER_ID(string inPARAMETER_ID) {
		return rdodb_KTSqlDAC.ReadByParams<PARAMETER>("PARAMETER", rdodb_KTSqlDAC.newInParam("@PARAMETER_ID", inPARAMETER_ID));
	}
	#endregion DAC Methods 
 }
}
