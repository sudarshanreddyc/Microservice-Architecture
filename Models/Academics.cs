namespace Portfolio.Models
{
    public class Academics
    {
        public int Id { get; set; } 
        public string? School { get; set; } 
        public decimal Percentage { get; set; } 
        public string? Level { get; set; }
        public string? Location { get; set; }
        public DateOnly FromDate { get; set; } 
        public DateOnly ToDate { get; set; } 
    }
}
