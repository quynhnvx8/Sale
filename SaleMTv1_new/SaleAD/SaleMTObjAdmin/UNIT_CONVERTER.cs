using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class UNIT_CONVERTER {
	#region members
	Guid cONVERSION_ID;
	string pRODUCT_ID;
	string eXCHANGE_ID;
	float? rATE;
	bool? iS_MININUM;

	#endregion members
	#region Properties
	[PKSqlColumn("CONVERSION_ID", SqlDbType.UniqueIdentifier, null)]
	public Guid CONVERSION_ID {
		get { return cONVERSION_ID; }
		set{ cONVERSION_ID = value; }
	}
	[StringSqlColumn("PRODUCT_ID")]
	public string PRODUCT_ID {
		get { return pRODUCT_ID; }
		set{ pRODUCT_ID = value; }
	}
	[StringSqlColumn("EXCHANGE_ID")]
	public string EXCHANGE_ID {
		get { return eXCHANGE_ID; }
		set{ eXCHANGE_ID = value; }
	}
	[SqlColumn("RATE", SqlDbType.Float)]
	public float? RATE {
		get { return rATE; }
		set{ rATE = value; }
	}
	[SqlColumn("IS_MININUM", SqlDbType.Bit)]
	public bool? IS_MININUM {
		get { return iS_MININUM; }
		set{ iS_MININUM = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public UNIT_CONVERTER() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<UNIT_CONVERTER> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<UNIT_CONVERTER>("UNIT_CONVERTER");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "UNIT_CONVERTER");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "UNIT_CONVERTER");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inCONVERSION_ID"></param>
	public static List<UNIT_CONVERTER> ReadByCONVERSION_ID(Guid inCONVERSION_ID) {
		return rdodb_KTSqlDAC.ReadByParams<UNIT_CONVERTER>("UNIT_CONVERTER", rdodb_KTSqlDAC.newInParam("@CONVERSION_ID", inCONVERSION_ID));
	}
	#endregion DAC Methods 
 }
}
