using Artsofte.DAL.Entities;

namespace Artsofte.DAL.Repositories.Interfaces;

public interface IEmployeeRepo : IRepo<Employee>
{
    public void AddDefault();
}