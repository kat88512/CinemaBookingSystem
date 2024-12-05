namespace Cinema.Backend.Models
{
    public struct Seat
    {
        public int Row { get; }
        public int Number { get; }

        public Seat(int row, int number)
        {
            Row = row;
            Number = number;
        }
    }
}
