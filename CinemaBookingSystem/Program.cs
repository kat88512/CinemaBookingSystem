using CinemaBookingSystem.Views;
using Services.Seeders;

var seeder = new MainSeeder();

seeder.Seed();

MainView.Instance.Display();
