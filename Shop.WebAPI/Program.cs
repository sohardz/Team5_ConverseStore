using Microsoft.EntityFrameworkCore;
using Shop.Application.IServices;
using Shop.Application.Services;
using Shop.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddTransient<IAllRepositories<ChucVu>, AllRepositories<ChucVu>>();
var connectionString = builder.Configuration.GetConnectionString("team5_converseStore");
builder.Services.AddDbContext<ShopDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddTransient<INhanVienServices, NhanVienServices>();
builder.Services.AddTransient<IChucVuService, ChucVuService>();
builder.Services.AddTransient<IGiamGiaService, GiamGiaService>();
builder.Services.AddTransient<IGioHangService, GioHangService>();
builder.Services.AddTransient<IKichCoService, KichCoService>();
builder.Services.AddTransient<IMauSacService, MauSacService>();
builder.Services.AddTransient<IAnhServices, AnhServices>();
builder.Services.AddTransient<IKhachhangServices, KhachHangServices>();
builder.Services.AddTransient<ISanPhamService, SanPhamService>();

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
