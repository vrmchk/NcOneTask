using Artsofte.DAL.Context;
using Artsofte.DAL.Entities;
using Artsofte.DAL.Repositories.Base;
using Artsofte.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Artsofte.DAL.Repositories;

public class ProgrammingLanguageRepo : BaseRepo<ProgrammingLanguage>, IProgrammingLanguageRepo
{
    public ProgrammingLanguageRepo(ApplicationDbContext context) : base(context) { }
    internal ProgrammingLanguageRepo(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public override async Task<IEnumerable<ProgrammingLanguage>> GetAllAsync()
    {
        return await Table
            .Include(pl => pl.EmployeesNavigation)
            .ToListAsync();
    }

    public override async Task<ProgrammingLanguage?> FindAsync(int id)
    {
        return await Table
            .Where(pl => pl.Id == id)
            .Include(pl => pl.EmployeesNavigation)
            .FirstOrDefaultAsync();
    }

    public override async Task<ProgrammingLanguage?> FindAsNoTrackingAsync(int id)
    {
        return await Table
            .AsNoTracking()
            .Where(pl => pl.Id == id)
            .Include(pl => pl.EmployeesNavigation)
            .FirstOrDefaultAsync();
    }
}