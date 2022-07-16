using System;

namespace ProductManagment.Dto.ResponseDto
{
    public class ProductsResponseDto
    {
        public Guid IdProduct { get; set; }
        public Guid IdMark { get; set; }
        public string? NameProduct { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? BarCode { get; set; }
    }
}
