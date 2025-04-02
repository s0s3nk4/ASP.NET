using FluentValidation;
using Lab_ASP.Models.ViewModels;

namespace Lab_ASP.Validators
{
    public class ReservationValidator : AbstractValidator<ReservationViewModel>
    {
        public ReservationValidator()
        {
            RuleFor(r => r.StartDate)
                .LessThanOrEqualTo(r => r.EndDate)
                .WithMessage("Data rozpoczęcia musi być wcześniejsza niż data zakończenia");

            RuleFor(r => r.EndDate)
                .GreaterThanOrEqualTo(r => r.StartDate)
                .WithMessage("Data zakończenia musi być późniejsza niż data rozpoczęcia");
        }
    }
}
