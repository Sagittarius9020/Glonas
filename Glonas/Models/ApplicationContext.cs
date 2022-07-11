using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glonas.Models
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserSignIn> UserSignIns { get; set; }
        public virtual DbSet<UserPostStatistic> UserPosts { get; set; }
        public ApplicationContext()
        {
            User user = new User { User_id = "b28d0ced - 8af5 - 4c94 - 8650 - c7946241fd1a" };
            if (!Users.Any(t => t.User_id == user.User_id))
            {
                Users.Add(user);
                SaveChanges();
            }

            for (var i = 0; i < 12; i++)
            {
                UserSignIn userSign = new UserSignIn
                {
                    User_id = "b28d0ced - 8af5 - 4c94 - 8650 - c7946241fd1a",
                    DateSignIn = DateTime.Now.AddMinutes(5 - i)
                };
                UserSignIns.Add(userSign);
                SaveChanges();
            }

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=GlonasDb.db");
        }
    }
}
