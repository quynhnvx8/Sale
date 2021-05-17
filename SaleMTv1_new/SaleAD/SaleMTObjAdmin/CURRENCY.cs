using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class CURRENCY {
	#region members
	string cURRENCY_ID;
	string cURRENCY_NAME;
	bool iS_MAIN_CUR;
	string rEMARK;

	#endregion members
	#region Properties
	[PKSqlColumn("CURRENCY_ID", SqlDbType.VarChar, null)]
	public string CURRENCY_ID {
		get { return cURRENCY_ID; }
		set{ cURRENCY_ID = value; }
	}
	[SqlColumn("CURRENCY_NAME", SqlDbType.NVarChar)]
	public string CURRENCY_NAME {
		get { return cURRENCY_NAME; }
		set{ cURRENCY_NAME = value; }
	}
	[SqlColumn("IS_MAIN_CUR", SqlDbType.Bit)]
	public bool IS_MAIN_CUR {
		get { return iS_MAIN_CUR; }
		set{ iS_MAIN_CUR = value; }
	}
	[SqlColumn("REMARK", SqlDbType.NVarChar)]
	public string REMARK {
		get { return rEMARK; }
		set{ rEMARK = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public CURRENCY() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<CURRENCY> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<CURRENCY>("CURRENCY");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "CURRENCY");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "CURRENCY");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inCURRENCY_ID"></param>
	public static List<CURRENCY> ReadByCURRENCY_ID(string inCURRENCY_ID) {
		return rdodb_KTSqlDAC.ReadByParams<CURRENCY>("CURRENCY", rdodb_KTSqlDAC.newInParam("@CURRENCY_ID", inCURRENCY_ID));
	}
	#endregion DAC Methods 
 }
}
