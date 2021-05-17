using System;
using System.Configuration;
using System.Data;
using StandardDAC;
using System.Data.SqlClient;
using StandardDAC.SqlClient;
using System.Collections.Generic;

using System.Data.Odbc;
using System.Reflection;
using System.ComponentModel;
using StandardDAC.Base;
using System.Data.Common;
using System.Linq;


namespace SaleMTDataAccessLayer.SaleMTDAL
{
    /// <summary>
    /// Created by Luannv – 20/09/2013: Description for DAC.
    /// </summary>
    public class posdb_vnmSqlDAC  //StandardDAC.SqlClient.SQLDac  posdb_vnmSqlDAC.save
    {
        #region Declaration
        /// <summary>
        /// Created by Luannv – 20/09/2013: Connection string.
        /// </summary>
        /// 
        private static string connection = AppConfigFileSettings.strConnectionSql;
        private static string connSync = AppConfigFileSettings.strConnectionSync;
        
        #endregion

        #region IdataModel
        /// <summary>
        /// Created by Luannv – 20/09/2013: Query All data
        /// </summary>
        public static List<T> ReadAll<T>(string table)
        {
            Type type = typeof(T);
            string procedure = table + "_Read";
            SqlParameter[] para = new SqlParameter[1];
            DataTable datatable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                //SqlConnection sqlConnection = new SqlConnection(connection);
                SqlCommand sqlCommand = new SqlCommand();
                try
                {

                    Dictionary<string, KeyValuePair<int, DBColumn>> parametersToSort = new Dictionary<string, KeyValuePair<int, DBColumn>>();
                    foreach (PropertyInfo info in type.GetProperties())
                    {
                        if (Attribute.IsDefined(info, typeof(DBColumn)))
                        {
                            DBColumn col = (DBColumn)Attribute.GetCustomAttribute(info, typeof(DBColumn));
                            if (col.IsPrimaryKey)
                            {
                                para[0] = newInParam(col.Name, null);
                            }
                        }
                    }

                    sqlCommand.CommandText = procedure;
                    sqlCommand.Parameters.AddRange(para);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    if (sqlConnection.State == ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }
                    sqlDataAdapter.Fill(datatable);
                    sqlConnection.Close();
                    int cou = datatable.Rows.Count;

                }
                catch (Exception ex)
                {
                    throw ex;
                } 
            }
            // convert datatable to  List<T>
            var columnNames = datatable.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();

            var properties = typeof(T).GetProperties();

            return datatable.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();

                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name))
                    {
                        object value = row[pro.Name];
                        if (value == DBNull.Value)
                        {
                            value = null;
                        }
                        else
                        {
                            Type typePro = pro.PropertyType; //will get this dynamically
                            if (typePro.IsGenericType && typePro.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                            {
                                var targetType = Nullable.GetUnderlyingType(pro.PropertyType);
                                value = Convert.ChangeType(value, targetType);
                            }
                            else
                                value = Convert.ChangeType(value, type);
                        }
                        pro.SetValue(objT, value, null);
                    }

                }

                return objT;
            }).ToList();
        }
        /// <summary>
        /// Created by Luannv – 20/09/2013: Query data by procedure returns Dataset.
        /// </summary>
        public static void Save(object obj,string table,bool isNew)
        {
            try
            {
                
                Type type = obj.GetType();
                string suffix = (isNew) ? "_Create" : "_Update";
                string procedure = table + suffix;             
                PropertyInfo[] propertyInfo = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                int mCountMember = propertyInfo.Length;
                SqlParameter[] para = new SqlParameter[mCountMember];
                for (int i = 0; i < mCountMember; i++)
                {
                    if (Attribute.IsDefined(propertyInfo[i], typeof(DBColumn)))
                    {
                        DBColumn col = (DBColumn)Attribute.GetCustomAttribute(propertyInfo[i], typeof(DBColumn));
                        para[i] = newInParam(col.Name, propertyInfo[i].GetValue(obj, null));                        
                    }                             
                }
                using (SqlConnection sqlConnection = new SqlConnection(connection))
                {
                    //SqlConnection sqlConnection = new SqlConnection(connection);
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = procedure;
                    sqlCommand.Parameters.AddRange(para);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    if (sqlConnection.State == ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }
                    int result = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close(); 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Dung de luu cac bang du lieu dong bo
        public static void SaveSync(object obj, string table, bool isNew)
        {
            try
            {

                Type type = obj.GetType();
                string suffix = (isNew) ? "_Create" : "_Update";
                string procedure = table + suffix;
                PropertyInfo[] propertyInfo = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                int mCountMember = propertyInfo.Length;
                SqlParameter[] para = new SqlParameter[mCountMember];
                for (int i = 0; i < mCountMember; i++)
                {
                    if (Attribute.IsDefined(propertyInfo[i], typeof(DBColumn)))
                    {
                        DBColumn col = (DBColumn)Attribute.GetCustomAttribute(propertyInfo[i], typeof(DBColumn));
                        para[i] = newInParam(col.Name, propertyInfo[i].GetValue(obj, null));
                    }
                }
                using (OdbcConnection sqlConnection = new OdbcConnection(connSync))
                {
                    OdbcCommand sqlCommand = new OdbcCommand();
                    sqlCommand.CommandText = procedure;
                    sqlCommand.Parameters.AddRange(para);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    if (sqlConnection.State == ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }
                    int result = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Created by Luannv – 20/09/2013: Query All data where Primarykey
        /// </summary>
        public static List<T> ReadById<T>(object obj, string table)
        {
            string procedure = table + "_Read";
            SqlParameter[] para = new SqlParameter[1];
            DataTable datatable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                //SqlConnection sqlConnection = new SqlConnection(connection);
                SqlCommand sqlCommand = new SqlCommand();
                try
                {
                    para[0] = SqlParamaterPrimaryKey(obj, true);

                    sqlCommand.CommandText = procedure;
                    sqlCommand.Parameters.AddRange(para);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    if (sqlConnection.State == ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }
                    sqlDataAdapter.Fill(datatable);
                    sqlConnection.Close();
                    int cou = datatable.Rows.Count;


                    // convert datatable to  List<T>
                    var columnNames = datatable.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();

                    var properties = typeof(T).GetProperties();

                    return datatable.AsEnumerable().Select(row =>
                    {
                        var objT = Activator.CreateInstance<T>();

                        foreach (var pro in properties)
                        {
                            if (columnNames.Contains(pro.Name))
                            {
                                object value = row[pro.Name];
                                if (value == DBNull.Value)
                                {
                                    value = null;
                                }
                                else
                                {
                                    Type type = pro.PropertyType; //will get this dynamically
                                    if (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                                    {
                                        var targetType = Nullable.GetUnderlyingType(pro.PropertyType);
                                        value = Convert.ChangeType(value, targetType);
                                    }
                                    else
                                        value = Convert.ChangeType(value, type);
                                }
                                pro.SetValue(objT, value, null);
                            }

                        }

                        return objT;
                    }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                } 
            }
        }       
        /// <summary>
        /// Created by Luannv – 20/09/2013: Delete data where Primarykey
        /// </summary>
        public static void Delete(object obj, string table)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                try
                {
                    Type type = obj.GetType();
                    string procedure = table + "_Delete";
                    SqlParameter[] para = new SqlParameter[1];
                    para[0] = SqlParamaterPrimaryKey(obj, true);
                    //SqlConnection sqlConnection = new SqlConnection(connection);
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = procedure;
                    sqlCommand.Parameters.AddRange(para);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;

                    if (sqlConnection.State == ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }
                    int result = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                } 
            }
            
        }
        /// <summary>
        /// Created by Luannv – 20/09/2013: Query data where Paramater
        /// </summary>
        public static List<T> ReadByParams<T>(string table, SqlParameter paramater)
        {
            string procedure = table + "_Read";
            SqlParameter[] para = new SqlParameter[1];
            DataTable datatable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                //SqlConnection sqlConnection = new SqlConnection(connection);
                SqlCommand sqlCommand = new SqlCommand();
                try
                {
                    para[0] = paramater;
                    sqlCommand.CommandText = procedure;
                    sqlCommand.Parameters.AddRange(para);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Connection = sqlConnection;
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    if (sqlConnection.State == ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }
                    sqlDataAdapter.Fill(datatable);
                    sqlConnection.Close();
                    int cou = datatable.Rows.Count;

                }
                catch (Exception ex)
                {
                    throw ex;
                } 
            }
            // convert datatable to  List<T>
            var columnNames = datatable.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToList();

            var properties = typeof(T).GetProperties();

            return datatable.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();

                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name))
                    {
                        object value = row[pro.Name];                        
                        if (value == DBNull.Value)
                        {
                            value = null;
                        }
                        else
                        {
                            Type type = pro.PropertyType; //will get this dynamically
                            if (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                            {
                                var targetType = Nullable.GetUnderlyingType(pro.PropertyType);
                                value = Convert.ChangeType(value, targetType);
                            }
                            else
                                value = Convert.ChangeType(value, type);
                        }
                        
                        pro.SetValue(objT, value, null);
                    }

                }

                return objT;
            }).ToList();
        }
        #endregion        

        #region GENERIC
        /// <summary>
        /// Created by Luannv – 20/09/2013: Query data by procedure returns Dataset.
        /// </summary>
        public DataSet GetDataSet(string procedure, SqlParameter[] parameters)
        {
            DataSet dataset = new DataSet();
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                //SqlConnection sqlConnection = new SqlConnection(connection);
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = procedure;
                sqlCommand.Parameters.AddRange(parameters);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandTimeout = 300;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                try
                {
                    if (sqlConnection.State == ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }
                    sqlDataAdapter.Fill(dataset);
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                } 
            }
            return dataset;
        }
        /// <summary>
        /// Created by Luannv – 20/09/2013: Query data by procedure returns Datatable.
        /// </summary>
        public DataTable GetDataTable(string procedure, SqlParameter[] parameters)
        {
            DataTable datatable = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                //SqlConnection sqlConnection = new SqlConnection(connection);
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = procedure;
                sqlCommand.CommandTimeout = 300;
                if (parameters != null)
                {
                    sqlCommand.Parameters.AddRange(parameters);
                }
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = sqlConnection;
                
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                try
                {
                    if (sqlConnection.State == ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }
                    sqlDataAdapter.Fill(datatable);
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                } 
            }
            return datatable;
        }
        /// <summary>
        /// Created by Luannv – 20/09/2013: Query data by procedure returns DataRow.
        /// </summary>
        public DataRow GetDataRow(string procedure, SqlParameter[] parameters)
        {
            DataRow datarow;
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                //SqlConnection sqlConnection = new SqlConnection(connection);
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = procedure;
                sqlCommand.Parameters.AddRange(parameters);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = sqlConnection;
                DataTable datatable = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                try
                {
                    if (sqlConnection.State == ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }
                    sqlDataAdapter.Fill(datatable);
                    sqlConnection.Close();
                    datarow = datatable.Rows[0]; 
                }
                catch (Exception ex)
                {
                    throw ex;
                } 
            }                    
            return datarow;
        }
        /// <summary>
        /// Created by Luannv – 20/09/2013: Execute store procedure.
        /// </summary>
        public void Execute(string procedure, SqlParameter[] parameters)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                //SqlConnection sqlConnection = new SqlConnection(connection);
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = procedure;
                if (parameters != null)
                {
                    sqlCommand.Parameters.AddRange(parameters);
                }
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandTimeout = 300;
                if (procedure == "SyncFromTempToData")
                {
                    sqlCommand.CommandTimeout = 30000;
                }
                try
                {
                    if (sqlConnection.State == ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }
                    int result = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                } 
            }
           

        }
        /// <summary>
        /// Người tạo Luannv – 24/09/2013:Lấy mã sinh tự động
        /// </summary>
        public string GetAutoCode(string table, string col, string prefix)
        {
            try
            {
                string result = "";
                SqlParameter[] para = new SqlParameter[3];
                para[0] = posdb_vnmSqlDAC.newInParam("@Col", col);
                para[1] = posdb_vnmSqlDAC.newInParam("@Table", table);
                para[2] = posdb_vnmSqlDAC.newInParam("@Prefix", prefix);
                DataTable datatable = GetDataTable("GetAutoCode", para);
                result = datatable.Rows[0]["code"].ToString();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Người tạo Luannv – 24/10/2013:Lấy ngày giờ hiện tại từ server
        /// </summary>
        public DateTime GetDateTimeServer()
        {
            DateTime datetime = DateTime.Now;
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection sqlConnection = new SqlConnection(connection))
                {
                    //SqlConnection sqlConnection = new SqlConnection(connection);
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = "Select GETDATE() date ";
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.Connection = sqlConnection;
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    if (sqlConnection.State == ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }
                    sqlDataAdapter.Fill(dt);
                    sqlConnection.Close();
                    datetime = Convert.ToDateTime(dt.Rows[0]["date"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return datetime;
        }
        //public DataSet ExecuteInTransaction(string procedureName, SqlParameter[] parameters)

        /// <summary>
        /// Created by Luannv – 20/09/2013:  Query data by query string returns DataRow.
        /// </summary>
        public DataSet InlineSql_Execute(string sqlString, SqlParameter[] parameters)
        {
            DataSet dataset = new DataSet();
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                //SqlConnection sqlConnection = new SqlConnection(connection);
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = sqlString;
                if (parameters != null)
                {
                    sqlCommand.Parameters.AddRange(parameters);
                }
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandTimeout = 300;
                //DataSet dataset = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                try
                {
                    if (sqlConnection.State == ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }
                    sqlDataAdapter.Fill(dataset);
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                } 
            }
            return dataset;
        }

        //public DataSet InlineSql_ExecuteInTransaction(string sqlString, SqlParameter[] parameters)
        /// <summary>
        /// Created by thanhnh – 20/09/2013: ExecuteNonQuery.
        /// </summary>
        public void InlineSql_ExecuteNonQuery(string sqlString, SqlParameter[] parameters)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connection))
            {
                //SqlConnection sqlConnection = new SqlConnection(connection);
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = sqlString;
                sqlCommand.CommandTimeout = 300;
                if (parameters != null)
                {
                    sqlCommand.Parameters.AddRange(parameters);
                }
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Connection = sqlConnection;
                try
                {
                    if (sqlConnection.State == ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                } 
            }
        }

        /// <summary>
        /// Người tạo Thanvn – 14/11/2013:Insert từ SaleOnline XML lên bảng tạm SaleMT
        /// </summary>
        public void Copy_To_ClientDB(DataTable dtSource,string desTableName)
        {
            DateTime datetime = DateTime.Now;
            try
            {
                using (SqlBulkCopy copy = new SqlBulkCopy(connection, SqlBulkCopyOptions.KeepNulls))
                {
                    foreach (DataColumn dc in dtSource.Columns)
                    {
                        copy.ColumnMappings.Add(dc.ColumnName, dc.ColumnName);
                    }                   
                    copy.DestinationTableName = desTableName;
                    copy.WriteToServer(dtSource);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }
        #endregion

        #region public methods - helpers [STATIC]
        public static SqlParameter newInParam(string name, object value)
        {
            SqlParameter p = new SqlParameter(name, value);
            return p;
        }
        public static SqlParameter newInParam(string name, SqlDbType type, object value)
        {
            SqlParameter p = new SqlParameter(name, value);
            p.SqlDbType = type;
            return p;
        }
        public static SqlParameter newOutParam(string name, SqlDbType type)
        {
            SqlParameter p = new SqlParameter(name, type);
            p.Direction = ParameterDirection.Output;
            return p;
        }
        /// <summary>
        /// Created by Luannv – 20/09/2013: Create primary key column parameters
        /// </summary> 
        private static SqlParameter SqlParamaterPrimaryKey(object obj,bool status)
        {
            SqlParameter para = new SqlParameter();
            Dictionary<string, KeyValuePair<int, DBColumn>> parametersToSort = new Dictionary<string, KeyValuePair<int, DBColumn>>();
            foreach (PropertyInfo info in obj.GetType().GetProperties())
            {
                if (Attribute.IsDefined(info, typeof(DBColumn)))
                {
                    DBColumn col = (DBColumn)Attribute.GetCustomAttribute(info, typeof(DBColumn));
                    if (col.IsPrimaryKey)
                    {
                        para = newInParam(col.Name,(status)? info.GetValue(obj, null):null);                        
                    }
                }
            }
            return para;
        }
        #endregion
    }
}

