namespace MicroRabbit.Banking.Application.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity?> GetById(int id);
        Task<bool> Add(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(int id);      
        Task<bool> Save();
    }
}
