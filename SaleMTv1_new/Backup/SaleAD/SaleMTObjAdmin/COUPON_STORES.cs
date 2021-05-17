using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class COUPON_STORES {
	#region members
	int dEPT_CODE;
	string cOUPON_NO;

	#endregion members
	#region Properties
    [PKSqlColumn("DEPT_CODE", SqlDbType.Int, false)]
	public int DEPT_CODE {
		get { return dEPT_CODE; }
		set{ dEPT_CODE = value; }
	}
	[PKSqlColumn("COUPON_NO", SqlDbType.VarChar, null)]
	public string COUPON_NO {
		get { return cOUPON_NO; }
		set{ cOUPON_NO = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public COUPON_STORES() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<COUPON_STORES> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<COUPON_STORES>("COUPON_STORES");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "COUPON_STORES");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "COUPON_STORES");
	}
	#endregion DAC Methods 
 }
}
