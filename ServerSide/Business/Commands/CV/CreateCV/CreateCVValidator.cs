using FluentValidation;

namespace Business.Commands.CV.CreateCV
{
    public class CreateDegreeValidator : AbstractValidator<CreateCVCommand>
    {
        public CreateDegreeValidator()
        {
            RuleFor(x => x.LastName).NotEmpty().WithMessage($"Last Name is mandatory.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage($"First Name is mandatory.");
            RuleFor(x => x.Email).NotEmpty().WithMessage($"Email is mandatory.");
            RuleFor(x => x.Mobile).NotEmpty().WithMessage($"Mobile is mandatory.");
            RuleFor(x => x.DegreeId).NotEmpty().WithMessage($"Degree is mandatory.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage($"First Name is mandatory.");

        }
    }
}
