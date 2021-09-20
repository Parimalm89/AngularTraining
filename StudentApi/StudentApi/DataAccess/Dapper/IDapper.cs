using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace POServiceApi.DataAccess.Dapper
{
    public interface IDapperHelper
    {
        void ClearParameter();
        string ExecuteScalarValue(string query, CommandType cmdType);
        void AddParameter(string name, object value);
        void AddParameter(string name, object value, System.Data.DbType type);
        void AddParameter(string name, object value, System.Data.DbType type = DbType.String, ParameterDirection pd = ParameterDirection.Input);
        string ExecuteNonQuery(string query, CommandType cmdtype);
        string ExecuteNonQuery<T>(string query, T obj, CommandType cmdtype);
        string ExecuteNonQuery(string query, CommandType cmdtype, string outputparam);
        string ExecuteScalar(string query, CommandType cmdType);
        string GetDataJson<T>(string query, CommandType cmdType);
        List<T> GetDataList<T>(string query, CommandType cmdType);
        string GetRecordJsonByID<T>(string query, CommandType cmdType);
        T GetRecordByID<T>(string query, CommandType cmdType);
        string ExecuteNonQueryReturnID(string query, CommandType cmdtype, string outputparam);

        string ExecuteNonQueryAng(string query, CommandType cmdtype);
        
        DataSet ExecuteSql(string sp, string tablenm, List<SqlParameter> param = null);
    }
}
