using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Chat.Models
{
    public class User
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsOnline { get; set; }
        public ICollection<int> ContactList { get; set; }
    }
}