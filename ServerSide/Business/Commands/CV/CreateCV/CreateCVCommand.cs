using MediatR;
using Microsoft.AspNetCore.Http;
using Model.DTO;

namespace Business.Commands.CV.CreateCV
{
    public class CreateCVCommand : IRequest<CVDTO>
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string? Mobile { get; set; }
        public Guid? DegreeId { get; set; }
        public IFormFile? Blob { get; set; }
    }
}
