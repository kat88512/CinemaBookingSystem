namespace Services.Requests
{
    public class Response<T>
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public T? Value { get; set; }
    }
}
