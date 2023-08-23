using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Unitagram.Infrastructure.DatabaseContext;
using Microsoft.IdentityModel.Tokens;
using Unitagram.Core.ServiceContracts;
using Unitagram.Core.Services;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Unitagram.Core.Domain.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);


// Serilog
builder.Host.UseSerilog((context,  services,  loggerConfiguration) =>
{
  loggerConfiguration
    .ReadFrom.Configuration(context.Configuration) // Read configuration settings from built-in IConfiguration(appsettings.json)
    .ReadFrom.Services(services);// reads out current app's services and make them available to serilog
});

// Add services to the container.

builder.Services.AddControllers();

// Add JWT Service
builder.Services.AddTransient<IJwtService, JwtService>();

// Enable API versioning
builder.Services.AddApiVersioning(config =>
{
  config.ApiVersionReader = new UrlSegmentApiVersionReader();

  config.DefaultApiVersion = new ApiVersion(1, 0);
  config.AssumeDefaultVersionWhenUnspecified = true;
});

// Add Default database connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

if (builder.Environment.IsDevelopment() || builder.Environment.IsProduction())
{
  // Add Swagger
  builder.Services.AddEndpointsApiExplorer(); // generates description for all endpoints
  builder.Services.AddSwaggerGen(options =>
  {
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "api.xml"));

    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
    {
      Title = "Test web API",
      Version = "1.0"
    });

    options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo()
    {
      Title = "Test web API",
      Version = "2.0"
    });

  }); // generates Open API specification
}

builder.Services.AddVersionedApiExplorer(options =>
{
  options.GroupNameFormat = "'v'VVV";
  options.SubstituteApiVersionInUrl = true;
});

//add identity
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
  options.Password.RequiredLength = 8;
  options.Password.RequireUppercase = true;
  options.Password.RequireLowercase = true;
})
  .AddEntityFrameworkStores<ApplicationDbContext>()
  .AddDefaultTokenProviders()
  .AddUserStore<UserStore<ApplicationUser, ApplicationRole, ApplicationDbContext, Guid>>()
  .AddRoleStore<RoleStore<ApplicationRole, ApplicationDbContext, Guid>>();


// Add JWT
builder.Services.AddAuthentication(options =>
{
  options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
  options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
  .AddJwtBearer(options =>
  {
    options.TokenValidationParameters = new TokenValidationParameters()
    {
      ValidateAudience = true,
      ValidAudience = builder.Configuration["Jwt:Audience"],
      ValidateIssuer = true,
      ValidIssuer = builder.Configuration["Jwt:Issuer"],
      ValidateLifetime = true,
      ValidateIssuerSigningKey = true,
      IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
    };
  });

var app = builder.Build();

app.UseSerilogRequestLogging();


// Configure the HTTP request pipeline.
if (builder.Environment.IsProduction())
{
  app.UseHsts();
  app.UseHttpsRedirection();
}



if (builder.Environment.IsDevelopment() || builder.Environment.IsProduction()) // TODO: remove production check later
{
  app.UseDeveloperExceptionPage();
  app.UseSwagger(); // creates endpoints for swagger.json
  app.UseSwaggerUI(options =>
  {
    string swaggerJsonBasePath = string.IsNullOrWhiteSpace(options.RoutePrefix) ? "." : "..";
    options.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "1.0");
    options.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v2/swagger.json", "2.0");
  });
}

app.UseRouting();
//app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
