
using Business.Commands.Degree.UpdateDegree;
using FluentValidation;

namespace Business.Commands.CV.UpdateCV
{
    public class UpdateDegreeValidator : AbstractValidator<UpdateDegreeCommand>
    {
        public UpdateDegreeValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage($"Name is mandatory.");

        }
    }
}
