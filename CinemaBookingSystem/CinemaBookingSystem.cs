using UI.Consts;
using UI.Views;

namespace UI
{
    internal class CinemaBookingSystem(Navigator navigator)
    {
        private readonly Navigator _navigator = navigator;

        public void Run()
        {
            SetColors();
            ShowInitialView();
        }

        private void SetColors()
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
