using System.Collections.Generic;
using System.Web.Http;

namespace WebApplication2.Interfaces
{
    public interface IWorker
    {
        IEnumerable<string> Get();

        string Get(int id);

        void Post([FromBody] string value);

        void Put(int id, [FromBody] string value);

        void Delete(int id);
    }
}