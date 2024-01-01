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
    private readonly IMapper _mapper;

    public ProductController(ProductService productService, CategoryService categoryService, IMapper mapper)
    {
        _productService = productService;
        _categoryService = categoryService;
        _mapper = mapper;
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
            return StatusCode(201, product);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Error: " + e);
        }
    }
}