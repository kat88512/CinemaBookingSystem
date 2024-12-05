namespace Cinema.Backend.Models
{
    public class Seat
    {
        public int Row { get; private set; }
        public int Number { get; private set; }

        public Seat(int row, int number)
        {
            Row = row;
            Number = number;
        }
    }
}
