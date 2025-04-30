using FluentValidation;
using Lab_ASP.Models;
using Lab_ASP.Models.ViewModels;

namespace Lab_ASP.Validators
{
    public class ReservationValidator : AbstractValidator<Reservation>
    {
        public ReservationValidator()
        {
            RuleFor(r => r.StartDate)
                .NotEmpty().WithMessage("Start date is required.");

            RuleFor(r => r.EndDate)
                .NotEmpty().WithMessage("End date is required.")
                .GreaterThanOrEqualTo(r => r.StartDate).WithMessage("End date must be after start date.");
        }
    }
}
