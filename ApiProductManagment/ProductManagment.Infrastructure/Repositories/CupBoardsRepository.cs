using ProductManagment.Contracts.Repositories;
using ProductManagment.Dto.Models;
using ProductManagment.Infrastructure.Data;

namespace ProductManagment.Infrastructure.Repositories
{
    public class CupBoardsRepository : BaseRepository<CupBoards>, ICupBoardRepository 
    {
        public CupBoardsRepository(CupBoardContext context) : base(context) 
        {

        }
    }

}
