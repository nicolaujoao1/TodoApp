using System.Linq.Expressions;

namespace TodoAPI.Repository.Interfaces
{
    public interface IBase<T>
    {
        IQueryable<T> Get();
        Task<T> GetById(Expression<Func<T, bool>> predicate);
        void Add(T Entity);
        void Update(T Entity);
        void Delete(T Entity);
    }
}
