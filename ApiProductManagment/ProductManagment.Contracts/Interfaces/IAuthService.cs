using ProductManagment.Dto.RequestDto;
using ProductManagment.Dto.ResponseDto;

namespace ProductManagment.Contracts.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> LoginUser(LoginRequestDto loginRequest);
        Task<RegisterResponseDto> RegisterUser(RegisterRequestDto registerUser);
    }
}
