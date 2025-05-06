using Confluent.Kafka;

namespace Infrastructure.Kafka.Factories;

public static class KafkaProducerFactory
{
    public static IProducer<Null, string> Create()
    {
        var config = new ProducerConfig
        {
            BootstrapServers = "localhost:9092"
        };

        return new ProducerBuilder<Null, string>(config).Build();
    }
}