using CinemaBookingSystem.Seeders;
using CinemaBookingSystem.Views;

var seeder = new MainSeeder();

seeder.Seed();

MainView.Instance.Display();
