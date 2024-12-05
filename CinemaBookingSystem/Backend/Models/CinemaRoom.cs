using Cinema.Backend.Models.Enums;

namespace Cinema.Backend.Models
{
    public class CinemaRoom
    {
        public int Id { get; private set; }
        public CinemaRoomType Type { get; private set; }
        public List<Seat> Seats { get; private set; }
    }
}
