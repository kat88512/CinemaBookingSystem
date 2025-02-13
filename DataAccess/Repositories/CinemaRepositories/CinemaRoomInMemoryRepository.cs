﻿using Domain.Models.CinemaModels;

namespace DataAccess.Repositories.CinemaRepositories
{
    public class CinemaRoomInMemoryRepository : ICinemaRoomRepository
    {
        private readonly List<CinemaRoom> _cinemaRooms = [];

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
