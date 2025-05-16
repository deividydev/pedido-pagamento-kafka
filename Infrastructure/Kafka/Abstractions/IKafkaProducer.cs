namespace Infrastructure.Kafka.Abstractions;

/// <summary>
/// Defines the contract for sending messages to Kafka topics.
/// </summary>
public interface IKafkaProducer
{
    /// <summary>
    /// Sends an event of type <typeparamref name="T"/> to the specified Kafka topic asynchronously.
    /// </summary>
    /// <typeparam name="T">The type of the event being sent. Must be a class.</typeparam>
    /// <param name="topic">The name of the Kafka topic.</param>
    /// <param name="event">The event to be serialized and sent.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task SendAsync<T>(string topic, T @event) where T : class;
}
