using Confluent.Kafka;

namespace Infrastructure.Kafka.Factories;

/// <summary>
/// Factory responsible for creating Kafka consumers.
/// </summary>
public static class KafkaConsumerFactory
{
    /// <summary>
    /// Creates a new Kafka consumer instance configured with the specified consumer group ID.
    /// </summary>
    /// <param name="groupId">The consumer group ID used to identify the consumer group.</param>
    /// <returns>
    /// An <see cref="IConsumer{Ignore, String}"/> configured to consume messages from Kafka.
    /// </returns>
    public static IConsumer<Ignore, string> Create(string groupId)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = "localhost:9092",
            GroupId = groupId,
            AutoOffsetReset = AutoOffsetReset.Earliest
        };

        return new ConsumerBuilder<Ignore, string>(config).Build();
    }
}