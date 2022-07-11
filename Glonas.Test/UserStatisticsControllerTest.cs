using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Glonas;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using System.Net;

namespace Glonas.Test
{
    public class UserStatisticsControllerTest
    {
        private readonly HttpClient _client;
        
        public UserStatisticsControllerTest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [Theory]
        [InlineData("GET")]
        public async Task UserStatisticsGetTest(string method)
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), "/report/user_statistics/");

            //Act
            var response = await _client.SendAsync(request);

            //Assert
            //response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
