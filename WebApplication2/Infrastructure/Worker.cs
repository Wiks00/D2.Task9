using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Interfaces;

namespace WebApplication2.Infrastructure
{
    public class Worker : IWorker
    {
        public IEnumerable<string> Get()
        {
            return new [] { "value1", "value2" };
        }

        public string Get(int id)
        {
            return "value";
        }

        public void Post(string value)
        {
            throw new NotImplementedException();
        }

        public void Put(int id, string value)
        {
            
        }

        public void Delete(int id)
        {
            
        }
    }
}