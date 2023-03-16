using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Model.DTO;

namespace Business.Queries.CV.GetCVs
{
    public class GetCVsHanlder : IRequestHandler<GetCVsQuery, List<CVDTO>>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCVsHanlder(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<CVDTO>> Handle(GetCVsQuery request, CancellationToken cancellationToken)
        {
            var cvs = await _dbContext.CVs.Where(x => request.Id == null || x.Id == request.Id).OrderBy(x => x.FirstName).ThenBy(x => x.LastName).Include("Degree").ToListAsync(cancellationToken);

            foreach(var v in cvs)
            {
                v.Degree = await _dbContext.Degrees.Where(x => x.Id == v.DegreeId).FirstOrDefaultAsync(cancellationToken);
            }


            return _mapper.Map<List<CVDTO>>(cvs);
        }
    }
}
