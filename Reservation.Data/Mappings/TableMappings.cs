using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Domain.Entities;

namespace Reservation.Data.Mappings;

public class TableMappings : IEntityTypeConfiguration<Table>
{
    public void Configure(EntityTypeBuilder<Table> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id).ValueGeneratedOnAdd();

        builder.HasData(
            new Table(1, 1, 2),
            new Table(2, 2, 4),
            new Table(3, 3, 2),
            new Table(4, 4, 2),
            new Table(5, 5, 4));
    }
}