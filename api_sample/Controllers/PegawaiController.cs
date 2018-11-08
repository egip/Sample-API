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
    public class PegawaiController : ApiController
    {
        private PegawaiDAL pegawaiDal;
        private List<Pegawai> listPegawai = new List<Pegawai> { };

        public PegawaiController()
        {
            pegawaiDal = new PegawaiDAL();
        }
        

        // GET: api/Pegawai/5
        /// <summary>
        /// Select satu pegawai berdasarkan NIP
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<Pegawai> Get()
        {
            return pegawaiDal.GetAll();
        }

        // GET: api/Pegawai/5
        /// <summary>
        /// Select satu pegawai berdasarkan NIP
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Pegawai Get(string id)
        {
            var result = pegawaiDal.GetById(id);
            return result;
        }

        /// <summary>
        /// Custom Route
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route("api/Pegawai/GetByName")]
        [HttpGet]
        public Pegawai getByName(string name,string nip)
        {
            var result = pegawaiDal.GetById(nip);
            return result;
        }


        // POST: api/Pegawai
        /// <summary>
        /// Add data pegawai
        /// </summary>
        /// <param name="pegawai"></param>
        /// <returns></returns>
        public IHttpActionResult Post(Pegawai pegawai)
        {
            try
            {
                pegawaiDal.Insert(pegawai);
                return Ok($"data pegawai {pegawai.nama} berhasil di tambahkan");
            }
            catch (Exception ex)
            {
                return BadRequest($"error : {ex.Message}");
            }

            
        }

        // PUT: api/Pegawai/5
        /// <summary>
        /// Update Pegawai NIP in URL
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mssgPegawai"></param>
        /// <returns></returns>
        public IHttpActionResult Put(string id, Pegawai mssgPegawai)
        {
            try
            {
                pegawaiDal.Update(mssgPegawai);
                return Ok($"data pegawai {mssgPegawai.nama} berhasil di Update");
            }
            catch (Exception ex)
            {
                return BadRequest($"error : {ex.Message}");
            }
            
        }

        // PUT: api/Pegawai/5
        /// <summary>
        /// Update Pegawai NIP in Body
        /// </summary>
        /// <param name="mssgPegawai"></param>
        /// <returns></returns>
        public IHttpActionResult Put(Pegawai mssgPegawai)
        {
            try {
                pegawaiDal.Update(mssgPegawai);
                return Ok($"data pegawai {mssgPegawai.nama} berhasil di Update");
            } catch (Exception ex)
            {
                return BadRequest($"error : {ex.Message}");
            }
            
        }

        // DELETE: api/Pegawai/5
        public IHttpActionResult Delete(string id)
        {
            try {
                pegawaiDal.Delete(id);
                return Ok($"data pegawai {id} berhasil di Delete");
            }
            catch (Exception ex) {
                return BadRequest($"error : {ex.Message}");
            }
        }
    }
}
