using ProductManagment.Contracts.Repositories;
using ProductManagment.Dto.Models;
using ProductManagment.Infrastructure.Data;

namespace ProductManagment.Infrastructure.Repositories
{
    public class UserXShoppingRepository : BaseRepository<UsersXShoppingLists>, IUserXShoppingRepository
    {
        public UserXShoppingRepository(CupBoardContext context) : base(context)
        {
        }
    }

}
