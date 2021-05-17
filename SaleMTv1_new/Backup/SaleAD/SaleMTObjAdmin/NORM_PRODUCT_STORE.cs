using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class NORM_PRODUCT_STORE {
	#region members
	Guid nORMCODE;
	string sTORECODE;
	string tYPE;
	string tRADEMARK;
	float qUANTITY;
	float aMOUNT;

	#endregion members
	#region Properties
	[PKSqlColumn("NORMCODE", SqlDbType.UniqueIdentifier, null)]
	public Guid NORMCODE {
		get { return nORMCODE; }
		set{ nORMCODE = value; }
	}
	[SqlColumn("STORECODE", SqlDbType.NVarChar)]
	public string STORECODE {
		get { return sTORECODE; }
		set{ sTORECODE = value; }
	}
	[SqlColumn("TYPE", SqlDbType.NVarChar)]
	public string TYPE {
		get { return tYPE; }
		set{ tYPE = value; }
	}
	[SqlColumn("TRADEMARK", SqlDbType.NVarChar)]
	public string TRADEMARK {
		get { return tRADEMARK; }
		set{ tRADEMARK = value; }
	}
	[SqlColumn("QUANTITY", SqlDbType.Float)]
	public float QUANTITY {
		get { return qUANTITY; }
		set{ qUANTITY = value; }
	}
	[SqlColumn("AMOUNT", SqlDbType.Float)]
	public float AMOUNT {
		get { return aMOUNT; }
		set{ aMOUNT = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public NORM_PRODUCT_STORE() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<NORM_PRODUCT_STORE> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<NORM_PRODUCT_STORE>("NORM_PRODUCT_STORE");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "NORM_PRODUCT_STORE");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "NORM_PRODUCT_STORE");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inNORMCODE"></param>
	public static List<NORM_PRODUCT_STORE> ReadByNORMCODE(Guid inNORMCODE) {
		return rdodb_KTSqlDAC.ReadByParams<NORM_PRODUCT_STORE>("NORM_PRODUCT_STORE", rdodb_KTSqlDAC.newInParam("@NORMCODE", inNORMCODE));
	}
	#endregion DAC Methods 
 }
}
