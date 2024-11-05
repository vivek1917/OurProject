using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace OurProject.Models
{
    public class TestCase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string AssignmentId { get; set; }

        public string Input { get; set; }
        public string ExpectedOutput { get; set; }
    }

}