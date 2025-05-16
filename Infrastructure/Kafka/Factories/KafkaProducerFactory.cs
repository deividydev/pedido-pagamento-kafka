using Confluent.Kafka;

namespace Infrastructure.Kafka.Factories;

/// <summary>
/// Factory responsible for creating Kafka producers used to publish messages to Kafka topics.
/// </summary>
public static class KafkaProducerFactory
{
    /// <summary>
    /// Creates a new Kafka <see cref="IProducer{TKey, TValue}"/> instance for producing messages with a null key and string value.
    /// </summary>
    /// <returns>
    /// An <see cref="IProducer{Null, String}"/> configured to connect to the Kafka cluster.
    /// </returns>
    public static IProducer<Null, string> Create()
    {
        var config = new ProducerConfig
        {
            BootstrapServers = "localhost:9092"
        };

        return new ProducerBuilder<Null, string>(config).Build();
    }
}
