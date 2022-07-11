using Glonas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Glonas.Controllers
{
    [Route("report/user_statistics")]
    [ApiController]
    public class UserStatisticsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public UserStatisticsController(ApplicationContext context)
        {
            _context = context;
            
        }

        // GET: api/<UserStatisticsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<UserStatisticsController>
        [HttpPost]
        public async Task<ActionResult> Post(UserPostStatistic userPosts)
        {
            Guid guid = Guid.NewGuid();
            UserPostStatistic userPost = new UserPostStatistic
            {
                Query_Id = guid.ToString(),
                User_id = userPosts.User_id,
                DateFrom = userPosts.DateFrom,
                DateTo = userPosts.DateTo,
                DatePost = DateTime.Now
            };

            _context.UserPosts.Add(userPost);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }


            int sign = await _context.UserSignIns.Where(t => t.DateSignIn >= userPosts.DateFrom && t.DateSignIn <= userPosts.DateTo).CountAsync();
            return new ObjectResult(guid);
        }

    }
}
