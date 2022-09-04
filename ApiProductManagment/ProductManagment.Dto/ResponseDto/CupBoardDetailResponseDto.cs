using System;

namespace ProductManagment.Dto.ResponseDto
{
    public class CupBoardDetailResponseDto
    {
        public Guid IdCupboardDetail { get; set; }
        public Guid? IdCupBoard { get; set; }
        public Guid? IdProduct { get; set; }
        public int? Amount { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? ExitDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
    }
}
