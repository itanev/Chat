using System;
using System.Collections.Generic;
using System.Linq;
using Chat.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace Chat.Repository
{
    public class UsersRepository : IRepository<User>
    {
        private MongoCollection users;

        public UsersRepository(string connectionString, string database)
        {
            //var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var db = server.GetDatabase(database);
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


        public User Update(User entity)
        {
            entity.IsOnline = !entity.IsOnline;
            var query = Query.EQ("UserName", entity.UserName);
            var update = new UpdateDocument { { "$set", new BsonDocument("IsOnline", entity.IsOnline.ToString()) } };
            this.users.Update(query, update);
            return entity;
        }
    }
}
