using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Glonas.Models
{
    public class User
    {
        [Key]
        public string User_id { get; set; }
    }
}
