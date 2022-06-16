using TodoAPI.Context;
using TodoAPI.Repository.Interfaces;

namespace TodoAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private TodoItemRepository _todoItemRepository;
        
        private readonly TodoContext _context;
        public UnitOfWork(TodoContext todoContext)
        {
            _context = todoContext;
        }
        public ITodoItemRepository TodoItemRepository
        {
            get { return _todoItemRepository = _todoItemRepository ?? new TodoItemRepository(_context); }
        }
       
        public async Task Commit()
        {
           
           await _context.SaveChangesAsync();    
        }
    }
}
