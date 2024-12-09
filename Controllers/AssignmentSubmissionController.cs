////using Microsoft.AspNetCore.Mvc;
////using OurProject.Models;
////using OurProject.Services;
////using System.Threading.Tasks;
////using System.Collections.Generic;

////namespace OurProject.Controllers
////{
////    [ApiController]
////    [Route("api/[controller]")]
////    public class AssignmentSubmissionController : ControllerBase
////    {
////        private readonly AssignmentSubmissionService _submissionService;

////        public AssignmentSubmissionController(AssignmentSubmissionService submissionService)
////        {
////            _submissionService = submissionService;
////        }

////        [HttpGet]
////        public async Task<ActionResult<List<AssignmentSubmission>>> GetAllSubmissions()
////        {
////            var submissions = await _submissionService.GetAllSubmissionsAsync();
////            return Ok(submissions);
////        }

////        [HttpGet("{id}")]
////        public async Task<ActionResult<AssignmentSubmission>> GetSubmissionById(string id)
////        {
////            var submission = await _submissionService.GetSubmissionByIdAsync(id);
////            if (submission == null)
////            {
////                return NotFound();
////            }
////            return Ok(submission);
////        }

////        [HttpGet("assignment/{assignmentId}")]
////        public async Task<ActionResult<List<AssignmentSubmission>>> GetSubmissionsByAssignmentId(string assignmentId)
////        {
////            var submissions = await _submissionService.GetSubmissionsByAssignmentIdAsync(assignmentId);
////            return Ok(submissions);
////        }

////        [HttpGet("student/{studentId}")]
////        public async Task<ActionResult<List<AssignmentSubmission>>> GetSubmissionsByStudentId(string studentId)
////        {
////            var submissions = await _submissionService.GetSubmissionsByStudentIdAsync(studentId);
////            return Ok(submissions);
////        }

////        [HttpPost]
////        public async Task<ActionResult> CreateSubmission([FromBody] AssignmentSubmission submission)
////        {
////            submission.SubmittedDate = DateTime.UtcNow;
////            await _submissionService.CreateSubmissionAsync(submission);
////            return CreatedAtAction(nameof(GetSubmissionById), new { id = submission.Id }, submission);
////        }

////        [HttpPut("{id}")]
////        public async Task<ActionResult> UpdateSubmission(string id, [FromBody] AssignmentSubmission updatedSubmission)
////        {
////            var existingSubmission = await _submissionService.GetSubmissionByIdAsync(id);
////            if (existingSubmission == null)
////            {
////                return NotFound();
////            }

////            updatedSubmission.Id = id;
////            await _submissionService.UpdateSubmissionAsync(id, updatedSubmission);
////            return NoContent();
////        }

////        [HttpDelete("{id}")]
////        public async Task<ActionResult> DeleteSubmission(string id)
////        {
////            var existingSubmission = await _submissionService.GetSubmissionByIdAsync(id);
////            if (existingSubmission == null)
////            {
////                return NotFound();
////            }

////            await _submissionService.DeleteSubmissionAsync(id);
////            return NoContent();
////        }
////    }
////}

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



using Microsoft.AspNetCore.Mvc;
using OurProject.Models;
using OurProject.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace OurProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentSubmissionController : ControllerBase
    {
        private readonly AssignmentSubmissionService _submissionService;

        public AssignmentSubmissionController(AssignmentSubmissionService submissionService)
        {
            _submissionService = submissionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AssignmentSubmission>>> GetAllSubmissions()
        {
            try
            {
                var submissions = await _submissionService.GetAllSubmissionsAsync();
                return Ok(submissions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetAllSubmissions: " + ex.Message);
                return StatusCode(500, "An error occurred while retrieving submissions.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AssignmentSubmission>> GetSubmissionById(string id)
        {
            try
            {
                var submission = await _submissionService.GetSubmissionByIdAsync(id);
                if (submission == null)
                {
                    return NotFound();
                }
                return Ok(submission);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetSubmissionById: " + ex.Message);
                return StatusCode(500, "An error occurred while retrieving the submission.");
            }
        }

        [HttpGet("check-submission/{studentId}/{assignmentId}")]
        public async Task<ActionResult<bool>> CheckSubmissionStatus(string studentId, string assignmentId)
        {
            try
            {
                var submissionExists = await _submissionService.CheckIfSubmittedAsync(studentId, assignmentId);

                // Return 'true' if a submission exists, otherwise 'false'
                return Ok(submissionExists);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in CheckSubmissionStatus: " + ex.Message);
                return StatusCode(500, "An error occurred while checking the submission status.");
            }
        }

        [HttpGet("assignment/{assignmentId}")]
        public async Task<ActionResult<List<AssignmentSubmission>>> GetSubmissionsByAssignmentId(string assignmentId)
        {
            try
            {
                var submissions = await _submissionService.GetSubmissionsByAssignmentIdAsync(assignmentId);
                return Ok(submissions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetSubmissionsByAssignmentId: " + ex.Message);
                return StatusCode(500, "An error occurred while retrieving submissions.");
            }
        }

        [HttpGet("student/{studentId}")]
        public async Task<ActionResult<List<AssignmentSubmission>>> GetSubmissionsByStudentId(string studentId)
        {
            try
            {
                var submissions = await _submissionService.GetSubmissionsByStudentIdAsync(studentId);
                return Ok(submissions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetSubmissionsByStudentId: " + ex.Message);
                return StatusCode(500, "An error occurred while retrieving submissions.");
            }
        }

        //[HttpPost]
        //public async Task<ActionResult> CreateSubmission([FromBody] AssignmentSubmission submission)
        //{
        //    try
        //    {
        //        submission.SubmittedDate = DateTime.UtcNow;
        //        bool isSuccess = await _submissionService.SubmitAssignmentAsync(submission);

        //        if (!isSuccess)
        //        {
        //            return Conflict("Duplicate submission.");
        //        }

        //        return CreatedAtAction(nameof(GetSubmissionById), new { id = submission.Id }, submission);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error in CreateSubmission: " + ex.Message);
        //        return StatusCode(500, "An error occurred while creating the submission.");
        //    }
        //}

        [HttpPost]
        public async Task<ActionResult> CreateSubmission([FromBody] AssignmentSubmission submission)
        {
            try
            {
                // Set the submission date
                submission.SubmittedDate = DateTime.UtcNow;

                // Call your service to submit the assignment
                bool isSuccess = await _submissionService.SubmitAssignmentAsync(submission);

                if (!isSuccess)
                {
                    return Conflict("Duplicate submission.");
                }

                // Return success response
                return CreatedAtAction(nameof(GetSubmissionById), new { id = submission.Id }, submission);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in CreateSubmission: " + ex.Message);
                return StatusCode(500, "An error occurred while creating the submission.");
            }
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSubmission(string id, [FromBody] AssignmentSubmission updatedSubmission)
        {
            try
            {
                var existingSubmission = await _submissionService.GetSubmissionByIdAsync(id);
                if (existingSubmission == null)
                {
                    return NotFound();
                }

                updatedSubmission.Id = id;
                await _submissionService.UpdateSubmissionAsync(id, updatedSubmission);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UpdateSubmission: " + ex.Message);
                return StatusCode(500, "An error occurred while updating the submission.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSubmission(string id)
        {
            try
            {
                var existingSubmission = await _submissionService.GetSubmissionByIdAsync(id);
                if (existingSubmission == null)
                {
                    return NotFound();
                }

                await _submissionService.DeleteSubmissionAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in DeleteSubmission: " + ex.Message);
                return StatusCode(500, "An error occurred while deleting the submission.");
            }
        }
    }
}
