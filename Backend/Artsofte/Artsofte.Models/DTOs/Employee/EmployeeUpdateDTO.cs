using Artsofte.Models.Enums;

namespace Artsofte.Models.DTOs.Employee;

public class EmployeeUpdateDTO
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public int DepartmentId { get; set; }
    public int ProgrammingLanguageId { get; set; }
}