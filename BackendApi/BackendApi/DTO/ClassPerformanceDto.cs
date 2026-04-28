namespace BackendApi.DTO
{
    public class ClassPerformanceDto
    {
        public Guid ClassId { get; set; }
        public string ClassName { get; set; } = string.Empty;
        public ClassSummaryDto Summary { get; set; } = new();
        public List<StudentSummaryDto> Students { get; set; } = new();
    }

    public class ClassSummaryDto
    {
        public int AdvancedCount { get; set; }
        public int OnTrackCount { get; set; }
        public int NeedsAttentionCount { get; set; }
        public int TotalStudents { get; set; }
    }

    public class StudentSummaryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int Progress { get; set; }
        public string Avatar { get; set; } = string.Empty;
    }

}
