using Microsoft.EntityFrameworkCore;
using Shop.Application.IServices;
using Shop.Application.Services;
using Shop.Data.Context;
using Shop.Data.IRepositories;
using Shop.Data.Models;
using Shop.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddTransient<IAllRepositories<ChucVu>, AllRepositories<ChucVu>>();
var connectionString = builder.Configuration.GetConnectionString("team5_converseStore");
builder.Services.AddDbContext<ShopDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddTransient<INhanVienServices, NhanVienServices>();
builder.Services.AddTransient<IChucVuService, ChucVuService>();


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
