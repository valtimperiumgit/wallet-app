using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using WalletApp.Api.Middleware;
using WalletApp.Infrastructure;
using WalletApp.Persistence;
using WalletApp.Persistence.DBContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddPersistence(builder.Configuration)
    .AddInfrastructure(builder.Configuration);

builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using IServiceScope serviceScope = ((IApplicationBuilder)app).ApplicationServices.CreateScope();
using WalletAppDbContext dbContext = serviceScope.ServiceProvider.GetRequiredService<WalletAppDbContext>();
dbContext.Database.Migrate();

app.UseMiddleware<ApplicationExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();