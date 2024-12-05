using Cinema.Backend.Models.Enums;

namespace Cinema.Backend.Models
{
    public class CinemaRoom
    {
        public int Id { get; private set; }
        public CinemaRoomType RoomType { get; private set; }

        public List<Seat> Seats { get; private set; }

        public CinemaRoom(CinemaRoomType roomType)
        {
            RoomType = roomType;
            Seats = GenerateSeats();
        }

        private List<Seat> GenerateSeats()
        {
            var seats = new List<Seat>();

            var rowsCount = RoomType.RowsCount;
            var seatsPerRowCount = RoomType.SeatsPerRowCount;

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < seatsPerRowCount; j++)
                {
                    Seats.Add(new Seat(row: i, number: j));
                }
            }

            return seats;
        }
    }
}
