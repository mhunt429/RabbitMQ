using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using RabbitMQ.Client;

namespace publisher.interfaces
{
    public interface IMessageService
    {
        bool Enqueue(string message);
    }
}
