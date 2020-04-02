using System;
using System.Text;
using RabbitMQ.Client;
using static System.Console;

namespace Demos.RabbitMQ.PublisherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "rabbitmq",
                Password = "rabbitmq",
                Port = 5672
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: "hello",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            byte[] GetBytes(string message) =>
                Encoding.UTF8.GetBytes(message);

            WriteLine("Please enter messages!");

            while (true)
            {
                channel.BasicPublish(
                    exchange: "",
                    routingKey: "hello",
                    basicProperties: null,
                    body: GetBytes(ReadLine())
                );
            }
        }
    }
}
