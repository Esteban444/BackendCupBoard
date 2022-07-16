using System;

namespace ProductManagment.Dto.RequestDto
{
    public class ProductsRequestDto
    {
        public Guid IdMark { get; set; }
        public string? NameProduct { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? BarCode { get; set; }
    }
}
