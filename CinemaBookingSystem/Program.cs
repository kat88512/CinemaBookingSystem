using CinemaBookingSystem.Repositories;
using CinemaBookingSystem.Seeders;
using CinemaBookingSystem.Views;

var cinemaRepository = new CinemaInMemoryRepository();
var cinemaRoomRepository = new CinemaRoomInMemoryRepository();
var movieRepository = new MovieInMemoryRepository();
var screeningRepository = new ScreeningInMemoryRepository();
var screeningSeatRepository = new ScreeningSeatInMemoryRepository();

var seeder = new MainSeeder(
    movieRepository,
    cinemaRepository,
    cinemaRoomRepository,
    screeningRepository,
    screeningSeatRepository
);

seeder.Seed();

var mainView = new MainView(screeningRepository, cinemaRepository);

mainView.Display();
