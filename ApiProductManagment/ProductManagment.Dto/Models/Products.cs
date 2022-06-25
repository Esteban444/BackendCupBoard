using System;


namespace ProductManagment.Dto.Models
{
    public class Products
    {
        public Guid IdProduct { get; set; }
        public Guid IdMark { get; set; }
        public string? NameProduct { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string? BarCode { get; set; }
        public TradeMarks? Trademark { get; set; }

        public ICollection<CategoryXProducts>? CategoriesXproducts { get; set; }
        public ICollection<CupBoardDetails>? CupBoardDetails { get; set; }
        public ICollection<ShoppingLists>? ShoppingLists { get; set; }
    }
}
