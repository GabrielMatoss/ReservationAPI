using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Domain.Entities;

namespace Reservation.Data.Mappings;

public class TableMappings : IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> builder)
    {
        builder.Property(e => e.Id).ValueGeneratedNever();
        
        builder.HasData(new[]
        {
            new Table(1), 
            new Table(2), 
            new Table(3), 
            new Table(4), 
            new Table(5)
        });
    }
}