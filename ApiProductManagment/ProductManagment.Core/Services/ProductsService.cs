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
    public class ProductsService : IProductService
    {

        private readonly IProductsRepository _repository;
        //private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryXProductRepository _categoryXProductRepository;
        private readonly IMapper _mapper;

        public ProductsService(IProductsRepository repository, /*ICategoryRepository category,*/ 
                               ICategoryXProductRepository categoryXProductRepository, IMapper mapper
        )
        {
            _repository = repository;
           // _categoryRepository = category;
            _categoryXProductRepository = categoryXProductRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductsResponseDto>> GetProducts()
        {
            var productsDb =  await _repository.GetAll().Include(x => x.Trademark).ToListAsync();
            var productsDto = _mapper.Map<IEnumerable<ProductsResponseDto>>(productsDb);
            return productsDto;
        }

        public async Task<ProductsResponseDto> GetProduct(Guid id)
        {
            var productBd =  await _repository.FindBy(p => p.IdProduct == id).FirstOrDefaultAsync();
            if (productBd == null) throw new GlobalException("Error reading product", HttpStatusCode.NotFound);
            
            return _mapper.Map<ProductsResponseDto>(productBd);
        }

        public async Task<ProductsResponseDto> CreateProduct(ProductsRequestDto product)
        {
            var productDb = _mapper.Map<Products>(product);
            await _repository.Create(productDb);
            var response = _mapper.Map<ProductsResponseDto>(productDb);
            return response;
        }

        public async Task<ProductsResponseDto> UploadProduct(Guid id, ProductsRequestDto RequestProduct)
        {
            var productBd = await _repository.FindBy(p => p.IdProduct == id).FirstOrDefaultAsync();
            if (productBd == null) throw new GlobalException("The product you want to update does not exist in the database.", HttpStatusCode.NotFound);

            _mapper.Map(RequestProduct, productBd);

            await _repository.Upload(productBd);
            var response = _mapper.Map<ProductsResponseDto>(productBd);
            return response;
           
        }

        public async Task<ProductsResponseDto> DeleteProduct(Guid id)
        {
            var product = await _repository.FindBy(p => p.IdProduct == id).FirstOrDefaultAsync();
            if (product == null) throw new GlobalException("The product you want to deleted does not exist in the database.", HttpStatusCode.NotFound);
           
            await _repository.Delete(product);
            var response = _mapper.Map<ProductsResponseDto>(product);
            return response;
            
        }

        public async Task<CategoryXProductsResponseDto> UploadCategoryXProduct(Guid idCategory, Guid idProduct)
        {
            /*var category = _categoryRepository.FindBy(x => x.IdCategory == idCategory).FirstOrDefaultAsync();
            if (category == null) throw new GlobalException("The category does not exist in the database.");

            var product = _repository.FindBy(x => x.IdProduct == idProduct).FirstOrDefaultAsync();
            if (product == null) throw new GlobalException("The product does not exist in the database.");

            var categoryxproduct = new CategoryXproducts()
            {
                IdCategory = category.IdCategory,
                IdProduct = product.IdProduct
            };

            await _categoryXProductRepository.Upload(categoryxproduct);
            var result = _mapper.Map<CategoryXProductsResponseDto>(categoryxproduct);
            return result;*/
            return null;
        }
    }

}
