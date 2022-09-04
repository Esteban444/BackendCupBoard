using System;


namespace ProductManagment.Dto.ResponseDto
{
    public class CupBoardResponseDto
    {
        public Guid IdCupBoard { get; set; }
        public string? NameCupBoard { get; set; }
        public bool? IsDefault { get; set; }
        public DateTime? CreationDate { get; set; }

         public List<CupBoardDetailResponseDto>? CupBoardDetails { get; set; }
    }
}
