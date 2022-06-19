using System;


namespace ProductManagment.Dto.Models
{
    public class UserXCupBoards 
    {
        public Guid IdUserXCupBoard { get; set; }
        public string? IdUser { get; set; }
        public Guid IdCupBoard { get; set; }

        public CupBoards? CupBoard { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
