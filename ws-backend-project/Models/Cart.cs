using System;
namespace ws_backend_project.Models;

public class Cart : BaseModel
{
    public int UserId { get; set; }
    public User? User { get; set; }
    public int CartItemId { get; set; }
    public List<CartItem> CartItems { get; set; }
    public decimal TotalPrice { get; set; }
}
