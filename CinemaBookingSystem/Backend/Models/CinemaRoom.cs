using Cinema.Backend.Models.Enums;

namespace Cinema.Backend.Models
{
    public class CinemaRoom
    {
        public int Id { get; private set; }
        public CinemaRoomType RoomType { get; private set; }

        public List<CinemaRoomSeat> RoomSeats { get; private set; }

        public CinemaRoom(CinemaRoomType roomType)
        {
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
