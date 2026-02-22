using core.Dto;
using core.Entities;
using StackExchange.Redis;
using System.Net;

namespace api.mapping
{
    public class ordermapping : AutoMapper.Profile
    {
        public ordermapping() {
            CreateMap<orders, orderToReturn>()
   .ForMember(dest => dest.deliveryMethod, opt => opt.MapFrom(src => src.deliveryMethod));
            CreateMap<orderitem, orderitemDto>().ReverseMap();
            CreateMap<shoppingAddress, ShipaddressDto>().ReverseMap();

            
           CreateMap<Address, ShipaddressDto>()
              
               .ReverseMap();
        }
    }
}
