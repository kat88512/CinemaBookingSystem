﻿using Domain.Models.ScreeningModels;

namespace DataAccess.Repositories.ScreeningRepositories
{
    public class ScreeningInMemoryRepository : IScreeningRepository
    {
        private readonly List<Screening> _screenings = [];

        public IEnumerable<Screening> GetAll(Guid cinemaId)
        {
            return _screenings.Where(s => s.CinemaRoom.CinemaId == cinemaId);
        }

        public Screening? GetById(Guid id)
        {
            return _screenings.FirstOrDefault(s => s.Id == id);
        }

        public void Add(Screening screening)
        {
            _screenings.Add(screening);
        }
    }
}
