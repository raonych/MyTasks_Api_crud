namespace MyTasks.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public bool Done { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;


        public int UserId { get; set; }
        public required User User { get; set; }
    }
}   
