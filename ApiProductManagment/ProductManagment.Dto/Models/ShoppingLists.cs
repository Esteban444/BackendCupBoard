using System;


namespace ProductManagment.Dto.Models
{
    public class ShoppingLists 
    {
        public Guid IdShopping { get; set; }
        public Guid IdProduct { get; set; }
        public int? Amount { get; set; }
        public decimal? Value { get; set; }
        public DateTime? ExpirationDate { get; set; }

        public Products? Product { get; set; }
        public ICollection<UsersXShoppingLists>? UserXshoppingLists { get; set; }
    }
}
