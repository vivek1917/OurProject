//using MongoDB.Driver;
//using OurProject.Models;

//namespace OurProject.Services
//{
//    public class AssignmentService
//    {
//        private readonly IMongoCollection<Assignment> _assignments;
//        private readonly IMongoCollection<Subject> _subjects;

//        public AssignmentService(IMongoDatabase database)
//        {
//            _assignments = database.GetCollection<Assignment>("Assignments"); // Replace "Assignments" with your collection name if different
//            _subjects = database.GetCollection<Subject>("Subjects"); // Ensure this matches your subject collection name
//        }

//        public async Task<List<Assignment>> GetAssignmentsAsync() =>
//            await _assignments.Find(_ => true).ToListAsync();

//        public async Task<Assignment?> GetAssignmentByIdAsync(string id) =>
//            await _assignments.Find(a => a.Id == id).FirstOrDefaultAsync();

//        public async Task<string?> GetSubjectNameByIdAsync(string subjectId)
//        {
//            var subject = await _subjects.Find(s => s.Id == subjectId).FirstOrDefaultAsync();
//            return subject?.Name; // Return the subject name or null if not found
//        }

//        public async Task CreateAssignmentAsync(Assignment assignment) =>
//            await _assignments.InsertOneAsync(assignment);

//        public async Task UpdateAssignmentAsync(string id, Assignment updatedAssignment) =>
//            await _assignments.ReplaceOneAsync(a => a.Id == id, updatedAssignment);

//        public async Task DeleteAssignmentAsync(string id) =>
//            await _assignments.DeleteOneAsync(a => a.Id == id);
//    }
//}



using MongoDB.Driver;
using OurProject.Models;

namespace OurProject.Services
{
    public class AssignmentService
    {
        private readonly IMongoCollection<Assignment> _assignments;
        private readonly IMongoCollection<Subject> _subjects;

        public AssignmentService(IMongoDatabase database)
        {
            _assignments = database.GetCollection<Assignment>("Assignments"); // Replace "Assignments" with your collection name if different
            _subjects = database.GetCollection<Subject>("Subjects"); // Ensure this matches your subject collection name
        }

        public async Task<List<Assignment>> GetAssignmentsAsync() =>
            await _assignments.Find(_ => true).ToListAsync();

        public async Task<Assignment?> GetAssignmentByIdAsync(string id) =>
            await _assignments.Find(a => a.Id == id).FirstOrDefaultAsync();

        public async Task<string?> GetSubjectNameByIdAsync(string subjectId)
        {
            var subject = await _subjects.Find(s => s.Id == subjectId).FirstOrDefaultAsync();
            return subject?.Name; // Return the subject name or null if not found
        }

        public async Task<List<Subject>> GetSubjectsByIdsAsync(List<string> subjectIds)
        {
            return await _subjects.Find(s => subjectIds.Contains(s.Id)).ToListAsync();
        }

        public async Task CreateAssignmentAsync(Assignment assignment) =>
            await _assignments.InsertOneAsync(assignment);

        public async Task UpdateAssignmentAsync(string id, Assignment updatedAssignment) =>
            await _assignments.ReplaceOneAsync(a => a.Id == id, updatedAssignment);

        public async Task DeleteAssignmentAsync(string id) =>
            await _assignments.DeleteOneAsync(a => a.Id == id);
    }
}
