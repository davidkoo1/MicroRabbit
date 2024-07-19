namespace MicroRabbit.Banking.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IAccountRepository Accounts { get; }

        Task<bool> CompleteAsync();
    }
}
