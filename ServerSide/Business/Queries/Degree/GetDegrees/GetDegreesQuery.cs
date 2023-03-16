using MediatR;
using Model.DTO;

namespace Business.Queries.Degree.GetDegrees
{
    public class GetDegreesQuery : IRequest<List<DegreeDTO>>
    {

    }
}
