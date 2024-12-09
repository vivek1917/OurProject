////using OurProject.Models;
////using MongoDB.Driver;

////namespace OurProject.Services
////{
////    public class AssignmentSubmissionService
////    {
////        private readonly IMongoCollection<AssignmentSubmission> _assignmentSubmissions;

////        public AssignmentSubmissionService(IMongoDatabase database)
////        {
////            _assignmentSubmissions = database.GetCollection<AssignmentSubmission>("AssignmentSubmissions");
////        }

////        public async Task<List<AssignmentSubmission>> GetAllSubmissionsAsync()
////        {
////            return await _assignmentSubmissions.Find(submission => true).ToListAsync();
////        }

////        public async Task<AssignmentSubmission> GetSubmissionByIdAsync(string id)
////        {
////            return await _assignmentSubmissions.Find(submission => submission.Id == id).FirstOrDefaultAsync();
////        }

////        public async Task<List<AssignmentSubmission>> GetSubmissionsByAssignmentIdAsync(string assignmentId)
////        {
////            return await _assignmentSubmissions.Find(submission => submission.AssignmentId == assignmentId).ToListAsync();
////        }

////        public async Task<List<AssignmentSubmission>> GetSubmissionsByStudentIdAsync(string studentId)
////        {
////            return await _assignmentSubmissions.Find(submission => submission.StudentId == studentId).ToListAsync();
////        }

////        public async Task CreateSubmissionAsync(AssignmentSubmission submission)
////        {
////            await _assignmentSubmissions.InsertOneAsync(submission);
////        }

////        public async Task UpdateSubmissionAsync(string id, AssignmentSubmission updatedSubmission)
////        {
////            await _assignmentSubmissions.ReplaceOneAsync(submission => submission.Id == id, updatedSubmission);
////        }

////        public async Task DeleteSubmissionAsync(string id)
////        {
////            await _assignmentSubmissions.DeleteOneAsync(submission => submission.Id == id);
////        }
////    }
////}



//using MongoDB.Driver;
//using OurProject.Models;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace OurProject.Services
//{
//    public class AssignmentSubmissionService
//    {
//        private readonly IMongoCollection<AssignmentSubmission> _submissions;
//        private readonly IMongoCollection<Assignment> _assignments;

//        public AssignmentSubmissionService(IMongoDatabase database)
//        {
//            _submissions = database.GetCollection<AssignmentSubmission>("AssignmentSubmissions");
//            _assignments = database.GetCollection<Assignment>("Assignments");
//        }

//        public async Task<List<AssignmentSubmission>> GetAllSubmissionsAsync()
//        {
//            return await _submissions.Find( _ => true).ToListAsync();
//        }

//        public async Task<AssignmentSubmission> GetSubmissionByIdAsync(string id)
//        {
//            return await _submissions.Find(sub => sub.Id == id).FirstOrDefaultAsync();
//        }

//        public async Task<List<AssignmentSubmission>> GetSubmissionsByAssignmentIdAsync(string assignmentId)
//        {
//            return await _submissions.Find(sub => sub.AssignmentId == assignmentId).ToListAsync();
//        }

//        public async Task<List<AssignmentSubmission>> GetSubmissionsByStudentIdAsync(string studentId)
//        {
//            return await _submissions.Find(sub => sub.StudentId == studentId).ToListAsync();
//        }

//        public async Task CreateSubmissionAsync(AssignmentSubmission submission)
//        {
//            await _submissions.InsertOneAsync(submission);
//        }

//        public async Task UpdateSubmissionAsync(string id, AssignmentSubmission updatedSubmission)
//        {
//            await _submissions.ReplaceOneAsync(sub => sub.Id == id, updatedSubmission);
//        }

//        public async Task DeleteSubmissionAsync(string id)
//        {
//            await _submissions.DeleteOneAsync(sub => sub.Id == id);
//        }

//        // Existing method to prevent duplicate submissions
//        public async Task<bool> SubmitAssignmentAsync(AssignmentSubmission submission)
//        {
//            var existingSubmission = await _submissions
//                .Find(sub => sub.AssignmentId == submission.AssignmentId && sub.StudentId == submission.StudentId)
//                .FirstOrDefaultAsync();

//            if (existingSubmission != null)
//            {
//                return false;
//            }

//            await _submissions.InsertOneAsync(submission);

//            var update = Builders<Assignment>.Update.Set(a => a.Status, "Submitted");
//            await _assignments.UpdateOneAsync(a => a.Id == submission.AssignmentId, update);

//            return true;
//        }
//    }
//}



//using MongoDB.Driver;
//using OurProject.Models;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using System;

//namespace OurProject.Services
//{
//    public class AssignmentSubmissionService
//    {
//        private readonly IMongoCollection<AssignmentSubmission> _submissions;
//        private readonly IMongoCollection<Assignment> _assignments;

//        public AssignmentSubmissionService(IMongoDatabase database)
//        {
//            _submissions = database.GetCollection<AssignmentSubmission>("AssignmentSubmissions");
//            _assignments = database.GetCollection<Assignment>("Assignments");
//        }

//        public async Task<List<AssignmentSubmission>> GetAllSubmissionsAsync()
//        {
//            try
//            {
//                return await _submissions.Find(_ => true).ToListAsync();
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error in GetAllSubmissionsAsync: " + ex.Message);
//                throw;
//            }
//        }

//        public async Task<AssignmentSubmission> GetSubmissionByIdAsync(string id)
//        {
//            try
//            {
//                return await _submissions.Find(sub => sub.Id == id).FirstOrDefaultAsync();
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error in GetSubmissionByIdAsync: " + ex.Message);
//                throw;
//            }
//        }

//        public async Task<List<AssignmentSubmission>> GetSubmissionsByAssignmentIdAsync(string assignmentId)
//        {
//            try
//            {
//                return await _submissions.Find(sub => sub.AssignmentId == assignmentId).ToListAsync();
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error in GetSubmissionsByAssignmentIdAsync: " + ex.Message);
//                throw;
//            }
//        }

//        public async Task<List<AssignmentSubmission>> GetSubmissionsByStudentIdAsync(string studentId)
//        {
//            try
//            {
//                return await _submissions.Find(sub => sub.StudentId == studentId).ToListAsync();
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error in GetSubmissionsByStudentIdAsync: " + ex.Message);
//                throw;
//            }
//        }

//        public async Task<bool> SubmitAssignmentAsync(AssignmentSubmission submission)
//        {
//            try
//            {
//                var existingSubmission = await _submissions
//                    .Find(sub => sub.AssignmentId == submission.AssignmentId && sub.StudentId == submission.StudentId)
//                    .FirstOrDefaultAsync();

//                if (existingSubmission != null)
//                {
//                    return false;
//                }

//                await _submissions.InsertOneAsync(submission);


//                return true;
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error in SubmitAssignmentAsync: " + ex.Message);
//                throw;
//            }
//        }

//        public async Task UpdateSubmissionAsync(string id, AssignmentSubmission updatedSubmission)
//        {
//            try
//            {
//                await _submissions.ReplaceOneAsync(sub => sub.Id == id, updatedSubmission);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error in UpdateSubmissionAsync: " + ex.Message);
//                throw;
//            }
//        }

//        public async Task DeleteSubmissionAsync(string id)
//        {
//            try
//            {
//                await _submissions.DeleteOneAsync(sub => sub.Id == id);
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error in DeleteSubmissionAsync: " + ex.Message);
//                throw;
//            }
//        }

//        public async Task<bool> CheckIfSubmittedAsync(string studentId, string assignmentId)
//        {
//            try
//            {
//                // Query the database to check if a submission exists for the student and assignment
//                var submission = await _submissions.AssignmentSubmissions
//                    .FirstOrDefaultAsync(s => s.StudentId == studentId && s.AssignmentId == assignmentId);

//                return submission != null;  // Returns 'true' if a submission exists, 'false' otherwise
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine("Error in CheckIfSubmittedAsync: " + ex.Message);
//                throw;  // Rethrow the exception to be handled in the controller
//            }
//        }
//    }
//}


using MongoDB.Driver;
using OurProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace OurProject.Services
{
    public class AssignmentSubmissionService
    {
        private readonly IMongoCollection<AssignmentSubmission> _submissions;
        private readonly IMongoCollection<Assignment> _assignments;

        public AssignmentSubmissionService(IMongoDatabase database)
        {
            _submissions = database.GetCollection<AssignmentSubmission>("AssignmentSubmissions");
            _assignments = database.GetCollection<Assignment>("Assignments");
        }

        public async Task<List<AssignmentSubmission>> GetAllSubmissionsAsync()
        {
            try
            {
                return await _submissions.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetAllSubmissionsAsync: " + ex.Message);
                throw;
            }
        }

        public async Task<AssignmentSubmission> GetSubmissionByIdAsync(string id)
        {
            try
            {
                return await _submissions.Find(sub => sub.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetSubmissionByIdAsync: " + ex.Message);
                throw;
            }
        }

        public async Task<List<AssignmentSubmission>> GetSubmissionsByAssignmentIdAsync(string assignmentId)
        {
            try
            {
                return await _submissions.Find(sub => sub.AssignmentId == assignmentId).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetSubmissionsByAssignmentIdAsync: " + ex.Message);
                throw;
            }
        }

        public async Task<List<AssignmentSubmission>> GetSubmissionsByStudentIdAsync(string studentId)
        {
            try
            {
                return await _submissions.Find(sub => sub.StudentId == studentId).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetSubmissionsByStudentIdAsync: " + ex.Message);
                throw;
            }
        }

        public async Task<bool> SubmitAssignmentAsync(AssignmentSubmission submission)
        {
            try
            {
                // Check if the student has already submitted the assignment
                bool hasAlreadySubmitted = await CheckIfSubmittedAsync(submission.StudentId, submission.AssignmentId);

                if (hasAlreadySubmitted)
                {
                    // If already submitted, return false
                    return false;
                }

                // If not submitted, insert the new submission
                await _submissions.InsertOneAsync(submission);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in SubmitAssignmentAsync: " + ex.Message);
                throw;
            }
        }

        public async Task UpdateSubmissionAsync(string id, AssignmentSubmission updatedSubmission)
        {
            try
            {
                await _submissions.ReplaceOneAsync(sub => sub.Id == id, updatedSubmission);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UpdateSubmissionAsync: " + ex.Message);
                throw;
            }
        }

        public async Task DeleteSubmissionAsync(string id)
        {
            try
            {
                await _submissions.DeleteOneAsync(sub => sub.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in DeleteSubmissionAsync: " + ex.Message);
                throw;
            }
        }

        // Method to check if the student has already submitted the assignment
        public async Task<bool> CheckIfSubmittedAsync(string studentId, string assignmentId)
        {
            try
            {
                // Query to check if a submission exists for the student and assignment
                var submission = await _submissions
                    .Find(s => s.StudentId == studentId && s.AssignmentId == assignmentId)
                    .FirstOrDefaultAsync();

                return submission != null;  // Returns true if a submission exists, false otherwise
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in CheckIfSubmittedAsync: " + ex.Message);
                throw;
            }
        }
    }
}
