using imdbAPI.Library.Internal;
using imdbAPI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imdbAPI.Library.DataAccess
{
    public class DirectorData
    {
        public static List<DirectorDataModel> GetAll()
        {
            return SqlDataAccess.LoadData<DirectorDataModel, dynamic>("spGetAllDirectors", new { }, "imbdDatabaseConnection");
        }

        public static void Insert(DirectorDataModel director)
        {
            SqlDataAccess.InsertData("spInsertDirector", director, "imbdDatabaseConnection");
        }
    }
}
