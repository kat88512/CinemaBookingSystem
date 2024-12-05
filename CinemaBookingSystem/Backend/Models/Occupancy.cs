using Cinema.Backend.Models;

namespace CinemaBookingSystem.Backend.Models
{
    internal class Occupancy
    {
        public Screening Screening { get; private init; }
        public IEnumerable<ScreeningSeat> AvailableSeats { get; private set; }

        public Occupancy(Screening screening)
        {
            Screening = screening;
            AvailableSeats = Screening
                .CinemaRoom.RoomSeats.Select(rs => new ScreeningSeat(
                    Screening.Id,
                    rs.Row,
                    rs.Number
                ))
                .ToList();
        }
    }
}
