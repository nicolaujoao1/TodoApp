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
     
}
