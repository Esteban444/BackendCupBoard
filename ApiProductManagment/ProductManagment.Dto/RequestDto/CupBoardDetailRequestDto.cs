using System;


namespace ProductManagment.Dto.RequestDto
{
    public class CupBoardDetailRequestDto 
    {
        public Guid? IdProduct { get; set; }
        public int? Amount { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? ExitDate { get; set; }
        public DateTime? ExpirationDate { get; set; }

    }
}
