using TodoAPI.Repository.Interfaces;

namespace TodoAPI.Repository
{
    public interface IUnitOfWork
    {
        ITodoItemRepository TodoItemRepository { get; }
        Task Commit();
    }
}
