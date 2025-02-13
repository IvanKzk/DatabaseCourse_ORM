using Microsoft.AspNetCore.Mvc;
using Shop.dto;
using Shop.model;
using Shop.repository.interfaces;

namespace Shop.controller;

[ApiController]
[Route("/api/discount")]
public class DiscountController(IDiscountRepository discountRepository) : ControllerBase
{
    
    private IDiscountRepository discountRepository = discountRepository;

    [HttpPost("add")]
    public IActionResult addDiscount([FromBody] DiscountDto? discountDto)
    {
        if (discountDto == null)
        {
            return BadRequest("Request body is null");
        }
        
        discountRepository.addDiscount(new Discount(discountDto.discount_rate, discountDto.min_purchase_amount));
        return Ok("Discount added");
    }

    [HttpGet("{id}")]
    public IActionResult searchDiscountById(long id)
    {
        var found = discountRepository.getDiscountById(id);
        if (found == null)
        {
            return NotFound("No Discount Found");
        }
        return Ok("Rate: " + found.discount_rate + "\nMin. purchase amount: " + found.min_purchase_amount);
    }

    [HttpPost("update/{id}")]
    public IActionResult updateDiscount([FromBody] DiscountDto? discount, long id)
    {
        var found = discountRepository.getDiscountById(id);
        if (found == null)
        {
            return NotFound("No Discount found");
        }
        found.discount_rate = discount.discount_rate;
        found.min_purchase_amount = discount.min_purchase_amount;
        discountRepository.updateDiscount(found);
        return Ok("Discount updated");
    }

    [HttpDelete("delete/{id}")]
    public IActionResult deleteDiscount(long id)
    {
        var found = discountRepository.getDiscountById(id);
        if (found == null)
        {
            return NotFound("No Discount found");
        }
        discountRepository.deleteDiscount(found);
        return Ok("Discount deleted");
    }

    [HttpGet("all")]
    public string? getAllDiscounts()
    {
        return discountRepository.getAllDiscounts()?.ToString();
    }
}