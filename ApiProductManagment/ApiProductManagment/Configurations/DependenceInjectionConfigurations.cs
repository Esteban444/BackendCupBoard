using ApiProductManagment.Configurations.Validations;
using FluentValidation;
using ProductManagment.Contracts.Interfaces;
using ProductManagment.Contracts.Repositories;
using ProductManagment.Core.Services;
using ProductManagment.Dto.RequestDto;
using ProductManagment.Infrastructure.Repositories;

namespace ApiProductManagment.Configurations
{
    public static class DependenceInjectionConfigurations
    {
        public static IServiceCollection AddDependenceInjectionConfiguration(this IServiceCollection services)
        {
            #region Repositories
            services.AddScoped<IUserRepository, UsersRepository >();
            services.AddScoped<ITrademarkRepository, TradeMarkRepository >();
            services.AddScoped<IProductsRepository, ProductsRepository >();
            services.AddScoped<ICategoryXProductRepository, CategoryXProductRepository >(); 
            services.AddScoped<IUserXShoppingRepository, UserXShoppingRepository >();
            services.AddScoped<IShoppingListRepository, ShoppingListRepository >();
            services.AddScoped<ISettingsRepository, SettingsRepository>();
            #endregion

            #region Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITrademarkService, TrademarkService>();
            services.AddScoped<IProductService, ProductsService>();
            services.AddScoped<IShoppingListService, ShoppingListService>();
            
            
            #endregion Services

            #region Validators
            services.AddScoped<IValidator<MarkRequestDto>, MarkValidations>();
            services.AddScoped<IValidator<ProductsRequestDto>, ProductsValidations>();
            services.AddScoped<IValidator<ShoppingListRequestDto>, ShoppingListValidations>(); 
           
            #endregion Validators


            return services;
        }
    }
}
