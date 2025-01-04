using Domain.Models.CinemaModels;
using Domain.Models.MovieModels;
using Domain.Models.UserModels;

namespace Services.Seeders
{
    internal static class SeedData
    {
        private const string UserFirstName = "Adam";
        private const string UserLastName = "Nowak";
        private const string UserEmail = "adam.nowak@example.com";

        public static readonly User User = new User(UserFirstName, UserLastName, UserEmail);

        private const string CinemaName = "Megakino";
        private const string CinemaCity = "Kalisz";

        public static readonly Cinema Cinema = new(CinemaName, CinemaCity);

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
