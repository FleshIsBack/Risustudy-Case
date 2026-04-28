using BackendApi.DTO;

namespace BackendApi.Interfaces
{
    public interface IRecommendationService
    {
        List<RecommendationDto> GetRecommendations(Guid classId);
    }
}
