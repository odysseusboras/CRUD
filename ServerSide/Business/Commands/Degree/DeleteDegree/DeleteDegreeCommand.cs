using MediatR;
using Model.DTO;

namespace Business.Commands.Degree.DeleteDegree
{
    public class DeleteDegreeCommand : IRequest<DegreeDTO>
    {
        public Guid Id { get; set; }
    }
}
