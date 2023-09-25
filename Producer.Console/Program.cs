using System.Data;
using Producer.Console;
using RabbitMQ.Client;

Console.WriteLine("[*] Rabbitmq producer project started.");

IConnection rabbitMQConnection = RabbitMQConnection.CreateConnection();

if (rabbitMQConnection.IsOpen)
    Console.WriteLine("[**] Rabbitmq connection is open.");


RabbitMQConnection.CloseConnection(rabbitMQConnection);

if(!rabbitMQConnection.IsOpen)
    Console.WriteLine("[**] Rabbitmq connection is close.");
















Console.ReadKey();

