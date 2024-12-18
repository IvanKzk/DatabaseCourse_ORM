using Microsoft.AspNetCore.Mvc;
using Shop.dto;
using Shop.model;
using Shop.repository.interfaces;

namespace Shop.controller;

[ApiController]
[Route("/api/category")]
public class CategoryController(ICategoryRepository categoryRepository) : ControllerBase
{
    
    private ICategoryRepository categoryRepository = categoryRepository;

    [HttpPost("add")]
    public IActionResult addCategory([FromBody] CategoryDto? categoryDto)
    {
        if (categoryDto == null)
        {
            return BadRequest("Request body is null");
        }
        
        categoryRepository.addCategory(new Category(categoryDto.category_name));
        return Ok("Category added");
    }

    [HttpGet("{id}")]
    public IActionResult searchCategoryByNId(long id)
    {
        var found = categoryRepository.getCategoryById(id);
        if (found == null)
        {
            return NotFound("No Category Found");
        }
        return Ok("Name: " + found.category_name);
    }

    [HttpPost("update/{id}")]
    public IActionResult updateCategory([FromBody] CategoryDto? category, long id)
    {
        var found = categoryRepository.getCategoryById(id);
        if (found == null)
        {
            return NotFound("No Category found");
        }
        found.category_name = category.category_name;
        categoryRepository.updateCategory(found);
        return Ok("Category updated");
    }

    [HttpDelete("delete/{id}")]
    public IActionResult deleteCategory(long id)
    {
        var found = categoryRepository.getCategoryById(id);
        if (found == null)
        {
            return NotFound("No Category found");
        }
        categoryRepository.deleteCategory(found);
        return Ok("Category deleted");
    }

    [HttpGet("all")]
    public string? getAllCategories()
    {
        return categoryRepository.getAllCategories()?.ToString();
    }
}