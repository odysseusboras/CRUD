using AutoMapper;
using Microsoft.Data.SqlClient;
using Model.DTO;
using Model.Entities;

namespace Business.Mappings
{
    public class CVDTOMapping : Profile
    {
        public CVDTOMapping()
        {
            CreateMap<CV, CVDTO>()
                .ForMember(dest => dest.DegreeName, opt => opt.MapFrom((src, dest) =>
                {
                    return src.Degree?.Name;
                }))
                .ForMember(dest => dest.HasBlob, opt => opt.MapFrom((src, dest) =>
                {
                    return src.Blob != null;
                }));
        }
    }
}
