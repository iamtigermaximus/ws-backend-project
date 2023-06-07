using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ws_backend_project.Models;

public class Product:BaseModel
{
  public string? Name { get; set; }
  public decimal? Price { get; set; } 
  public string? Description { get; set; } 
  public string? Image { get; set; }
  public int CategoryId { get; set; }
  public string CategoryName { get; set; } 
}
