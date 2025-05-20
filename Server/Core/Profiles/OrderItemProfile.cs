using System.Linq;
using AutoMapper;
using Core.Transports.OrderItems;
using EF.Models.Models;

namespace Core.Profiles;

public class OrderItemProfile : Profile
{
    public OrderItemProfile()
    {
        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(dest => dest.OrderId, opt => opt
                .MapFrom(src => src.OrderId))
            .ForMember(dest => dest.Quantity, opt => opt
                .MapFrom(src => src.Quantity))
            .ForMember(dest => dest.Price, opt => opt
                .MapFrom(src => src.Price));
    }
}