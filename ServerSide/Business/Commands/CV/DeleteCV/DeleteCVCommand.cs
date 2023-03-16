using MediatR;
using Model.DTO;

namespace Business.Commands.CV.DeleteCV
{
    public class DeleteCVCommand : IRequest<CVDTO>
    {
        public Guid Id { get; set; }
    }
}
