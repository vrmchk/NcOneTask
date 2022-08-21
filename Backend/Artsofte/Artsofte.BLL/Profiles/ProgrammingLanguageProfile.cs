using Artsofte.DAL.Entities;
using Artsofte.Models.DTOs.ProgrammingLanguage;
using AutoMapper;

namespace Artsofte.BLL.Profiles;

public class ProgrammingLanguageProfile : Profile
{
    public ProgrammingLanguageProfile()
    {
        CreateMap<ProgrammingLanguage, ProgrammingLanguageDTO>();
    }
}