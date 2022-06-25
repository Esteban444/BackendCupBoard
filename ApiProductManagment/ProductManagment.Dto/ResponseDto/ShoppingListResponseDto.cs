using System;

namespace ProductManagment.Dto.ResponseDto
{
    public class ShoppingListResponseDto
    {
        public Guid IdShopping { get; set; }
        public Guid IdProduct { get; set; }
        public int? Amount { get; set; }
        public decimal? Value { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
