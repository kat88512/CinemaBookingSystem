﻿using CinemaBookingSystem.Models;
using CinemaBookingSystem.Models.Consts;
using CinemaBookingSystem.Repositories;

namespace CinemaBookingSystem.Views
{
    internal class MainView : IView
    {
        public static MainView Instance => _instance;

        private static readonly MainView _instance = new MainView();

        private readonly ScreeningInMemoryRepository _screeningRepository =
            ScreeningInMemoryRepository.Instance;
        private readonly CinemaInMemoryRepository _cinemaRepository =
            CinemaInMemoryRepository.Instance;

        private Cinema _cinema = null!;
        private List<Screening> _screenings = [];

        private MainView() { }

        public void Display()
        {
            Console.Clear();

            FetchData();

            PrintScreenings();
            var screening = ChooseScreening();

            new SeatView(screening.Id).Display();
        }

        private void FetchData()
        {
            _cinema = _cinemaRepository.GetFirst()!;
            _screenings = _screeningRepository.GetAll(_cinema.Id).ToList();
        }

        private void PrintScreenings()
        {
            Console.WriteLine($"Welcome to {_cinema.Name} in {_cinema.City}! \n");

            Console.WriteLine($"Available screenings: \n");

            for (int i = 0; i < _screenings.Count; i++)
            {
                var number = i;
                var movieName = _screenings[i].Movie.Name;
                var formattedStartDate = _screenings[i].TimeFrom.ToString(Formats.DateTimeFormat);

                Console.WriteLine($"{number}. {movieName} on {formattedStartDate}");
            }
        }

        private Screening ChooseScreening()
        {
            while (true)
            {
                Console.Write($"\nPlease choose a screening [0-{_screenings.Count - 1}]: ");

                var input = Console.ReadLine();
                var parseSuccess = int.TryParse(input, out var number);

                if (!parseSuccess || _screenings.ElementAtOrDefault(number) is null)
                {
                    Console.WriteLine("Incorrect number!");
                }
                else
                {
                    return _screenings[number];
                }
            }
        }
    }
}
