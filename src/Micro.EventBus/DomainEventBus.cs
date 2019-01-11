using System.Threading.Tasks;
using MediatR;
using NetCoreKit.Domain;

namespace Micro.EventBus
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IMediator _mediator;

        public DomainEventDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Dispatch(IEvent @event)
        {
            await _mediator.Publish(new NotificationEnvelope(@event));
        }

        public void Dispose()
        {
        }
    }
}
