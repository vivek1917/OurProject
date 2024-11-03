//using OurProject.Models;
//using MongoDB.Driver;

//namespace OurProject.Services
//{
//    public class AssignmentSubmissionService
//    {
//        private readonly IMongoCollection<AssignmentSubmission> _assignmentSubmissions;

//        public AssignmentSubmissionService(IMongoDatabase database)
//        {
//            _assignmentSubmissions = database.GetCollection<AssignmentSubmission>("AssignmentSubmissions");
//        }

//        public async Task<List<AssignmentSubmission>> GetAllSubmissionsAsync()
//        {
//            return await _assignmentSubmissions.Find(submission => true).ToListAsync();
//        }

//        public async Task<AssignmentSubmission> GetSubmissionByIdAsync(string id)
//        {
//            return await _assignmentSubmissions.Find(submission => submission.Id == id).FirstOrDefaultAsync();
//        }

//        public async Task<List<AssignmentSubmission>> GetSubmissionsByAssignmentIdAsync(string assignmentId)
//        {
//            return await _assignmentSubmissions.Find(submission => submission.AssignmentId == assignmentId).ToListAsync();
//        }

//        public async Task<List<AssignmentSubmission>> GetSubmissionsByStudentIdAsync(string studentId)
//        {
//            return await _assignmentSubmissions.Find(submission => submission.StudentId == studentId).ToListAsync();
//        }

//        public async Task CreateSubmissionAsync(AssignmentSubmission submission)
//        {
//            await _assignmentSubmissions.InsertOneAsync(submission);
//        }

//        public async Task UpdateSubmissionAsync(string id, AssignmentSubmission updatedSubmission)
//        {
//            await _assignmentSubmissions.ReplaceOneAsync(submission => submission.Id == id, updatedSubmission);
//        }

//        public async Task DeleteSubmissionAsync(string id)
//        {
//            await _assignmentSubmissions.DeleteOneAsync(submission => submission.Id == id);
//        }
//    }
//}
