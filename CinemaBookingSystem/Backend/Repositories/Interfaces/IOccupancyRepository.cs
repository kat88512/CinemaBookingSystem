using CinemaBookingSystem.Backend.Models;

namespace CinemaBookingSystem.Backend.Repositories.Interfaces
{
    internal interface IOccupancyRepository
    {
        Occupancy GetBy(Guid screeningId);
    }
}
