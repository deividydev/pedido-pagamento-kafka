using MediatR;

namespace Application.Orders.Requests;

public class OrderParymentRequest(Guid orderId, decimal value) : IRequest
{
    public Guid OrderId { get; set; } = orderId;
    public decimal Value { get; set; } = value;
}