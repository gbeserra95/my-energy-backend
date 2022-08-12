using DEVinHouse.SolarEnergy.Data.Context;
using DEVinHouse.SolarEnergy.Identity.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DotNetEnv.Env.TraversePath().Load();

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(System.Environment.GetEnvironmentVariable("CONNECTION_STRING"))
);

builder.Services.AddDbContext<IdentityDataContext>(options =>
    options.UseSqlServer(System.Environment.GetEnvironmentVariable("CONNECTION_STRING"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
