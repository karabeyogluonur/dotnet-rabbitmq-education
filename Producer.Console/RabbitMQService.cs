using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Producer.Console
{
	public static class RabbitMQService
	{
		private static IConnection connection = RabbitMQConnection.CreateConnection();
		private static IModel channel = connection.CreateModel();

		public static void CreateExchange(string exchangeName, string exchangeType)
		{
			channel.ExchangeDeclare(exchange: exchangeName, type: exchangeType);
		}
        public static void CreateQueue(string queueName)
        {
			channel.QueueDeclare(queue: queueName, autoDelete: false, exclusive: false);
        }
        public static void BindQueue(string queueName,string exchangeName,string routingKey)
        {
			channel.QueueBind(queue: queueName, exchange: exchangeName, routingKey: routingKey);
        }
    }
}

