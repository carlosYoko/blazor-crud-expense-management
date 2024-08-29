namespace ExpenseManagement.Shared
{
    public class Movement
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public double Quantity { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public User? User { get; set; }
        public int UserId { get; set; }
    }
}
