using System;
using System.Collections.Generic;
using System.Linq;
using Chat.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Chat.Repository
{
    public class UsersRepository : IRepository<User>
    {
        private MongoCollection Users { get; set; }

        public UsersRepository(string connectionString)
        {
            //var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = MongoServer.Create(connectionString);
            var db = server.GetDatabase("chat");
            this.Users = db.GetCollection<User>("users");
        }

        public void Add(User user)
        {
            this.Users.Insert(user);
        }

        public IQueryable<User> All()
        {
            return this.Users.AsQueryable<User>();
        }
    }
}
