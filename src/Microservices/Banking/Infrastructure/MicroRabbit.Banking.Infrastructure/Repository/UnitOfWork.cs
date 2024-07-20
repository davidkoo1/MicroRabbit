using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Infrastructure.Persistance;
using MicroRabbit.Domain.Core.Bus;
using Microsoft.Extensions.Logging;

namespace MicroRabbit.Banking.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly BankingDbContext _dbContext;

        public IAccountRepository Accounts { get; }
        private readonly IEventBus _eventBus;

        public UnitOfWork(BankingDbContext dbContext, ILoggerFactory loggerFactory, IEventBus eventBus)
        {
            _dbContext = dbContext;

            var logger = loggerFactory.CreateLogger("logs");

            Accounts = new AccountRepository(_dbContext, logger, eventBus);
        }

        public async Task<bool> CompleteAsync() => await _dbContext.SaveChangesAsync() > 0;

        public void Dispose() => _dbContext.Dispose();
    }
}
