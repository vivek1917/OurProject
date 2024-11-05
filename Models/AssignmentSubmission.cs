using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace OurProject.Models
{
    public class AssignmentSubmission
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        //[BsonRepresentation(BsonType.ObjectId)]
        public string StudentId { get; set; }

        //[BsonRepresentation(BsonType.ObjectId)]
        public string AssignmentId { get; set; }

        public string SubmittedCode { get; set; }
        public string ExecutionImage { get; set; }
        public DateTime SubmittedDate { get; set; }
    }

}
