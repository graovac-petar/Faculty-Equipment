using FluentValidation;
using IRC.Models;

namespace IRC.Blazor.ModelValidator
{
    public class EquipmentF
    {
        public string Name { get; set; } = "";
        public string SerialNumber { get; set; } = "";
        public string InventoryNumber { get; set; } = "";
        public int? Quantity { get; set; }
        public EquipmentType Type { get; set; }
    }
    public class EquipmetValidator : AbstractValidator<EquipmentF>
    {
        public EquipmetValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Can not be Empty").Must((equipment, name) => ContainsSerialNumber(name, equipment.SerialNumber))
        .WithMessage("Name must contain SerialNumber");
            RuleFor(p => p.Name).MaximumLength(50).WithMessage("Max length for Name is 50");
            RuleFor(p => p.Name).Matches("^[A-Z0-9]+$").WithMessage("Can contain only capital letters and numbers");
            RuleFor(p => p.SerialNumber).NotEmpty().WithMessage("You must enter a SerialNumber");
            RuleFor(p => p.SerialNumber).MaximumLength(50).WithMessage("Max length for Serial Number is 50");
            RuleFor(p => p.SerialNumber).Matches("^[A-Z0-9]+$").WithMessage("Can contain only capital letters and numbers");
            RuleFor(p => p.InventoryNumber).NotEmpty().WithMessage("You must enter a Inventory Number");
            RuleFor(p => p.InventoryNumber).MaximumLength(50).WithMessage("Max length for Inventory Number is 50");
            RuleFor(p => p.Quantity).GreaterThanOrEqualTo(0).WithMessage("Quantity must be greater than or equal to 0.").When((equipment) => equipment.Quantity != null);
            RuleFor(p => (int)p.Type).GreaterThanOrEqualTo(0).WithMessage("Choose a type");
        }
        private bool ContainsSerialNumber(string name, string serialNumber)
        {
            // Check if the name contains the serial number
            return name.Contains(serialNumber);
        }
    }
}
