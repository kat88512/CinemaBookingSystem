using CinemaBookingSystem.Models;
using CinemaBookingSystem.Repositories.Interfaces;

namespace CinemaBookingSystem.Repositories
{
    internal class CinemaRoomInMemoryRepository : ICinemaRoomRepository
    {
        private readonly List<CinemaRoom> _cinemaRooms = new List<CinemaRoom>();

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
