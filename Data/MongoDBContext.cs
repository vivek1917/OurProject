using Microsoft.Extensions.Options;
using MongoDB.Driver;
using OurProject.Models;

namespace OurProject.Data
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<Student> Students => _database.GetCollection<Student>("Students");
        public IMongoCollection<Teacher> Teachers => _database.GetCollection<Teacher>("Teachers");
        public IMongoCollection<Authentication> Authentications => _database.GetCollection<Authentication>("Authentications");
        public IMongoCollection<Assignment> Assignments => _database.GetCollection<Assignment>("Assignments");
        public IMongoCollection<AssignmentSubmission> AssignmentSubmissions => _database.GetCollection<AssignmentSubmission>("AssignmentSubmissions");
        public IMongoCollection<AssignmentResult> AssignmentResults => _database.GetCollection<AssignmentResult>("AssignmentResults");
        public IMongoCollection<Subject> Subjects => _database.GetCollection<Subject>("Subjects");
        public IMongoCollection<TeacherSubject> TeacherSubjects => _database.GetCollection<TeacherSubject>("TeacherSubjects");
        public IMongoCollection<Course> Courses => _database.GetCollection<Course>("Courses");
        public IMongoCollection<CourseSubject> CourseSubjects => _database.GetCollection<CourseSubject>("CourseSubjects");
        public IMongoCollection<TestCase> TestCases => _database.GetCollection<TestCase>("TestCases");

    }
}