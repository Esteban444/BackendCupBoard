using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductManagment.Contracts.Interfaces;
using ProductManagment.Contracts.Repositories;
using ProductManagment.Dto.Models;
using ProductManagment.Dto.RequestDto;
using ProductManagment.Dto.ResponseDto;

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


        public MarkResponseDto GetTrademark(Guid id)
        {
            var trademarkdb = _repository.QueryById(c => c.IdTrademark == id);
            if (trademarkdb != null)
            {
                return _mapper.Map<MarkResponseDto>(trademarkdb);
            }
            throw new Exception("Error reading Trademark");
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
            var trademarkdb = _repository.QueryById(t => t.IdTrademark == id);
            if (trademarkdb != null)
            {
                trademarkdb.Mark = trademark.Mark;
                // var uptrademark = _mapper.Map<Trademark>(trademark);
                await _repository.Upload(trademarkdb);
                var response = _mapper.Map<MarkResponseDto>(trademarkdb);
                return response;
            }
            else
            {
                throw new Exception("Error editing Trademark");
            }
        }


        public async Task<MarkResponseDto> DeleteTrademark(Guid id)
        {
            var trademarkDb = _repository.QueryById(t => t.IdTrademark == id);
            if (trademarkDb != null)
            {
                await _repository.Delete(trademarkDb);
                var response = _mapper.Map<MarkResponseDto>(trademarkDb);
                return response;
            }
            else
            {
                throw new Exception("Error deleting Trademark");
            }
        }
    }
}
