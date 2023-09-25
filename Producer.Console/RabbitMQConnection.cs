using System;
using RabbitMQ.Client;

namespace Producer.Console
{
	public static class RabbitMQConnection
	{
		public static IConnection CreateConnection()
		{
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri($"{RabbitMQDefaults.Prefix}" +
                              $"{RabbitMQDefaults.Username}:{RabbitMQDefaults.Password}@" +
                              $"{RabbitMQDefaults.Host}:{RabbitMQDefaults.Port}", UriKind.RelativeOrAbsolute)
            };

            return connectionFactory.CreateConnection();
		}

	}
}

