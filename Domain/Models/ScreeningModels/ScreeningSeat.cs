namespace Domain.Models.ScreeningModels
{
    public class ScreeningSeat
    {
        public Guid Id { get; private init; } = Guid.NewGuid();
        public Guid ScreeningId { get; }
        public int Row { get; }
        public int Number { get; }
        public bool IsTaken { get; private set; }

        public ScreeningSeat(Guid screeningId, int row, int number, bool isTaken = false)
        {
            ScreeningId = screeningId;
            Row = row;
            Number = number;
            IsTaken = isTaken;
        }

        public void ChangeStatus(bool isTaken)
        {
            IsTaken = isTaken;
        }

        public override string ToString()
        {
            return $"{Row}{Number}";
        }
    }
}
