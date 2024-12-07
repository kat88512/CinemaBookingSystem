namespace Services.Requests
{
    public class RequestResult<T>
    {
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public T? Value { get; set; }
    }
}
