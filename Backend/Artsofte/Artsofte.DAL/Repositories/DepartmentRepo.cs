using Artsofte.DAL.Context;
using Artsofte.DAL.Entities;
using Artsofte.DAL.Repositories.Base;
using Artsofte.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Artsofte.DAL.Repositories;

public class DepartmentRepo : BaseRepo<Department>, IDepartmentRepo
{
    public DepartmentRepo(ApplicationDbContext context) : base(context) { }
    internal DepartmentRepo(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public override async Task<IEnumerable<Department>> GetAllAsync()
    {
        return await Table
            .Include(d => d.EmployeesNavigation)
            .ToListAsync();
    }

    public override async Task<Department?> FindAsync(int id)
    {
        return await Table
            .Where(d => d.Id == id)
            .Include(d => d.EmployeesNavigation)
            .FirstOrDefaultAsync();
    }

    public override async Task<Department?> FindAsNoTrackingAsync(int id)
    {
        return await Table
            .AsNoTracking()
            .Where(d => d.Id == id)
            .Include(d => d.EmployeesNavigation)
            .FirstOrDefaultAsync();
    }
}