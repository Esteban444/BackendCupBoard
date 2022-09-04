using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagment.Contracts.Interfaces;
using ProductManagment.Dto.RequestDto;
using ProductManagment.Dto.ResponseDto;

namespace ApiProductManagment.Controllers
{
    [Route("api/cupboars")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CupBoardsController : ControllerBase
    {
        private readonly ICupBoardService _cupboardService;
        public CupBoardsController(ICupBoardService cupboardService)
        {
           _cupboardService = cupboardService; 
        }

        [HttpGet("all-cupboards")]
        [ProducesResponseType(typeof(CupBoardResponseDto), 200)]
        [ProducesResponseType(typeof(CupBoardResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> Get()
        {
            var cupBoards = await _cupboardService.GetCupBoards();
            return Ok(cupBoards);
        }

        [HttpGet("cupboard-by/{id}")]
        [ProducesResponseType(typeof(CupBoardResponseDto), 200)]
        [ProducesResponseType(typeof(CupBoardResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> GetCupBoard(Guid id)
        {
            var response = await _cupboardService.GetCupBoard(id);
            return Ok(response);
        }

        [HttpPost("cupboard")]
        [ProducesResponseType(typeof(CupBoardResponseDto), 200)]
        [ProducesResponseType(typeof(CupBoardResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> AddAsync(CupBoardRequestDto cupBoard)
        {
            var result = await _cupboardService.CreateCupBoard(cupBoard);
            return Ok(result);
        }

        [HttpPut("update-cupboard-by/{id}")]
        [ProducesResponseType(typeof(CupBoardResponseDto), 200)]
        [ProducesResponseType(typeof(CupBoardResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> UpdateCupBoard(Guid id, UpdatedCupBoardRequestDto cupBoard)
        {
            var response = await _cupboardService.UploadCupBoard(id, cupBoard);
            return Ok(response);
        }

        [HttpDelete("delete-cupboard-by/{id}")]
        [ProducesResponseType(typeof(CupBoardResponseDto), 200)]
        [ProducesResponseType(typeof(CupBoardResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _cupboardService.DeleteCupBoard(id);
            return Ok(response);
        }
    }
}
