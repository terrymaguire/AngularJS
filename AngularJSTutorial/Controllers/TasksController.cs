using AngularJSTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AngularJSTutorial.Controllers
{
    public class TasksController : ApiController
    {
        static List<Task> tasks = new List<Task> {
            new Task { Id = 1, Name = "Report", Status = TaskStatus.Pending.ToString() },
            new Task { Id = 2, Name = "DB Call", Status = TaskStatus.Pending.ToString() },
            new Task { Id = 3, Name = "SignalR", Status = TaskStatus.Done.ToString() },
        };



        // GET api/values
        public IEnumerable<Task> Get()
        {

            return tasks;
        }

        // GET api/values/5
        public Task Get(int id)
        {
            return tasks.Single(p => p.Id == id);
        }

        static int maxId = 3;

        // POST api/values
        public void Post([FromBody]Task value)
        {
            var headers = HttpContext.Current.Request.Headers;
            IEnumerable<string> headerValues = headers.GetValues("CommandType");
            var commandType = headerValues.FirstOrDefault();
            if (commandType != "CreateTask")
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            value.Id = ++maxId;
            value.Status = TaskStatus.Pending.ToString();
            tasks.Add(value);

            HttpContext.Current.Response.AddHeader("Location", "/api/tasks/" + value.Id);

        }

        //// POST api/values
        //public void Post([FromBody]Task value)
        //{
        //    value.Id = ++maxId;
        //    value.Status = TaskStatus.Pending.ToString();
        //    tasks.Add(value);

        //    HttpContext.Current.Response.AddHeader("Location", "/api/tasks/" + value.Id);

        //}

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
