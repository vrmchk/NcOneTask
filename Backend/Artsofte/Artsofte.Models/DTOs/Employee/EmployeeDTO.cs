using Artsofte.Models.DTOs.Department;
using Artsofte.Models.DTOs.ProgrammingLanguage;
using Artsofte.Models.Enums;

namespace Artsofte.Models.DTOs.Employee;

public class EmployeeDTO
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public DepartmentDTO Department { get; set; } = null!;
    public ProgrammingLanguageDTO ProgrammingLanguage { get; set; } = null!;
}