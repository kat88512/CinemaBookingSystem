using CinemaBookingSystem.Models.Enums;

namespace CinemaBookingSystem.Models
{
    public class CinemaRoom
    {
        public Guid Id { get; private init; } = Guid.NewGuid();
        public Guid CinemaId { get; private init; }
        public int RoomNumber { get; private set; }
        public CinemaRoomType RoomType { get; private set; }

        public List<CinemaRoomSeat> RoomSeats { get; private set; }

        public CinemaRoom(Guid cinemaId, int roomNumber, CinemaRoomType roomType)
        {
            CinemaId = cinemaId;
            RoomNumber = roomNumber;
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
                    seats.Add(new CinemaRoomSeat(row: i, number: j));
                }
            }

            return seats;
        }
    }
}
