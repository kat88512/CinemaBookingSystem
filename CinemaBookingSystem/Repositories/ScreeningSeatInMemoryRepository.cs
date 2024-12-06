﻿using CinemaBookingSystem.Models;
using CinemaBookingSystem.Repositories.Interfaces;

namespace CinemaBookingSystem.Repositories
{
    internal class ScreeningSeatInMemoryRepository : IScreeningSeatRepository
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

        public ScreeningSeat? GetById(Guid id)
        {
            return _screeningSeats.FirstOrDefault(ss => ss.Id == id);
        }
    }
}
