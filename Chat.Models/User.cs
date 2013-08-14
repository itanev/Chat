using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Chat.Models
{
    public class User
    {
        [BsonId]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public ICollection<int> ContactList { get; set; }
    }
}
