namespace CinemaBookingSystem.Models
{
    public class ScreeningSeat
    {
        public Guid ScreeningId { get; }
        public int Row { get; }
        public int Number { get; }

        public ScreeningSeat(Guid screeningId, int row, int number)
        {
            ScreeningId = screeningId;
            Row = row;
            Number = number;
        }
    }
}
