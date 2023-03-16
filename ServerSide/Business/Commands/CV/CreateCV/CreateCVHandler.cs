using AutoMapper;
using Data;
using MediatR;
using Model.DTO;
using Microsoft.EntityFrameworkCore;
using System;

namespace Business.Commands.CV.CreateCV
{
    public class CreateDegreeHandler : IRequestHandler<CreateCVCommand, CVDTO>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateDegreeHandler(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CVDTO> Handle(CreateCVCommand command, CancellationToken cancellationToken)
        {
            Model.Entities.CV newItem = new Model.Entities.CV()
            {
                LastName = command.LastName,
                FirstName = command.FirstName,
                Email = command.Email,
                Mobile = command.Mobile,
                DegreeId = command.DegreeId,
              
            };

            if (command.Blob != null)
            {
                using (var ms = new MemoryStream())
                {
                    using (var stream = command.Blob.OpenReadStream())
                    {
                        await stream.CopyToAsync(ms);
                        newItem.Blob = Convert.ToBase64String(ms.ToArray());
                    }
                }
            }

            await _dbContext.CVs.AddAsync(newItem, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            newItem = await _dbContext.CVs.Where(x => x.Id == newItem.Id).FirstOrDefaultAsync(cancellationToken);
            newItem.Degree = await _dbContext.Degrees.Where(x => x.Id == newItem.DegreeId).FirstOrDefaultAsync(cancellationToken);

            return _mapper.Map<CVDTO>(newItem);
        }
    }
}
