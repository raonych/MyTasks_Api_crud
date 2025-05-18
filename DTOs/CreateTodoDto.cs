namespace MyTasks.DTOs
{
    public class CreateTodoDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public bool Done { get; set; }

        public int UserId { get; set; }

    }
}