using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace OurProject.Models
{
    public class Assignment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Description { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string SubjectId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CourseId { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string TeacherId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        //public string Status { get; set; }  // "Ongoing", "Overdue", "Submitted", "Rated"
    }
    
}
