﻿namespace Domain.Models.MovieModels
{
    public class Movie
    {
        public Guid Id { get; private init; } = Guid.NewGuid();
        public string Name { get; private set; } = string.Empty;

        public Movie(string name)
        {
            Name = name;
        }
    }
}
