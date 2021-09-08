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
            return SqlDataAccess.LoadWithForeign<MovieDataModel, DirectorDataModel, dynamic>("spGetAllMovies", 
                (movie, director) => 
                {
                    movie.Director = director;
                    return movie;
                }, new { }, "DirectorId", "imbdDatabaseConnection");
        }

        public static void Insert(MovieDataModel movie)
        {
            SqlDataAccess.InsertData("spInsertMovie", movie, "imbdDatabaseConnection");
        }

        public static void Update(int id, MovieDBModel movie)
        {
            movie.Id = id;
            SqlDataAccess.InsertData("spUpdateMovie", movie, "imbdDatabaseConnection");
        }

        public static void Delete(int id)
        {
            SqlDataAccess.InsertData("spDeleteMovie", new { Id = id }, "imbdDatabaseConnection");
        }

        public static MovieDataModel Get(int id)
        {
            // TODO - Implement eager loading
            try
            {
                MovieDataModel movie = SqlDataAccess.LoadWithForeign<MovieDataModel, DirectorDataModel, dynamic>("spGetMovieById", (m, d) => 
                {
                    m.Director = d;
                    return m;
                }, new { Id = id }, "DirectorId", "imbdDatabaseConnection").First();
                return movie;
            } catch
            {
                throw;
            }
        }
    }
}
