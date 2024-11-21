using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Reservation.Application.Interfaces.Services;
using Reservation.Data.Context;
using Reservation.Data.Repository;
using Reservation.Domain.Interfaces.Repository;
using Reservation.Identity.Data;
using Reservation.Identity.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = Environment.GetEnvironmentVariable("ReservationsDb") 
                       ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<DataContext>(options => {
    options.UseSqlServer(connectionString);
});

builder.Services.AddDbContext<IdentityDataContext>(options => {
    options.UseSqlServer(connectionString);
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityDataContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<ITableRepository, TableRepository>();
builder.Services.AddScoped<IIdentityService, IdentityService>();

builder.Services.AddControllers();
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
