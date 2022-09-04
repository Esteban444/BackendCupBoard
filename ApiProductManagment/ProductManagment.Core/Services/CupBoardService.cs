using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductManagment.Contracts.Interfaces;
using ProductManagment.Contracts.Repositories;
using ProductManagment.Dto.Models;
using ProductManagment.Dto.RequestDto;
using ProductManagment.Dto.ResponseDto;
using ProductManagment.Infrastructure.Data;
using System.Net;

namespace ProductManagment.Core.Services
{
    public class CupBoardService : ICupBoardService
    {
        private readonly ICupBoardRepository _cupBoardRepository;
        private readonly IMapper _mapper;
        private readonly CupBoardContext _cupBoardContext;
        public CupBoardService(ICupBoardRepository cupBoardRepository, IMapper mapper, CupBoardContext cupBoardContext)
        {
            _cupBoardRepository = cupBoardRepository;
            _mapper = mapper;
            _cupBoardContext = cupBoardContext;
        }
        public async Task<IEnumerable<CupBoardResponseDto>> GetCupBoards()
        {
            var result = await _cupBoardRepository.GetAll().Include(x => x.CupBoardDetails).ToListAsync();
            var response = _mapper.Map<IEnumerable<CupBoardResponseDto>>(result);
            return response;
        }
        public async Task<CupBoardResponseDto> GetCupBoard(Guid id)
        {
            var result = await _cupBoardRepository.FindBy(c => c.IdCupBoard == id).Include(x => x.CupBoardDetails).FirstOrDefaultAsync();
            if (result == null) throw new GlobalException("Error reading cupboard", HttpStatusCode.NotFound);

            return _mapper.Map<CupBoardResponseDto>(result);
        }

        public async Task<CupBoardResponseDto> CreateCupBoard(CupBoardRequestDto cupBoard) 
        {
            using var transaction = _cupBoardContext.Database.BeginTransaction();

            var tableCupBoard = new CupBoards();
            try
            {
                tableCupBoard = _mapper.Map<CupBoards>(cupBoard); ; 
                 _cupBoardContext.CupBoards!.Add(tableCupBoard);
                _cupBoardContext.SaveChanges();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Changes were not saved.", ex);
            }

            var response = _mapper.Map<CupBoardResponseDto>(tableCupBoard);
            return response;
        }

        public async Task<CupBoardResponseDto> UploadCupBoard(Guid id, UpdatedCupBoardRequestDto cupBoard)
        {
            var cupboard = await _cupBoardRepository.FindBy(t => t.IdCupBoard == id).FirstOrDefaultAsync();
            if (cupboard == null) throw new GlobalException("Error editing cupboard", HttpStatusCode.NotFound);

            var updated  = _mapper.Map(cupBoard, cupboard);
            await _cupBoardRepository.Upload(updated);
            var response = _mapper.Map<CupBoardResponseDto>(updated);
            return response;
        }

        public async Task<CupBoardResponseDto> DeleteCupBoard(Guid id)
        {
            var cupboard = await _cupBoardRepository.FindBy(t => t.IdCupBoard == id).FirstOrDefaultAsync();
            if (cupboard == null) throw new GlobalException("Error deleting cupboard", HttpStatusCode.NotFound);

            await _cupBoardRepository.Delete(cupboard);
            var response = _mapper.Map<CupBoardResponseDto>(cupboard);
            return response;
        }
    }
}
