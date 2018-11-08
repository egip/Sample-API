using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_sample.Models
{
    public class Pegawai
    {
        public string nip { get; set; }
        public string nama { get; set; }
        public string jabatan { get; set; }
        public int eselon { get; set; }
        public string email { get; set; }
    }
}