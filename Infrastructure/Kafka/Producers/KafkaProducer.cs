using System.Text.Json;
using Confluent.Kafka;
using Infrastructure.Kafka.Abstractions;
using Infrastructure.Kafka.Factories;

namespace Infrastructure.Kafka.Producers;

public class KafkaProducer : IKafkaProducer
{
    private readonly IProducer<Null, string> _producer;

    public KafkaProducer()
    {
        _producer = KafkaProducerFactory.Create();
    }

    public async Task SendAsync<T>(string topic, T @event) where T : class
    {
        var json = JsonSerializer.Serialize(@event);

        await _producer.ProduceAsync(topic, new Message<Null, string> { Value = json });
    }
}