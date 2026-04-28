namespace BackendApi.Models
{
    public class Student
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        StudentStatus Status { get; set; }
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
