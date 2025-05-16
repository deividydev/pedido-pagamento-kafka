using Confluent.Kafka;

namespace Infrastructure.Kafka.Factories;

/// <summary>
/// Factory responsible for creating Kafka admin clients used to manage Kafka resources (e.g., topics).
/// </summary>
public static class KafkaManagerFactory
{
    /// <summary>
    /// Creates a new Kafka <see cref="IAdminClient"/> instance for administrative operations.
    /// </summary>
    /// <returns>
    /// An <see cref="IAdminClient"/> configured to connect to the Kafka cluster.
    /// </returns>
    public static IAdminClient Create()
    {
        return new AdminClientBuilder(new AdminClientConfig
        {
            BootstrapServers = "localhost:9092"
        }).Build();
    }
}
