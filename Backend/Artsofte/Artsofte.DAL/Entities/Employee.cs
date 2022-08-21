using System.ComponentModel.DataAnnotations.Schema;
using Artsofte.DAL.Entities.Base;
using Artsofte.Models.Enums;

namespace Artsofte.DAL.Entities;

public class Employee : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public int DepartmentId { get; set; }
    public int ProgrammingLanguageId { get; set; }

    [ForeignKey(nameof(DepartmentId))]
    public Department Department { get; set; } = null!;

    [ForeignKey(nameof(ProgrammingLanguageId))]
    public ProgrammingLanguage ProgrammingLanguage { get; set; } = null!;
}