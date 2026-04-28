namespace BackendApi.Models
{
    public class AllInsigt
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public string Analysis { get; set; } = string.Empty;
        public List<Topic> WeakTopics { get; set; } = new();
        public List<Topic> StrongTopics { get; set; } = new();
        public LearningTrend Trend { get; set; }
        public DateTime GeneratedAt { get; set; }

    }
    public enum LearningTrend
    {
        Improving,
        Stable,
        Declining,
    }
}
