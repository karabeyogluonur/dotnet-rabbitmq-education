using System.Data;
using Producer.Console;
using RabbitMQ.Client;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("[*] Rabbitmq producer project started.");


        #region Connection create

        IConnection rabbitMQConnection = RabbitMQConnection.CreateConnection();

        if (rabbitMQConnection.IsOpen)
            Console.WriteLine("[**] Rabbitmq connection is open.");

        #endregion

        #region Connection close

        RabbitMQConnection.CloseConnection(rabbitMQConnection);

        if (!rabbitMQConnection.IsOpen)
            Console.WriteLine("[**] Rabbitmq connection is close.");

        #endregion

        #region Create Exchanges

        RabbitMQService.CreateExchange("Product", ExchangeType.Direct);
        RabbitMQService.CreateExchange("Category", ExchangeType.Fanout);
        RabbitMQService.CreateExchange("Brand", ExchangeType.Headers);
        RabbitMQService.CreateExchange("Attribute", ExchangeType.Topic);

        Console.WriteLine("[**] Rabbitmq exchanges created.");

        #endregion

        #region Create Queues

        RabbitMQService.CreateQueue("Comment");
        RabbitMQService.CreateQueue("Payment");


        Console.WriteLine("[**] Rabbitmq queues created.");

        #endregion

        #region Bind Queue

        string bindTestExchangeName = "bind_test_exchange";
        string bindTestQueueName = "bind_test_queue";

        RabbitMQService.CreateExchange(bindTestExchangeName, ExchangeType.Direct);
        RabbitMQService.CreateQueue(bindTestQueueName);
        RabbitMQService.BindQueue(queueName: bindTestQueueName, exchangeName: bindTestExchangeName, routingKey: "sent_email");


        Console.WriteLine("[**] Rabbitmq queues bind added.");

        #endregion








        Console.ReadKey();
    }
}

