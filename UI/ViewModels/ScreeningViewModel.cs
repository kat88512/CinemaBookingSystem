using Domain.Models.CinemaModels;
using Domain.Models.ScreeningModels;
using Domain.Models.UserModels;
using Services.Services;
using UI.DataContext;

namespace UI.ViewModels
{
    internal class ScreeningViewModel
    {
        public User User { get; private set; } = null!;
        public Cinema Cinema { get; private set; } = null!;
        public List<Screening> Screenings { get; private set; } = [];

        private readonly SessionContext _context;

        private readonly CinemaService _cinemaService;
        private readonly ScreeningService _screeningService;
        private readonly UserService _userService;

        public ScreeningViewModel(
            CinemaService cinemaService,
            ScreeningService screeningService,
            UserService userService,
            SessionContext context
        )
        {
            _cinemaService = cinemaService;
            _screeningService = screeningService;
            _userService = userService;
            _context = context;
        }

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
