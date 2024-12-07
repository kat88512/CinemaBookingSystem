using Domain.Utilities;

namespace Domain.Models.Enums
{
    public class CinemaRoomType : Enumeration
    {
        public static readonly CinemaRoomType Small =
            new(1, nameof(Small), rowsCount: 5, seatsPerRowCount: 5);
        public static readonly CinemaRoomType Medium =
            new(2, nameof(Medium), rowsCount: 5, seatsPerRowCount: 7);
        public static readonly CinemaRoomType Large =
            new(3, nameof(Large), rowsCount: 5, seatsPerRowCount: 10);

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
