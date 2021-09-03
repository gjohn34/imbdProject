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
            return SqlDataAccess.LoadWithForeign<MovieDataModel, DirectorDataModel>("imbdDatabaseConnection", 
                (movie, director) => 
                {
                    movie.Director = director;
                    return movie;
                }, "DirectorId");
            //return SqlDataAccess.LoadData<MovieDataModel, dynamic>("spGetAllMovies", new { }, "imbdDatabaseConnection");
        }

        public static void Insert(MovieDataModel movie)
        {
            SqlDataAccess.InsertData("spInsertMovie", movie, "imbdDatabaseConnection");
        }
            
        public static MovieDataModel Get(int id)
        {
            // TODO - Implement eager loading
            try
            {
                MovieDataModel movie = SqlDataAccess.LoadData<MovieDataModel, dynamic>("spGetMovieById", new { Id = id }, "imbdDatabaseConnection").First();
                //movie.Director = SqlDataAccess.LoadData<DirectorDataModel, dynamic>("spGetDirectorById", new { DirectorId = movie.DirectorId }, "imbdDatabaseConnection").First();
                return movie;
            } catch
            {
                throw;
            }
        }
    }
}
