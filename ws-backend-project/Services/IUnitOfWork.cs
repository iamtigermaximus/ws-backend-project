using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ws_backend_project.Services;

public interface IUnitOfWork
{
    IUserService Users { get; }

    Task CompleteAsync();
}
