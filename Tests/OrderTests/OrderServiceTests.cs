using DataAccess.Repositories.OrderRepositories;
using DataAccess.Repositories.ScreeningRepositories;
using DataAccess.Repositories.UserRepositories;
using Domain.Models.OrderModels;
using Domain.Models.ScreeningModels;
using Domain.Models.UserModels;
using Services.Services;
using Tests.Builders;

namespace Tests.OrderTests
{
    [TestFixture]
    internal class OrderServiceTests
    {
        private IScreeningRepository _screeningRepository;
        private IScreeningSeatRepository _screeningSeatRepository;
        private IOrderRepository _orderRepository;
        private IUserRepository _userRepository;

        private OrderService _orderService;

        private User _user;

        [SetUp]
        public void Setup()
        {
            _screeningRepository = new ScreeningInMemoryRepository();
            _screeningSeatRepository = new ScreeningSeatInMemoryRepository();
            _orderRepository = new OrderInMemoryRepository();
            _userRepository = new UserInMemoryRepository();

            _orderService = new OrderService(
                _orderRepository,
                _screeningRepository,
                _screeningSeatRepository,
                _userRepository
            );

            _user = UserBuilder.Create().WithDefaultData().Build();
            _userRepository.Add(_user);
        }

        [Test]
        public void ShouldAddSeatToOrder()
        {
            var screening = ScreeningBuilder.Create().WithDefaultData().Build();
            var screeningSeat = new ScreeningSeat(screening.Id, 5, 5);
            var order = new Order(_user.Id);

            _screeningRepository.Add(screening);
            _screeningSeatRepository.Add(screeningSeat);
            _orderRepository.Add(order);

            _orderService.AddScreeningSeatToOrder(order.Id, screeningSeat.Id);

            var changedOrder = _orderRepository.GetById(order.Id)!;
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
            var order = new Order(_user.Id);

            _screeningRepository.Add(screening);
            _screeningSeatRepository.Add(screeningSeat);
            _orderRepository.Add(order);

            _orderService.AddScreeningSeatToOrder(order.Id, screeningSeat.Id);

            var changedOrder = _orderRepository.GetById(order.Id)!;
            Assert.That(changedOrder.Items.Any(), Is.False);
        }

        [Test]
        public void ShouldNotAddSeatWhenSeatIsTaken()
        {
            var screening = ScreeningBuilder.Create().WithDefaultData().Build();

            var screeningSeat = new ScreeningSeat(screening.Id, 5, 5, isTaken: true);
            var order = new Order(_user.Id);

            _screeningRepository.Add(screening);
            _screeningSeatRepository.Add(screeningSeat);
            _orderRepository.Add(order);

            _orderService.AddScreeningSeatToOrder(order.Id, screeningSeat.Id);

            var changedOrder = _orderRepository.GetById(order.Id)!;
            Assert.That(changedOrder.Items.Any(), Is.False);
        }

        [Test]
        public void ShouldNotAddSeatWhenScreeningDoesNotExist()
        {
            var screeningSeat = new ScreeningSeat(Guid.NewGuid(), 5, 5);
            var order = new Order(_user.Id);

            _screeningSeatRepository.Add(screeningSeat);
            _orderRepository.Add(order);

            _orderService.AddScreeningSeatToOrder(order.Id, screeningSeat.Id);

            var changedOrder = _orderRepository.GetById(order.Id)!;
            Assert.That(changedOrder.Items.Any(), Is.False);
        }
    }
}
