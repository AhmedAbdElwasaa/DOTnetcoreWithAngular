using AutoMapper;
using DOTnetcore.Data.Entities;
using DOTnetcore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOTnetcore.Data
{
 
    public class DOTcoreMappingProfile:Profile
    {
        public DOTcoreMappingProfile()
        {
            CreateMap<Order,OrderViewModel>()
                .ForMember(src => src.Id ,dst => dst.MapFrom(src => src.Id))
                .ForMember(src => src.OrderDate,dst => dst.MapFrom(src => src.OrderDate))
                .ForMember(src => src.OrderNumber, dst => dst.MapFrom(src => src.OrderNumber))
                .ForMember(src => src .Items, dst => dst.MapFrom(src => src.Items))
                .ReverseMap();

            CreateMap<OrderItem, OrderItemViewModel>()
                .ReverseMap();
        }
    }
}
