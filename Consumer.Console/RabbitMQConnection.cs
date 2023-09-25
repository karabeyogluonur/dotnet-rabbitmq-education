using System;
using RabbitMQ.Client;

namespace Consumer.Console
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

        public static void CloseConnection(IConnection connection)
        {
            if (connection.IsOpen)
            {
                connection.Close();
                connection.Dispose();
            }               
        }

	}
}

