using imbdAPI.Library.Internal;
using imbdAPI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imbdAPI.Library.DataAccess
{
    public class DirectorData
    {
        public static List<DirectorDataModel> GetAll()
        {
            Dictionary<int, DirectorDataModel> DirectorDictionary = new Dictionary<int, DirectorDataModel>();

            return SqlDataAccess.LoadWithForeign<DirectorDataModel, MovieDataModel, dynamic>("spGetAllDirectors",
                (director, movie) =>
                {
                    DirectorDataModel directorEntity;
                    if (!DirectorDictionary.TryGetValue(director.Id, out directorEntity))
                    {
                        directorEntity = director;
                        DirectorDictionary.Add(directorEntity.Id, directorEntity);
                    }
                    directorEntity.movies.Add(movie);
                    return directorEntity;
                }, new { }, "Id", "imbdDatabaseConnection").Distinct().ToList();
                //<DirectorDataModel, dynamic>("spGetAllDirectors", new { }, "imbdDatabaseConnection");
        }

        public static void Delete(int id)
        {
            // TODO - Rename insert to save - less confusing
            SqlDataAccess.InsertData("spDeleteDirector", new { Id = id }, "imbdDatabaseConnection");
        }

        public static void Update(int id, DirectorDBModel director)
        {
            director.Id = id;
            SqlDataAccess.InsertData("spUpdateDirector", director, "imbdDatabaseConnection");
        }


        public static void Insert(DirectorDataModel director)
        {
            SqlDataAccess.InsertData("spInsertDirector", director, "imbdDatabaseConnection");
        }
        public static DirectorDataModel GetOne(int id)
        {

            Dictionary<int, DirectorDataModel> DirectorDictionary = new Dictionary<int, DirectorDataModel>();

            return SqlDataAccess.LoadWithForeign<DirectorDataModel, MovieDataModel, dynamic>("spGetMovieById", 
                (director, movie) => 
                { 
                    DirectorDataModel directorEntity;
                    if (!DirectorDictionary.TryGetValue(director.Id , out directorEntity))
                    {
                        directorEntity = director;
                        DirectorDictionary.Add(directorEntity.Id, directorEntity);
                    }
                    directorEntity.movies.Add(movie);
                    return directorEntity;

                }, new { Id = id }, "Id", "imbdDatabaseConnection").First();
        }
    }
}
