namespace Infrastructure.Kafka.Abstractions;

public interface IKafkaProducer
{
    Task SendAsync<T>(string topic, T @event) where T : class;
}