using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using imdbAPI.Library.Internal;
using imdbAPI.Library.Models;

namespace imdbAPI.Library.DataAccess
{
    public class MovieData
    {
        public static List<MovieDataModel> GetAll()
        {
            return SqlDataAccess.LoadData<MovieDataModel, dynamic>("spGetAllMovies", new { }, "imbdDatabaseConnection");
        }

        public static void Insert(MovieDataModel movie)
        {
            SqlDataAccess.InsertData("spInsertMovie", movie, "imbdDatabaseConnection");

        }
    }
}
