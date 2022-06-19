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
            services.AddScoped<ITrademarkRepository, TradeMarkRepository >();

            #endregion

            #region Services
            services.AddScoped<ITrademarkService, TrademarkService>();
            
            
            #endregion End Services

            #region Validators
            services.AddScoped<IValidator<MarkRequestDto>, MarkValidations>();
           
            #endregion Validators


            return services;
        }
    }
}
