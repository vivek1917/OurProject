using Microsoft.AspNetCore.Mvc;
using OurProject.Models;
using OurProject.Services;

namespace OurProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly AssignmentService _assignmentService;

        public AssignmentController(AssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAssignments()
        {
            var assignments = await _assignmentService.GetAssignmentsAsync();
            var assignmentResponses = new List<object>();

            foreach (var assignment in assignments)
            {
                var subjectName = await _assignmentService.GetSubjectNameByIdAsync(assignment.SubjectId);
                assignmentResponses.Add(new
                {
                    assignment,
                    SubjectName = subjectName
                });
            }

            return Ok(assignmentResponses);
        }

        [HttpGet("teacher")]
        public async Task<IActionResult> GetAssignments([FromQuery] string teacherId)
        {
            if (string.IsNullOrEmpty(teacherId))
            {
                return BadRequest(new { message = "Teacher ID is required" });
            }

            var assignments = await _assignmentService.GetAssignmentsByTeacherIdAsync(teacherId);
            var assignmentResponses = new List<object>();

            foreach (var assignment in assignments)
            {
                var subjectName = await _assignmentService.GetSubjectNameByIdAsync(assignment.SubjectId);
                assignmentResponses.Add(new
                {
                    assignment,
                    SubjectName = subjectName
                });
            }

            return Ok(assignmentResponses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssignmentById(string id)
        {
            var assignment = await _assignmentService.GetAssignmentByIdAsync(id);
            if (assignment == null)
            {
                return NotFound(new { message = "Assignment not found" });
            }

            var subjectName = await _assignmentService.GetSubjectNameByIdAsync(assignment.SubjectId);
            var response = new
            {
                assignment,
                SubjectName = subjectName
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAssignment([FromBody] Assignment assignment)
        {
            await _assignmentService.CreateAssignmentAsync(assignment);
            return CreatedAtAction(nameof(GetAssignmentById), new { id = assignment.Id }, assignment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAssignment(string id, [FromBody] Assignment updatedAssignment)
        {
            var assignment = await _assignmentService.GetAssignmentByIdAsync(id);
            if (assignment == null)
            {
                return NotFound(new { message = "Assignment not found" });
            }

            updatedAssignment.Id = id;
            await _assignmentService.UpdateAssignmentAsync(id, updatedAssignment);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment(string id)
        {
            var assignment = await _assignmentService.GetAssignmentByIdAsync(id);
            if (assignment == null)
            {
                return NotFound(new { message = "Assignment not found" });
            }

            await _assignmentService.DeleteAssignmentAsync(id);
            return NoContent();
        }
    }
}
