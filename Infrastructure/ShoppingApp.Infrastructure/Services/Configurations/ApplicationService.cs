﻿using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using ShoppingApp.Application.Abstractions.Services.Configurations;
using ShoppingApp.Application.CustomAttributes;
using ShoppingApp.Application.DTOs.Configurations;
using ShoppingApp.Application.Enums;
using Action = ShoppingApp.Application.DTOs.Configurations.Action;

namespace ShoppingApp.Infrastructure.Services.Configurations;

public class ApplicationService : IApplicationService
{
    public List<Menu> GetAuthorizeDefinitionEndpoints(Type type)
    {
        Assembly assembly = Assembly.GetAssembly(type);

        List<Menu> menus = new();

        var controllers = assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(ControllerBase)));
        if (controllers != null)
        {
            foreach (var controller in controllers)
            {

                var actions = controller.GetMethods().Where(m => m.IsDefined(typeof(AuthorizeDefinitionAttribute)));

                if (actions != null)
                {
                    foreach (var action in actions)
                    {
                        var attributes = action.GetCustomAttributes(true);

                        if (attributes != null)
                        {
                            Menu menu = null;

                            var authorizeDefinitionAttribute = attributes.FirstOrDefault(a => a.GetType() == typeof(AuthorizeDefinitionAttribute)) as AuthorizeDefinitionAttribute;

                            if (!menus.Any(m => m.Name == authorizeDefinitionAttribute.Menu))
                            {
                                menu = new() { Name = authorizeDefinitionAttribute.Menu };
                                menus.Add(menu);
                            }
                            else
                            {
                                menu = menus.FirstOrDefault(m => m.Name == authorizeDefinitionAttribute.Menu);
                            }

                            Action _action = new()
                            {
                                ActionType = Enum.GetName(typeof(ActionType), authorizeDefinitionAttribute.ActionType),
                                Definition = authorizeDefinitionAttribute.Definition,
                            };

                            var httpAttribute = attributes.FirstOrDefault(a => a.GetType().IsAssignableTo(typeof(HttpMethodAttribute))) as HttpMethodAttribute;
                            if (httpAttribute != null)
                                _action.HttpType = httpAttribute.HttpMethods.First();
                            else
                                _action.HttpType = HttpMethods.Get;

                            _action.Code = $"{_action.HttpType}.{_action.ActionType}.{_action.Definition.Replace(" ", "")}";

                            menu.Actions.Add(_action);
                        }
                    }
                }

            }
        }

        return menus;
    }
}