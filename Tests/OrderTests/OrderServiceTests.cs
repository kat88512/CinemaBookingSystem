using DataAccess.Repositories.OrderRepositories;
using DataAccess.Repositories.ScreeningRepositories;
using Domain.Models.OrderModels;
using Domain.Models.ScreeningModels;
using Services.Services;
using Tests.Builders;

namespace Tests.OrderTests
{
    [TestFixture]
    internal class OrderServiceTests
    {
        private IScreeningRepository _screenings;
        private IScreeningSeatRepository _screeningSeats;
        private IOrderRepository _orders;

        private OrderService _orderService;

        [SetUp]
        public void Setup()
        {
            _screenings = new ScreeningInMemoryRepository();
            _screeningSeats = new ScreeningSeatInMemoryRepository();
            _orders = new OrderInMemoryRepository();

            _orderService = new OrderService(_orders, _screenings, _screeningSeats);
        }

        [Test]
        public void ShouldAddSeatToOrder()
        {
            var screening = ScreeningBuilder.Create().WithDefaultData().Build();
            var screeningSeat = new ScreeningSeat(screening.Id, 5, 5);
            var order = new Order();

            _screenings.Add(screening);
            _screeningSeats.Add(screeningSeat);
            _orders.Add(order);

            _orderService.AddScreeningSeatToOrder(order.Id, screeningSeat.Id);

            var changedOrder = _orders.GetById(order.Id)!;
            Assert.That(changedOrder.Items.Any(), Is.True);
        }

        [Test]
        public void ShouldNotAddSeatWhenScreeningStartTimeIsInThePast()
        {
            var yesterday = DateTime.Now.AddDays(-1);

            var screening = ScreeningBuilder
                .Create()
                .WithDefaultData()
                .WithTime(timeFrom: yesterday, duration: TimeSpan.FromHours(2))
                .Build();

            var screeningSeat = new ScreeningSeat(screening.Id, 5, 5);
            var order = new Order();

            _screenings.Add(screening);
            _screeningSeats.Add(screeningSeat);
            _orders.Add(order);

            _orderService.AddScreeningSeatToOrder(order.Id, screeningSeat.Id);

            var changedOrder = _orders.GetById(order.Id)!;
            Assert.That(changedOrder.Items.Any(), Is.False);
        }

        [Test]
        public void ShouldNotAddSeatWhenSeatIsTaken()
        {
            var screening = ScreeningBuilder.Create().WithDefaultData().Build();

            var screeningSeat = new ScreeningSeat(screening.Id, 5, 5, isTaken: true);
            var order = new Order();

            _screenings.Add(screening);
            _screeningSeats.Add(screeningSeat);
            _orders.Add(order);

            _orderService.AddScreeningSeatToOrder(order.Id, screeningSeat.Id);

            var changedOrder = _orders.GetById(order.Id)!;
            Assert.That(changedOrder.Items.Any(), Is.False);
        }

        [Test]
        public void ShouldNotAddSeatWhenScreeningDoesNotExist()
        {
            var screeningSeat = new ScreeningSeat(Guid.NewGuid(), 5, 5);
            var order = new Order();

            _screeningSeats.Add(screeningSeat);
            _orders.Add(order);

            _orderService.AddScreeningSeatToOrder(order.Id, screeningSeat.Id);

            var changedOrder = _orders.GetById(order.Id)!;
            Assert.That(changedOrder.Items.Any(), Is.False);
        }
    }
}
