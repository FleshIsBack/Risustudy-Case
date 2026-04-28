using BackendApi.DTO;

namespace BackendApi.Interfaces
{
    public interface IClassPerformanceService
    {
        ClassPerformanceDto GetClassPerformance(Guid classId);
    }
}
