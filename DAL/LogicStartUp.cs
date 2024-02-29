using datalayer.Messages;
using datalayer.Messages.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace datalayer;

public static class DalStartUp
{
    public static IServiceCollection TryAddDal(this IServiceCollection serviceCollection)
    {
        serviceCollection.TryAddScoped<IMessageRepository, MessageRepository>();
        return serviceCollection;
    }
}