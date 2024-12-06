using CinemaBookingSystem.Models.Enums;

namespace CinemaBookingSystem.Models
{
    public class CinemaRoom
    {
        public int Id { get; private set; }
        public Guid CinemaId { get; private init; }
        public CinemaRoomType RoomType { get; private set; }

        public List<CinemaRoomSeat> RoomSeats { get; private set; }

        public CinemaRoom(Guid cinemaId, CinemaRoomType roomType)
        {
            CinemaId = cinemaId;
            RoomType = roomType;
            RoomSeats = GenerateSeats();
        }

        private List<CinemaRoomSeat> GenerateSeats()
        {
            var seats = new List<CinemaRoomSeat>();

            var rowsCount = RoomType.RowsCount;
            var seatsPerRowCount = RoomType.SeatsPerRowCount;

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < seatsPerRowCount; j++)
                {
                    RoomSeats.Add(new CinemaRoomSeat(row: i, number: j));
                }
            }

            return seats;
        }
    }
}
