namespace Cinema.Backend.Models
{
    public class Seat
    {
        public Guid Id { get; private init; }
        public int Row { get; private set; }
        public int Number { get; private set; }
    }
}
