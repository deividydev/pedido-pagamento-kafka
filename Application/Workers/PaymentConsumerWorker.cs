using System.Text.Json;
using Domain.Events;
using Infrastructure.Kafka.Factories;
using Microsoft.Extensions.Hosting;

namespace Application.Workers;

public class PaymentConsumerWorker : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = KafkaConsumerFactory.Create("group_order");

        consumer.Subscribe("payment_topic");

        while (!stoppingToken.IsCancellationRequested)
        {
            var result = consumer.Consume(stoppingToken);
            var @event = JsonSerializer.Deserialize<PaymentEvent>(result.Message.Value);

            if (@event == null)
                Console.WriteLine("Error object null");

            Console.WriteLine($"Receive event: OrderId: {@event!.OrderId} Value: {@event.Value}");
        }

        return Task.CompletedTask;
    }
}