using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Infrastructure.Persistance;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly BankingDbContext _dbContext;
        
        public IAccountRepository Accounts { get; }


        public UnitOfWork(BankingDbContext dbContext, ILoggerFactory loggerFactory)
        {
            _dbContext = dbContext;

            var logger = loggerFactory.CreateLogger("logs");

            Accounts = new AccountRepository(_dbContext, logger);
        }

        public async Task<bool> CompleteAsync() => await _dbContext.SaveChangesAsync() > 0;

        public void Dispose() => _dbContext.Dispose();
    }
}
