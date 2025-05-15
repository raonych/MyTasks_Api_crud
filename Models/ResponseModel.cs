namespace MyTasks.Models
{ 
    public class ResponseModel<T>
    {
        public T? Data { get; set; }
        public string? Message { get; set; }
        public bool Success { get; set; } = true;
    }
}