﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingApp.Application.Abstractions.Services.Configurations;
using ShoppingApp.Application.CustomAttributes;
using ShoppingApp.Application.Enums;

namespace ShoppingApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Admin")]
public class ApplicationServicesController : ControllerBase
{
    private readonly IApplicationService _applicationService;

    public ApplicationServicesController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }
    [HttpGet]
    [AuthorizeDefinition(ActionType = ActionType.Reading, Definition = "Get Authorize Definition Endpoints", Menu = "Application Services")]
    public IActionResult GetAuthorizeDefinitionEndpoints()
    {
        var datas = _applicationService.GetAuthorizeDefinitionEndpoints(typeof(Program));

        return Ok(datas);
    }
}