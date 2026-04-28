using BackendApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentInsightController : ControllerBase
    {
        private readonly IStudentInsightService _studentInsightService;
        public StudentInsightController(IStudentInsightService studentInsightService)
        {
            _studentInsightService = studentInsightService;
        }
        [HttpGet("{studentId:guid}/insight")]
        public IActionResult GetStudentInsight(Guid studentId)
        {
            var insight = _studentInsightService.GetStudentInsight(studentId);
            if (insight == null)
            {
                return NotFound(new { message = $"Student with ID {studentId} not found" });
            }
            return Ok(insight);
        }
    }

}
