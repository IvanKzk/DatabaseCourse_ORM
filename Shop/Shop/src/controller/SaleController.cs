using Microsoft.AspNetCore.Mvc;
using Shop.dto;
using Shop.model;
using Shop.repository.interfaces;

namespace Shop.controller;

[ApiController]
[Route("/api/sale")]
public class SaleController(ISaleRepository saleRepository, ICustomerRepository customerRepository, IProductRepository productRepository) : ControllerBase
{
    
    private ISaleRepository saleRepository = saleRepository;

    private ICustomerRepository customerRepository = customerRepository;

    private IProductRepository productRepository = productRepository;

    [HttpPost("add")]
    public IActionResult addSale([FromBody] SaleDto? saleDto)
    {
        if (saleDto == null)
        {
            return BadRequest("Request body is null");
        }

        var foundCustomer = customerRepository.getCustomerByName(saleDto.customer_name);
        if (foundCustomer == null)
        {
            return NotFound("Customer Not Found");
        }

        var foundProduct = productRepository.getProductByName(saleDto.product_name);
        if (foundProduct == null)
        {
            return NotFound("Product Not Found");
        }
        
        saleRepository.addSale(new Sale(foundCustomer.customer_id, foundProduct.product_id, saleDto.quantity, saleDto.sale_date));
        return Ok("Sale added");
    }

    [HttpGet("{id}")]
    public IActionResult searchSaleById(long id)
    {
        var found = saleRepository.getSaleById(id);
        if (found == null)
        {
            return NotFound("No Sale Found");
        }

        var foundCustomer = customerRepository.getCustomerById(found.customer_id);
        if (foundCustomer == null)
        {
            return NotFound("Customer Not Found");
        }

        var foundProduct = productRepository.getProductById(found.product_id);
        if (foundProduct == null)
        {
            return NotFound("Product Not Found");
        }

        return Ok("Customer: " + foundCustomer.customer_name + "\nProduct: " + foundProduct.product_name + "\nQuantity: " + found.quantity + "\nDate: " + found.sale_date);
    }

    [HttpPost("update/{id}")]
    public IActionResult updateSale([FromBody] SaleDto? sale, long id)
    {
        var found = saleRepository.getSaleById(id);
        if (found == null)
        {
            return NotFound("No Sale found");
        }

        var foundCustomer = customerRepository.getCustomerByName(sale.customer_name);
        if (foundCustomer == null)
        {
            return NotFound("Customer Not Found");
        }

        var foundProduct = productRepository.getProductByName(sale.product_name);
        if (foundProduct == null)
        {
            return NotFound("Product Not Found");
        }

        found.customer_id = foundCustomer.customer_id;
        found.product_id = foundProduct.product_id;
        found.quantity = sale.quantity;
        found.sale_date = sale.sale_date;
        saleRepository.updateSale(found);
        return Ok("Sale updated");
    }

    [HttpDelete("delete/{id}")]
    public IActionResult deleteSale(long id)
    {
        var found = saleRepository.getSaleById(id);
        if (found == null)
        {
            return NotFound("No Sale found");
        }
        saleRepository.deleteSale(found);
        return Ok("Sale deleted");
    }

    [HttpGet("all")]
    public string? getAllSales()
    {
        return saleRepository.getAllSales()?.ToString();
    }

    [HttpGet("customer/{customer}")]
    public string? getAllSalesByCustomer(string customer)
    {
        return saleRepository.getSalesByCustomer(customer)?.ToString();
    }

    [HttpGet("product/{product}")]
    public string? getAllSalesByProduct(string product)
    {
        return saleRepository.getSalesByProduct(product)?.ToString();
    }
}