using CityInfo.API;
using CityInfo.API.DbContexts;
using CityInfo.API.Services;
using Contracts;
using LoggerService;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NLog;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
//builder.Logging.AddConsole();

// Add services to the container.
//builder.Services.AddControllers();

//option to allow/disallow specific Accept header and content like application/json or application/xml
builder.Services.AddControllers(options =>
{
    //will only return defautl formatters (JSON)
    options.ReturnHttpNotAcceptable = true;
    //For XML - add AddXmlDataContractSerializerFormatters
}).AddNewtonsoftJson()
.AddXmlDataContractSerializerFormatters();

builder.Services.AddProblemDetails();
//return more details about status code return aside from 200 levels
//builder.Services.AddProblemDetails(options =>
//{
//    options.CustomizeProblemDetails = ctx =>
//    {
//        ctx.ProblemDetails.Extensions.Add("additionalInfo", "Additional info example");
//        //ctx.ProblemDetails.Extensions.Add("server", Environment.MachineName);
//    };
//});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Use for file content type
builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

#if DEBUG
builder.Services.AddTransient<IMailService, LocalMailService>();
#else
builder.Services.AddTransient<IMailService, CloudMailService>();
#endif

builder.Services.AddTransient<CitiesDataStore>();

var connectionString = builder.Configuration["ConnectionStrings:CityInfoDBConnectionString"];
builder.Services.AddDbContext<CityInfoContext>(
    options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<ICityInfoRepository, CityInfoRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Convert.FromBase64String(builder.Configuration["Authentication:SecretForKey"]!))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("MustBeFromAntwerp", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("city", ["Antwerp"]);
    });
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
