using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Item, ItemDto>();

            CreateMap<Shopper, ShopperDto>()
                .ForMember(dest => dest.ShoppingList, opt => opt.MapFrom(src => src.ShoppingList));

            CreateMap<ShoppingList, ShoppingListDto>()                
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.ShoppingListItems.Select(sli => sli.Item.ItemName)));
        }
    }
}
