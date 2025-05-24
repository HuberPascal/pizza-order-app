using System.Linq;
using AutoMapper;
using Core.Transports.Orders;
using EF.Models.Models;

namespace Core.Profiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.OrderStatus, opt => opt
                .MapFrom(src => src.OrderStatus));
    }
}