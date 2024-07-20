using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroRabbit.Transfer.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private TransferDbContext _dbContext;

        public TransferRepository(TransferDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Add(TransferLog entity)
        {
            _dbContext.TransferLogs.Add(entity);
            return await Save();
        }

        public async Task<IEnumerable<TransferLog>> GetAllGetTransferLogsAsync() => await _dbContext.TransferLogs.ToListAsync();

        public async Task<bool> Save() => await _dbContext.SaveChangesAsync() > 0;
    }
}
