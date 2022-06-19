using System;

namespace ProductManagment.Dto.Models
{
    public class CategoryXProducts
    {
        public Guid IdCategoryXproduct { get; set; }
        public Guid IdCategory { get; set; }
        public Guid IdProduct { get; set; }

        public Categories? Category { get; set; }

        public Products? Product { get; set; }
    }
}
