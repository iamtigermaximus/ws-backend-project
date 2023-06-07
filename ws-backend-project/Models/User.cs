using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ws_backend_project.Models;
public class User : BaseModel
{
  public string Name { get; set; }
  public string Email { get; set; }
  public string Password { get; set; }
  public string Avatar { get; set; }
  //public int CartId { get; set; }
  //public Cart Cart { get; set; }
}
