using System;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using Producer.Console;

namespace OrderProducer.Console
{
    public static class RabbitMQService
    {
        private static IModel channel = CreateChannel();

        public static void CreateExchange(string exchangeName, string exchangeType)
        {
            channel.ExchangeDeclare(exchange: exchangeName, type: exchangeType);
        }
        public static void CreateQueue(string queueName)
        {
            channel.QueueDeclare(queue: queueName, autoDelete: false, exclusive: false);
        }
        public static void BindQueue(string queueName, string exchangeName, string routingKey)
        {
            channel.QueueBind(queue: queueName, exchange: exchangeName, routingKey: routingKey);
        }
        public static void Publish(string exchangeName, string routingKey, object data)
        {
            Byte[] dataArray = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));

            channel.BasicPublish(exchange: exchangeName, routingKey: routingKey, basicProperties: null, body: dataArray);
        }

        private static IConnection CreateConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory
            {
                UserName = RabbitMQDefaults.Username,
                Password = RabbitMQDefaults.Password,
                HostName = RabbitMQDefaults.Host,
                Port = RabbitMQDefaults.Port,

                // Doesn't seem to have any effect on broken connections
                RequestedConnectionTimeout = TimeSpan.FromSeconds(60),

                // The behaviour appears to be the same with or without these included
                // AutomaticRecoveryEnabled = true,
                // NetworkRecoveryInterval = TimeSpan.FromSeconds(10),
            };

            return connectionFactory.CreateConnection();
        }

        private static IModel CreateChannel()
        {
            IConnection connection = CreateConnection();

            return connection.CreateModel();
        }
    }
}

