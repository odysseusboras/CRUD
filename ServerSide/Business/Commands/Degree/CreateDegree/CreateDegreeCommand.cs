using MediatR;
using Model.DTO;

namespace Business.Commands.Degree.CreateDegree
{
    public class CreateDegreeCommand : IRequest<DegreeDTO>
    {
        public string Name { get; set; }
    }
}
