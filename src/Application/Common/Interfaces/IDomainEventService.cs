using pruebaworkshop.Domain.Common;
using System.Threading.Tasks;

namespace pruebaworkshop.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
