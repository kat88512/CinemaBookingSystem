using Cinema.Backend.Models.Enums;

namespace Cinema.Backend.Models
{
    public class CinemaRoom
    {
        public Guid Id { get; private set; }
        public Guid CinemaId { get; private set; }
        public CinemaRoomType Type { get; private set; }
    }
}
