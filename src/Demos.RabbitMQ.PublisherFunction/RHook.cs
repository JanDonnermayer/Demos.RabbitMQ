using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Demos.RabbitMQ.Function
{
    public static class RabbitHook
    {
        [FunctionName("RHook")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "RHook/{queue}/{routingKey}")] HttpRequest req,
            string queue,
            string routingKey,
            ILogger logger)
        {
            logger.LogInformation("C# HTTP trigger function processed a request.");

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
                queue: queue,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null
            );

            static byte[] GetBytes(string message) =>
                Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(
                exchange: "",
                routingKey: routingKey,
                basicProperties: null,
                body: GetBytes("Hello!")
            );

            return new OkResult();
        }
    }
}
