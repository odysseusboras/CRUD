using AutoMapper;
using Data;
using MediatR;
using Model.DTO;

namespace Business.Commands.CV.DeleteCV
{
    public class DeleteCVHandler : IRequestHandler<DeleteCVCommand, CVDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public DeleteCVHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CVDTO> Handle(DeleteCVCommand command, CancellationToken cancellationToken)
        {

            Model.Entities.CV item = await _dbContext.CVs.FindAsync(command.Id, cancellationToken);

            if (item is null)
                throw new InvalidOperationException($"Couldn't find item with Id: '{command.Id}'");

            _dbContext.Remove(item);

            await _dbContext.SaveChangesAsync(cancellationToken);


            return _mapper.Map<CVDTO>(item);
        }
    }
}
