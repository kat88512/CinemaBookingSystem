namespace Cinema.Backend.Models
{
    public class SeatStatus
    {
        public Seat Seat { get; private init; }
        public bool IsTaken { get; private set; } = false;

        public SeatStatus(Seat seat)
        {
            Seat = seat;
        }

        public void ChangeStatus(bool isTaken)
        {
            IsTaken = isTaken;
        }
    }
}
