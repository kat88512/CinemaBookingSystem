namespace CinemaBookingSystem.Requests
{
    internal interface IRequest<TResponse>
    {
        RequestResult<TResponse> Execute();
    }
}
