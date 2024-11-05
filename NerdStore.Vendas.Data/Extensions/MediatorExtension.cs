using MediatR;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Vendas.Data.Extensions;

public static class MediatorExtension
{
    public static async Task PublicarEventos(this IMediator mediator, VendasContext context)
    {
        var domainEntities = context.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.Notifications.Count != 0)
            .ToList();

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.Notifications)
            .ToList();

        domainEntities.ForEach(entity => entity.Entity.LimparEventos());

        var tasks = domainEvents
            .Select(async (domainEvent) =>
            {
                await mediator.Publish(domainEvents);
            });

        await Task.WhenAll(tasks);
    }
    
}