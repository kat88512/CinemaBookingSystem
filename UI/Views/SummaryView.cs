using UI.Extensions;
using UI.ViewModels;

namespace UI.Views
{
    internal class SummaryView : IView
    {
        private readonly SummaryViewModel _viewModel;
        private readonly Navigator _navigator;

        public SummaryView(SummaryViewModel viewModel, Navigator navigator)
        {
            _viewModel = viewModel;
            _navigator = navigator;
        }

        public void Display()
        {
            Console.Clear();

            _viewModel.FetchData();

            PrintOrderSummary();
        }

        private void PrintOrderSummary()
        {
            Console.WriteLine("Your order summary: \n");
            ConsoleExtensions.WriteLineInColor("Seats:\n", foregroundColor: ConsoleColor.Cyan);

            foreach (var item in _viewModel.Order.Items)
            {
                ConsoleExtensions.WriteInColor(
                    $"{item.ScreeningSeat} ",
                    backgroundColor: ConsoleColor.DarkBlue
                );
                Console.WriteLine($": {item.SeatPrice} zł");
            }

            Console.WriteLine();
            ConsoleExtensions.WriteInColor("Value to pay: ", foregroundColor: ConsoleColor.Cyan);
            Console.WriteLine($"{_viewModel.Order.ValueToPay} zł");
        }
    }
}
