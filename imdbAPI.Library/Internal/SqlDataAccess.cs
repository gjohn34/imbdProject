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
        public static List<T> LoadWithForeign<T,U>(string db, Func<T, U, T> rule, string splitOn)
        {
            using (IDbConnection cn = new SqlConnection(GetConnectionString(db)))
            {
                cn.Open();
                List<T> movies = cn.Query<T, U, T>("SELECT m.Id, m.Title, m.ReleaseYear, m.DirectorId, d.Id, d.FirstName, d.LastName from dbo.Movies as m INNER JOIN dbo.Directors as d ON m.DirectorId = d.Id", rule, splitOn: splitOn).ToList();
                //splitOn: new { id: id}
                return movies;

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
