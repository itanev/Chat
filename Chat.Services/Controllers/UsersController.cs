using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Chat.Repository;
using Chat.Models;
using System.Configuration;

namespace Chat.Services.Controllers
{
    public class UsersController : ApiController
    {
        private UsersRepository data;

        public UsersController()
        {
            this.data = new UsersRepository(
                ConfigurationManager.AppSettings["MongoConnectionString"], 
                ConfigurationManager.AppSettings["Database"]);
        }        

        [HttpPost]
        public HttpResponseMessage RegisterOrLoginUser(User user)
        {
            var userFromData = this.data.All()
                .Where(x => x.UserName == user.UserName)
                .FirstOrDefault();
            if (userFromData != null)
            {
                ICollection<Message> userMessages = userFromData.UnreceivedMessages;
                userFromData = this.data.UpdateStatus(userFromData);
                userFromData = this.data.DeleteMessages(userFromData);
                return this.Request.CreateResponse(HttpStatusCode.OK, userFromData);
            }

            this.data.Add(user);
            var updatedUser = this.data.UpdateStatus(user);
            var response = this.Request.CreateResponse(HttpStatusCode.Created, updatedUser);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage LogoutUser(User user)
        {
            var entity = this.data.All().Where(x => x.UserName == user.UserName).First();
            var updatedUser = this.data.UpdateStatus(entity);
            var response = this.Request.CreateResponse(HttpStatusCode.OK, updatedUser);
            return response;
        }
    }
}
