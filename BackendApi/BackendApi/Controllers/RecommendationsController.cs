using BackendApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("api/classes")]
    public class RecommendationController : ControllerBase
    {
        private readonly IRecommendationService _recommendationService;

        public RecommendationController(IRecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }

        [HttpGet("{classId:guid}/recommendations")]
        public IActionResult GetRecommendations(Guid classId)
        {
            var recommendations = _recommendationService.GetRecommendations(classId);
            if(recommendations == null || !recommendations.Any())
            {
                return NotFound(new { message = $"No recommendations found for class with ID {classId}" });
            }
            return Ok(recommendations);
        }
    }
}
