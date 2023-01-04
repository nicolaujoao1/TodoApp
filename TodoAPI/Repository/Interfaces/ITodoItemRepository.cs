using TodoAPI.Models;

namespace TodoAPI.Repository.Interfaces
{
    public interface ITodoItemRepository:IBase<TodoItem>
    {
        Task<IEnumerable<TodoItem>> GetAllTaskCompleted();
        Task<IEnumerable<TodoItem>> GetAllTaskNoCompleted();
    }
}
