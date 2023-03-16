using MediatR;
using Microsoft.AspNetCore.Http;
using Model.DTO;

namespace Business.Commands.CV.UpdateCV
{
    public class UpdateCVCommand : IRequest<CVDTO>
    {
        public Guid Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string? Mobile { get; set; }
        public Guid? DegreeId { get; set; }
    }
}
