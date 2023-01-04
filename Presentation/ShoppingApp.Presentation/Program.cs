using System.Security.Claims;
using System.Text;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Sinks.PostgreSQL;
using ShoppingApp.Application;
using ShoppingApp.Application.Validators.Products;
using ShoppingApp.Infrastructure;
using ShoppingApp.Infrastructure.Filters;
using ShoppingApp.Infrastructure.Services.Storage.Azure;
using ShoppingApp.Persistence;
using ShoppingApp.Presentation.Configurations.ColumnWriters;
using ShoppingApp.Presentation.Extensions;
using ShoppingApp.Presentation.Filters;
using ShoppingApp.SignalR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();

builder.Services.AddInfrastructureServices();

builder.Services.AddPersistenceServices();

builder.Services.AddApplicationServices();

builder.Services.AddSignalRServices();

//builder.Services.AddStorage<LocalStorage>();
builder.Services.AddStorage<AzureStorage>();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>

    policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials()

));

Logger log = new LoggerConfiguration()

    .WriteTo.PostgreSQL(builder.Configuration.GetConnectionString("ShoppingAppLogDb"), "Logs", needAutoCreateTable: true,
        columnOptions: new Dictionary<string, ColumnWriterBase>
        {
            {"Message",new RenderedMessageColumnWriter()},
            {"MessageTemplate",new MessageTemplateColumnWriter()},
            {"Level",new LevelColumnWriter()},
            {"TimeStamp",new TimestampColumnWriter()},
            {"Exception",new ExceptionColumnWriter()},
            {"LogEvent", new LogEventSerializedColumnWriter()},
            {"Username",new UsernameColumnWriter()}
        })

    .WriteTo.File("logs/log.txt")
    .WriteTo.Seq(builder.Configuration["Seq:ServerUrl"])

    .Enrich.FromLogContext()
    .MinimumLevel.Information()
    .CreateLogger();

builder.Host.UseSerilog(log);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.ResponseHeaders.Add("ShoppingAppLog");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;

});


builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
    options.Filters.Add<RolePermissionFilter>();
})
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin", options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:IssuerSigningKey"])),

            NameClaimType = ClaimTypes.Name,  //JWT name claim'e karþýlýk gelen deðeri User.Identity.Name üzerinden elde etme
        };
    });


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{

}

app.ConfigureExcepitonHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>());

app.UseStaticFiles();

app.UseSerilogRequestLogging();

app.UseHttpLogging();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.Use(async (context, next) =>
{
    var username = context.User?.Identity?.IsAuthenticated != null || true ? context.User?.Identity?.Name : null;

    LogContext.PushProperty("Username", username);

    await next();
});

app.MapControllers();

app.MapHubs();

app.Run();
