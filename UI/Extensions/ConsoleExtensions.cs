using UI.Consts;

namespace UI.Extensions
{
    internal class ConsoleExtensions
    {
        public static void WriteLineInColor(
            string value,
            ConsoleColor foregroundColor = Colors.DefaultForegroundColor,
            ConsoleColor backgroundColor = Colors.DefaultBackgroundColor
        )
        {
            SetColors(foregroundColor, backgroundColor);
            Console.WriteLine(value);
            ResetToDefaultColors();
        }

        public static void WriteLineInColor(
            int value,
            ConsoleColor foregroundColor = Colors.DefaultForegroundColor,
            ConsoleColor backgroundColor = Colors.DefaultBackgroundColor
        )
        {
            SetColors(foregroundColor, backgroundColor);
            Console.WriteLine(value);
            ResetToDefaultColors();
        }

        public static void WriteInColor(
            string value,
            ConsoleColor foregroundColor = Colors.DefaultForegroundColor,
            ConsoleColor backgroundColor = Colors.DefaultBackgroundColor
        )
        {
            SetColors(foregroundColor, backgroundColor);
            Console.Write(value);
            ResetToDefaultColors();
        }

        public static void WriteInColor(
            int value,
            ConsoleColor foregroundColor = Colors.DefaultForegroundColor,
            ConsoleColor backgroundColor = Colors.DefaultBackgroundColor
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
            Console.ForegroundColor = Colors.DefaultForegroundColor;
            Console.BackgroundColor = Colors.DefaultBackgroundColor;
        }
    }
}
