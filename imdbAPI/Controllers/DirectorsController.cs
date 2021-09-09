using imdbAPI.Library.DataAccess;
using imdbAPI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace imdbAPI.Controllers
{
    public class DirectorsController : ApiController
    {
        // GET: api/Director
        [HttpGet]
        public List<DirectorDataModel> Get()
        {
            return DirectorData.GetAll();
        }
        [HttpPost]
        [Authorize]
        public void Insert([FromBody] DirectorDataModel director)
        {
            DirectorData.Insert(director);
        }

        [HttpGet]
        public DirectorDataModel Get(int id)
        {
            return DirectorData.GetOne(id);
        }

        [HttpPut]
        [Authorize]
        public void Update(int id, [FromBody] DirectorDBModel director)
        {
            // create director db model - no movies
            DirectorData.Update(id, director);
        }

        [HttpDelete]
        [Authorize]
        public void Delete(int id)
        {
            DirectorData.Delete(id);
        }
    }
}
