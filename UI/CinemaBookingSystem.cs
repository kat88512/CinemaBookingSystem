using Services.Seeders;
using UI.Consts;
using UI.Views;

namespace UI
{
    internal class CinemaBookingSystem(Navigator navigator, MainSeeder seeder)
    {
        private readonly Navigator _navigator = navigator;
        private readonly MainSeeder _seeder = seeder;

        public void Run()
        {
            _seeder.Seed();

            SetDefaultColors();

            ShowInitialView();
        }

        private void SetDefaultColors()
        {
            Console.ForegroundColor = Colors.DefaultForegroundColor;
            Console.BackgroundColor = Colors.DefaultBackgroundColor;
        }

        private void ShowInitialView()
        {
            _navigator.ChangeView<ScreeningsView>();
        }
    }
}
