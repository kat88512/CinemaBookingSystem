using DataAccess.Repositories.OrderRepositories;
using DataAccess.Repositories.ScreeningRepositories;
using Domain.Models.OrderModels;
using Domain.Models.ScreeningModels;
using Services.Requests.OrderRequests;
using Tests.Builders;

namespace Tests.OrderTests
{
    [TestFixture]
    internal class AddScreeningSeatToOrderTests
    {
        private readonly IScreeningRepository _screenings = ScreeningInMemoryRepository.Instance;
        private readonly IScreeningSeatRepository _screeningSeats =
            ScreeningSeatInMemoryRepository.Instance;
        private readonly IOrderRepository _orders = OrderInMemoryRepository.Instance;

        [SetUp]
        public void Setup() { }

        [Test]
        public void ShouldAddSeatToOrder()
        {
            var screening = ScreeningBuilder.Create().WithDefaultData().Build();

            var screeningSeat = new ScreeningSeat(screening.Id, 5, 5);
            var order = new Order();

            _screenings.Add(screening);
            _screeningSeats.Add(screeningSeat);
            _orders.Add(order);

            new AddScreeningSeatToOrder(screeningSeat.Id, order.Id).Execute();

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

            new AddScreeningSeatToOrder(screeningSeat.Id, order.Id).Execute();

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

            new AddScreeningSeatToOrder(screeningSeat.Id, order.Id).Execute();

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

            new AddScreeningSeatToOrder(screeningSeat.Id, order.Id).Execute();

            var changedOrder = _orders.GetById(order.Id)!;
            Assert.That(changedOrder.Items.Any(), Is.False);
        }
    }
}
