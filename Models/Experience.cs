namespace Portfolio.Models
{
    public class Experience
    {
        public int Id { get; set; } 
        public string? JobTitle { get; set; } 
        public string? Company { get; set; }
        public string? Responsibilities { get; set; }
        public DateOnly FromDate { get; set; } 
        public DateOnly ToDate { get; set; } 
    }
}
