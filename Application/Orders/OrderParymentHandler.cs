using Application.Orders.Requests;
using Domain.Events;
using Infrastructure.Kafka.Abstractions;
using MediatR;

namespace Application.Orders;

public class OrderParymentHandler(IKafkaProducer kafkaProducer) : IRequestHandler<OrderParymentRequest>
{
    private readonly IKafkaProducer _kafkaProducer = kafkaProducer;

    public async Task Handle(OrderParymentRequest request, CancellationToken cancellationToken)
    {
        Console.WriteLine("Payment completed.");

        var @event = new PaymentEvent(Guid.NewGuid(), 100);

        await _kafkaProducer.SendAsync("payment_topic", @event);
    }
}