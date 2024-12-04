namespace Cinema.Backend.Models
{
    public class SeatStatus
    {
        public Guid SeatId { get; private init; }
        public bool IsTaken { get; private set; }
    }
}
