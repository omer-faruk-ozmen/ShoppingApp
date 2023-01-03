using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace ShoppingApp.Presentation.Extensions;

public static class ConfigureExceptionHandlerExtension
{
    public static void ConfigureExcepitonHandler<T>(this WebApplication application, ILogger<T> logger)
    {
        application.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = MediaTypeNames.Application.Json;
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                if (contextFeature != null)
                {
                    logger.LogError($"Unknown error was encountered \nError Message: {contextFeature.Error.Message} ");

                    await context.Response.WriteAsync(JsonSerializer.Serialize(new
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = contextFeature.Error.Message,
                        Title = "Error!"
                    }));
                }
            });
        });
    }
}