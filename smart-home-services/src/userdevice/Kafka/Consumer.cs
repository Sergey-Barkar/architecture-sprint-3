using Confluent.Kafka;

namespace SmartHome.Devices.Kafka;

public class KafkaConsumer : IHostedService
{
    private readonly IConsumer<Ignore, string> consumer;
    private readonly string topicMono;

    public KafkaConsumer(IConfiguration _configuration)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = _configuration["Kafka:BootstrapServers"],
            GroupId = _configuration["Kafka:GroupId"],
            AutoOffsetReset = AutoOffsetReset.Earliest,
            AllowAutoCreateTopics = true,
        };

        topicMono = _configuration["Kafka:Topic_Mono"]!;
        consumer = new ConsumerBuilder<Ignore, string>(config).Build();
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        consumer.Subscribe(topicMono);
        
        try
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var consumeResult = consumer.Consume(cancellationToken); // mono sent something
            }
        }
        catch (OperationCanceledException)
        {
        }
        finally
        {
            consumer?.Close();
        }
        
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        consumer?.Close();
        return Task.CompletedTask;
    }
}