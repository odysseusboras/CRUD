using FluentValidation;

namespace Business.Commands.CV.DeleteCV
{
    public class DeleteCVValidator : AbstractValidator<DeleteCVCommand>
    {
        public DeleteCVValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage($"iD is mandatory.");
        }
    }
}
