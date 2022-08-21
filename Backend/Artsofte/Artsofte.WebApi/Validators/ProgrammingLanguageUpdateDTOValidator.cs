using Artsofte.Models.DTOs.ProgrammingLanguage;
using FluentValidation;

namespace Artsofte.Validators;

public class ProgrammingLanguageUpdateDTOValidator : AbstractValidator<ProgrammingLanguageUpdateDTO>
{
    public ProgrammingLanguageUpdateDTOValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty()
            .MinimumLength(1);
    }
}