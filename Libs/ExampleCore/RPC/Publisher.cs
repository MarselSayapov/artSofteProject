using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace ExampleCore.RPC;

public class Publisher<T> : IDisposable
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly string _queueName;
    private readonly T _data;
    private readonly string _exchange;
    
    public Publisher(string queueName, T data, string hostName = "localhost", string exchange = "")
    {
        _queueName = queueName;
        _data = data;
        _exchange = exchange;

        var factory = new ConnectionFactory { HostName = hostName };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
    }
    
    public async Task<bool> PublishAsync()
    {
        try
        {
            if (_exchange != string.Empty)
                _channel.ExchangeDeclare(_queueName, _exchange);

            _channel.QueueDeclare(
                queue: _queueName,
                exclusive: false,
                durable: true,
                autoDelete: false,
                arguments: null);

            var serializedData = JsonConvert.SerializeObject(_data);
            var body = Encoding.UTF8.GetBytes(serializedData);
            var properties = _channel.CreateBasicProperties();
            properties.Persistent = true;

            await Task.Run(() => _channel.BasicPublish(
                exchange: _exchange,
                routingKey: _queueName,
                basicProperties: properties,
                body: body));

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception("Произошла ошибка при работе издателя RPC", ex);
        }
    }
    
    public void Dispose()
    {
        _channel?.Dispose();
        _connection?.Dispose();
    }
}