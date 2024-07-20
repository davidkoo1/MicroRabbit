using MediatR;
using MicroRabbit.Banking.Application.Commands.CreateTransfer;
using MicroRabbit.Banking.Application.Events;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Domain.Core.Commands;

namespace MicroRabbit.Banking.Application.Commands
{
    public abstract class TransferCommand : Command
    {
        public int From { get; set; }
        public int To { get; set; }
        public decimal Amount { get; set; }
    }

    public class TransferCommandHandler : IRequestHandler<CreateTransferCommand, bool>
    {

        private readonly IEventBus _eventBus;

        public TransferCommandHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public Task<bool> Handle(CreateTransferCommand request, CancellationToken cancellationToken)
        {
            //publish event to RabbitMq
            _eventBus.Publisher(new TransferCreatedEvent(request.From, request.To, request.Amount));

            return Task.FromResult(true);
        }
    }
}
