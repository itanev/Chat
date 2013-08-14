﻿using System;
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
        private IRepository<User> data;

        public UsersController()
        {
            this.data = new UsersRepository(
                ConfigurationManager.AppSettings["MongoConnectionString"], 
                ConfigurationManager.AppSettings["Database"]);
        }

        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            var users = this.data.All().ToList();
            return users;
        }

        [HttpPost]
        public HttpResponseMessage RegisterOrLoginUser(User user)
        {
            var userFromData = this.data.All()
                .Where(x => x.UserName == user.UserName)
                .FirstOrDefault();
            if (userFromData != null)
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, userFromData);
            }

            this.data.Add(user);
            var updatedUser = this.data.Update(user);
            var response = this.Request.CreateResponse(HttpStatusCode.Created, updatedUser);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage LogoutUser(User user)
        {
            var entity = this.data.All().Where(x => x.UserName == user.UserName).First();
            var updatedUser = this.data.Update(entity);
            var response = this.Request.CreateResponse(HttpStatusCode.OK, updatedUser);
            return response;
        }
    }
}