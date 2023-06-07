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
public class CartItemController : ControllerBase
{

    private readonly IUnitOfWork _unitOfWork;

    public CartItemController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _unitOfWork.CartItems.All());
    }


    [HttpGet("GetById")]
    public async Task<IActionResult> Get(int id)
    {
        var cartItem = await _unitOfWork.CartItems.GetById(id);

        if (cartItem == null) return NotFound();

        return Ok(cartItem);
    }



    [HttpPost("Add")]
    public async Task<IActionResult> AddCartITem(CartItem cartItem)
    {
        await _unitOfWork.CartItems.Add(cartItem);
        await _unitOfWork.CompleteAsync();

        return Ok();
    }


    [HttpDelete("DeleteCartItem")]
    public async Task<IActionResult> RemoveCartItem(int id)
    {
        var cartItem = await _unitOfWork.CartItems.GetById(id);

        if (cartItem == null)

            return NotFound();

        await _unitOfWork.CartItems.Delete(cartItem);

        await _unitOfWork.CompleteAsync();

        return NoContent();

    }


    [HttpPatch("Update")]
    public async Task<IActionResult> Update(CartItem cartItem)
    {
        var existCart = await _unitOfWork.CartItems.GetById(cartItem.Id);

        if (existCart == null)

            return NotFound();

        await _unitOfWork.CartItems.Update(cartItem);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }
}