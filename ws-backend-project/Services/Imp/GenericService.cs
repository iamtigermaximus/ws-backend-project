using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ws_backend_project.Data;

namespace ws_backend_project.Services.Imp;

public class GenericService<T> : IGenericService<T> where T : class
{
    protected DataContext _context;
    internal DbSet<T> _dbSet;
    protected readonly ILogger _logger;

    public GenericService(
        DataContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
        this._dbSet = context.Set<T>();
    }

    public virtual async Task<bool> Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        return true;
    }

    public virtual async Task<IEnumerable<T>> All()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public virtual async Task<bool> Delete(T entity)
    {
        _dbSet.Remove(entity);
        return true;
    }

    public virtual async Task<T?> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<bool> Update(T entity)
    {
        _dbSet.Update(entity);
        return true;
    }
}
