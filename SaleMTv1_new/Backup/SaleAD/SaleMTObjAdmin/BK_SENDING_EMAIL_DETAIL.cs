using System;
using System.Collections.Generic;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using SaleMTDataAccessLayer.SaleMTDAL;
  namespace SaleAD.SaleMTObjAdmin{


public class BK_SENDING_EMAIL_DETAIL {
	#region members
	Guid aUTO_ID;
	decimal sENDING_ID;
	string tO_ADDRESS;
	string cUSTOMER_ID;
	string fIRST_NAME;
	string lAST_NAME;

	#endregion members
	#region Properties
	[PKSqlColumn("AUTO_ID", SqlDbType.UniqueIdentifier, null)]
	public Guid AUTO_ID {
		get { return aUTO_ID; }
		set{ aUTO_ID = value; }
	}
	[SqlColumn("SENDING_ID", SqlDbType.Decimal)]
	public decimal SENDING_ID {
		get { return sENDING_ID; }
		set{ sENDING_ID = value; }
	}
	[SqlColumn("TO_ADDRESS", SqlDbType.NText)]
	public string TO_ADDRESS {
		get { return tO_ADDRESS; }
		set{ tO_ADDRESS = value; }
	}
	[StringSqlColumn("CUSTOMER_ID")]
	public string CUSTOMER_ID {
		get { return cUSTOMER_ID; }
		set{ cUSTOMER_ID = value; }
	}
	[SqlColumn("FIRST_NAME", SqlDbType.NVarChar)]
	public string FIRST_NAME {
		get { return fIRST_NAME; }
		set{ fIRST_NAME = value; }
	}
	[SqlColumn("LAST_NAME", SqlDbType.NVarChar)]
	public string LAST_NAME {
		get { return lAST_NAME; }
		set{ lAST_NAME = value; }
	}

	#endregion Properties
	#region Constructors
	/// <summary>
	///Default Constructor. Required by DAL Helper
	/// </summary>
	public BK_SENDING_EMAIL_DETAIL() { }

	#endregion Constructors
	#region DAC Methods
	/// <summary>
	///Reads all items in database.
	/// </summary>
	public static List<BK_SENDING_EMAIL_DETAIL> ReadAll() {
		return rdodb_KTSqlDAC.ReadAll<BK_SENDING_EMAIL_DETAIL>("BK_SENDING_EMAIL_DETAIL");
	}
	/// <summary>
	///Saves item to database.
	/// </summary>
	public void Save() {
		rdodb_KTSqlDAC.Save(this, "BK_SENDING_EMAIL_DETAIL");
	}
	/// <summary>
	///Deletes item from database.
	/// </summary>
	public void Delete() {
		rdodb_KTSqlDAC.Delete(this, "BK_SENDING_EMAIL_DETAIL");
	}
	/// <summary>
	///Read by Unique Constraint
	/// </summary>
	/// <param name="inAUTO_ID"></param>
	public static List<BK_SENDING_EMAIL_DETAIL> ReadByAUTO_ID(Guid inAUTO_ID) {
		return rdodb_KTSqlDAC.ReadByParams<BK_SENDING_EMAIL_DETAIL>("BK_SENDING_EMAIL_DETAIL", rdodb_KTSqlDAC.newInParam("@AUTO_ID", inAUTO_ID));
	}
	#endregion DAC Methods 
 }
}
