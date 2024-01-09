using FluentValidation;

namespace IRC.Blazor.ModelValidator
{
    public class EquipmentAssignementF
    {
        public int EquipmentId { get; set; }
        public int EmployeeId { get; set; }
        public int RoomId { get; set; }
        public DateTime DateBorrowed { get; set; }
    }
    public class EquipmentAssignementFValidator : AbstractValidator<EquipmentAssignementF>
    {
        public EquipmentAssignementFValidator()
        {
            RuleFor(p => p.EmployeeId).NotEqual(-1).WithMessage("Please pick an Employee");
            RuleFor(p => p.EmployeeId).NotEmpty().WithMessage("Please pick an Employee");
            RuleFor(p => p.RoomId).NotEqual(-1).WithMessage("Please pick a Room");
            RuleFor(p => p.RoomId).NotEmpty().WithMessage("Please pick a Room");
            RuleFor(x => x.DateBorrowed)
            .Must(BeValidDate).WithMessage("Date borrowed must be between 1990 and today.");
        }
        private bool BeValidDate(DateTime date)
        {
            var today = DateTime.Today;
            var minDate = new DateTime(1990, 1, 1);

            return date <= today && date >= minDate;
        }
    }
}
