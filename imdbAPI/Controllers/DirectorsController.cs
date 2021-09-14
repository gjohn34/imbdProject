using imbdAPI.Library.DataAccess;
using imbdAPI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace imbdAPI.Controllers
{
    public class DirectorsController : ApiController
    {
        // GET: api/Director
        [HttpGet]
        public List<DirectorDataModel> Get()
        {
            List<DirectorDataModel> data = DirectorData.GetAll();
            return data;
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
            try
            {
                return DirectorData.GetOne(id);
            }
            catch 
            {
                throw;
            }
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
