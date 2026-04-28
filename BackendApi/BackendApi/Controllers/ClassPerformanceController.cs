using BackendApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("api/classes")]
    public class ClassPerformanceController : ControllerBase
    {
        private readonly IClassPerformanceService _classPerformanceService;

        public ClassPerformanceController(IClassPerformanceService classPerformanceService)
        {
            _classPerformanceService = classPerformanceService;
        }

        [HttpGet("{classId:guid}/performance")]
        public IActionResult GetClassPerformance(Guid classId)
        {
            try
            {
                var performance = _classPerformanceService.GetClassPerformance(classId);
                return Ok(performance);
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = $"Class with ID {classId} not found" });
            }
        }
    }
}