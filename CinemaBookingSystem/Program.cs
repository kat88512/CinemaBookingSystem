using CinemaBookingSystem.Consts;
using CinemaBookingSystem.Views;
using Services.Seeders;

var seeder = new MainSeeder();

seeder.Seed();

Console.ForegroundColor = Colors.DefaultForegroundColor;
Console.BackgroundColor = Colors.DefaultBackgroundColor;

MainView.Instance.Display();
