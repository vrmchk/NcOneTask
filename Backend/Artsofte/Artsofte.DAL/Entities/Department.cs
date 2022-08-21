using Artsofte.DAL.Entities.Base;

namespace Artsofte.DAL.Entities;

public class Department : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int Floor { get; set; }
    public IEnumerable<Employee> EmployeesNavigation { get; set; } = null!;
}