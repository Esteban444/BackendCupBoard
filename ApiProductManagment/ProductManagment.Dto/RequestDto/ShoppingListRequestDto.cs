using System;

namespace ProductManagment.Dto.RequestDto
{
    public class ShoppingListRequestDto
    {
        public Guid IdProduct { get; set; }
        public int? Amount { get; set; }
        public decimal? Value { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
