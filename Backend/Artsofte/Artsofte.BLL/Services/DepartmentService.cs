using Artsofte.BLL.Exceptions;
using Artsofte.BLL.Services.Interfaces;
using Artsofte.DAL.Entities;
using Artsofte.DAL.Repositories.Interfaces;
using Artsofte.Models.DTOs.Department;
using AutoMapper;

namespace Artsofte.BLL.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IMapper _mapper;
    private readonly IDepartmentRepo _departmentRepo;

    public DepartmentService(IMapper mapper, IDepartmentRepo departmentRepo)
    {
        _mapper = mapper;
        _departmentRepo = departmentRepo;
    }

    public async Task<IEnumerable<DepartmentDTO>> GetAllAsync()
    {
        var departments = await _departmentRepo.GetAllAsync();
        return _mapper.Map<IEnumerable<DepartmentDTO>>(departments);
    }

    public async Task<DepartmentDTO> GetOneAsync(int id)
    {
        var department = await _departmentRepo.FindAsync(id);
        if (department == null)
            throw new DepartmentDoesntExistException(nameof(department), "Department not found");

        return _mapper.Map<DepartmentDTO>(department);
    }

    public async Task<DepartmentDTO> Add(DepartmentCreateDTO dto)
    {
        var department = _mapper.Map<Department>(dto);
        await _departmentRepo.AddAsync(department);
        return _mapper.Map<DepartmentDTO>(dto);
    }

    public async Task<DepartmentDTO> Update(int id, DepartmentUpdateDTO dto)
    {
        var department = await _departmentRepo.FindAsync(id);
        if (department == null)
            throw new DepartmentDoesntExistException(nameof(department), "Department not found");

        _mapper.Map(dto, department);
        await _departmentRepo.UpdateAsync(department);
        return _mapper.Map<DepartmentDTO>(department);
    }

    public async Task Delete(int id)
    {
        var department = await _departmentRepo.FindAsync(id);
        if (department == null)
            throw new DepartmentDoesntExistException(nameof(department), "Department not found");

        await _departmentRepo.DeleteAsync(department);
    }
}