using Artsofte.BLL.Services.Interfaces;
using Artsofte.Models.DTOs.Department;
using Artsofte.Models.DTOs.Employee;
using Microsoft.AspNetCore.Mvc;

namespace Artsofte.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _service;


    public DepartmentController(IDepartmentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployee(int id)
    {
        return Ok(await _service.GetOneAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee([FromBody] DepartmentCreateDTO createDTO)
    {
        var employeeDTO = await _service.Add(createDTO);
        return CreatedAtAction(nameof(GetEmployee), new {id = employeeDTO.Id}, employeeDTO);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(int id, [FromBody] DepartmentUpdateDTO updateDTO)
    {
        var employeeDTO = await _service.Update(id, updateDTO);
        return Ok(employeeDTO);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        await _service.Delete(id);
        return NoContent();
    }
}