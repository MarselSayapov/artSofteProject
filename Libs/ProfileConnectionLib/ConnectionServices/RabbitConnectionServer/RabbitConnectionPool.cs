using Microsoft.Extensions.ObjectPool;
using RabbitMQ.Client;

namespace ProfileConnectionLib.ConnectionServices.RabbitConnectionServer;

public class RabbitConnectionPool : IPooledObjectPolicy<IConnection>
{
    private readonly ConnectionFactory _connectionFactory;

    public RabbitConnectionPool(string hostName)
    {
        _connectionFactory = new ConnectionFactory { HostName = hostName };
    }

    public IConnection Create()
    {
        return _connectionFactory.CreateConnection();
    }

    public bool Return(IConnection obj)
    {
        return true;
    }
}