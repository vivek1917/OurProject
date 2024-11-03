using OurProject.Models;
using MongoDB.Driver;

namespace OurProject.Services
{
    public class AuthenticationService
    {
        private readonly IMongoCollection<Authentication> _authentications;
        private readonly IMongoCollection<Student> _students;
        private readonly IMongoCollection<Teacher> _teachers;

        public AuthenticationService(IMongoDatabase database)
        {
            _authentications = database.GetCollection<Authentication>("Authentications");
            _students = database.GetCollection<Student>("Students");
            _teachers = database.GetCollection<Teacher>("Teachers");
        }

        public async Task<object> AuthenticateUser(string email, string password)
        {
            var authRecord = await _authentications.Find(a => a.Email == email && a.Password == password).FirstOrDefaultAsync();

            if (authRecord == null)
                return null;

            if (authRecord.Role == "Teacher")
            {
                var teacher = await _teachers.Find(t => t.Id == authRecord.UserId).FirstOrDefaultAsync();
                return new
                {
                    Id = authRecord.Id,
                    Role = authRecord.Role,
                    Name = teacher?.Name,
                    UserId = authRecord.UserId
                };
            }
            else if (authRecord.Role == "Student")
            {
                var student = await _students.Find(s => s.Id == authRecord.UserId).FirstOrDefaultAsync();
                return new
                {
                    Id = authRecord.Id,
                    Role = authRecord.Role,
                    Name = student?.Name,
                    UserId = authRecord.UserId,
                    CourseId = student?.CourseId,
                    Semester = student?.Semester,
                    Year = student?.Year
                };
            }

            return null;
        }
    }
}
