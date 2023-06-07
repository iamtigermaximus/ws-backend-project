using System;
using Microsoft.EntityFrameworkCore;
using ws_backend_project.Data;
using ws_backend_project.Models;

namespace ws_backend_project.Services.Imp;

public class CartService : GenericService<Cart>, ICartService
{
    public CartService(DataContext context, ILogger logger) : base(context, logger)
    {
    }
    public override async Task<IEnumerable<Cart>> All()
    {
        try
        {
            return await _context.Carts.Where(x => x.Id < 100).ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public override async Task<Cart?> GetById(int id)
    {
        try
        {
            return await _context.Carts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}


