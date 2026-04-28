using BackendApi.Data;
using BackendApi.DTO;
using BackendApi.Interfaces;

namespace BackendApi.Services
{
    public class RecommendationService : IRecommendationService
    {
        public List<RecommendationDto> GetRecommendations(Guid classId)
        {
            var recommendations = MockData.Recommendations
                .Where(r => r.ClassId == classId)
                .OrderByDescending(r => r.Priority)
                .ThenByDescending(r => r.CreatedAt)
                .ToList();

            return recommendations.Select(r => new RecommendationDto
            {
                Id = r.Id,
                Type = r.Type.ToString().ToLower(),
                Priority = r.Priority.ToString().ToLower(),
                Title = r.Title,
                Description = r.Description,
                StudentNames = GetStudentNames(r.TargetStudentIds),
                ExpectedImpact = r.ExpectedImpact,
                CreatedAt = r.CreatedAt
            }).ToList();
        }

        private static List<string> GetStudentNames(List<Guid> studentIds)
        {
            return MockData.Students
                .Where(s => studentIds.Contains(s.Id))
                .Select(s => s.Name)
                .ToList();
        }
    }
}
