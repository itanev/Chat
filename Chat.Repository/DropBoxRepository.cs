using System;
using System.Collections.Generic;
using System.Linq;
using Chat.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Chat.Repository
{
    public class DropBoxRepository : IRepository<Dropbox>
    {
        private MongoCollection AccessTokens { get; set; }

        public DropBoxRepository(string connectionString)
        {
            //var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var db = server.GetDatabase("chat");
            this.AccessTokens = db.GetCollection<Dropbox>("dropbox");
        }

        public void Add(Dropbox entity)
        {
            this.AccessTokens.Insert(entity);
        }

        public IQueryable<Dropbox> All()
        {
            return this.AccessTokens.AsQueryable<Dropbox>();
        }


        public Dropbox Update(Dropbox entity)
        {
            throw new NotImplementedException();
        }
    }
}
