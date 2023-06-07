using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ws_backend_project.Models;
using ws_backend_project.Services;

namespace ws_backend_project.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
   
private readonly IUnitOfWork _unitOfWork;

public ProductController(IUnitOfWork unitOfWork)
{
    _unitOfWork = unitOfWork;
}

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _unitOfWork.Products.All());
    }


    [HttpGet("GetById")]
    public async Task<IActionResult> Get(int id)
    {
        var product = await _unitOfWork.Products.GetById(id);

        if (product == null) return NotFound();

        return Ok(product);
    }



    [HttpPost("AddProduct")]
    public async Task<IActionResult> AddProduct(Product product)
    {
        await _unitOfWork.Products.Add(product);
        await _unitOfWork.CompleteAsync();

        return Ok();
    }


    [HttpDelete("DeleteProduct")]
    public async Task<IActionResult> RemoveProduct(int id)
    {
        var product = await _unitOfWork.Products.GetById(id);

        if (product == null)

            return NotFound();

        await _unitOfWork.Products.Delete(product);

        await _unitOfWork.CompleteAsync();

        return NoContent();

    }


    [HttpPatch("UpdateProduct")]
    public async Task<IActionResult> UpdateProduct(Product product)
    {
        var existProduct = await _unitOfWork.Products.GetById(product.Id);

        if (existProduct == null)

            return NotFound();

        await _unitOfWork.Products.Update(product);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }
}