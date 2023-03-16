using AutoMapper;
using Data;
using MediatR;
using Model.DTO;

namespace Business.Commands.Degree.CreateDegree
{
    public class CreateDegreeHandler : IRequestHandler<CreateDegreeCommand, DegreeDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateDegreeHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<DegreeDTO> Handle(CreateDegreeCommand command, CancellationToken cancellationToken)
        {
            Model.Entities.Degree newItem = new Model.Entities.Degree()
            {
                Name = command.Name
            };

            await _dbContext.Degrees.AddAsync(newItem, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DegreeDTO>(newItem);
        }
    }
}
