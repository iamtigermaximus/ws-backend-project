using System;
namespace ws_backend_project.Models;

public class CartItem: BaseModel
{
	public int CartId { get; set; }
	public Cart Cart { get; set; }
    public int ItemQuantity { get; set; }
    public int ProductId { get; set; }
    public Product? Product { get; set; }
}



