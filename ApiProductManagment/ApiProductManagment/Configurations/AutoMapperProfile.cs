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
            CreateMap<ApplicationUser, RegisterRequestDto>().ReverseMap();

            CreateMap<CupBoards, CupBoardRequestDto>().ReverseMap();
            CreateMap<CupBoards, CupBoardResponseDto>().ReverseMap();
            //.ForMember(x => x.CupBoardDetails, o => o.MapFrom(y => y.CupBoardDetails));

            CreateMap<CupBoardDetails, CupBoardDetailRequestDto>().ReverseMap();
            CreateMap<CupBoardDetails, CupBoardDetailResponseDto>().ReverseMap();

            CreateMap<TradeMarks, MarkRequestDto>().ReverseMap();
            CreateMap<TradeMarks, MarkResponseDto>().ReverseMap();

            CreateMap<Products, ProductsRequestDto>().ReverseMap();
            CreateMap<Products, ProductsResponseDto>().ReverseMap();

            CreateMap<ShoppingLists, ShoppingListRequestDto>().ReverseMap();
            CreateMap<ShoppingLists, ShoppingListResponseDto>().ReverseMap();
        }   
    }
}
