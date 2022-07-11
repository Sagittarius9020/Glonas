using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Glonas.Models
{
    public class UserPostStatistic
    {
        [Key]
        public string Query_Id { get; set; }
        public string User_id { get; set; }
        public DateTime DatePost { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
