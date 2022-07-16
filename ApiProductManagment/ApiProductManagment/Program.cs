using ApiProductManagment.Configurations;
using Microsoft.AspNetCore.Identity;
using ProductManagment.Dto.Models;
using ProductManagment.Infrastructure.Data;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMvc()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDependenceInjectionConfiguration();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<CupBoardContext>().AddDefaultTokenProviders();

builder.Services.Configure<DataProtectionTokenProviderOptions>(opt => opt.TokenLifespan = TimeSpan.FromDays(15));

builder.Services.AddSwagger();

#region Cors
// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("api",
    builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
#endregion

builder.Services.DatabaseConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiProductManagment v1"));


app.UseHttpsRedirection();

app.UseExceptionHandler(HandlingExceptions.UseAPIErrorHandling);

app.UseCors("api");

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
