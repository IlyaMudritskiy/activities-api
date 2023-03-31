using Application.Activities;
using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

//==============================================================================
//=                                  Builder                                   =
//==============================================================================
var builder = WebApplication.CreateBuilder(args);

//==============================================================================
//=                              Default Services                              =
//==============================================================================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//==============================================================================
//=                           DB Context for SQLite                            =
//==============================================================================
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//==============================================================================
//=                                Cors policy                                 =
//==============================================================================
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
    });
});

//==============================================================================
//=                              Custom Services                               =
//==============================================================================
builder.Services.AddMediatR(typeof(List.Handler));
builder.Services.AddAutoMapper(typeof(MappingProfiles));

//==============================================================================
//=                                    App                                     =
//==============================================================================
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

//==============================================================================
//=                                    Run                                     =
//==============================================================================
app.Run();
