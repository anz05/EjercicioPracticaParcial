using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces;

public interface IRepository
{
    public Task<T?> GetByIdAsync<T>(Guid id) where T : EntityBase;
    public Task<List<T>?> GetAll<T>() where T : EntityBase;
    public Task<T?> AddAsync<T>(T entity) where T : EntityBase;
    public Task<T?> DeleteAsync<T>(Guid id) where T : EntityBase;
    public Task<T?> UpdateAsync<T>(Guid id) where T : EntityBase;
    public Task<T?> First<T>(Expression<Func<T, bool>> predicate) where T : EntityBase;
}
