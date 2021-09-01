﻿using imdbAPI.Library.DataAccess;
using imdbAPI.Library.Models;
using imdbAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace imdbAPI.Controllers
{
    //[Authorize]
    public class MoviesController : ApiController
    {
        [HttpGet]
        public List<MovieDataModel> Get()
        {
            return MovieData.GetAll();
        }

        [HttpPost]
        public void Post([FromBody] MovieDataModel movie)
        {
            MovieData.Insert(movie);
        }

        // GET: api/Movies/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //POST: api/Movies
        //public void Post([FromBody] string value)
        //{
        //}

        //PUT: api/Movies/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //DELETE: api/Movies/5
        //public void Delete(int id)
        //{
        //}
    }
}