namespace Services.Requests
{
    internal interface IRequest<TResponse>
    {
        Response<TResponse> Execute();
    }
}
