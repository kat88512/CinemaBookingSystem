namespace Domain.Models.OrderModels
{
    public class Order(Guid userId)
    {
        public Guid Id { get; private init; } = Guid.NewGuid();
        public Guid UserId { get; private init; } = userId;
        public OrderStatus Status { get; private set; } = OrderStatus.InProgress;
        public IEnumerable<OrderItem> Items => _items.ToList();
        public decimal ValueToPay => _items.Sum(i => i.SeatPrice);

        private readonly ICollection<OrderItem> _items = [];

        public static readonly int MaxOrderItemsCount = 10;

        public void AddItem(OrderItem item)
        {
            _items.Add(item);
        }
    }
}
