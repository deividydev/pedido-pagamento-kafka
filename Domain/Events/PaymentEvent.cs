namespace Domain.Events;

public class PaymentEvent(Guid orderId, decimal value)
{
    public Guid OrderId { get; set; } = orderId;
    public decimal Value { get; set; } = value;
}