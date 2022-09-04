using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagment.Contracts.Interfaces;
using ProductManagment.Dto.RequestDto;
using ProductManagment.Dto.ResponseDto;

namespace ApiProductManagment.Controllers
{
    [Route("api/ShoppingLists")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ShoppingListsController : ControllerBase
    {
        private readonly IShoppingListService _shoppingkService;

        public ShoppingListsController(IShoppingListService shoppingService)
        {
            _shoppingkService = shoppingService;
        }

        [HttpGet("all-shopping-list")]
        [ProducesResponseType(typeof(ShoppingListResponseDto), 200)]
        [ProducesResponseType(typeof(ShoppingListResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> GetShoppingList()
        {
            var shoppingLists = await _shoppingkService.GetShoppingLists();
            return Ok(shoppingLists);
        }

        [HttpGet("shopping-list-by/{id}")]
        [ProducesResponseType(typeof(ShoppingListResponseDto), 200)]
        [ProducesResponseType(typeof(ShoppingListResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> GetShoppinsList(Guid id)
        {
            var list =  await _shoppingkService.GetShoppingList(id);
            return Ok(list);
        }

        [HttpPost("shopping-list")]
        [ProducesResponseType(typeof(ShoppingListResponseDto), 200)]
        [ProducesResponseType(typeof(ShoppingListResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> AddAsync(ShoppingListRequestDto shoppingList) 
        {
            var shoppingListresult = await _shoppingkService.CreateShoppingList(shoppingList);
            return Ok(shoppingListresult);
        }

        [HttpPut("updated-shopping-list-by/{id}")]
        [ProducesResponseType(typeof(ShoppingListResponseDto), 200)]
        [ProducesResponseType(typeof(ShoppingListResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdatedShoppingList(Guid id, ShoppingListRequestDto shoppingList)
        {
            var shoppingListresult = await _shoppingkService.UploadShoppingList(id, shoppingList);
            return Ok(shoppingListresult); ;
        }

        [HttpPut("assign-User-shopping")]
        public async Task<IActionResult> UpdateUserXShopping(string idUser, Guid idShopping)
        {
            var result = await _shoppingkService.UploadUserXShopping(idUser, idShopping);
            return Ok(result);
        }

        [HttpDelete("delete-shopping-list-by/{id}")]
        [ProducesResponseType(typeof(ShoppingListResponseDto), 200)]
        [ProducesResponseType(typeof(ShoppingListResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _shoppingkService.DeleteShoppingList(id);
            return Ok(response);
        }
    }
}

