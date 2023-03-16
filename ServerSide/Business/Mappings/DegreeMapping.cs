using AutoMapper;
using Model.DTO;
using Model.Entities;

namespace Business.Mappings
{
    public class DegreeMapping : Profile
    {
        public DegreeMapping()
        {
            CreateMap<Degree, DegreeDTO>();
        }
    }
}
