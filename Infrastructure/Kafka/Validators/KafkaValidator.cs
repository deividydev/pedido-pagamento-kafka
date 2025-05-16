using Confluent.Kafka;
using Infrastructure.Kafka.Abstractions;
using Infrastructure.Kafka.Factories;

namespace Infrastructure.Kafka.Validators;

public class KafkaValidator : IKafkaValidator
{
    public bool TopicExists(string topicName)
    {
        try
        {
            var adminClient = KafkaManagerFactory.Create();

            var metadata = adminClient.GetMetadata(TimeSpan.FromSeconds(5));
            return metadata.Topics.Any(t => t.Topic == topicName && !t.Error.IsError);
        }
        catch (KafkaException ex)
        {
            Console.WriteLine($"Error topic: {ex.Message}");
            return false;
        }
    }
}