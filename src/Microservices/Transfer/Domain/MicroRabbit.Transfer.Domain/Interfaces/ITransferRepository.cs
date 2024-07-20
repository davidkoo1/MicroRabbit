using MicroRabbit.Transfer.Domain.Models;

namespace MicroRabbit.Transfer.Domain.Interfaces
{
    public interface ITransferRepository
    {
        Task<IEnumerable<TransferLog>> GetAllGetTransferLogsAsync();
        Task<bool> Add(TransferLog entity);
        Task<bool> Save();
    }
}
