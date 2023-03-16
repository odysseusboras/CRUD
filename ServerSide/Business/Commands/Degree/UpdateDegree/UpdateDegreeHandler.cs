using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Model.DTO;

namespace Business.Commands.Degree.UpdateDegree
{
    public class UpdateDegreeHandler : IRequestHandler<UpdateDegreeCommand, DegreeDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateDegreeHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<DegreeDTO> Handle(UpdateDegreeCommand command, CancellationToken cancellationToken)
        {

            Model.Entities.Degree item = await _dbContext.Degrees.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

            if (item is null)
                throw new InvalidOperationException($"Couldn't find item with Id: '{command.Id}'");

            item.Name = command.Name;

            _dbContext.Update(item);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<DegreeDTO>(item);
        }
    }
}
