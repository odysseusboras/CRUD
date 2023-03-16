using FluentValidation;
using System.Threading.Tasks;

namespace Business.Commands.Degree.CreateDegree
{
    public class CreateDegreeValidator : AbstractValidator<CreateDegreeCommand>
    {
        public CreateDegreeValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage($"Name is mandatory.");

        }
    }
}
