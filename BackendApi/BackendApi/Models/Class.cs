namespace BackendApi.Models
{
    public class Class
    {
        public Guid id { get; set; }
        public required string Name { get; set; }
        public required string Subject { get; set; }
        public required string Grade { get; set; }
    }
}
