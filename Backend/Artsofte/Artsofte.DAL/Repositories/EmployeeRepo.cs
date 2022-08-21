using Artsofte.DAL.Context;
using Artsofte.DAL.Entities;
using Artsofte.DAL.Repositories.Base;
using Artsofte.DAL.Repositories.Interfaces;
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
}