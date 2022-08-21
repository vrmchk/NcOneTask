using Artsofte.Models.DTOs.Employee;
using FluentValidation;

namespace Artsofte.Validators;

public class EmployeeUpdateDTOValidator : AbstractValidator<EmployeeUpdateDTO>
{
    public EmployeeUpdateDTOValidator()
    {
        RuleFor(dto => dto.Name)
            .NotEmpty()
            .MinimumLength(2);

        RuleFor(dto => dto.Surname)
            .NotEmpty()
            .MinimumLength(2);

        RuleFor(dto => dto.DepartmentId)
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(dto => dto.ProgrammingLanguageId)
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(dto => dto.Age)
            .NotEmpty()
            .GreaterThan(14);

        RuleFor(dto => dto.Gender)
            .NotEmpty();
    }
}