using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GC_MovieDatabase_Dapper
{
    public class Secret
    {
        public static string Connection { get; set; } = $"server=127.0.0.1;uid=root;pwd=1111;database=movierentals";

    }
}
