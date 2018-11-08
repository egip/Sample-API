using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace api_sample.DAL
{
    public class Helper
    {
        public static string getConnection()
        {
            return ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        }
    }
}