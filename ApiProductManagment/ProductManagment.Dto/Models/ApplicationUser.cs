using Microsoft.AspNetCore.Identity;
using System;

namespace ProductManagment.Dto.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string? Names { get; set; } 
        public string? LastNames { get; set; }  


        public ICollection<UserXCupBoards>? UserXcupBoards { get; set; }
        public ICollection<UsersXShoppingLists>? UserXshoppingLists { get; set; }
    }
}
