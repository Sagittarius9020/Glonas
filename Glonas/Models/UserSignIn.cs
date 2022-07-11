using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Glonas.Models
{
    public class UserSignIn
    {
        [Key]
        public int Id { get; set; }
        public string User_id { get; set; }
        public DateTime DateSignIn { get; set; }
    }
}
