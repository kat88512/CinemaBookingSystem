using Domain.Models.CinemaModels;
using Domain.Models.ScreeningModels;
using Services.Services;
using UI.DataContext;

namespace UI.ViewModels
{
    internal class ScreeningViewModel(
        CinemaService cinemaService,
        ScreeningService screeningService,
        SessionContext context
    )
    {
        public Cinema Cinema { get; private set; } = null!;
        public List<Screening> Screenings { get; private set; } = [];

        private readonly SessionContext _context = context;

        private readonly CinemaService _cinemaService = cinemaService;
        private readonly ScreeningService _screeningService = screeningService;

        public void FetchData()
        {
            Cinema = _cinemaService.GetCinemaDetails().Value!;
            Screenings = _screeningService.GetCinemaScreenings(Cinema.Id).Value!.ToList();
        }

        public void AddScreeningContext(Guid screeningId)
        {
            _context.ScreeningId = screeningId;
        }
    }
}
