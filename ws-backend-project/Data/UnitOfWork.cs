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
    public IProductService Products { get; private set; }
    public ICategoryService Categories { get; private set; }
    public ICartService Carts { get; private set; }
    public ICartItemService CartItems { get; private set; }


    public UnitOfWork(DataContext context, ILoggerFactory loggerFactory)
    {
        _context = context;
        var _logger = loggerFactory.CreateLogger("logs");

        Users = new UserService(_context, _logger);
        Products = new ProductService(_context, _logger);
        Categories = new CategoryService(_context, _logger);
        Carts = new CartService(_context, _logger);
        CartItems = new CartItemService(_context, _logger);
    }

    public IUserService User => throw new NotImplementedException();

    public IProductService Product => throw new NotImplementedException();

    public ICategoryService Category => throw new NotImplementedException();

    public ICartService Cart => throw new NotImplementedException();

    public ICartItemService CartItem => throw new NotImplementedException();


    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
