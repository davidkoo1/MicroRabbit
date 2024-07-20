using MicroRabbit.Banking.Application.Commands.CreateTransfer;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Entities;
using MicroRabbit.Banking.Infrastructure.Persistance;
using MicroRabbit.Domain.Core.Bus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MicroRabbit.Banking.Infrastructure.Repository
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly IEventBus _eventBus;
        public AccountRepository(BankingDbContext dbContext, ILogger logger, IEventBus eventBus) : base(dbContext, logger) { _eventBus = eventBus; }


        public override async Task<IEnumerable<Account>> GetAll()
        {
            try
            {
                return await _dbSet.Where(x => x.Id > 0).AsNoTracking().AsSplitQuery().OrderBy(x => x.AccountBalance).ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "{Repo} GetAll method error", typeof(AccountRepository));

                throw;
            }

        }

        public async Task Transfer(AccountTransfer accountTransfer)
        {
            var createTranserCommand = new CreateTransferCommand(accountTransfer.FromAccount, accountTransfer.ToAccount, accountTransfer.TransferAmount);

            await _eventBus.SendCommand(createTranserCommand);
        }
    }
}
