using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repositories;

public class InMemory : IRepository
{
    private readonly EjercicioChatLibrosContext _context;
    private List<Book> _books;
    private List<Loan> _loans;
    private List<User> _users;
    private List<Category> _categories;
    public InMemory()
    {
        LoadBooks();
        LoadCategories();
        LoadLoans();
        LoadUsers();
    }

    #region Loads
    private void LoadBooks()
    {

        var json1 = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Sources\\books.json"));
        _books = JsonSerializer.Deserialize<List<Book>>(json1, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        });
    }

    private void LoadCategories()
    {
        var json2 = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Sources\\categories.json"));
        _categories = JsonSerializer.Deserialize<List<Category>>(json2, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true, //No importa si hay mayusculas o minusculas en el doc
        });
    }
    private void LoadLoans()
    {
        var json3 = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Sources\\loans.json"));
        _loans = JsonSerializer.Deserialize<List<Loan>>(json3, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        });
    }
    private void LoadUsers()
    {
        var json4 = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Sources\\users.json"));
        _users = JsonSerializer.Deserialize<List<User>>(json4, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        });
    }
#endregion
    private List<T>? GetList<T>() where T : EntityBase
    {
        if (typeof(T) == typeof(Book))
        {
            return _books as List<T>;
        }
        else if (typeof(T) == typeof(Category))
        {
            return _categories as List<T>;
        }
        else if (typeof(T) == typeof(Loan))
        {
            return _loans as List<T>;
        }
        else if (typeof(T) == typeof(User))
        {
            return _users as List<T>;
        }
        else throw new NotSupportedException();
    }

    public async Task<T?> GetByIdAsync<T>(Guid id) where T : EntityBase 
    {
        return await Task.FromResult(GetList<T>()?.FirstOrDefault(e => e.Id == id));
    }
    public async Task<List<T>?> GetAll<T>() where T : EntityBase
    {
        return await Task.FromResult(GetList<T>()?.ToList());
    }
    public async Task<T?> AddAsync<T>(T entity) where T : EntityBase
    {
        GetList<T>()?.Add(entity);
        return await Task.FromResult(entity);
    }
    public async Task<T?> DeleteAsync<T>(Guid id) where T : EntityBase
    {
        /*
        var entity = await _context.T.FindAsync(id);
        if (entity != null)
        {
            //_context.T.Remove(entity);
            GetList<T>()?.Remove(entity);
            await _context.SaveChangesAsync();
        }
        return await Task.FromResult(entity);
        */
        throw new NotImplementedException();
    }
    public async Task<T?> UpdateAsync<T>(Guid id) where T : EntityBase
    {          
        throw new NotImplementedException();
    }

    public async Task<T?> First<T>(Expression<Func<T, bool>> predicate) where T : EntityBase
    {
        var product = GetList<T>()?.FirstOrDefault(predicate.Compile());
        return await Task.FromResult(product);
    }
}
