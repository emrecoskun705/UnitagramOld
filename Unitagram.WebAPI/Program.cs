using Serilog;
using Unitagram.WebAPI.Middleware;
using Unitagram.WebAPI.StartupExtensions;

var builder = WebApplication.CreateBuilder(args);

// Serilog
builder.Host.UseSerilog((context,  services,  loggerConfiguration) =>
{
  loggerConfiguration
    .ReadFrom.Configuration(context.Configuration) // Read configuration settings from built-in IConfiguration(appsettings.json)
    .ReadFrom.Services(services);// reads out current app's services and make them available to serilog
});

builder.Services.ConfigureServices(builder.Configuration, builder.Environment);

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (builder.Environment.IsProduction())
{
  app.UseHsts();
  app.UseHttpsRedirection();
}

if (builder.Environment.IsDevelopment() || builder.Environment.IsProduction()) // TODO: remove production check later
{
  // app.UseDeveloperExceptionPage();
  app.UseSwagger(); // creates endpoints for swagger.json
  app.UseSwaggerUI(options =>
  {
    string swaggerJsonBasePath = string.IsNullOrWhiteSpace(options.RoutePrefix) ? "." : "..";
    options.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "1.0");
    options.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v2/swagger.json", "2.0");
  });
}

app.UseRouting();
app.UseCors("all");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

/// <summary>
/// make the auto-generated Program accessible programmatically
/// </summary>
public partial class Program { } 
