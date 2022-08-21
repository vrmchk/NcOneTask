using Artsofte.Models.DTOs.Department;

namespace Artsofte.BLL.Services.Interfaces;

public interface IDepartmentService
{
    Task<IEnumerable<DepartmentDTO>> GetAllAsync();
    Task<DepartmentDTO> GetOneAsync(int id);
    Task<DepartmentDTO> Add(DepartmentCreateDTO dto);
    Task<DepartmentDTO> Update(int id, DepartmentUpdateDTO dto);
    Task Delete(int id);
}