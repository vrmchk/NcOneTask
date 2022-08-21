using Artsofte.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Artsofte.DAL.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public virtual DbSet<Employee> Employees { get; set; } = null!;
    public virtual DbSet<Department> Departments { get; set; } = null!;
    public virtual DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(employee =>
        {
            employee
                .HasOne(e => e.Department)
                .WithMany(d => d.EmployeesNavigation)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.ClientCascade);

            employee
                .HasOne(e => e.ProgrammingLanguage)
                .WithMany(pl => pl.EmployeesNavigation)
                .HasForeignKey(e => e.ProgrammingLanguageId)
                .OnDelete(DeleteBehavior.ClientCascade);
        });
    }
}