using ShoppingApp.Application.DTOs.Configurations;

namespace ShoppingApp.Application.Abstractions.Services.Configurations;

public interface IApplicationService
{
    List<Menu> GetAuthorizeDefinitionEndpoints(Type type);
}