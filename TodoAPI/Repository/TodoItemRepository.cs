using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TodoAPI.Context;
using TodoAPI.Models;
using TodoAPI.Repository.Interfaces;

namespace TodoAPI.Repository;
public class TodoItemRepository : Base<TodoItem>,ITodoItemRepository
{
    
    public TodoItemRepository(TodoContext todoContext) : base(todoContext)
    {
    }

    public async Task<IEnumerable<TodoItem>> GetAllTaskCompleted()
    {
        var todoItem = await Get().Where(p => p.IsComplete).ToListAsync();
        return todoItem;    
    }

    public async Task<IEnumerable<TodoItem>> GetAllTaskNoCompleted()
    {
        var todoItem=await Get().Where(p => p.IsComplete==false).ToListAsync();
        return todoItem;
    }
}
