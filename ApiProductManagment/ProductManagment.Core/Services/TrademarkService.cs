using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductManagment.Contracts.Interfaces;
using ProductManagment.Contracts.Repositories;
using ProductManagment.Dto.Models;
using ProductManagment.Dto.RequestDto;
using ProductManagment.Dto.ResponseDto;
using System.Net;

namespace ProductManagment.Core.Services
{
    public class TrademarkService : ITrademarkService
    {
        private readonly ITrademarkRepository _repository;
        private readonly IMapper _mapper;

        public TrademarkService(ITrademarkRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<IEnumerable<MarkResponseDto>> GetTrademarks()
        {
            var trademarks =  await _repository.GetAll().ToListAsync();
            var trademarksDto = _mapper.Map<IEnumerable<MarkResponseDto>>(trademarks);
            return trademarksDto;
        }


        public async Task< MarkResponseDto> GetTrademark(Guid id)
        {
            var trademarkdb =  await _repository.FindBy(c => c.IdTrademark == id).FirstOrDefaultAsync();
            if (trademarkdb == null) throw new GlobalException("Error reading Trademark", HttpStatusCode.NotFound);
            
            return _mapper.Map<MarkResponseDto>(trademarkdb);
        }


        public async Task<MarkResponseDto> CreateTrademark(MarkRequestDto trademark)
        {
            var newtrademark = _mapper.Map<TradeMarks>(trademark);
            await _repository.Create(newtrademark);
            var response = _mapper.Map<MarkResponseDto>(newtrademark);
            return response;
        }


        public async Task<MarkResponseDto> UploadTrademark(Guid id, MarkRequestDto trademark)
        {
            var trademarkdb = await _repository.FindBy(t => t.IdTrademark == id).FirstOrDefaultAsync();
            if (trademarkdb == null) throw new GlobalException("Error editing Trademark", HttpStatusCode.NotFound);
            
            trademarkdb.Mark = trademark.Mark;
            await _repository.Upload(trademarkdb);
            var response = _mapper.Map<MarkResponseDto>(trademarkdb);
            return response;
        }


        public async Task<MarkResponseDto> DeleteTrademark(Guid id)
        {
            var trademarkDb =  await _repository.FindBy(t => t.IdTrademark == id).FirstOrDefaultAsync();
            if (trademarkDb == null) throw new GlobalException("Error deleting Trademark", HttpStatusCode.NotFound);
            
            await _repository.Delete(trademarkDb);
            var response = _mapper.Map<MarkResponseDto>(trademarkDb);
            return response;
        }
    }
}
