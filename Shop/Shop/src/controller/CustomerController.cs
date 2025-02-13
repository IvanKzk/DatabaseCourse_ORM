using Microsoft.AspNetCore.Mvc;
using Shop.dto;
using Shop.model;
using Shop.repository.interfaces;

namespace Shop.controller;

[ApiController]
[Route("/api/customer")]
public class CustomerController(ICustomerRepository customerRepository) : ControllerBase
{
    
    private ICustomerRepository customerRepository = customerRepository;

    [HttpPost("add")]
    public IActionResult addCustomer([FromBody] CustomerDto? customerDto)
    {
        if (customerDto == null)
        {
            return BadRequest("Request body is null");
        }
        
        customerRepository.addCustomer(new Customer(customerDto.customer_name, customerDto.total_spent));
        return Ok("Customer added");
    }

    [HttpGet("{id}")]
    public IActionResult searchCustomerById(long id)
    {
        var found = customerRepository.getCustomerById(id);
        if (found == null)
        {
            return NotFound("No Customer Found");
        }
        return Ok("Name: " + found.customer_name);
    }

    [HttpPost("update/{id}")]
    public IActionResult updateCustomer([FromBody] CustomerDto? customer, long id)
    {
        var found = customerRepository.getCustomerById(id);
        if (found == null)
        {
            return NotFound("No Customer found");
        }
        found.customer_name = customer.customer_name;
        customerRepository.updateCustomer(found);
        return Ok("Customer updated");
    }

    [HttpDelete("delete/{id}")]
    public IActionResult deleteCustomer(long id)
    {
        var found = customerRepository.getCustomerById(id);
        if (found == null)
        {
            return NotFound("No Customer found");
        }
        customerRepository.deleteCustomer(found);
        return Ok("Customer deleted");
    } 

    [HttpGet("all")]
    public string? getAllCustomers()
    {
        return customerRepository.getAllCustomers()?.ToString();
    }
}