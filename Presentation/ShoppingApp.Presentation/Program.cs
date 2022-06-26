using FluentValidation.AspNetCore;
using ShoppingApp.Application.Validators.Products;
using ShoppingApp.Infrastructure;
using ShoppingApp.Infrastructure.Enums;
using ShoppingApp.Infrastructure.Filters;
using ShoppingApp.Infrastructure.Services.Storage.Local;
using ShoppingApp.Persistence;
using ShoppingApp.Presentation;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddInfrastructureServices();

builder.Services.AddPersistenceServices();

builder.Services.AddStorage<LocalStorage>();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>

    policy.WithOrigins("http://localhost:4200","https://localhost:4200").AllowAnyHeader().AllowAnyMethod()
    
));

builder.Services.AddControllers(options=>options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter=true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
