//using Microsoft.AspNetCore.Mvc;
//using OurProject.Models;
//using OurProject.Services;
//using System.Threading.Tasks;
//using System.Collections.Generic;

//namespace OurProject.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AssignmentSubmissionController : ControllerBase
//    {
//        private readonly AssignmentSubmissionService _submissionService;

//        public AssignmentSubmissionController(AssignmentSubmissionService submissionService)
//        {
//            _submissionService = submissionService;
//        }

//        [HttpGet]
//        public async Task<ActionResult<List<AssignmentSubmission>>> GetAllSubmissions()
//        {
//            var submissions = await _submissionService.GetAllSubmissionsAsync();
//            return Ok(submissions);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<AssignmentSubmission>> GetSubmissionById(string id)
//        {
//            var submission = await _submissionService.GetSubmissionByIdAsync(id);
//            if (submission == null)
//            {
//                return NotFound();
//            }
//            return Ok(submission);
//        }

//        [HttpGet("assignment/{assignmentId}")]
//        public async Task<ActionResult<List<AssignmentSubmission>>> GetSubmissionsByAssignmentId(string assignmentId)
//        {
//            var submissions = await _submissionService.GetSubmissionsByAssignmentIdAsync(assignmentId);
//            return Ok(submissions);
//        }

//        [HttpGet("student/{studentId}")]
//        public async Task<ActionResult<List<AssignmentSubmission>>> GetSubmissionsByStudentId(string studentId)
//        {
//            var submissions = await _submissionService.GetSubmissionsByStudentIdAsync(studentId);
//            return Ok(submissions);
//        }

//        [HttpPost]
//        public async Task<ActionResult> CreateSubmission([FromBody] AssignmentSubmission submission)
//        {
//            submission.SubmittedDate = DateTime.UtcNow;
//            await _submissionService.CreateSubmissionAsync(submission);
//            return CreatedAtAction(nameof(GetSubmissionById), new { id = submission.Id }, submission);
//        }

//        [HttpPut("{id}")]
//        public async Task<ActionResult> UpdateSubmission(string id, [FromBody] AssignmentSubmission updatedSubmission)
//        {
//            var existingSubmission = await _submissionService.GetSubmissionByIdAsync(id);
//            if (existingSubmission == null)
//            {
//                return NotFound();
//            }

//            updatedSubmission.Id = id;
//            await _submissionService.UpdateSubmissionAsync(id, updatedSubmission);
//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult> DeleteSubmission(string id)
//        {
//            var existingSubmission = await _submissionService.GetSubmissionByIdAsync(id);
//            if (existingSubmission == null)
//            {
//                return NotFound();
//            }

//            await _submissionService.DeleteSubmissionAsync(id);
//            return NoContent();
//        }
//    }
//}
