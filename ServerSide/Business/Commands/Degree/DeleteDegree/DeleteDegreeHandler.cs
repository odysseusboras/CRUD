using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Model.DTO;

namespace Business.Commands.Degree.DeleteDegree
{
    public class DeleteDegreeHandler : IRequestHandler<DeleteDegreeCommand, DegreeDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteDegreeHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<DegreeDTO> Handle(DeleteDegreeCommand command, CancellationToken cancellationToken)
        {

            Model.Entities.Degree item = await _dbContext.Degrees.FindAsync(command.Id, cancellationToken);

            if (item is null)
                throw new InvalidOperationException($"Couldn't find item with Id: '{command.Id}'");

            if(await _dbContext.CVs.AnyAsync(x => x.DegreeId == item.Id, cancellationToken))
            {
                throw new InvalidOperationException($"Yout cannot delete the degree: '{item.Name}' because it is used on CVs");
            }

            _dbContext.Remove(item);

            await _dbContext.SaveChangesAsync(cancellationToken);


            return _mapper.Map<DegreeDTO>(item);
        }
    }
}
