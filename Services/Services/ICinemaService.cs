using Domain.Models.CinemaModels;
using Services.Requests;

namespace Services.Services
{
    public interface ICinemaService
    {
        Response<Cinema> GetCinemaDetails();
    }
}
