using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Reservation.API.Configurations;
using Reservation.Application.Interfaces.Services;
using Reservation.Application.Services;
using Reservation.Data.Context;
using Reservation.Data.Repository;
using Reservation.Domain.Interfaces.Repository;
using Reservation.Domain.Interfaces.Services;
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

builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<ITableService, TableService>();
builder.Services.AddScoped<ITableRepository, TableRepository>();
builder.Services.AddScoped<IReserveService, ReserveService>();
builder.Services.AddScoped<IReserveRepository, ReserveRepository>();

builder.Services.AddControllers();
builder.Services.AddConfigAuthentication(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. 
                      Enter 'Bearer' [space] and then your token in the text input below. 
                      Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
        new OpenApiSecurityScheme
        {
           Reference = new OpenApiReference
           {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
           },
                Scheme = "Bearer",
                Name = "Bearer",
                In = ParameterLocation.Header
        },
            new List<string>()
        }
    });
});

builder.Logging.AddConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
