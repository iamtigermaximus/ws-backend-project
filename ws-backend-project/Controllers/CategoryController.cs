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
public class CategoryController : ControllerBase
{

    private readonly IUnitOfWork _unitOfWork;

    public CategoryController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _unitOfWork.Categories.All());
    }


    [HttpGet("GetById")]
    public async Task<IActionResult> Get(int id)
    {
        var category = await _unitOfWork.Categories.GetById(id);

        if (category == null) return NotFound();

        return Ok(category);
    }



    [HttpPost("AddCategory")]
    public async Task<IActionResult> AddCategory(Category category)
    {
        await _unitOfWork.Categories.Add(category);
        await _unitOfWork.CompleteAsync();

        return Ok();
    }


    [HttpDelete("DeleteCategory")]
    public async Task<IActionResult> RemoveCategory(int id)
    {
        var category = await _unitOfWork.Categories.GetById(id);

        if (category == null)

            return NotFound();

        await _unitOfWork.Categories.Delete(category);

        await _unitOfWork.CompleteAsync();

        return NoContent();

    }


    [HttpPatch("UpdateCategory")]
    public async Task<IActionResult> UpdateCategory(Category category)
    {
        var existCategory = await _unitOfWork.Categories.GetById(category.Id);

        if (existCategory == null)

            return NotFound();

        await _unitOfWork.Categories.Update(category);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }
}