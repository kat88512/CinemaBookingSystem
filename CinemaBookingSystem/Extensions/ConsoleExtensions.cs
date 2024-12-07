namespace CinemaBookingSystem.Extensions
{
    internal class ConsoleExtensions
    {
        public static void WriteLineInColor(
            string value,
            ConsoleColor foregroundColor = Consts.Colors.DefaultForegroundColor,
            ConsoleColor backgroundColor = Consts.Colors.DefaultBackgroundColor
        )
        {
            SetColors(foregroundColor, backgroundColor);
            Console.WriteLine(value);
            ResetToDefaultColors();
        }

        public static void WriteLineInColor(
            int value,
            ConsoleColor foregroundColor = Consts.Colors.DefaultForegroundColor,
            ConsoleColor backgroundColor = Consts.Colors.DefaultBackgroundColor
        )
        {
            SetColors(foregroundColor, backgroundColor);
            Console.WriteLine(value);
            ResetToDefaultColors();
        }

        public static void WriteInColor(
            string value,
            ConsoleColor foregroundColor = Consts.Colors.DefaultForegroundColor,
            ConsoleColor backgroundColor = Consts.Colors.DefaultBackgroundColor
        )
        {
            SetColors(foregroundColor, backgroundColor);
            Console.Write(value);
            ResetToDefaultColors();
        }

        public static void WriteInColor(
            int value,
            ConsoleColor foregroundColor = Consts.Colors.DefaultForegroundColor,
            ConsoleColor backgroundColor = Consts.Colors.DefaultBackgroundColor
        )
        {
            SetColors(foregroundColor, backgroundColor);
            Console.Write(value);
            ResetToDefaultColors();
        }

        private static void SetColors(ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
        }

        private static void ResetToDefaultColors()
        {
            Console.ForegroundColor = Consts.Colors.DefaultForegroundColor;
            Console.BackgroundColor = Consts.Colors.DefaultBackgroundColor;
        }
    }
}
