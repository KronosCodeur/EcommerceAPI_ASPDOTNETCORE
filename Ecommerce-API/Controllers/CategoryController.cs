using AutoMapper;
using Ecommerce_API.DTO;
using Ecommerce_API.Models;
using Ecommerce_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_API.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly CategoryService _categoryService;
    private readonly IMapper _mapper;



    [HttpGet("GetAllCategories")]
    public async Task<ActionResult<List<Category>>> GetAllCategories()
    {
        List<Category> categories = new List<Category>();
         categories = await _categoryService.GetAllCategories();
        return Ok(categories);
    }

    [HttpPost("CreateCategory")]
    public async Task<ActionResult<Category>> CreateCategory(CategoryDto categoryDto)
    {
        try
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryService.CreateCategory(category);
            return StatusCode(201, category);
        }
        catch (Exception e)
        {
            return StatusCode(500, "erreur" + e);
        }
    }
}