using Confluent.Kafka;
using Confluent.Kafka.Admin;

namespace SmartHome.Devices.Kafka;

public class KafkaProducer
{
    private readonly IProducer<string, string> producer;

    private readonly string topicTelemetry;

    public KafkaProducer(IConfiguration _configuration)
    {
        topicTelemetry = _configuration["Kafka:Topic_Telemetry"]!;

        var producerConfig = new ProducerConfig
        {
            BootstrapServers = _configuration["Kafka:BootstrapServers"]
        };

        producer = new ProducerBuilder<string, string>(producerConfig).Build();
    }

    public void registrateAction(Int64 _deviceId, Int64 _actionId, TimeSpan timeout)
    {
        producer.Produce(topicTelemetry, new Message<string, string>
        {
            Key = Guid.NewGuid().ToString(),
            Value = $"{_deviceId};1;33;{DateTime.UtcNow.ToString()}"
        });
    }
    
    public void Dispose()
    {
        producer?.Dispose();
    }
}