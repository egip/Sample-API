using api_sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Dapper;

namespace api_sample.DAL
{
    public class GajiDAL : ICrud<Gaji>
    {
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Gaji> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(Helper.getConnection()))
            {
                string strSql = @"select * from GAJI order by NIP";
                var result = conn.Query<Gaji>(strSql); //use DAPPER
                return result;
            }
        }

        public Gaji GetById(string id)
        {
            using (SqlConnection conn = new SqlConnection(Helper.getConnection()))
            {
                string strSql = @"select * from GAJI where ID = @id";
                var param = new { id = id };
                var result = conn.QuerySingle<Gaji>(strSql, param); //use DAPPER
                return result;
            }
        }

        public IEnumerable<Gaji> GetByAmount(decimal amt, string curr)
        {
            using (SqlConnection conn = new SqlConnection(Helper.getConnection()))
            {
                string strSql = @"select * from GAJI where AMOUNT >= @amt and CURRENCY = @curr";
                var param = new { amt = amt, curr = curr };
                var result = conn.Query<Gaji>(strSql, param); //use DAPPER
                return result;
            }
        }

        public void Insert(Gaji obj)
        {
            using (SqlConnection conn = new SqlConnection(Helper.getConnection()))
            {
                string strSql = @"insert into GAJI (NIP, ACCOUNTNUMBER, CURRENCY, AMOUNT, POTONGAN)
                                    values (@nip, @acctno, @curr, @amt, @potongan)";
                var param = new { nip = obj.NIP, acctno = obj.ACCOUNTNUMBER, curr = obj.CURRENCY, amt = obj.AMOUNT, potongan = obj.POTONGAN };
                try
                {
                    conn.Query<Gaji>(strSql, param); //use DAPPER
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Number: {ex.Number}, Error: {ex.Message}");
                }
            }
        }

        public void Update(Gaji obj)
        {
            using (SqlConnection conn = new SqlConnection(Helper.getConnection()))
            {
                string strSql = @"update GAJI set ACCOUNTNUMBER=@acctno, AMOUNT=@amt, POTONGAN=@potongan where nip=@nip and CURRENCY=@curr)";
                var param = new { nip = obj.NIP, acctno = obj.ACCOUNTNUMBER, curr = obj.CURRENCY, amt = obj.AMOUNT, potongan = obj.POTONGAN };
                try
                {
                    conn.Query<Gaji>(strSql, param); //use DAPPER
                }
                catch (SqlException ex)
                {
                    throw new Exception($"Number: {ex.Number}, Error: {ex.Message}");
                }
            }
        }
    }
}