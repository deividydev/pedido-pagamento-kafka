using System.Text.Json;
using Domain.Events;
using Infrastructure.Kafka.Abstractions;
using Infrastructure.Kafka.Factories;
using Microsoft.Extensions.Hosting;

namespace Application.Workers;

/// <summary>
/// Background worker that consumes payment events from a Kafka topic.
/// </summary>
/// <param name="kafkaValidator">Validator service to check if Kafka topics exist.</param>
public class PaymentConsumerWorker(IKafkaValidator kafkaValidator) : BackgroundService
{
    private readonly IKafkaValidator _kafkaValidator = kafkaValidator;

    /// <summary>
    /// Executes the background service, subscribing to the "payment_topic" and processing messages.
    /// </summary>
    /// <param name="stoppingToken">Cancellation token to stop the execution.</param>
    /// <returns>A task representing the background operation.</returns>
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = KafkaConsumerFactory.Create("group_order");

        if (consumer == null || !_kafkaValidator.TopicExists("payment_topic"))
            return Task.CompletedTask;

        consumer.Subscribe("payment_topic");

        while (!stoppingToken.IsCancellationRequested)
        {
            var result = consumer.Consume(stoppingToken);
            var @event = JsonSerializer.Deserialize<PaymentEvent>(result.Message.Value);

            if (@event == null)
                Console.WriteLine("Error object is null");

            Console.WriteLine($"Receive event: OrderId: {@event!.OrderId} Value: {@event.Value}");

            Console.WriteLine("Send email to confirm payment.");
        }

        return Task.CompletedTask;
    }
}
