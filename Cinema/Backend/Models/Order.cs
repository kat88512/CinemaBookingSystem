namespace Cinema.Backend.Models
{
    public class Order
    {
        public Guid Id { get; private init; } = Guid.NewGuid();
        public OrderStatus Status { get; private set; }
        public int ValueToPay { get; private set; }
    }
}
