using System;

namespace ProductManagment.Dto.ResponseDto
{
    public class RegisterResponseDto
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
    }
}
