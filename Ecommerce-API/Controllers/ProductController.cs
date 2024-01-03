using AutoMapper;
using Ecommerce_API.DTO;
using Ecommerce_API.Models;
using Ecommerce_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_API.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class ProductController:ControllerBase
{
    private readonly ProductService _productService;
    private readonly CategoryService _categoryService;
    private readonly UserService _userService;
    private readonly IMapper _mapper;

    public ProductController(ProductService productService, CategoryService categoryService, IMapper mapper, UserService userService)
    {
        _productService = productService;
        _categoryService = categoryService;
        _mapper = mapper;
        _userService = userService;
    }

    [HttpPost("CreateProduct")]
    public async Task<IActionResult> CreateProduct(ProductDto productDto)
    {
        try
        {
            var category = await _categoryService.GetCategoryById(productDto.CategoryId);
            if (category is null)
            {
                return StatusCode(404, "Category not Found");
            }
            var product = _mapper.Map<Product>(productDto);
            product.Category = category;
            await _productService.CreateProduct(product);
            return StatusCode(201, new Dictionary<string,dynamic>()
            {
                {"id",product.Id},
                {"name",product.Name},
                {"price",product.Price},
                {"category",new Dictionary<string,dynamic>()
                {
                    {"title",product.Category.Title},
                    {"description",product.Category.Description}
                }}
            });
        }
        catch (Exception e)
        {
            return StatusCode(500, "Error: " + e);
        }
    }

    [HttpGet("GetAllProducts")]
    public async Task<IActionResult> GetAllProducts()
    {
        string authorizationHeader = Request.Headers["Authorization"]!;

        if (string.IsNullOrEmpty(authorizationHeader))
        {
            return BadRequest("Token manquant dans le header de la requête.");
        }

        string token = authorizationHeader.StartsWith("Bearer ") ? authorizationHeader.Substring(7) : authorizationHeader;
        var result =await _userService.IsTokenValid(token);
        if (!result)
        {
            return BadRequest("Token non valide");

        }
        var products = await _productService.GetAllProducts();
        return Ok(products);
    }
}