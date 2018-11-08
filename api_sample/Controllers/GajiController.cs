using api_sample.DAL;
using api_sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace api_sample.Controllers
{
    
    public class GajiController : ApiController
    {
        private GajiDAL gajiDAL;

        public GajiController() {
            gajiDAL = new GajiDAL();
        }
        // GET: api/Gaji
        public IEnumerable<Gaji> Get()
        {
            return gajiDAL.GetAll();
        }

        // GET: api/Gaji/5
        public Gaji Get(string id)
        {
            try
            {
                return gajiDAL.GetById(id);
            }
            catch (Exception ex) {
                return null;
            }
        }

        /// <summary>
        /// Custom Route
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route("api/Gaji/GetByAmount")]
        [HttpGet]
        public IEnumerable<Gaji> getByAmount(decimal amt, string curr)
        {
            var result = gajiDAL.GetByAmount(amt,curr);
            return result;
        }

        // POST: api/Gaji
        public IHttpActionResult Post(Gaji gaji)
        {
            try
            {
                gajiDAL.Insert(gaji);
                return Ok($"Data Gaji nip: {gaji.NIP} berhasil di tambahkan");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // PUT: api/Gaji/5
        public IHttpActionResult Put(Gaji gaji)
        {
            try
            {
                gajiDAL.Insert(gaji);
                return Ok($"Data Gaji nip: {gaji.NIP} berhasil di update");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        // DELETE: api/Gaji/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                gajiDAL.Delete(id);
                return Ok($"Data Gaji id: {id} berhasil di delete");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
