namespace Services.Requests
{
    internal interface IRequest<TResponse>
    {
        RequestResult<TResponse> Execute();
    }
}
