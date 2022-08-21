using Artsofte.BLL.Exceptions;
using Artsofte.BLL.Services.Interfaces;
using Artsofte.DAL.Entities;
using Artsofte.DAL.Repositories.Interfaces;
using Artsofte.Models.DTOs.Employee;
using AutoMapper;

namespace Artsofte.BLL.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IMapper _mapper;
    private readonly IEmployeeRepo _employeeRepo;
    private readonly IDepartmentRepo _departmentRepo;
    private readonly IProgrammingLanguageRepo _programmingLanguageRepo;

    public EmployeeService(IMapper mapper, IEmployeeRepo employeeRepo, IDepartmentRepo departmentRepo,
        IProgrammingLanguageRepo programmingLanguageRepo)
    {
        _mapper = mapper;
        _employeeRepo = employeeRepo;
        _departmentRepo = departmentRepo;
        _programmingLanguageRepo = programmingLanguageRepo;
    }

    public async Task<IEnumerable<EmployeeDTO>> GetAllAsync()
    {
        var employees = await _employeeRepo.GetAllAsync();
        return _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
    }

    public async Task<EmployeeDTO> GetOneAsync(int id)
    {
        var employee = await _employeeRepo.FindAsync(id);
        if (employee == null)
            throw new EmployeeDoesntExistException(nameof(employee), "Employee not found");
        return _mapper.Map<EmployeeDTO>(employee);
    }

    public async Task<EmployeeDTO> Add(EmployeeCreateDTO dto)
    {
        var employee = _mapper.Map<Employee>(dto);
        bool containsDepartment = await _departmentRepo.Contains(dto.DepartmentId);
        if (!containsDepartment)
            throw new DepartmentDoesntExistException(nameof(containsDepartment), "Department not found");

        bool containsLanguage = await _programmingLanguageRepo.Contains(dto.ProgrammingLanguageId);
        if (!containsLanguage)
            throw new ProgrammingLanguageDoesntExistException(
                nameof(containsDepartment), "Programming language not found");

        await _employeeRepo.AddAsync(employee);
        return _mapper.Map<EmployeeDTO>(employee);
    }

    public async Task<EmployeeDTO> Update(int id, EmployeeUpdateDTO dto)
    {
        var employee = await _employeeRepo.FindAsync(id);
        if (employee == null)
            throw new Exception(nameof(employee));

        bool containsDepartment = await _departmentRepo.Contains(dto.DepartmentId);
        if (!containsDepartment)
            throw new DepartmentDoesntExistException(nameof(containsDepartment), "Department not found");

        bool containsLanguage = await _programmingLanguageRepo.Contains(dto.ProgrammingLanguageId);
        if (!containsLanguage)
            throw new ProgrammingLanguageDoesntExistException(
                nameof(containsDepartment), "Programming language not found");
        
        _mapper.Map(dto, employee);
        await _employeeRepo.UpdateAsync(employee);
        return _mapper.Map<EmployeeDTO>(employee);
    }

    public async Task Delete(int id)
    {
        var employee = await _employeeRepo.FindAsync(id);
        if (employee == null)
            throw new EmployeeDoesntExistException(nameof(employee), "Employee not found");
        
        await _employeeRepo.DeleteAsync(employee);
    }
}