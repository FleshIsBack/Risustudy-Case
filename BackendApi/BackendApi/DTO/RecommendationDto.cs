namespace BackendApi.DTO
{
    public class RecommendationDto
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> StudentNames { get; set; } = new();
        public string ExpectedImpact { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }

}
