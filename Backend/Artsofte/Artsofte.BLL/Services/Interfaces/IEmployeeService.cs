using Artsofte.Models.DTOs.Employee;

namespace Artsofte.BLL.Services.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDTO>> GetAllAsync();
    Task<EmployeeDTO> GetOneAsync(int id);
    Task<EmployeeDTO> Add(EmployeeCreateDTO dto);
    Task<EmployeeDTO> Update(int id, EmployeeUpdateDTO dto);
    Task Delete(int id);
}