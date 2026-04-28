namespace BackendApi.Models
{
    public class Recommendation
    {
        public Guid Id { get; set; }
        public Guid ClassId { get; set; }
        public RecommendationType Type { get; set; }
        public Priority Priority { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Guid> TargetStudentIds { get; set; } = new();
        public string ExpectedImpact { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

    }
    public enum RecommendationType
    {
        Intervention,
        Grouping,
        Assignment,
        CheckIn
    }

    public enum Priority
    {
        High,
        Medium,
        Low
    }

}
