using ProductManagment.Dto.RequestDto;
using ProductManagment.Dto.ResponseDto;

namespace ProductManagment.Contracts.Interfaces
{
    public interface IShoppingListService
    {
        Task <IEnumerable<ShoppingListResponseDto>> GetShoppingLists();
        Task<ShoppingListResponseDto> GetShoppingList(Guid id);
        Task<ShoppingListResponseDto> CreateShoppingList(ShoppingListRequestDto shoppingList);
        Task<ShoppingListResponseDto> UploadShoppingList(Guid id, ShoppingListRequestDto shoppingList);
        Task<ShoppingListResponseDto> UploadUserXShopping(string idUser, Guid idShopping);
        Task<ShoppingListResponseDto> DeleteShoppingList(Guid id);
    }
}
