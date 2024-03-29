﻿using ProductManagment.Contracts.Repositories;
using ProductManagment.Dto.Models;
using ProductManagment.Infrastructure.Data;

namespace ProductManagment.Infrastructure.Repositories
{
    public class TradeMarkRepository : BaseRepository<TradeMarks>, ITrademarkRepository
    {
        public TradeMarkRepository(CupBoardContext context) : base(context)
        {
            
        }
    }

}
