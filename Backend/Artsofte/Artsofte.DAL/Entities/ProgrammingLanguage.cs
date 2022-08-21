using Artsofte.DAL.Entities.Base;

namespace Artsofte.DAL.Entities;

public class ProgrammingLanguage : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public IEnumerable<Employee> EmployeesNavigation { get; set; } = null!;
}