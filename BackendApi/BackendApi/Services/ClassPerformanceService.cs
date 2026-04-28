using BackendApi.Data;
using BackendApi.DTO;
using BackendApi.Interfaces;
using BackendApi.Models;

namespace BackendApi.Services
{
    public class ClassPerformanceService : IClassPerformanceService
    {
        public ClassPerformanceDto GetClassPerformance(Guid classId)
        {
            var classEntity = MockData.Classes.FirstOrDefault(c => c.Id == classId);
            if (classEntity == null)
            {
                throw new KeyNotFoundException($"Class with ID {classId} not found");
            }

            var students = MockData.Students.Where(s => s.ClassId == classId).ToList();

            return new ClassPerformanceDto
            {
                ClassId = classEntity.Id,
                ClassName = classEntity.Name,
                Summary = CalculateSummary(students),
                Students = students.Select(MapToStudentSummary).ToList()
            };
        }

        private static ClassSummaryDto CalculateSummary(List<Student> students)
        {
            return new ClassSummaryDto
            {
                AdvancedCount = students.Count(s => s.Status == StudentStatus.Advanced),
                OnTrackCount = students.Count(s => s.Status == StudentStatus.OnTrack),
                NeedsAttentionCount = students.Count(s => s.Status == StudentStatus.NeedsAttention),
                TotalStudents = students.Count
            };
        }

        private static StudentSummaryDto MapToStudentSummary(Student student)
        {
            return new StudentSummaryDto
            {
                Id = student.Id,
                Name = student.Name,
                Status = student.Status.ToString().ToLower(),
                Progress = student.progressPercentage,
            };
        }
    }
}