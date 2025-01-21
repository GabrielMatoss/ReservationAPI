using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Domain.Entities;

namespace Reservation.Data.Mappings;

public class ReserveMappings : IEntityTypeConfiguration<Reserve>
{
    public void Configure(EntityTypeBuilder<Reserve> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.DateTimeReserve).HasColumnType("datetime2");
        
        builder
            .HasOne<Table>()
            .WithMany(e => e.Reserves)
            .HasForeignKey(e => e.TableId).OnDelete(DeleteBehavior.NoAction);


        builder.Property(e => e.UserId)
        .IsRequired();
    }
}