using System;


namespace ProductManagment.Dto.Models
{
    public class CupBoards
    {
        public Guid IdCupBoard { get; set; }
        public string? NameCupBoard { get; set; }
        public bool? IsDefault { get; set; }
        public DateTime? CreationDate { get; set; }

        public ICollection<CupBoardDetails>? CupBoardDetails { get; set; }
        public ICollection<UserXCupBoards>? UserXcupBoards { get; set; }
    }
}
