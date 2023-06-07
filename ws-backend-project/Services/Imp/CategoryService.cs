using System;
using Microsoft.EntityFrameworkCore;
using ws_backend_project.Data;
using ws_backend_project.Models;

namespace ws_backend_project.Services.Imp;

public class CategoryService : GenericService<Category>, ICategoryService
{
    public CategoryService(DataContext context, ILogger logger) : base(context, logger)
    {
    }
    public override async Task<IEnumerable<Category>> All()
    {
        try
        {
            return await _context.Categories.Where(x => x.Id < 100).ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public override async Task<Category?> GetById(int id)
    {
        try
        {
            return await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}

