using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ws_backend_project.Data;
using ws_backend_project.Models;

namespace ws_backend_project.Services.Imp;

public class ProductService : GenericService<Product>, IProductService
{
    public ProductService(DataContext context, ILogger logger) : base(context, logger)
    {
    }
    public override async Task<IEnumerable<Product>> All()
    {
        try
        {
            return await _context.Products.Where(x => x.Id < 100).ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public override async Task<Product?> GetById(int id)
    {
        try
        {
            return await _context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}
