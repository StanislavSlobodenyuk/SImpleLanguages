
namespace Dal.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T?> GetById(int id);
        Task<bool> Create(T entity);
        Task<T?> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
