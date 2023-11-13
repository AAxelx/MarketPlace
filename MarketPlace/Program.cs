using MarketPlace.DAL.Contexts;
using MarketPlace.DAL.Repositories;
using MarketPlace.DAL.Repositories.Abstractions;
using MarketPlace.SAL.AutoMapperProfiles;
using MarketPlace.SAL.Services;
using MarketPlace.SAL.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<MarketPlaceDbContext>(options =>
{
    // Configure your database connection
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppSettings"));
});
builder.Services.AddScoped(typeof(IDbRepository<>), typeof(DbRepository<>));

builder.Services.AddAutoMapper(typeof(MapperProfiles));

builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IAuctionService, AuctionService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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