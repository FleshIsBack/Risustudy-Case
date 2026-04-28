namespace BackendApi.DTO
{
    public class StudentInsightDto
    {
        public Guid StudentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string AIAnalysis { get; set; } = string.Empty;
        public List<string> WeakTopics { get; set; } = new();
        public List<string> StrongTopics { get; set; } = new();
        public string Trend { get; set; } = string.Empty;
        public DateTime LastUpdated { get; set; }
    }
}
