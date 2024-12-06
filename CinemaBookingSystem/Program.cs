using CinemaBookingSystem.Repositories;
using CinemaBookingSystem.Seeders;
using CinemaBookingSystem.Services;

var cinemaId = SeedData.Cinema.Id;

var cinemaRepository = new CinemaInMemoryRepository();
var cinemaRoomRepository = new CinemaRoomInMemoryRepository();
var movieRepository = new MovieInMemoryRepository();
var screeningRepository = new ScreeningInMemoryRepository();

var seeder = new MainSeeder(
    movieRepository,
    cinemaRepository,
    cinemaRoomRepository,
    screeningRepository
);

seeder.Seed();

var screeningService = new ScreeningService(screeningRepository);

screeningService.PrintAll(cinemaId);
