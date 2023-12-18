using FluentValidation;
using IRC.Models;

namespace IRC.EFC.Validators
{
    public class EquipmentValidator : AbstractValidator<Equipment>
    {
        public EquipmentValidator()
        {
            RuleFor(equipment => equipment).NotNull();
            RuleFor(equipment => equipment.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters.");

            RuleFor(equipment => equipment.SerialNumber)
                .NotEmpty().WithMessage("Serial number is required.")
                .MaximumLength(50).WithMessage("Serial number cannot exceed 50 characters.");

            RuleFor(equipment => equipment.InventoryNumber)
                .NotEmpty().WithMessage("Inventory number is required.")
                .MaximumLength(50).WithMessage("Inventory number cannot exceed 50 characters.");

            RuleFor(equipment => equipment.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }
    }
}
