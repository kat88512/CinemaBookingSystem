namespace Domain.Models.ScreeningModels
{
    public class ScreeningSeat(Guid screeningId, int row, int number, bool isTaken = false)
    {
        public Guid Id { get; private init; } = Guid.NewGuid();
        public Guid ScreeningId { get; } = screeningId;
        public int Row { get; } = row;
        public int Number { get; } = number;
        public bool IsTaken { get; private set; } = isTaken;

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
