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
public class CartController : ControllerBase
{

    private readonly IUnitOfWork _unitOfWork;

    public CartController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _unitOfWork.Carts.All());
    }


    [HttpGet("GetById")]
    public async Task<IActionResult> Get(int id)
    {
        var cart = await _unitOfWork.Carts.GetById(id);

        if (cart == null) return NotFound();

        return Ok(cart);
    }



    [HttpPost("Add")]
    public async Task<IActionResult> AddCart(Cart cart)
    {
        await _unitOfWork.Carts.Add(cart);
        await _unitOfWork.CompleteAsync();

        return Ok();
    }


    [HttpDelete("DeleteCart")]
    public async Task<IActionResult> RemoveCart(int id)
    {
        var cart = await _unitOfWork.Carts.GetById(id);

        if (cart == null)

            return NotFound();

        await _unitOfWork.Carts.Delete(cart);

        await _unitOfWork.CompleteAsync();

        return NoContent();

    }


    [HttpPatch("Update")]
    public async Task<IActionResult> Update(Cart cart)
    {
        var existCart = await _unitOfWork.Carts.GetById(cart.Id);

        if (existCart == null)

            return NotFound();

        await _unitOfWork.Carts.Update(cart);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }
}