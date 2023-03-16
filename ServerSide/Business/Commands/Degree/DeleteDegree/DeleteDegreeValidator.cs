using FluentValidation;

namespace Business.Commands.Degree.DeleteDegree
{
    public class DeleteDegreeValidator : AbstractValidator<DeleteDegreeCommand>
    {
        public DeleteDegreeValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage($"iD is mandatory.");
        }
    }
}
