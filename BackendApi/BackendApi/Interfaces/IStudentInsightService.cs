using BackendApi.DTO;

namespace BackendApi.Interfaces
{
    public interface IStudentInsightService
    {
        StudentInsightDto? GetStudentInsight(Guid studentId);
    }
}
