using Artsofte.Models.DTOs.ProgrammingLanguage;
using FluentValidation;

namespace Artsofte.Validators;

public class ProgrammingLanguageCreateDTOValidator : AbstractValidator<ProgrammingLanguageCreateDTO>
{
    public ProgrammingLanguageCreateDTOValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty()
            .MinimumLength(1);
    }
}