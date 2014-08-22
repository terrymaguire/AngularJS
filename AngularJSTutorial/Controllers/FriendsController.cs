using AngularJSTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularJSTutorial.Controllers
{
    public class FriendsController : ApiController
    {
        // GET api/values
        public IEnumerable<Friend> Get()
        {
            var list = new List<Friend>();
            list.Add(new Friend { FirstName = "John", LastName = "Doe" });
            list.Add(new Friend { FirstName = "Ann", LastName = "Wellington" });
            list.Add(new Friend { FirstName = "Sabrina", LastName = "Burke" });

            return list;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
