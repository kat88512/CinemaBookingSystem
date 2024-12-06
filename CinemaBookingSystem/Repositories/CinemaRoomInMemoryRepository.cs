using CinemaBookingSystem.Models;
using CinemaBookingSystem.Repositories.Interfaces;

namespace CinemaBookingSystem.Repositories
{
    internal class CinemaRoomInMemoryRepository : ICinemaRoomRepository
    {
        public static CinemaRoomInMemoryRepository Instance => _instance;

        private static readonly CinemaRoomInMemoryRepository _instance =
            new CinemaRoomInMemoryRepository();

        private readonly List<CinemaRoom> _cinemaRooms = [];

        private CinemaRoomInMemoryRepository() { }

        public void Add(CinemaRoom cinemaRoom)
        {
            _cinemaRooms.Add(cinemaRoom);
        }

        public CinemaRoom? GetById(Guid id)
        {
            return _cinemaRooms.FirstOrDefault(cr => cr.Id == id);
        }
    }
}
