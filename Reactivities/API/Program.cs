using API.Extensions;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

//==============================================================================
//=                      Configure HTTP request pipeline                       =
//==============================================================================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//==============================================================================
//=                                  App Use                                   =
//==============================================================================
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

//==============================================================================
//=                                   Scope                                    =
//==============================================================================
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

//==============================================================================
//=                        Migrations and seedind data                         =
//==============================================================================
try
{
    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();
    await Seed.SeedData(context);
}
catch (Exception exception)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(exception, "An error occurred during migration");
}

app.Run();
