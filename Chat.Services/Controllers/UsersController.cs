using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Chat.Services.Models;
using Chat.Repository;
using Chat.Models;
using System.Configuration;

namespace Chat.Services.Controllers
{
    public class UsersController : ApiController
    {
        private IRepository<User> data;

        public UsersController()
        {
            this.data = new UsersRepository(
                ConfigurationManager.AppSettings["MongoConnectionString"]);
        }

        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage RegisterUser(UserModel userModel)
        {
            var user = new User { UserName = userModel.Username, Password = userModel.AuthCode };
            this.data.Add(user);
            var response = this.Request.CreateResponse(HttpStatusCode.Created, user);
            return response;
        }

        // GET api/users
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/users/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/users
        public void Post([FromBody]string value)
        {
        }

        // PUT api/users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/users/5
        public void Delete(int id)
        {
        }
    }
}
