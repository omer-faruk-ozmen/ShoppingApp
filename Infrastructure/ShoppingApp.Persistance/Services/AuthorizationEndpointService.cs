using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShoppingApp.Application.Abstractions.Services;
using ShoppingApp.Application.Abstractions.Services.Configurations;
using ShoppingApp.Application.Repositories.Endpoint;
using ShoppingApp.Application.Repositories.Menu;
using ShoppingApp.Domain.Entities;
using ShoppingApp.Domain.Entities.Identity;

namespace ShoppingApp.Persistence.Services;

public class AuthorizationEndpointService : IAuthorizationEndpointService
{
    private readonly IApplicationService _applicationService;
    private readonly IEndpointReadRepository _endpointReadRepository;
    private readonly IEndpointWriteRepository _endpointWriteRepository;
    private readonly IMenuReadRepository _menuReadRepository;
    private readonly IMenuWriteRepository _menuWriteRepository;
    private readonly RoleManager<AppRole> _roleManager;
    public AuthorizationEndpointService(IApplicationService applicationService, IEndpointReadRepository endpointReadRepository, IEndpointWriteRepository endpointWriteRepository, IMenuWriteRepository menuWriteRepository, IMenuReadRepository menuReadRepository, RoleManager<AppRole> roleManager)
    {
        _applicationService = applicationService;
        _endpointReadRepository = endpointReadRepository;
        _endpointWriteRepository = endpointWriteRepository;
        _menuWriteRepository = menuWriteRepository;
        _menuReadRepository = menuReadRepository;
        _roleManager = roleManager;
    }

    public async Task AssignRoleEndpointAsync(string[] roles, string menu, string code, Type type)
    {
        Menu? _menu = await _menuReadRepository.GetSingleAsync(m => m.Name == menu);
        if (_menu is null)
        {
            _menu = new()
            {
                Id = Guid.NewGuid(),
                Name = menu
            };
            await _menuWriteRepository.AddAsync(_menu);
            await _menuWriteRepository.SaveAsync();
        }


        Endpoint? endpoint = await _endpointReadRepository.Table.Include(e => e.Menu).Include(e => e.AppRoles).FirstOrDefaultAsync(e => e.Code == code && e.Menu.Name == menu);
        if (endpoint is null)
        {
            var action = _applicationService.GetAuthorizeDefinitionEndpoints(type).FirstOrDefault(m => m.Name == menu)?
                .Actions.FirstOrDefault(e => e.Code == code);

            endpoint = new()
            {
                Code = action.Code,
                ActionType = action.ActionType,
                HttpType = action.HttpType,
                Definition = action.Definition,
                Menu = _menu,
                Id = Guid.NewGuid()
            };

            await _endpointWriteRepository.AddAsync(endpoint);
            await _endpointWriteRepository.SaveAsync();
        }

        foreach (var role in endpoint.AppRoles)
        {
            endpoint.AppRoles.Remove(role);
        }

        var appRoles = await _roleManager.Roles.Where(r => roles.Contains(r.Name)).ToListAsync();

        foreach (var role in appRoles)
        {
            endpoint.AppRoles.Add(role);
        }

        await _endpointWriteRepository.SaveAsync();


    }

    public async Task<List<string>> GetRolesToEndpointAsync(string code, string menu)
    {

        Endpoint? endpoint = await _endpointReadRepository.Table.Include(e => e.AppRoles).Include(e => e.Menu).FirstOrDefaultAsync(e => e.Code == code && e.Menu.Name == menu);

        if (endpoint is not null)

            return endpoint.AppRoles.Select(r => r.Name).ToList();

        return null;
    }
}