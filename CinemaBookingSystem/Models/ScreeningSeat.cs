namespace CinemaBookingSystem.Models
{
    public class ScreeningSeat
    {
        public Guid Id { get; private init; } = Guid.NewGuid();
        public Guid ScreeningId { get; }
        public int Row { get; }
        public int Number { get; }
        public bool IsTaken { get; private set; } = false;

        public ScreeningSeat(Guid screeningId, int row, int number)
        {
            ScreeningId = screeningId;
            Row = row;
            Number = number;
        }

        public override string ToString()
        {
            return $"{Row}{Number}";
        }
    }
}
