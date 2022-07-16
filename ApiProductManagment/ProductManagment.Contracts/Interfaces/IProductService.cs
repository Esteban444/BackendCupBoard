using ProductManagment.Dto.RequestDto;
using ProductManagment.Dto.ResponseDto;

namespace ProductManagment.Contracts.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductsResponseDto>> GetProducts();
        Task<ProductsResponseDto> GetProduct(Guid id);
        Task<ProductsResponseDto> CreateProduct(ProductsRequestDto product);
        Task<ProductsResponseDto> UploadProduct(Guid id, ProductsRequestDto product);
        Task<CategoryXProductsResponseDto> UploadCategoryXProduct(Guid idCategory, Guid IdProduct);
        Task<ProductsResponseDto> DeleteProduct(Guid id);
    }
}
