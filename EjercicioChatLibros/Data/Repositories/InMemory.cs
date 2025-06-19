using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Data.Repositories;

public class InMemory
{
    private readonly EjercicioChatLibrosContext _context;
    private List<Book> _books;
    private List<Loan> _loans;
    private List<User> _users;
    private List<Category> _categories;
    public InMemory(EjercicioChatLibrosContext context)
    {
        _context = context;
    }
    private List<T>? GetSet<T>() where T : EntityBase
    {
        Type type = typeof(T);
        switch (type)
        {
            case var _ when type == typeof(Book):
                return  _books as List<T>;
            case var _ when type == typeof(Loan):
                return _loans as List<T>;
            case var _ when type == typeof(User):
                return _users as List<T>;
            case var _ when type == typeof(Category):
                return _categories as List<T>;
            default:
                throw new NotSupportedException();
        }
        /*if (typeof(T) == typeof(Book))
        {
            return _books as List<T>;
        }
        throw new NotSupportedException();*/
    }
    /*public async Task<IEnumerable<Loan>> GetAllAsync()
    {
        return await _context.Loans
            .Include(l => l.Book)
            .Include(l => l.User)
            .ToListAsync();
    }*/
    public async Task<T?> GetByIdAsync<T>(Guid id) where T : EntityBase 
    {
        return await Task.FromResult(GetSet<T>()?.FirstOrDefault(e => e.Id == id));
    }
    public async Task<T?> AddAsync<T>(T entity) where T : EntityBase
    {
        GetSet<T>()?.Add(entity);
        return await Task.FromResult(entity);
    }
    public async Task<T?> DeleteAsync<T>(Guid id) where T : EntityBase
    {
        var entity = await _context.T.FindAsync(id);
        if (entity != null)
        {
            //_context.T.Remove(entity);
            GetSet<T>()?.Remove(entity);
            await _context.SaveChangesAsync();
        }
        return await Task.FromResult(entity);
    }
}
