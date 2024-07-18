using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using MicroRabbit.Banking.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace MicroRabbit.Banking.Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankingDbContext _dbContext;

        public AccountRepository(BankingDbContext dbContext) => _dbContext = dbContext;
        
        public async Task<IEnumerable<Account>> GetAccounts() => await _dbContext.Accounts.ToArrayAsync();
    }
}
