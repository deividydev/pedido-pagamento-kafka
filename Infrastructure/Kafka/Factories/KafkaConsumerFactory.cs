using Confluent.Kafka;

namespace Infrastructure.Kafka.Factories;

public static class KafkaConsumerFactory
{
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