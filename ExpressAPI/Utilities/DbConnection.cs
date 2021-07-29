using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressAPI.Utilities
{
    public static class DBConnection
    {
        public static string _connectionString;

        public static string GetConnectionString()
        {
            _connectionString = ""; 
            return _connectionString;
        }
    }
}
