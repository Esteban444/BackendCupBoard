using ProductManagment.Contracts.Repositories;
using ProductManagment.Dto.Models;
using ProductManagment.Infrastructure.Data;

namespace ProductManagment.Infrastructure.Repositories
{
    public class CupBoardDetailRepository : BaseRepository<CupBoardDetails>, ICupBoardDetailRepository
    {
        public CupBoardDetailRepository(CupBoardContext context) : base(context)
        {

        }
    }

}
