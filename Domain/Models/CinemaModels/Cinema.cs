﻿namespace Domain.Models.CinemaModels
{
    public class Cinema
    {
        public Guid Id { get; private init; } = Guid.NewGuid();
        public string Name { get; private set; }
        public string City { get; private set; }

        public Cinema(string name, string city)
        {
            Name = name;
            City = city;
        }
    }
}
