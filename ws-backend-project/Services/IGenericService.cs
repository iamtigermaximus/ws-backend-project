using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ws_backend_project.Services;

public interface IGenericService<T> where T : class
{
    Task<IEnumerable<T>> All();
    Task<T?> GetById(int id);
    Task<bool> Add(T entity);
    Task<bool> Update(T entity);
    Task<bool> Delete(T entity);
}

