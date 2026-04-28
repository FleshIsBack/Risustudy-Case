namespace BackendApi.Models
{
    public class Topic
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Subject { get; set; }
    }
}
