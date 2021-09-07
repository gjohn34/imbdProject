using Dapper;
using Dapper.FluentColumnMapping;
using imdbAPI.Library.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imdbAPI.Library.Internal
{
    internal class SqlDataAccess
    {
        private static string GetConnectionString(string db)
        {
            return ConfigurationManager.ConnectionStrings[db].ConnectionString;
        }
        public static List<T> LoadWithForeign<T,U, P>(string storedProcedure, Func<T, U, T> rule, P parameters, string splitOn, string db)
        {
            using (IDbConnection cn = new SqlConnection(GetConnectionString(db)))
            {
                cn.Open();
                List<T> rows = cn.Query<T, U, T>(storedProcedure, rule, parameters, commandType: CommandType.StoredProcedure, splitOn: splitOn).ToList();
                //splitOn: new { id: id}
                cn.Close();
                return rows;

            }
        }

        public static List<T> TESTLoadWithForeign<T, U, P>(string sql, Func<T, U, T> rule, P parameters, string splitOn, string db)
        {
            using (IDbConnection cn = new SqlConnection(GetConnectionString(db)))
            {
                cn.Open();
                List<T> rows = cn.Query<T, U, T>(sql, rule, parameters, splitOn: splitOn).ToList();
                //splitOn: new { id: id}
                cn.Close();
                return rows;

            }
        }

        public static List<T> LoadData<T, U>(string storedProcedure, U parameters, string db)
        {
            using (IDbConnection cn = new SqlConnection(GetConnectionString(db)))
            {
                return cn.Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        public static void InsertData<T>(string storedProcedure, T parameters, string db)
        {
            using (IDbConnection cn = new SqlConnection(GetConnectionString(db)))
            {
                cn.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
