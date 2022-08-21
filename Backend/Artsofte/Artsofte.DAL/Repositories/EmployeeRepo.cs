using Artsofte.DAL.Context;
using Artsofte.DAL.Entities;
using Artsofte.DAL.Repositories.Base;
using Artsofte.DAL.Repositories.Interfaces;
using Artsofte.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Artsofte.DAL.Repositories;

public class EmployeeRepo : BaseRepo<Employee>, IEmployeeRepo
{
    public EmployeeRepo(ApplicationDbContext context) : base(context) { }
    internal EmployeeRepo(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public override async Task<IEnumerable<Employee>> GetAllAsync()
    {
        return await Table
            .Include(e => e.Department)
            .Include(e => e.ProgrammingLanguage).ToListAsync();
    }

    public override async Task<Employee?> FindAsync(int id)
    {
        return await Table
            .Where(e => e.Id == id)
            .Include(e => e.Department)
            .Include(e => e.ProgrammingLanguage)
            .FirstOrDefaultAsync();
    }

    public override async Task<Employee?> FindAsNoTrackingAsync(int id)
    {
        return await Table
            .AsNoTracking()
            .Where(e => e.Id == id)
            .Include(e => e.Department)
            .Include(e => e.ProgrammingLanguage)
            .FirstOrDefaultAsync();
    }

    public void AddDefault()
    {
        Context.ProgrammingLanguages.AddRange(
            new ProgrammingLanguage {Name = "C#"}, new ProgrammingLanguage {Name = "TypeScript"});
        Context.Departments.AddRange(
            new Department {Name = "Backend", Floor = 1}, new Department {Name = "Frontend", Floor = 2});
        Context.SaveChanges();
        Context.Employees.AddRange(
            new Employee
            {
                Name = "pipi",
                Surname = "pipi",
                Age = 14,
                Gender = Gender.Female,
                Department = Context.Departments.First(d => d.Id == 2),
                ProgrammingLanguage = Context.ProgrammingLanguages.First(d => d.Id == 2)
            },
            new Employee
            {
                Name = "pisia",
                Surname = "kaka",
                Age = 18,
                Gender = Gender.Male,
                Department = Context.Departments.First(d => d.Id == 1),
                ProgrammingLanguage = Context.ProgrammingLanguages.First(d => d.Id == 1)
            });
        Context.SaveChanges();
    }
}