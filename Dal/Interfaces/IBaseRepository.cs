
namespace Dal.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> Select();

        Task<T?> GetById(int id);
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
        Task<bool> Save();  
    }
}
