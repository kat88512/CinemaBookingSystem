using CinemaBookingSystem.Seeders;
using CinemaBookingSystem.Views;

var seeder = new MainSeeder();

seeder.Seed();

var mainView = new MainView();

mainView.Display();
