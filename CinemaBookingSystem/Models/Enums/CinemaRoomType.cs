using CinemaBookingSystem.Utilities;

namespace CinemaBookingSystem.Models.Enums
{
    public class CinemaRoomType : Enumeration
    {
        public static readonly CinemaRoomType Small =
            new(1, nameof(Small), rowsCount: 8, seatsPerRowCount: 10);
        public static readonly CinemaRoomType Medium =
            new(2, nameof(Medium), rowsCount: 12, seatsPerRowCount: 10);
        public static readonly CinemaRoomType Large =
            new(3, nameof(Large), rowsCount: 16, seatsPerRowCount: 10);

        public int RowsCount { get; private init; }
        public int SeatsPerRowCount { get; private init; }

        private CinemaRoomType(int id, string name, int rowsCount, int seatsPerRowCount)
            : base(id, name)
        {
            RowsCount = rowsCount;
            SeatsPerRowCount = seatsPerRowCount;
        }
    }
}
