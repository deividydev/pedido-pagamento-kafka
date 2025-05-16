namespace Infrastructure.Kafka.Abstractions;

/// <summary>
/// Defines a contract for validating Kafka-related operations.
/// </summary>
public interface IKafkaValidator
{
    /// <summary>
    /// Checks if a given Kafka topic exists.
    /// </summary>
    /// <param name="topicName">The name of the Kafka topic to check.</param>
    /// <returns><c>true</c> if the topic exists; otherwise, <c>false</c>.</returns>
    bool TopicExists(string topicName);
}
