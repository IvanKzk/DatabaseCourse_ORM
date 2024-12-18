using Microsoft.AspNetCore.Mvc;
using Shop.dto;
using Shop.model;
using Shop.repository.interfaces;

namespace Shop.controller;

[ApiController]
[Route("/api/department")]
public class DepartmentController(IDepartmentRepository departmentRepository) : ControllerBase
{
    
    private IDepartmentRepository departmentRepository = departmentRepository;

    [HttpPost("add")]
    public IActionResult addDepartment([FromBody] DepartmentDto? departmentDto)
    {
        if (departmentDto == null)
        {
            return BadRequest("Request body is null");
        }
        
        departmentRepository.addDepartment(new Department(departmentDto.department_name));
        return Ok("Department added");
    }

    [HttpGet("{id}")]
    public IActionResult searchDepartmentById(long id)
    {
        var found = departmentRepository.getDepartmentById(id);
        if (found == null)
        {
            return NotFound("No Department Found");
        }
        return Ok("Name: " + found.department_name);
    }

    [HttpPost("update/{id}")]
    public IActionResult updateDepartment([FromBody] DepartmentDto? department, long id)
    {
        var found = departmentRepository.getDepartmentById(id);
        if (found == null)
        {
            return NotFound("No Department found");
        }
        found.department_name = department.department_name;
        departmentRepository.updateDepartment(found);
        return Ok("Department updated");
    }

    [HttpDelete("delete/{id}")]
    public IActionResult deleteDepartment(long id)
    {
        var found = departmentRepository.getDepartmentById(id);
        if (found == null)
        {
            return NotFound("No Department found");
        }
        departmentRepository.deleteDepartment(found);
        return Ok("Department deleted");
    } 

    [HttpGet("all")]
    public string? getAllDepartments()
    {
        return departmentRepository.getAllDepartments()?.ToString();
    }
}