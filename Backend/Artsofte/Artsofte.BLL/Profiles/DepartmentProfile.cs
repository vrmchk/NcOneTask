using Artsofte.DAL.Entities;
using Artsofte.Models.DTOs.Department;
using AutoMapper;

namespace Artsofte.BLL.Profiles;

public class DepartmentProfile : Profile
{
    public DepartmentProfile()
    {
        CreateMap<Department, DepartmentDTO>();
    }
}