using System.Text.Json.Serialization;

namespace MyTasks.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool Done { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;


        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
    }
}   
