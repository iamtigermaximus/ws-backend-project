﻿using System;
namespace ws_backend_project.Models;

public class Category: BaseModel
{
    public string? Name { get; set; }
    public List<Product> Products { get; set; } 
}

