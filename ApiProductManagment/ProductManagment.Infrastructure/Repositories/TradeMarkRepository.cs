using ProductManagment.Contracts.Repositories;
using ProductManagment.Dto.Models;
using ProductManagment.Infrastructure.Data;

namespace ProductManagment.Infrastructure.Repositories
{
    public class TradeMarkRepository : BaseRepository<TradeMarks>, ITrademarkRepository
    {
        public CupBoardContext CupboardContext { get; set; }

        public TradeMarkRepository(CupBoardContext context) : base(context)
        {
            CupboardContext = context;
        }
    }

}
