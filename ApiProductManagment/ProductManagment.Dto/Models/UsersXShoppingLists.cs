using System;


namespace ProductManagment.Dto.Models
{
    public class UsersXShoppingLists
    {
        public Guid IdUserXshopping { get; set; }
        public string? IdUser { get; set; }
        public Guid IdShopping { get; set; }

        public ShoppingLists? Shopping { get; set; }

        public ApplicationUser? User { get; set; }
    }
}
