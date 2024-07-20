using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Transfer.Domain.Events;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;

namespace MicroRabbit.Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository _transferRepository;
        public TransferEventHandler(ITransferRepository transferRepository)
        {
            _transferRepository = transferRepository;
        }

        public async Task Handle(TransferCreatedEvent @event)
        {
            await _transferRepository.Add(new TransferLog
            {
                FromAccountId = @event.From,
                ToAccountId = @event.To,
                TransferAmount = @event.Amount
            });

            //return Task.CompletedTask;
        }

    }
}
