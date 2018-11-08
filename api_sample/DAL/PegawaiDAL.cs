using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using api_sample.Models;
using System.Data;
using System.Net;

namespace api_sample.DAL
{
    public class PegawaiDAL : ICrud<Pegawai>
    {
        public void Delete(string id)
        {
            var result = GetById(id);
            if (result != null)
            {
                using (SqlConnection conn = new SqlConnection(Helper.getConnection()))
                {
                    string strSQL = @"Delete from PEGAWAI where NIP = @nip";
                    SqlCommand cmd = new SqlCommand(strSQL, conn);
                    cmd.Parameters.AddWithValue("@nip", id);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        conn.Close();
                    }
                }
            }
            else throw new Exception($"Data NIP {id} tidak ditemukan");

        }

        public IEnumerable<Pegawai> GetAll()
        {
            List<Pegawai> listPegawai = new List<Pegawai>();
            using (SqlConnection conn = new SqlConnection(Helper.getConnection()))
            {
                string strSQL = @"Select * From PEGAWAI order by NAMA asc";
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        listPegawai.Add(new Pegawai
                        {
                            nip = dr["NIP"].ToString(),
                            nama = dr["NAMA"].ToString(),
                            jabatan = dr["JABATAN"].ToString(),
                            eselon = Int32.Parse(dr["ESELON"].ToString()),
                            email = dr["EMAIL"].ToString(),
                        });
                    }
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
            return listPegawai;
        }

        public Pegawai GetById(string id)
        {
            Pegawai pegawai = new Pegawai();
            using (SqlConnection conn = new SqlConnection(Helper.getConnection()))
            {
                string strSQL = @"Select * From PEGAWAI where NIP = @nip";
                SqlCommand cmd = new SqlCommand(strSQL, conn);
                cmd.Parameters.AddWithValue("@nip", id);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    dr.Read();
                    pegawai.nip = dr["NIP"].ToString();
                    pegawai.nama = dr["NAMA"].ToString();
                    pegawai.jabatan = dr["JABATAN"].ToString();
                    pegawai.eselon = Int32.Parse(dr["ESELON"].ToString());
                    pegawai.email = dr["EMAIL"].ToString();
                }
                else
                {
                    pegawai = null;
                }
                dr.Close();
                cmd.Dispose();
                conn.Close();
            }
            return pegawai;
        }

        public void Insert(Pegawai obj)
        {
            if (obj != null)
            {
                using (SqlConnection conn = new SqlConnection(Helper.getConnection()))
                {
                    string strSQL = @"Insert Into Pegawai (NIP, NAMA, JABATAN, ESELON, EMAIL) VALUES (@nip, @nama, @jabatan, @eselon, @email)";

                    SqlCommand cmd = new SqlCommand(strSQL, conn);
                    cmd.Parameters.Add("@nip", SqlDbType.VarChar).Value = obj.nip;
                    cmd.Parameters.Add("@nama", SqlDbType.VarChar).Value = obj.nama;
                    cmd.Parameters.Add("@jabatan", SqlDbType.VarChar).Value = obj.jabatan;
                    cmd.Parameters.Add("@eselon", SqlDbType.Int).Value = obj.eselon;
                    cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = obj.email;

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex) {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        conn.Close();
                    }
                }
                
            }
        }

        public void Update(Pegawai obj)
        {
            var result = GetById(obj.nip);
            if (result != null)
            {
                using (SqlConnection conn = new SqlConnection(Helper.getConnection()))
                {
                    string strSQL = @"Update Pegawai  SET NAMA = @nama, JABATAN = @jabatan, ESELON = @eselon, EMAIL = @email where NIP = @nip";

                    SqlCommand cmd = new SqlCommand(strSQL, conn);
                    cmd.Parameters.AddWithValue("@nip", obj.nip);
                    cmd.Parameters.AddWithValue("@nama", obj.nama);
                    cmd.Parameters.AddWithValue("@jabatan", obj.jabatan);
                    cmd.Parameters.AddWithValue("@eselon", obj.eselon);
                    cmd.Parameters.AddWithValue("@email", obj.email);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex) {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        conn.Close();
                    }
                }
                
            }
            else throw new Exception($"Data NIP {obj.nip} tidak ditemukan");

        }
    }
}