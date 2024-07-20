using MicroRabbit.Transfer.Domain.Models;

namespace MicroRabbit.Transfer.Application.Interfaces
{
    public interface ITransferService
    {
        Task<IEnumerable<TransferLog>> GetTransferLogs();
    }
}
