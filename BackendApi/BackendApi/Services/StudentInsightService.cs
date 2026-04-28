using BackendApi.Data;
using BackendApi.DTO;
using BackendApi.Interfaces;

namespace RisustudyTeacher.Api.Services
{
    public class StudentInsightService : IStudentInsightService
    {
        public StudentInsightDto? GetStudentInsight(Guid studentId)
        {
            var student = MockData.Students.FirstOrDefault(s => s.Id == studentId);
            if (student == null)
            {
                return null;
            }

            if (!MockData.Insights.TryGetValue(studentId, out var insight))
            {
                return null;
            }

            return new StudentInsightDto
            {
                StudentId = student.Id,
                Name = student.Name,
                AIAnalysis = insight.Analysis,
                WeakTopics = insight.WeakTopics.Select(t => t.Name).ToList(),
                StrongTopics = insight.StrongTopics.Select(t => t.Name).ToList(),
                Trend = insight.Trend.ToString().ToLower(),
                LastUpdated = insight.GeneratedAt
            };
        }
    }
}