using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Entities;

namespace MicroRabbit.Banking.Application.Interfaces
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task Transfer(AccountTransfer accountTransfer);
    }
}
