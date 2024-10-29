using Microsoft.EntityFrameworkCore;
using Reservation.Domain.Entities;

namespace Reservation.Data.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options): base(options) {}
    
    public DbSet<Table> Tables { get; set; }
    public DbSet<Reserve> Reservations { get; set; }
    public DbSet<Guest> Guests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }
}