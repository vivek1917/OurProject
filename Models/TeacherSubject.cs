using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace OurProject.Models
{
    public class TeacherSubject
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string TeacherId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string SubjectId { get; set; }
    }

}
