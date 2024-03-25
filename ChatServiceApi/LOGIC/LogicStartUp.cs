using LogicStartUp.Messages;
using LogicStartUp.Messages.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LogicStartUp;

public static class LogicStartUp
{
    public static IServiceCollection TryAddLogic(this IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddScoped<IMessageLogicManager, MessageLogicManager>();
        return serviceCollection;
    }
}