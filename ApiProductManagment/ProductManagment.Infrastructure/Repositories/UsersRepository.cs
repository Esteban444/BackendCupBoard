using ProductManagment.Contracts.Repositories;
using ProductManagment.Dto.Models;
using ProductManagment.Infrastructure.Data;

namespace ProductManagment.Infrastructure.Repositories
{
    public class UsersRepository : BaseRepository<ApplicationUser>, IUserRepository
    {
        public UsersRepository(CupBoardContext context) : base(context)
        {
        }
    }

}
