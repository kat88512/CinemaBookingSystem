﻿using Cinema.Backend.Models;

namespace CinemaBookingSystem.Backend.Models
{
    internal class Occupancy
    {
        public Screening Screening { get; private init; }
        public IEnumerable<SeatStatus> SeatStatuses { get; private set; }

        public Occupancy(Screening screening)
        {
            Screening = screening;
            SeatStatuses = Screening.CinemaRoom.Seats.Select(s => new SeatStatus(s)).ToList();
        }
    }
}
