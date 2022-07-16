using ProductManagment.Contracts.Repositories;
using ProductManagment.Dto.Models;
using ProductManagment.Infrastructure.Data;

namespace ProductManagment.Infrastructure.Repositories
{
    public class ShoppingListRepository : BaseRepository<ShoppingLists>, IShoppingListRepository
    {
        public ShoppingListRepository(CupBoardContext context) : base(context)
        {
            
        }
    }
}
