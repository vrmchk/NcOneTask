using Artsofte.DAL.Entities;
using Artsofte.Models.DTOs.Department;
using Artsofte.Models.DTOs.Employee;
using Artsofte.Models.DTOs.ProgrammingLanguage;
using AutoMapper;

namespace Artsofte.BLL.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        var mapper = new Mapper(new MapperConfiguration(config =>
            config.AddProfiles(new Profile[] {new DepartmentProfile(), new ProgrammingLanguageProfile()})));

        CreateMap<Employee, EmployeeDTO>()
            .ForMember(dest => dest.Department,
                options => options.MapFrom(e => mapper.Map<DepartmentDTO>(e.Department)))
            .ForMember(dest => dest.ProgrammingLanguage,
                options => options.MapFrom(e => mapper.Map<ProgrammingLanguageDTO>(e.ProgrammingLanguage)));

        CreateMap<EmployeeCreateDTO, Employee>();
        CreateMap<EmployeeUpdateDTO, Employee>();
    }
}