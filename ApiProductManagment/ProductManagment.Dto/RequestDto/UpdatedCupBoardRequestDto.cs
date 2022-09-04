using ProductManagment.Dto.Models;
using System;

namespace ProductManagment.Dto.RequestDto
{
    public class UpdatedCupBoardRequestDto
    {
        public string? NameCupBoard { get; set; }
        public bool? IsDefault { get; set; }
        public DateTime? CreationDate { get; set; }

        //public List<CupBoardDetailRequestDto>? CupBoardDetails { get; set; }
    }
}
