using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_sample.Models
{
    public class Gaji
    {
        public int ID { get; set; }
        public string NIP { get; set; }
        public string ACCOUNTNUMBER { get; set; }
        public string CURRENCY { get; set; }
        public decimal AMOUNT { get; set; }
        public decimal POTONGAN { get; set; }
    }
}