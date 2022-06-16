using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TodoAPI.Context;
using TodoAPI.Repository.Interfaces;

namespace TodoAPI.Repository;

public class Base<T> : IBase<T> where T:class
{
    private readonly TodoContext _context;
    public Base(TodoContext todoContext)
    {
        _context = todoContext; 
    }
    public void Add(T Entity)
    {
       _context.Set<T>().Add(Entity);   
    }

    public void Delete(T Entity)
    {
       _context.Set<T>().Remove(Entity);    
    }

    public IQueryable<T> Get()
    {
        return _context.Set<T>().AsNoTracking();
    }

    public async Task<T> GetById(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().SingleOrDefaultAsync(predicate);
    }

    public void Update(T Entity)
    {
        _context.Entry(Entity).State = EntityState.Modified;
        _context.Set<T>().Update(Entity);
    }
}
