using CinemaBookingSystem.Models;
using CinemaBookingSystem.Models.Enums;

namespace CinemaBookingSystem.Seeders
{
    internal static class SeedData
    {
        private const string CinemaName = "Megakino";
        private const string CinemaCity = "Kalisz";
        public static readonly Cinema Cinema = new Cinema(CinemaName, CinemaCity);

        public static readonly List<CinemaRoom> CinemaRooms =
        [
            new CinemaRoom(Cinema.Id, roomNumber: 1, roomType: CinemaRoomType.Small),
            new CinemaRoom(Cinema.Id, roomNumber: 2, roomType: CinemaRoomType.Medium),
            new CinemaRoom(Cinema.Id, roomNumber: 3, roomType: CinemaRoomType.Large),
        ];

        public static List<Movie> Movies =>
            [
                new Movie("The Godfather"),
                new Movie("The Shawshank Redemption"),
                new Movie("The Dark Knight"),
                new Movie("The Big Lebowski"),
                new Movie("Gladiator"),
                new Movie("Saving Private Ryan"),
                new Movie("Amélie"),
                new Movie("Seven Samurai"),
                new Movie("Friday")
            ];
    }
}
