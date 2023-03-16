using MediatR;
using Model.DTO;

namespace Business.Commands.Degree.UpdateDegree
{
    public class UpdateDegreeCommand : IRequest<DegreeDTO>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
