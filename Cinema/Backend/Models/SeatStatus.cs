namespace Cinema.Backend.Models
{
    public class SeatStatus
    {
        public Seat Seat { get; private init; }
        public bool IsTaken { get; private set; }
    }
}
