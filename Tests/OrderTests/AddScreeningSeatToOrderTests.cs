using DataAccess.Repositories.OrderRepositories;
using DataAccess.Repositories.ScreeningRepositories;
using Domain.Models.CinemaModels;
using Domain.Models.MovieModels;
using Domain.Models.OrderModels;
using Domain.Models.ScreeningModels;
using Services.Requests.OrderRequests;

namespace Tests.OrderTests
{
    [TestFixture]
    internal class AddScreeningSeatToOrderTests
    {
        private readonly IScreeningRepository _screenings = ScreeningInMemoryRepository.Instance;
        private readonly IScreeningSeatRepository _screeningSeats =
            ScreeningSeatInMemoryRepository.Instance;
        private readonly IOrderRepository _orders = OrderInMemoryRepository.Instance;

        private Movie _defaultMovie = new("Test movie name");
        private Cinema _defaultCinema = new("Test cinema name", "Test city");

        [SetUp]
        public void Setup() { }

        [Test]
        public void ShouldAddSeatToOrder()
        {
            var cinemaRoom = new CinemaRoom(_defaultCinema.Id, 1, CinemaRoomType.Large);
            var timeFrom = DateTime.Now.AddDays(1);
            var timeTo = DateTime.Now.AddDays(1).AddHours(2);
            var screening = new Screening(_defaultMovie, cinemaRoom, timeFrom, timeTo);
            var screeningSeat = new ScreeningSeat(screening.Id, 5, 5);
            var order = new Order();

            _screenings.Add(screening);
            _screeningSeats.Add(screeningSeat);
            _orders.Add(order);

            new AddScreeningSeatToOrder(screeningSeat.Id, order.Id).Execute();

            var changedOrder = _orders.GetById(order.Id)!;
            Assert.IsTrue(changedOrder.Items.Any());
        }

        [Test]
        public void ShouldNotAddSeatWhenScreeningStartTimeIsInThePast()
        {
            var cinemaRoom = new CinemaRoom(_defaultCinema.Id, 1, CinemaRoomType.Large);
            var timeFrom = DateTime.Now.AddDays(-1);
            var timeTo = DateTime.Now.AddDays(-1).AddHours(2);
            var screening = new Screening(_defaultMovie, cinemaRoom, timeFrom, timeTo);
            var screeningSeat = new ScreeningSeat(screening.Id, 5, 5);
            var order = new Order();

            _screenings.Add(screening);
            _screeningSeats.Add(screeningSeat);
            _orders.Add(order);

            new AddScreeningSeatToOrder(screeningSeat.Id, order.Id).Execute();

            var changedOrder = _orders.GetById(order.Id)!;
            Assert.IsFalse(changedOrder.Items.Any());
        }

        [Test]
        public void ShouldNotAddSeatWhenSeatIsTaken()
        {
            var cinemaRoom = new CinemaRoom(_defaultCinema.Id, 1, CinemaRoomType.Large);
            var timeFrom = DateTime.Now.AddDays(1);
            var timeTo = DateTime.Now.AddDays(1).AddHours(2);
            var screening = new Screening(_defaultMovie, cinemaRoom, timeFrom, timeTo);
            var screeningSeat = new ScreeningSeat(screening.Id, 5, 5, isTaken: true);
            var order = new Order();

            _screenings.Add(screening);
            _screeningSeats.Add(screeningSeat);
            _orders.Add(order);

            new AddScreeningSeatToOrder(screeningSeat.Id, order.Id).Execute();

            var changedOrder = _orders.GetById(order.Id)!;
            Assert.IsFalse(changedOrder.Items.Any());
        }
    }
}
