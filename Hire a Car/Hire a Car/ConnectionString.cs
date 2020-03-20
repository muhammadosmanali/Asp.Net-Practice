using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hire_a_Car
{
    class ConnectionString
    {
        public static string connection_string { get; set; } = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog='HIRE A CAR';Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
