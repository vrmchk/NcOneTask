using Artsofte.Models.DTOs.ProgrammingLanguage;

namespace Artsofte.BLL.Services.Interfaces;

public interface IProgrammingLanguageService
{
    Task<IEnumerable<ProgrammingLanguageDTO>> GetAllAsync();
    Task<ProgrammingLanguageDTO> GetOneAsync(int id);
    Task<ProgrammingLanguageDTO> Add(ProgrammingLanguageCreateDTO dto);
    Task<ProgrammingLanguageDTO> Update(int id, ProgrammingLanguageUpdateDTO dto);
    Task Delete(int id);

}