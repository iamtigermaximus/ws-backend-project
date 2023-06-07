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
public class UserController : ControllerBase
{

    private readonly IUnitOfWork _unitOfWork;

    public UserController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _unitOfWork.Users.All());
    }


    [HttpGet("GetById")]
    public async Task<IActionResult> Get(int id)
    {
        var driver = await _unitOfWork.Users.GetById(id);

        if (driver == null) return NotFound();

        return Ok(driver);
    }



    [HttpPost("AddUser")]
    public async Task<IActionResult> AddDriver(User user)
    {
        await _unitOfWork.Users.Add(user);
        await _unitOfWork.CompleteAsync();

        return Ok();
    }


    [HttpDelete("DeleteUser")]
    public async Task<IActionResult> RemoveDriver(int id)
    {
        var driver = await _unitOfWork.Users.GetById(id);

        if (driver == null)

            return NotFound();

        await _unitOfWork.Users.Delete(driver);

        await _unitOfWork.CompleteAsync();

        return NoContent();

    }


    [HttpPatch("UpdateUser")]
    public async Task<IActionResult> UpdateDriver(User user)
    {
        var existDriver = await _unitOfWork.Users.GetById(user.Id);

        if (existDriver == null)

            return NotFound();

        await _unitOfWork.Users.Update(user);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }


}