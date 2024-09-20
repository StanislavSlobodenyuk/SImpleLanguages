
namespace Dal.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T?> GetById(int id);
        Task<bool> Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
