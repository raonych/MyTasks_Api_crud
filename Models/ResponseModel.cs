namespace MyTasks.Models
{
    public class ResponseModel<T>
    {
        public T? Data { get; set; }
        public string? Message { get; set; }
        public bool Success { get; set; } = true;
        public int Status { get; set; } = 200; // retorna status 200 por padrão 
    }
}