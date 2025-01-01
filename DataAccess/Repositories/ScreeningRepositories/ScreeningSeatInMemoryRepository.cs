using Domain.Models.ScreeningModels;

namespace DataAccess.Repositories.ScreeningRepositories
{
    public class ScreeningSeatInMemoryRepository : IScreeningSeatRepository
    {
        private readonly List<ScreeningSeat> _screeningSeats = [];

        public void Add(ScreeningSeat screeningSeat)
        {
            _screeningSeats.Add(screeningSeat);
        }

        public void AddBatch(IEnumerable<ScreeningSeat> screeningSeats)
        {
            _screeningSeats.AddRange(screeningSeats);
        }

        public IEnumerable<ScreeningSeat> GetAll(Guid screeningId)
        {
            return _screeningSeats.Where(ss => ss.ScreeningId == screeningId);
        }

        public IOrderedEnumerable<ScreeningSeat> GetRow(Guid screeningId, int rowNumber)
        {
            return _screeningSeats
                .Where(ss => ss.ScreeningId == screeningId && ss.Row == rowNumber)
                .OrderBy(ss => ss.Number);
        }

        public ScreeningSeat? GetById(Guid id)
        {
            return _screeningSeats.FirstOrDefault(ss => ss.Id == id);
        }

        public void Update(ScreeningSeat screeningSeat)
        {
            var item = _screeningSeats.FirstOrDefault(ss => ss.Id == screeningSeat.Id);
            item = screeningSeat;
        }

        public int GetSeatsCount(Guid screeningId, bool? isTaken)
        {
            if (isTaken is null)
            {
                return _screeningSeats.Where(ss => ss.Id == screeningId).Count();
            }
            else
            {
                return _screeningSeats
                    .Where(ss => ss.Id == screeningId && ss.IsTaken == isTaken)
                    .Count();
            }
        }
    }
}
