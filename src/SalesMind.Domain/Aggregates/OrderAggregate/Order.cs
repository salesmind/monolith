namespace SalesMind.Domain.Aggregates.OrderAggregate;
public class Order : Entity<Guid>, IAggregateRoot
{
    private readonly List<OrderItem> _items = [];
    public OrderAddress Address { get; private set; }
    public string OrderNo { get; private set; }
    public string Description { get; private set; }
    public OrderStatus Status { get; private set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();
}
