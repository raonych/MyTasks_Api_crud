namespace MyTasks.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string Username { get; set; }
        
        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

        public List<Todo> Todos { get; set; } = new();
    }

}
