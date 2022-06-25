using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductManagment.Contracts.Interfaces;
using ProductManagment.Contracts.Repositories;
using ProductManagment.Dto.Models;
using ProductManagment.Dto.RequestDto;
using ProductManagment.Dto.ResponseDto;
using System.Net;

namespace ProductManagment.Core.Services
{
    public class ShoppingListService : IShoppingListService
    {
        private readonly IShoppingListRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IUserXShoppingRepository _userXShoppingRepository;
        private readonly IMapper _mapper;

        public ShoppingListService(IShoppingListRepository repository,
                                    IUserRepository userRepository, IUserXShoppingRepository userXShoppingRepository,
                                    IMapper mapper
        )
        {
            _repository = repository;
            _userRepository = userRepository;
            _userXShoppingRepository = userXShoppingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ShoppingListResponseDto>> GetShoppingLists()
        {
            var shoppingListsDb = await _repository.GetAll().Include(x => x.Product).ToListAsync();
            var shoppingListsDto = _mapper.Map<IEnumerable<ShoppingListResponseDto>>(shoppingListsDb);
            return shoppingListsDto;
        }

        public async Task<ShoppingListResponseDto> GetShoppingList(Guid id)
        {
            var shoppingListDb = await _repository.FindBy(s => s.IdShopping == id).FirstOrDefaultAsync();
            if (shoppingListDb == null) throw new GlobalException("Error reading shopping List", HttpStatusCode.NotFound);
            
            return _mapper.Map<ShoppingListResponseDto>(shoppingListDb);
        }

        public async Task<ShoppingListResponseDto> CreateShoppingList(ShoppingListRequestDto shoppingList)
        {
            var ShoppingListDb = _mapper.Map<ShoppingLists>(shoppingList);
            await _repository.Create(ShoppingListDb);
            var response = _mapper.Map<ShoppingListResponseDto>(ShoppingListDb);
            return response;
        }

        public async Task<ShoppingListResponseDto> UploadShoppingList(Guid id, ShoppingListRequestDto shoppingList)
        {
            var shoppingListDb = await _repository.FindBy(s => s.IdShopping == id).FirstOrDefaultAsync();
            if (shoppingListDb == null) throw new GlobalException("Error editing ShoppingList", HttpStatusCode.NotFound);
            
                // Si la propiedad va nula
                shoppingListDb.IdProduct = shoppingList.IdProduct;
                shoppingListDb.Amount = shoppingList.Amount ?? shoppingListDb.Amount;
                shoppingListDb.Value = shoppingList.Value ?? shoppingListDb.Value;
                shoppingListDb.ExpirationDate = shoppingList.ExpirationDate ?? shoppingListDb.ExpirationDate;

                await _repository.Upload(shoppingListDb);
                var response = _mapper.Map<ShoppingListResponseDto>(shoppingListDb);
                return response;
        }


        public async Task<ShoppingListResponseDto> DeleteShoppingList(Guid id)
        {
            var shoppingListDB = await _repository.FindBy(s => s.IdShopping == id).FirstOrDefaultAsync();
            if (shoppingListDB == null) throw new GlobalException("Error delete shopping list", HttpStatusCode.NotFound);
            
                await _repository.Delete(shoppingListDB);
                var response = _mapper.Map<ShoppingListResponseDto>(shoppingListDB);
                return response;
        }

        public async Task<ShoppingListResponseDto> UploadUserXShopping(string idUser, Guid idShopping)
        {
            var shopping = await _repository.FindBy(x => x.IdShopping == idShopping).FirstOrDefaultAsync();
            if (shopping == null) throw new GlobalException("El shoppingList no existe.", HttpStatusCode.NotFound);

            var user =  await _userRepository.FindBy(x => x.Id == idUser).FirstOrDefaultAsync();
            if (user == null) throw new GlobalException("El User no existe.", HttpStatusCode.NotFound);

            var userxshopping = new UsersXShoppingLists()
            {
                IdUser = user.Id,
                IdShopping = shopping.IdShopping
            };

            await _userXShoppingRepository.Upload(userxshopping);
            var result = _mapper.Map<ShoppingListResponseDto>(userxshopping);
            return result;
        }
    }

}
