using AutoMapper;
using Data;
using MediatR;
using Model.DTO;
using Microsoft.EntityFrameworkCore;

namespace Business.Queries.Degree.GetDegrees
{
    public class GetDegreesHandler : IRequestHandler<GetDegreesQuery, List<DegreeDTO>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDegreesHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<DegreeDTO>> Handle(GetDegreesQuery request, CancellationToken cancellationToken)
        {
            var degrees = await _dbContext.Degrees.OrderBy(x => x.Name).ToListAsync(cancellationToken);
            return _mapper.Map<List<DegreeDTO>>(degrees);
        }
    }
}
