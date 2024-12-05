using Cinema.Backend.Models.Enums;

namespace Cinema.Backend.Models
{
    public class CinemaRoom
    {
        public int Id { get; private set; }
        public CinemaRoomType Type { get; private set; }

        public List<Seat> Seats { get; private set; }

        public CinemaRoom(CinemaRoomType type)
        {
            Type = type;
            Seats = GenerateSeats();
        }

        private List<Seat> GenerateSeats()
        {
            var seats = new List<Seat>();

            var rowsCount = Type.RowsCount;
            var seatsPerRowCount = Type.SeatsPerRowCount;

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
