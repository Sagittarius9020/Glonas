using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glonas.Models
{
    public class QueryState
    {
        public string query { get; set; }
        public int percent { get; set; }
        public UserPost result { get; set; }

    }
}
