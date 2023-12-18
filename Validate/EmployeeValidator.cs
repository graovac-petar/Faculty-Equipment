using FluentValidation;
namespace IRC.Validate
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(employee => employee).NotNull();
            RuleFor(employee => employee.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(employee => employee.Department)
                .NotEmpty().WithMessage("Department is required.")
                .MaximumLength(50).WithMessage("Department cannot exceed 50 characters.");

            // Add more rules for other properties if necessary
        }
    }
}
