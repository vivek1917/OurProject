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
                var existingSubmission = await _submissions
                    .Find(sub => sub.AssignmentId == submission.AssignmentId && sub.StudentId == submission.StudentId)
                    .FirstOrDefaultAsync();

                if (existingSubmission != null)
                {
                    return false;
                }

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
    }
}
