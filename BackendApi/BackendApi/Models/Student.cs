namespace BackendApi.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public StudentStatus Status { get; set; }
        public int progressPercentage { get; set; }
        public Guid ClassId { get; set; }
    }

    public enum StudentStatus
    {
        Advanced,
        OnTrack,
        NeedsAttention
    }
}
