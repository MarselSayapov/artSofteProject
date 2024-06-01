﻿using System.Text;
using ExampleCore.Dal.Base;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.ObjectPool;
using Newtonsoft.Json;
using ProfileConnectionLib.ConnectionServices.DtoModels.CheckUserExists;
using ProfileConnectionLib.ConnectionServices.DtoModels.UserNameLists;
using ProfileConnectionLib.ConnectionServices.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ProfileConnectionLib.ConnectionServices.RabbitConnectionServer;

public class RabbitGetUserNameListService<TModel>(IServiceScopeFactory serviceProviderFactory, ObjectPool<IConnection> connectionPool): BackgroundService
    where TModel : BaseEntityDal<Guid>
{
    private readonly IServiceScopeFactory _serviceProviderFactory = serviceProviderFactory;
    private readonly ObjectPool<IConnection> _connectionPool = connectionPool;
    private readonly string _queueName = "GetProjectQueue";
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = _serviceProviderFactory.CreateScope();

        var getUserById = scope.ServiceProvider.GetRequiredService<IProfileConnectionService>();
        
        using var connection = _connectionPool.Get();
        using var channel = connection.CreateModel();
        
        channel.QueueDeclare(queue: _queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
        
        var consumer = new EventingBasicConsumer(model: channel);
        consumer.Received += async (model, ea) =>
        {
            var content = Encoding.UTF8.GetString(ea.Body.ToArray());
            channel.BasicAck(ea.DeliveryTag, false);

            var message = Encoding.UTF8.GetString(ea.Body.ToArray());

            var getUserDeserializedData = JsonConvert.DeserializeObject<UserNameListProfileApiRequest>(message)
                                             ?? throw new Exception($"Ошибка при десериализации {typeof(UserNameListProfileApiRequest)}");
            
            await getUserById.GetUserNameListAsync(getUserDeserializedData);
        };
        
        channel.BasicConsume(
            consumer: consumer,
            queue: _queueName,
            autoAck: true);

        await Task.CompletedTask;
        _connectionPool.Return(connection);
    }
}