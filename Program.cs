using Microsoft.EntityFrameworkCore;
using TestDotnet;
using TestDotnet.Data;
using TestDotnet.Mappings;
using TestDotnet.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddDbContext<TestDotNetDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestDotnetConnectionString"))
    );

// like bind in laravel AppServiceProvider
builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();
builder.Services.AddScoped<IWalkRepository, SQLWalkRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
