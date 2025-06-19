using System.Linq;
using AutoMapper;
using Core.Transports.ExtraToppings;
using Core.Transports.Pizzas;
using EF.Models.Models;
using Microsoft.EntityFrameworkCore;


namespace Core.Profiles;

public class ExtraToppingsProfile : Profile
{
    public ExtraToppingsProfile()
    {
        CreateMap<ExtraTopping, ExtraToppingDto>()
            .ForMember(dest => dest.Id, opt => opt
                .MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt
                .MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt
                .MapFrom(src => src.Description))
            .ForMember(dest => dest.Price, opt => opt
                .MapFrom(src => src.Price))
            .ForMember(dest => dest.IsVegetarian, opt => opt
                .MapFrom(src => src.IsVegetarian))
            .ForMember(dest => dest.IsVegan, opt => opt
                .MapFrom(src => src.IsVegan))
            .ForMember(dest => dest.IsAvailable, opt => opt
                .MapFrom(src => src.IsAvailable));
    }
}