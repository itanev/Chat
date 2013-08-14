using MongoDB.Bson.Serialization.Attributes;

namespace Chat.Models
{
    class Dropbox
    {
        [BsonId]
        public int Id { get; set; }
        public string Value { get; set; }
        public string Secret { get; set; }
    }
}
