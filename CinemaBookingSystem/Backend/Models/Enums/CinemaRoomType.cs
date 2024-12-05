using Cinema.Backend.Utilities;

namespace Cinema.Backend.Models.Enums
{
    public class CinemaRoomType : Enumeration
    {
        public static CinemaRoomType Small = new(1, nameof(Small));
        public static CinemaRoomType Medium = new(2, nameof(Medium));
        public static CinemaRoomType Large = new(3, nameof(Large));

        private CinemaRoomType(int id, string name)
            : base(id, name) { }
    }
}
