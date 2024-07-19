using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Domain.Entities;
using MicroRabbit.Banking.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.Infrastructure.Repository
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(BankingDbContext dbContext, ILogger logger) : base(dbContext, logger) { }


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

    }
}
