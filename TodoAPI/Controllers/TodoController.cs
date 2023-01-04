using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoAPI.Context;
using TodoAPI.Models;
using TodoAPI.Repository;

namespace TodoAPI.Controllers
{
    [Route("api/todoitems")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        public readonly IUnitOfWork _context;
        public TodoController(IUnitOfWork todoContext)
        {
            _context = todoContext;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
        {
            var todoItem = await _context.TodoItemRepository.GetById(p => p.Id == id);
            return todoItem is null ? NotFound() : todoItem;
        }
        [HttpGet("/items")]
        public async Task<ActionResult<IEnumerable<TodoItem>>> Get()
        {
            var todoItem = await _context.TodoItemRepository.Get().ToListAsync();
            return todoItem is null ? NotFound() : todoItem;
        }
        [HttpGet("/items/completed")]
        public async Task<IEnumerable<TodoItem>> GetTodoItemCompleted()
        {
            var todoItem = await _context.TodoItemRepository.GetAllTaskCompleted();
            return todoItem;
        }
        [HttpGet("/items/no-completed")]
        public async Task<IEnumerable<TodoItem>> GetTodoItemNoCompleted()
        {
            var todoItem = await _context.TodoItemRepository.GetAllTaskNoCompleted();
            return todoItem;
        }
        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
           _context.TodoItemRepository.Add(todoItem);
            await _context.Commit(); 
            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TodoItem>> PutTodoItem(int id,TodoItem todoItem)
        {
            var todoitem= await _context.TodoItemRepository.GetById(p=>p.Id==id);
            if (todoItem is null)
                return NotFound();
            _context.TodoItemRepository.Update(todoitem);
            await _context.Commit();    
            return Ok(todoItem);
        }
        [HttpDelete("id")]
        public async Task<ActionResult<TodoItem>> DeleteTodoItem(int id)
        {
            var todoItem = await _context.TodoItemRepository.GetById(p=>p.Id==id);
            if (todoItem is null)
                return NotFound();  
            _context.TodoItemRepository.Delete(todoItem);
            await _context.Commit();
            return todoItem;
        }
    }
}
