using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace OurProject.Models
{
    public class Authentication
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }
    }

}
