using FluentValidation;
using IRC.Models;

namespace IRC.EFC.Validators
{
    public class RoomValidator : AbstractValidator<Room>
    {
        public RoomValidator()
        {
            RuleFor(room => room).NotNull().NotEmpty();
            RuleFor(room => room.RoomNumber)
            .NotEmpty().WithMessage("Room number is required.")
            .MaximumLength(5).WithMessage("Room number cannot exceed 50 characters.");
        }
    }
}
