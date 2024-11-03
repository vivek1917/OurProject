﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace OurProject.Models
{
    public class AssignmentResult
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string AssignmentSubmissionId { get; set; }

        public string Marks { get; set; }  // Could be grade or numeric
        public string ResultStatus { get; set; }  // "Success", "Partial Success", "Failure"
    }

}