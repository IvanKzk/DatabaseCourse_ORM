using Microsoft.AspNetCore.Mvc;
using Shop.dto;
using Shop.model;
using Shop.repository.interfaces;

namespace Shop.controller;

[ApiController]
[Route("/api/product")]
public class ProductController(IProductRepository productRepository, IDepartmentRepository departmentRepository, ICategoryRepository categoryRepository) : ControllerBase
{
    
    private IProductRepository productRepository = productRepository;

    private IDepartmentRepository departmentRepository = departmentRepository;

    private ICategoryRepository categoryRepository = categoryRepository;

    [HttpPost("add")]
    public IActionResult addProduct([FromBody] ProductDto? productDto)
    {
        if (productDto == null)
        {
            return BadRequest("Request body is null");
        }

        var foundDepartment = departmentRepository.getDepartmentByName(productDto.department_name);
        if (foundDepartment == null)
        {
            return NotFound("Department Not Found");
        }

        var foundCategory = categoryRepository.getCategoryByName(productDto.category_name);
        if (foundCategory == null)
        {
            return NotFound("Category Not Found");
        }
        
        productRepository.addProduct(new Product(productDto.product_name, foundDepartment.department_id, foundCategory.category_id, productDto.price, productDto.stock, productDto.size, productDto.color, productDto.pattern));
        return Ok("Product added");
    }

    [HttpGet("{id}")]
    public IActionResult searchProductById(long id)
    {
        var found = productRepository.getProductById(id);
        if (found == null)
        {
            return NotFound("No Product Found");
        }

        var foundDepartment = departmentRepository.getDepartmentById(found.department_id);
        if (foundDepartment == null)
        {
            return NotFound("Department Not Found");
        }

        var foundCategory = categoryRepository.getCategoryById(found.category_id);
        if (foundCategory == null)
        {
            return NotFound("Category Not Found");
        }

        return Ok("Department: " + foundDepartment.department_name + "\nCategory: " + foundCategory.category_name + "\nPrice: " + found.price + "\nStock: " + found.stock+ "\nSize: " + found.size + "\nColor: " + found.color+ "\nPattern: " + found.pattern);
    }

    [HttpPost("update")]
    public IActionResult updateProduct([FromBody] ProductDto? product)
    {
        var found = productRepository.getProductByName(product.product_name);
        if (found == null)
        {
            return NotFound("No Product found");
        }

        var foundDepartment = departmentRepository.getDepartmentByName(product.department_name);
        if (foundDepartment == null)
        {
            return NotFound("Department Not Found");
        }

        var foundCategory = categoryRepository.getCategoryByName(product.category_name);
        if (foundCategory == null)
        {
            return NotFound("Category Not Found");
        }

        found.product_name = product.product_name;
        found.department_id = foundDepartment.department_id;
        found.category_id = foundCategory.category_id;
        found.price = product.price;
        found.stock = product.stock;
        found.size = product.size;
        found.color = product.color;
        found.pattern = product.pattern;
        productRepository.updateProduct(found);
        return Ok("Product updated");
    }

    [HttpDelete("delete/{id}")]
    public IActionResult deleteProduct(long id)
    {
        var found = productRepository.getProductById(id);
        if (found == null)
        {
            return NotFound("No Product found");
        }
        productRepository.deleteProduct(found);
        return Ok("Product deleted");
    }

    [HttpGet("all")]
    public string? getAllProducts()
    {
        return productRepository.getAllProducts()?.ToString();
    }

    [HttpGet("department/{department}")]
    public string? getAllProductsByDepartment(string department)
    {
        return productRepository.getProductsByDepartment(department)?.ToString();
    }

    [HttpGet("category/{category}")]
    public string? getAllProductsByCategory(string category)
    {
        return productRepository.getProductsByCategory(category)?.ToString();
    }
}