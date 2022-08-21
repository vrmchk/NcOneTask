using Artsofte.Models.DTOs.Department;
using FluentValidation;

namespace Artsofte.Validators;

public class DepartmentUpdateDTOValidator : AbstractValidator<DepartmentUpdateDTO>
{
    public DepartmentUpdateDTOValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty()
            .MinimumLength(1)
            .MaximumLength(255);

        RuleFor(dto => dto.Floor)
            .NotEmpty();
    }
}