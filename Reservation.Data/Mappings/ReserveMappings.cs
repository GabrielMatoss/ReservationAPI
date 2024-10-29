using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservation.Domain.Entities;

namespace Reservation.Data.Mappings;

public class ReserveMappings : IEntityTypeConfiguration<Reserve>
{
    public void Configure(EntityTypeBuilder<Reserve> builder)
    {
        builder.HasOne<Table>()
            .WithMany(e => e.Reserves)
            .HasForeignKey(e => e.TableId);
       
        builder.HasMany(e => e.Guests)
            .WithOne(e => e.Reserve).HasForeignKey(e => e.ReservationId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}