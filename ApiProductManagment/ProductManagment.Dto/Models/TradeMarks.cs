using System;

namespace ProductManagment.Dto.Models
{
    public class TradeMarks
    {
        public Guid IdTrademark { get; set; }
        public string? Mark { get; set; }

        public ICollection<Products>? Products { get; set; }
    }
}
