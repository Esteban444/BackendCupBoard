using ProductManagment.Contracts.Repositories;
using ProductManagment.Dto.Models;
using ProductManagment.Infrastructure.Data;

namespace ProductManagment.Infrastructure.Repositories
{
    public class CategoryXProductRepository : BaseRepository<CategoryXProducts>, ICategoryXProductRepository
    {
        public CategoryXProductRepository(CupBoardContext context) : base(context)
        {

        }
    }

}
