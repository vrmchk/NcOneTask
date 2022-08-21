using Artsofte.BLL.Exceptions;
using Artsofte.BLL.Services.Interfaces;
using Artsofte.DAL.Entities;
using Artsofte.DAL.Repositories.Interfaces;
using Artsofte.Models.DTOs.ProgrammingLanguage;
using AutoMapper;

namespace Artsofte.BLL.Services;

public class ProgrammingLanguageService : IProgrammingLanguageService
{
    private readonly IMapper _mapper;
    private readonly IProgrammingLanguageRepo _languageRepo;
    
    public ProgrammingLanguageService(IProgrammingLanguageRepo languageRepo, IMapper mapper)
    {
        _languageRepo = languageRepo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProgrammingLanguageDTO>> GetAllAsync()
    {
        var departments = await _languageRepo.GetAllAsync();
        return _mapper.Map<IEnumerable<ProgrammingLanguageDTO>>(departments);
    }

    public async Task<ProgrammingLanguageDTO> GetOneAsync(int id)
    {
        var department = await _languageRepo.FindAsync(id);
        if (department == null)
            throw new ProgrammingLanguageDoesntExistException(nameof(department), "Department not found");

        return _mapper.Map<ProgrammingLanguageDTO>(department);
    }

    public async Task<ProgrammingLanguageDTO> Add(ProgrammingLanguageCreateDTO dto)
    {
        var department = _mapper.Map<ProgrammingLanguage>(dto);
        await _languageRepo.AddAsync(department);
        return _mapper.Map<ProgrammingLanguageDTO>(dto);
    }

    public async Task<ProgrammingLanguageDTO> Update(int id, ProgrammingLanguageUpdateDTO dto)
    {
        var department = await _languageRepo.FindAsync(id);
        if (department == null)
            throw new ProgrammingLanguageDoesntExistException(nameof(department), "Department not found");

        _mapper.Map(dto, department);
        await _languageRepo.UpdateAsync(department);
        return _mapper.Map<ProgrammingLanguageDTO>(department);
    }

    public async Task Delete(int id)
    {
        var department = await _languageRepo.FindAsync(id);
        if (department == null)
            throw new ProgrammingLanguageDoesntExistException(nameof(department), "Department not found");

        await _languageRepo.DeleteAsync(department);
    }

}