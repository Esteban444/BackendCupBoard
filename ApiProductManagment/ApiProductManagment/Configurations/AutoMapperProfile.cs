using AutoMapper;
using ProductManagment.Dto.Models;
using ProductManagment.Dto.RequestDto;
using ProductManagment.Dto.ResponseDto;

namespace ApiProductManagment.Configurations
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {

            CreateMap<TradeMarks, MarkRequestDto>().ReverseMap();
            CreateMap<TradeMarks, MarkResponseDto>().ReverseMap();

            CreateMap<ShoppingLists, ShoppingListRequestDto>().ReverseMap();
            CreateMap<ShoppingLists, ShoppingListResponseDto>().ReverseMap();
        }   
    }
}
