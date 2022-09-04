using ProductManagment.Dto.RequestDto;
using ProductManagment.Dto.ResponseDto;
using System.Threading.Tasks;

namespace ProductManagment.Contracts.Interfaces
{
    public interface ICupBoardService 
    {
        Task<IEnumerable<CupBoardResponseDto>> GetCupBoards();
        Task<CupBoardResponseDto> GetCupBoard(Guid id);
        Task<CupBoardResponseDto> CreateCupBoard(CupBoardRequestDto cupBoard);
        Task<CupBoardResponseDto> UploadCupBoard(Guid id, UpdatedCupBoardRequestDto cupBoard);
        Task<CupBoardResponseDto> DeleteCupBoard(Guid id);  
    }
}
