using ProductManagment.Dto.RequestDto;
using ProductManagment.Dto.ResponseDto;

namespace ProductManagment.Contracts.Interfaces
{
    public interface ITrademarkService
    {
        Task <IEnumerable<MarkResponseDto>> GetTrademarks();
        MarkResponseDto GetTrademark(Guid id);
        Task<MarkResponseDto> CreateTrademark(MarkRequestDto trademark);
        Task<MarkResponseDto> UploadTrademark(Guid id, MarkRequestDto trademark);
        Task<MarkResponseDto> DeleteTrademark(Guid id);
    }
}
