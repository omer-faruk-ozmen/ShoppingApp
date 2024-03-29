﻿using Microsoft.AspNetCore.Mvc;

namespace ShoppingApp.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilesController : ControllerBase
{
    readonly IConfiguration _configuration;

    public FilesController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet("[action]")]
    public IActionResult GetBaseStorageUrl()
    {
        return Ok(new
        {
            Url = _configuration["Storage:Azure:BaseUrl"]
        });
            
    }
}