using System.Linq;
using AutoMapper;
using Core.Transports.Pizzas;
using EF.Models.Models;
using Microsoft.EntityFrameworkCore;


namespace Core.Profiles;

public class PizzaProfile : Profile
{
    public PizzaProfile()
    {
        CreateMap<Pizza, PizzaDto>()
            .ForMember(dest => dest.Id, opt => opt
                .MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt
                .MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt
                .MapFrom(src => src.Description))
            .ForMember(dest => dest.Price, opt => opt
                .MapFrom(src => src.Price))
            .ForMember(dest => dest.ImageUrl, opt => opt
                .MapFrom(src => src.ImageUrl))
            .ForMember(dest => dest.IsVegetarian, opt => opt
                .MapFrom(src => src.IsVegetarian))
            .ForMember(dest => dest.IsVegan, opt => opt
                .MapFrom(src => src.IsVegan))
            .ForMember(dest => dest.IsAvailable, opt => opt
                .MapFrom(src => src.IsAvailable));
    }
}