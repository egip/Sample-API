using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_sample.Controllers
{
    public class ValuesController : ApiController
    {
        private static List<string> listNama = new List<string> {
                "WONDO","Budi","Ari","WINDA"
        };

        // GET api/values
        public IEnumerable<string> Get()
        {
            return listNama;
        }

        // GET api/values
        /// <summary>
        /// get nama contain chr
        /// </summary>
        /// <param name="chr"></param>
        /// <returns></returns>
        public IEnumerable<string> Get(string chr)
        {
            var result = from a in listNama
                         where a.ToLower().Contains(chr.ToLower())
                         select a;
            return result;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        

        /// <summary>
        /// menambahkan data nama
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        // POST api/values
        public IEnumerable<string> Post([FromBody]string name)
        {
            listNama.Add(name);
            return new string[] { "Data sudah di tambahkan -> "+name};
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
