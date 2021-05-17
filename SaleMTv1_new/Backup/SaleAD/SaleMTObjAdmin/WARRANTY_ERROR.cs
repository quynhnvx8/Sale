using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class WARRANTY_ERROR {
	#region members
	string wARRANTY_ERROR_CODE;
	string iD_NO_RECEIPT;
	string wARRANTY_ERROR_REMARK;
	float? wARRANTY_ERROR_PRICE;
	float? wARRANTY_ERROR_PRICE_COMPANY;
	string eVENT_ID;

	#endregion members
	#region Properties
	[PKSqlColumn("WARRANTY_ERROR_CODE", SqlDbType.VarChar, null)]
	public string WARRANTY_ERROR_CODE {
		get { return wARRANTY_ERROR_CODE; }
		set{ wARRANTY_ERROR_CODE = value; }
	}
	[PKSqlColumn("ID_NO_RECEIPT", SqlDbType.VarChar, null)]
	public string ID_NO_RECEIPT {
		get { return iD_NO_RECEIPT; }
		set{ iD_NO_RECEIPT = value; }
	}
	[SqlColumn("WARRANTY_ERROR_REMARK", SqlDbType.NVarChar)]
	public string WARRANTY_ERROR_REMARK {
		get { return wARRANTY_ERROR_REMARK; }
		set{ wARRANTY_ERROR_REMARK = value; }
	}
	[SqlColumn("WARRANTY_ERROR_PRICE", SqlDbType.Float)]
	public float? WARRANTY_ERROR_PRICE {
		get { return wARRANTY_ERROR_PRICE; }
		set{ wARRANTY_ERROR_PRICE = value; }
	}
	[SqlColumn("WARRANTY_ERROR_PRICE_COMPANY", SqlDbType.Float)]
	public float? WARRANTY_ERROR_PRICE_COMPANY {
		get { return wARRANTY_ERROR_PRICE_COMPANY; }
		set{ wARRANTY_ERROR_PRICE_COMPANY = value; }
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
	public WARRANTY_ERROR() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<WARRANTY_ERROR> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<WARRANTY_ERROR>("WARRANTY_ERROR");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "WARRANTY_ERROR");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "WARRANTY_ERROR");
	}
	/// <summary>
	///Read By Foreign Key
	/// </summary>
	/// <param name="inWARRANTY_ERROR_CODE"></param>
	public static List<WARRANTY_ERROR> ReadByWARRANTY_ERROR_CODE(string inWARRANTY_ERROR_CODE) {
		return rdodb_KTSqlDAC.ReadByParams<WARRANTY_ERROR>("WARRANTY_ERROR", rdodb_KTSqlDAC.newInParam("@WARRANTY_ERROR_CODE", inWARRANTY_ERROR_CODE));
	}
	/// <summary>
	///Read By Foreign Key
	/// </summary>
	/// <param name="inID_NO_RECEIPT"></param>
	public static List<WARRANTY_ERROR> ReadByID_NO_RECEIPT(string inID_NO_RECEIPT) {
		return rdodb_KTSqlDAC.ReadByParams<WARRANTY_ERROR>("WARRANTY_ERROR", rdodb_KTSqlDAC.newInParam("@ID_NO_RECEIPT", inID_NO_RECEIPT));
	}
	#endregion DAC Methods 
 }
}
