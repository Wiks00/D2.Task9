using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication2.Interfaces;

namespace WebApplication2.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IWorker worker;

        public ValuesController(IWorker worker)
        {
            this.worker = worker;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return worker.Get();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return worker.Get(id);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
            worker.Post(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            worker.Put(id,value);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            worker.Delete(id);
        }
    }
}
