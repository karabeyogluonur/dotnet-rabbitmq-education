using System.Text;
using Consumer.Console;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

IConnection connection = RabbitMQConnection.CreateConnection();
IModel channel = connection.CreateModel();


string publishTestQueueName = "publish_test_queue";

EventingBasicConsumer consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"[**] Received : {message} ");
};

channel.BasicConsume(queue: publishTestQueueName,
                     autoAck: true,
                     consumer: consumer);

Console.ReadKey();