using AutoMapper;
using repasoFinal2daMesa.DTOS;
using repasoFinal2daMesa.Models;

namespace repasoFinal2daMesa.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SucursalRequest, Sucursales>();
        }
    }
}
