using AutoMapper;
using Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Model.DTO;

namespace Business.Commands.CV.UpdateCV
{
    public class UpdateCVHandler : IRequestHandler<UpdateCVCommand, CVDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateCVHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CVDTO> Handle(UpdateCVCommand command, CancellationToken cancellationToken)
        {

            Model.Entities.CV item = await _dbContext.CVs.FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

            if (item is null)
                throw new InvalidOperationException($"Couldn't find item with Id: '{command.Id}'");

            item.LastName = command.LastName;
            item.FirstName = command.FirstName;
            item.Email = command.Email;
            item.Mobile = command.Mobile;
            if(command.DegreeId != Guid.Empty)
                item.DegreeId = command.DegreeId;

              
            _dbContext.Update(item);

            await _dbContext.SaveChangesAsync(cancellationToken);

            item = await _dbContext.CVs.Where(x => x.Id == command.Id).FirstOrDefaultAsync(cancellationToken);
            item.Degree = await _dbContext.Degrees.Where(x => x.Id == item.DegreeId).FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<CVDTO>(item);
        }
    }
}
