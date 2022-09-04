using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagment.Contracts.Interfaces;
using ProductManagment.Dto.RequestDto;
using ProductManagment.Dto.ResponseDto;

namespace ApiProductManagment.Controllers
{
    [Route("api/marks")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TrademarksController : ControllerBase
    {

        private readonly ITrademarkService _trademarkService;
        private readonly IMapper _mapper;

        public TrademarksController(ITrademarkService trademarkservice, IMapper mapper)
        {
            _trademarkService = trademarkservice;
            _mapper = mapper;
        }

        [HttpGet("all-marks")]
        [ProducesResponseType(typeof(MarkResponseDto), 200)]
        [ProducesResponseType(typeof(MarkResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> Get()
        {
            var trademarks = await _trademarkService.GetTrademarks();
            return Ok(trademarks);
        }

        [HttpGet("mark-by/{id}")]
        [ProducesResponseType(typeof(MarkResponseDto), 200)]
        [ProducesResponseType(typeof(MarkResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> GetCategory(Guid id)
        {
           var mark =  await _trademarkService.GetTrademark(id);
           return Ok(mark);
        }

        [HttpPost("mark")]
        [ProducesResponseType(typeof(MarkResponseDto), 200)]
        [ProducesResponseType(typeof(MarkResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> Post(MarkRequestDto trademark)
        {
            var resultrademark = await _trademarkService.CreateTrademark(trademark);
            return Ok(resultrademark);
        }

        [HttpPut("update-mark-by/{id}")]
        [ProducesResponseType(typeof(MarkResponseDto), 200)]
        [ProducesResponseType(typeof(MarkResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> Put(Guid id, MarkRequestDto trademark)
        {
            var trademarkresult = await _trademarkService.UploadTrademark(id, trademark);
            return Ok(trademarkresult);
        }

        [HttpDelete("delete-mark-by/{id}")]
        [ProducesResponseType(typeof(MarkResponseDto), 200)]
        [ProducesResponseType(typeof(MarkResponseDto), 400)]
        [ProducesResponseType(typeof(FailedOperationResultDto), 404)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _trademarkService.DeleteTrademark(id);
            return Ok(response);
        }
    }
}
