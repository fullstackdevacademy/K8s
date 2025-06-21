using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace EnrollmentsApi.Services
{
    public class MessageProducer : IMessageProducer
    {
        public void SendingMessage<T>(T message)
        {
            //var factory = new ConnectionFactory()
            //{
            //    HostName = "localhost",
            //    UserName = "user",
            //    Password = "mypass",
            //    VirtualHost = "/"
            //    //Port = 15672

            //};
            // factory.Uri = new Uri("amqp://user:password@rabbitmq-service:5672");

            var factory = new ConnectionFactory
            {
                //HostName = "rabbitmq-service", // Replace with actual RabbitMQ service name in Kubernetes
                HostName = "192.168.1.205",
                // Port = 15672,   
                Port = 5672,// Replace with your RabbitMQ port if different
                UserName = "user",
                Password = "mypass",
              //  VirtualHost = "/"
            };
            // factory.Uri= new Uri("amqp://user:mypass@rabbitmq-service:5672");

            var conn=factory.CreateConnection();
            using var channel = conn.CreateModel();
           // channel.QueueDeclare("enrollmentsQueue", durable: true, exclusive: false);
            channel.QueueDeclare(queue: "enrollmentsQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var jsonString =JsonSerializer.Serialize(message);
            var body=Encoding.UTF8.GetBytes(jsonString);
            channel.BasicPublish("", "enrollmentsQueue", body: body);
        }
    }
}
