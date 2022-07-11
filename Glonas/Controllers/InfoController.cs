using Glonas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Glonas.Controllers
{
    [Route("report/info")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly ApplicationContext _context;

        private IOptions<MyConfig> _settings;

        public InfoController(ApplicationContext context, IOptions<MyConfig> settings)
        {
            _context = context;
            _settings = settings;

        }

        // GET: api/<InfoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<InfoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            int del = _settings.Value.TimeQ;
            UserPostStatistic userPost = _context.UserPosts.FindAsync(id).Result;
            int sign = await _context.UserSignIns.Where(t => t.DateSignIn >= userPost.DateFrom && t.DateSignIn <= userPost.DateTo).CountAsync();

            QueryState state = new QueryState();
            if (userPost.DatePost.AddSeconds(del) < DateTime.Now)
            {
                state.query = id;
                state.percent = 100;
                state.result = new UserPost { User_id = userPost.User_id, count_sign_in = sign };

            }
            else
            {
                int perc = Convert.ToInt32((del - (userPost.DatePost.AddSeconds(del) - DateTime.Now).TotalSeconds) / del * 100);
                state.query = id;
                state.percent = perc;
                state.result = null;
            }
            return new ObjectResult(state);
        }

    }
}
