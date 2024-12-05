namespace Cinema.Backend.Models
{
    public readonly struct CinemaRoomSeat
    {
        public int Row { get; }
        public int Number { get; }

        public CinemaRoomSeat(int row, int number)
        {
            Row = row;
            Number = number;
        }
    }
}
