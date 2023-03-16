using MediatR;
using Model.DTO;

namespace Business.Queries.CV.GetCVs
{
    public class GetCVsQuery : IRequest<List<CVDTO>>
    {
        public Guid? Id { get; set; }
    }
}
