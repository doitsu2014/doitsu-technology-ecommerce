using AutoMapper;
using HatDieu.ApplicationCore.Domains;
using HatDieu.Infrastructure.PayrixGateway.PayrixGatewayModels;

namespace HatDieu.Infrastructure.PayrixGateway;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<PayrixEntityResponseModel, PayrixEntity>()
            .ForMember(d => d.Frozen, opt => opt.MapFrom(s => s.Frozen == 1))
            .ForMember(d => d.Reserved, opt => opt.MapFrom(s => s.Reserved == 1))
            .ForMember(d => d.Public, opt => opt.MapFrom(s => s.Public == 1))
            ;
    }
}