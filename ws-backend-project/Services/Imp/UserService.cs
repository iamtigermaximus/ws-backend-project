using System;
using Microsoft.EntityFrameworkCore;
using ws_backend_project.Data;
using ws_backend_project.Models;

namespace ws_backend_project.Services.Imp;

public class UserService : GenericService<User>, IUserService
{
    public UserService(DataContext context, ILogger logger) : base(context, logger)
    {
    }

    public override async Task<IEnumerable<User>> All()
    {
        try
        {
            return await _context.Users.Where(x => x.Id < 100).ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public override async Task<User?> GetById(int id)
    {
        try
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

}