using Confluent.Kafka;
using SmartHomeSystem.Controllers;
using SmartHomeSystem.Model;
using System;

namespace SmartHomeSystem.Kafka
{
    public class KafkaConsumerService : BackgroundService
    {
        private readonly IConsumer<string, string> consumer;
        private readonly IServiceScopeFactory factory;
        private readonly string topicTelemetry;
        //public event EventHandler<MessageConsumeEventArgs> OnMessageConsume;

        public KafkaConsumerService(IConfiguration _configuration, IServiceScopeFactory _factory)
        {
            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = _configuration["Kafka:BootstrapServers"],
                GroupId = _configuration["Kafka:GroupId"],
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            consumer = new ConsumerBuilder<string, string>(consumerConfig).Build();
            factory = _factory;
            topicTelemetry = _configuration["Kafka:Topic_Telemetry"]!;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(() => 
            {
                consumer.Subscribe(topicTelemetry);

                while (!stoppingToken.IsCancellationRequested)
                {
                    //OnMessageConsume?.Invoke(this, new MessageConsumeEventArgs((consumer.Consume(stoppingToken).Message.Value));
                    ProcessMessage(consumer.Consume(stoppingToken).Message.Value);
                }
            }, 
            stoppingToken);
        }

        /*
        public class MessageConsumeEventArgs : EventArgs
        {
            public MessageConsumeEventArgs(string _message)
            {
                message = _message;
            }
            public string message { get; }
        }
        */

        enum MessagePartType
        {
            userDeviceId = 0,
            valueType = 1,
            value = 2,
            dateTime = 3
        }

        private void ProcessMessage(string _message)
        {
            var messageParts = _message.Split(";");
            
            var telemetryController = factory.CreateScope().ServiceProvider.GetRequiredService<UserDeviceTelemetryApiController>();
            telemetryController.createTelemetry(Int64.Parse(messageParts[(int)MessagePartType.userDeviceId]),
                                             Enum.Parse<UserDeviceTelemetry.ValueTypeEnum>(messageParts[(int)MessagePartType.valueType]),
                                             Decimal.Parse(messageParts[(int)MessagePartType.value]),
                                             DateTime.Parse(messageParts[(int)MessagePartType.dateTime]));
        }

        public override Task StopAsync(CancellationToken stoppingToken)
        {
            consumer?.Close();
            return base.StopAsync(stoppingToken);
        }
    }
}