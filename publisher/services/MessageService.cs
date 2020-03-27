using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using publisher.interfaces;
using RabbitMQ.Client;
using System.Text;

namespace publisher.services
{
    public class MessageService : IMessageService   
    {
        ConnectionFactory _factory;
        IConnection _connection;
        IModel _channel;

        public MessageService()
        {
            Console.WriteLine("Attemption Connection To RabbitMQ");

            _factory = new ConnectionFactory() { HostName = "rabbitmq", Port = 5672 };
            _factory.UserName = "guest";
            _factory.Password = "guest";
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "hello",
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);
        }

        public bool Enqueue(string message)
        {
            var body = Encoding.UTF8.GetBytes("Server processed " + message);
            _channel.BasicPublish(exchange: "",
                                  routingKey: "hello",
                                  basicProperties: null,
                                  body: body);
            Console.WriteLine(" [x] Published {0} to RabbitMQ", message);

            return true;
        }
    }
}
