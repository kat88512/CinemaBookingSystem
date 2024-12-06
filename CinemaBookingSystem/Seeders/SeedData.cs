namespace CinemaBookingSystem.Seeders
{
    internal static class SeedData
    {
        public static List<string> MovieNames =>
            [
                "The Godfather",
                "The Shawshank Redemption",
                "The Dark Knight",
                "The Big Lebowski",
                "Gladiator",
                "Saving Private Ryan",
                "Amélie",
                "Seven Samurai",
                "Friday"
            ];

        public static DateTime ScreeningDate => DateTime.Now.AddHours(new Random().Next(1, 80));
    }
}
