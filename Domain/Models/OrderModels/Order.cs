namespace Domain.Models.OrderModels
{
    public class Order
    {
        public Guid Id { get; private init; } = Guid.NewGuid();
        public OrderStatus Status { get; private set; } = OrderStatus.InProgress;
        public IEnumerable<OrderItem> Items => _items.ToList();
        public int ValueToPay { get; private set; } = 0;

        public const int MaxOrderItemsCount = 10;

        private readonly ICollection<OrderItem> _items = [];

        public void AddItem(OrderItem item)
        {
            _items.Add(item);
        }
    }
}
