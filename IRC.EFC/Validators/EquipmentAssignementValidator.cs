using FluentValidation;
using IRC.Models;
using Microsoft.EntityFrameworkCore;

namespace IRC.EFC.Validators
{
    public class EquipmentAssignementValidator : AbstractValidator<EquipmentAssignement>
    {


        public EquipmentAssignementValidator(DBContext context)
        {
            RuleFor(ea => ea.EmployeeId)
                .NotEmpty().WithMessage("Employee ID is required")
                .MustAsync(BeValidEmployee).WithMessage("Employee does not exist.");

            RuleFor(ea => ea.EquipmentId)
                .NotEmpty().WithMessage("Equipment ID is required")
                .MustAsync(BeValidEquipment).WithMessage("Equipment does not exist.");

            RuleFor(ea => ea.RoomId)
                .NotEmpty().WithMessage("Room ID is required")
                .MustAsync(BeValidRoom).WithMessage("Room does not exist."); ;
            Context = context;
            RuleFor(x => x.DateBorrowed)
           .Must((dateBorrowed) => dateBorrowed <= DateTime.Now)
           .WithMessage("DateBorrowed must be in the past or at the moment");
        }

        public DBContext Context { get; }

        private async Task<bool> BeValidEmployee(int employeeId, CancellationToken cancellationToken)
        {
            return await Context.Employee.AnyAsync(e => e.EmployeeId == employeeId, cancellationToken);
        }

        private async Task<bool> BeValidEquipment(int equipmentId, CancellationToken cancellationToken)
        {
            return await Context.Equipment.AnyAsync(e => e.EquipmentId == equipmentId, cancellationToken);
        }

        private async Task<bool> BeValidRoom(int roomId, CancellationToken cancellationToken)
        {
            return await Context.Room.AnyAsync(r => r.RoomId == roomId, cancellationToken);
        }
    }
}
