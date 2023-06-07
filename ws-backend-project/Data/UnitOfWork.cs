using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ws_backend_project.Services;
using ws_backend_project.Services.Imp;

namespace ws_backend_project.Data;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly DataContext _context;

    public IUserService Users { get; private set; }

    public UnitOfWork(DataContext context, ILoggerFactory loggerFactory)
    {
        _context = context;
        var _logger = loggerFactory.CreateLogger("logs");

        Users = new UserService(_context, _logger);
    }

    public IUserService User => throw new NotImplementedException();

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
