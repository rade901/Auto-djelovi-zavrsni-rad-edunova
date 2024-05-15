using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<InsertDto, Dio>();
            CreateMap<UpdateDto, Dio>();
        }
    }
}
