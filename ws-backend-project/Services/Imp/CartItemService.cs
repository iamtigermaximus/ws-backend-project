using System;
using ws_backend_project.Data;
using ws_backend_project.Models;

namespace ws_backend_project.Services.Imp;

public class CartItemService : GenericService<CartItem>, ICartItemService
{
    public CartItemService(DataContext context, ILogger logger) : base(context, logger)
    {
    }
}

