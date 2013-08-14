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
        private MongoCollection users;

        public UsersRepository(string connectionString)
        {
            //var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var db = server.GetDatabase("chat");
            this.users = db.GetCollection<User>("users");
        }

        public void Add(User user)
        {
            this.users.Insert(user);
        }

        public IQueryable<User> All()
        {
            return this.users.AsQueryable<User>();
        }
    }
}
