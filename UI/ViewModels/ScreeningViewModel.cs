using Domain.Models.CinemaModels;
using Domain.Models.ScreeningModels;
using Domain.Models.UserModels;
using Services.Services;
using UI.DataContext;

namespace UI.ViewModels
{
    internal class ScreeningViewModel(
        CinemaService cinemaService,
        ScreeningService screeningService,
        UserService userService,
        SessionContext context
    )
    {
        public User User { get; private set; } = null!;
        public Cinema Cinema { get; private set; } = null!;
        public List<Screening> Screenings { get; private set; } = [];

        private readonly SessionContext _context = context;

        private readonly CinemaService _cinemaService = cinemaService;
        private readonly ScreeningService _screeningService = screeningService;
        private readonly UserService _userService = userService;

        public void FetchData()
        {
            User = _userService.GetUserDetails().Value!;
            Cinema = _cinemaService.GetCinemaDetails().Value!;
            Screenings = _screeningService.GetCinemaScreenings(Cinema.Id).Value!.ToList();

            _context.UserId = User.Id;
            _context.CinemaId = Cinema.Id;
        }

        public void ChooseScreening(Guid screeningId)
        {
            _context.ScreeningId = screeningId;
        }
    }
}
